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

using NAudio.Dsp;
using NAudio.Wave;
using System;

namespace RadioMessageGenerator.TextToSpeech
{
    /// <summary>
    /// Adds an "AM radio" filter effect to the Windows text-to-speech output.
    /// </summary>
    public sealed class AMRadioFilter : ISampleProvider, IDisposable
    {
        private readonly ISampleProvider SourceProvider;
        private readonly float CutOffFreq;
        private readonly int Channels;
        private readonly BiQuadFilter[] Filters;

        public WaveFormat WaveFormat { get { return SourceProvider.WaveFormat; } }

        public AMRadioFilter(ISampleProvider sourceProvider, int cutOffFreq = 750)
        {
            SourceProvider = sourceProvider;
            CutOffFreq = cutOffFreq;

            Channels = sourceProvider.WaveFormat.Channels;
            Filters = new BiQuadFilter[Channels];
            CreateFilters();
        }

        public void Dispose() { }

        public int Read(float[] buffer, int offset, int count)
        {
            int i;
            float max = 0;

            int samplesRead = SourceProvider.Read(buffer, offset, count);

            for (i = 0; i < samplesRead; i++)
                buffer[offset + i] = Filters[(i % Channels)].Transform(buffer[offset + i]);

            for (i = 0; i < buffer.Length; i++) max = Math.Max(buffer[i], max);
            max = 1f / Math.Min(Math.Max(max, 0.01f), 1f);
            for (i = 0; i < buffer.Length; i++) buffer[i] *= max;

            return samplesRead;
        }

        private void CreateFilters()
        {
            for (int n = 0; n < Channels; n++)
                Filters[n] = BiQuadFilter.HighPassFilter(22050, CutOffFreq, 1);
        }
    }
}
