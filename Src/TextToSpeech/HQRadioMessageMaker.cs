/*
==========================================================================
This file is part of Radio Message Generator, an utility which creates
WAV radio messages using the Windows 7/10 text-to-speech library.

RadioMessageGenerator was created by @akaAgar.
The source code repository is available here: https://github.com/akaAgar/radio-message-generator

Radio Message Generator is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Radio Message Generator is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Radio Message Generator. If not, see https://www.gnu.org/licenses/
==========================================================================
*/

using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;

namespace RadioMessageGenerator.TextToSpeech
{
    /// <summary>
    /// Creates radio messages using the Windows text-to-speech engine
    /// </summary>
    public sealed class HQRadioMessageMaker : IDisposable
    {
        public const int SPEECH_RATE_MIN = -6;
        public const int SPEECH_RATE_DEFAULT = 2;
        public const int SPEECH_RATE_MAX = 6;

        public const int RADIOFX_AMOUNT_MIN = 0;
        public const int RADIOFX_AMOUNT_DEFAULT = 5;
        public const int RADIOFX_AMOUNT_MAX = 5;

        private const double MIN_SPEECH_DURATION = 0.5; // in seconds
        private const double MAX_SPEECH_DURATION = 10.0; // in seconds

        public int RadioFXIntensity { get { return FXIntensity; } set { FXIntensity = Math.Min(RADIOFX_AMOUNT_MAX, Math.Max(value, RADIOFX_AMOUNT_MIN)); } }
        private int FXIntensity = RADIOFX_AMOUNT_DEFAULT;

        public int Speed { get { return Reader.Rate; } set { Reader.Rate = Math.Min(SPEECH_RATE_MAX, Math.Max(value, SPEECH_RATE_MIN)); } }

        /// <summary>
        /// The default voice if thr provided voice does not exist. Set in the constructor.
        /// </summary>
        private readonly string DefaultVoice = null;

        public readonly SpeechSynthesizer Reader = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public HQRadioMessageMaker()
        {
            Reader = new SpeechSynthesizer { Volume = 100 };
            Reader.Rate = SPEECH_RATE_DEFAULT;

            DefaultVoice = GetDefaultVoice();
        }

        public void Dispose() { Reader.Dispose(); }

        /// <summary>
        /// Try to find a suitable english TTS voice to use
        /// </summary>
        /// <returns>The name of the default voice to use</returns>
        private string GetDefaultVoice()
        {
            // First try to find a male English voice
            InstalledVoice voice =
                (from InstalledVoice v in Reader.GetInstalledVoices() where v.Enabled &&
                 v.VoiceInfo.Culture.TwoLetterISOLanguageName.ToLowerInvariant() == "en" &&
                 v.VoiceInfo.Gender == VoiceGender.Male select v).SingleOrDefault();
            if (voice != null) return voice.VoiceInfo.Name;

            // If no male voice found, pick any English voice
            voice =
                (from InstalledVoice v in Reader.GetInstalledVoices()
                 where v.Enabled &&
                 v.VoiceInfo.Culture.TwoLetterISOLanguageName.ToLowerInvariant() == "en"
                 select v).SingleOrDefault();
            if (voice != null) return voice.VoiceInfo.Name;

            return null; // No voice found, return null
        }

        /// <summary>
        /// Uses the Windows TTS library to get the bytes of a PCM Wave file from a text messages.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="voiceName"></param>
        /// <returns>The way files bytes, or an empty array if something went wrong.</returns>
        public byte[] GenerateRadioMessageWavBytes(string message, string voiceName = null)
        {
            // Media files are stored in the Release build directory, so if we're running a Debug build, we have to look for them here.
            string debugPathToRelease = "";
//#if DEBUG
//            debugPathToRelease = "..\\Release\\";
//#endif

            if (string.IsNullOrEmpty(message)) message = ""; // Make sure message is not null

            // No voice name provided, use the default voice instead
            if (voiceName == null)
            {
                if (DefaultVoice == null) // Default voice not set/doesn't exist
                    return new byte[0];

                voiceName = DefaultVoice;
            }

            try { Reader.SelectVoice(voiceName); }
            catch (Exception) { return new byte[0]; }

            // Text-to-speech
            MemoryStream ttsStream = new MemoryStream(); // create a new memory stream
            Reader.SetOutputToWaveStream(ttsStream); // set the stream as output for the TTS reader
            Reader.Volume = 35;
            Reader.Speak(message); // read the text into the stream
            ttsStream.Seek(0, SeekOrigin.Begin); // rewind the stream to position 0
            WaveFileReader waveTTS = new WaveFileReader(ttsStream); // read the stream into a WaveFileReader object

            // Mix voice with radio static
            WaveFileReader waveStatic = new WaveFileReader(debugPathToRelease + "Media/Loop.wav"); // load the static sound loop
            ISampleProvider providerSpeech = new AMRadioFilter(waveTTS.ToSampleProvider(), FXIntensity * 250); // get the sample provider for the TTS, apply a radio filter
            ISampleProvider providerStatic = waveStatic.ToSampleProvider(); // get the sample provider for the static
            TimeSpan ttsDuration = waveTTS.TotalTime; // get the tts wave duration
            if (ttsDuration < TimeSpan.FromSeconds(MIN_SPEECH_DURATION)) ttsDuration = TimeSpan.FromSeconds(MIN_SPEECH_DURATION); // check min value
            if (ttsDuration > TimeSpan.FromSeconds(MAX_SPEECH_DURATION)) ttsDuration = TimeSpan.FromSeconds(MAX_SPEECH_DURATION); // check max value
            ISampleProvider[] sources = new[] { providerSpeech.Take(ttsDuration), providerStatic.Take(ttsDuration) }; // use both providers as source with a duration of ttsDuration
            MixingSampleProvider mixingSampleProvider = new MixingSampleProvider(sources); // mix both channels
            IWaveProvider radioMix = mixingSampleProvider.ToWaveProvider16(); // convert the mix output to a PCM 16bit sample provider

            // Concatenate radio in/out sounds
            WaveFileReader waveRadioIn = new WaveFileReader(debugPathToRelease + "Media/In.wav"); // load the radio in FX
            WaveFileReader waveRadioOut = new WaveFileReader(debugPathToRelease + "Media/Out.wav"); // load the radio out FX
            IWaveProvider[] radioFXParts = new IWaveProvider[] { waveRadioIn, radioMix, waveRadioOut }; // create an array with all 3 parts

            byte[] buffer = new byte[1024]; // create a buffer to store wav data to concatenate
            MemoryStream finalWavStr = new MemoryStream(); // create a stream for the final concatenated wav
            WaveFileWriter waveFileWriter = null; // create a writer to fill the stream

            foreach (IWaveProvider wav in radioFXParts) // iterate all three parts
            {
                if (waveFileWriter == null) // no writer, first part of the array
                    waveFileWriter = new WaveFileWriter(finalWavStr, wav.WaveFormat); // create a writer of the proper format
                else if (!wav.WaveFormat.Equals(waveFileWriter.WaveFormat)) // else, check the other parts are of the same format
                    continue; // file is not of the proper format

                int read; // bytes read
                while ((read = wav.Read(buffer, 0, buffer.Length)) > 0) // read data from the wave
                { waveFileWriter.Write(buffer, 0, read); } // fill the buffer with it
            }

            // Copy the stream to a byte array
            waveFileWriter.Flush();
            finalWavStr.Seek(0, SeekOrigin.Begin);
            byte[] waveBytes = new byte[finalWavStr.Length];
            finalWavStr.Read(waveBytes, 0, waveBytes.Length);

            // Close/dispose of everything
            ttsStream.Close(); ttsStream.Dispose();
            waveTTS.Close(); waveTTS.Dispose();
            waveStatic.Close(); waveStatic.Dispose();
            waveRadioIn.Close(); waveRadioIn.Dispose();
            waveRadioOut.Close(); waveRadioOut.Dispose();
            waveFileWriter.Close(); waveFileWriter.Dispose();
            finalWavStr.Close(); finalWavStr.Dispose();

            // Return the bytes
            return waveBytes;
        }

        public void SetDefaultParameters()
        {
            Speed = 2;
            RadioFXIntensity = 5;
        }

        /// <summary>
        /// Is a TTC voice installed?
        /// </summary>
        /// <param name="name">The name of the voice.</param>
        /// <returns>True if voice is installed, false if not.</returns>
        private bool IsVoiceInstalled(string name)
        {
            foreach (InstalledVoice v in Reader.GetInstalledVoices())
                if (v.VoiceInfo.Name == name) return true;

            return false;
        }

        /// <summary>
        /// Returns the names of all installed voices.
        /// </summary>
        /// <returns>An array of voices names, in the "Name, Gender, Culture" format.</returns>
        public string[] GetAllVoices()
        {
            List<string> voicesList = new List<string>();

            foreach (InstalledVoice v in Reader.GetInstalledVoices())
            {
                if (!v.Enabled) continue;
                voicesList.Add(v.VoiceInfo.Name + ", " + v.VoiceInfo.Gender.ToString() + ", " + v.VoiceInfo.Culture.EnglishName);
            }

            return voicesList.ToArray();
        }
    }
}
