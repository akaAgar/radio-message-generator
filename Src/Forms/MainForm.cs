using RadioMessageGenerator.TextToSpeech;
using NAudio.Wave;
using System;
using System.IO;
using System.Windows.Forms;

namespace RadioMessageGenerator.Forms
{
    /// <summary>
    /// Main form for the standalong radio message maker.
    /// </summary>
    internal partial class MainForm : Form
    {
        // ===============================================
        // PRIVATE FIELDS
        // ===============================================

        //private readonly HQ4DCS HQ;

        private WaveFileReader WaveFile = null;
        private WaveOutEvent WavePlayer = null;
        private MemoryStream WaveStream = null;

        private string LastSavePath = ""; // HQToolbox.PATH_USER_DOCS;

        private readonly HQRadioMessageMaker RadioMsgMaker = null;

        // ===============================================
        // CONSTRUCTOR
        // ===============================================

        internal MainForm()
        {
            InitializeComponent();

            RadioMsgMaker = new HQRadioMessageMaker();
        }

        // ===============================================
        // PRIVATE WINFORM EVENT METHODS
        // ===============================================

        private void Frm_RadioMessageMaker_Load(object sender, EventArgs e)
        {
            VoiceComboBox.Items.Clear();
            foreach (string v in RadioMsgMaker.GetAllVoices()) VoiceComboBox.Items.Add(v);
            if (VoiceComboBox.Items.Count > 0) VoiceComboBox.SelectedIndex = 0;

            if (VoiceComboBox.Items.Count == 0)
            {
                PlayButton.Enabled = false;
                SaveButton.Enabled = false;
            }
        }

        private void RadioMessageMakerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopSound();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (VoiceComboBox.Items.Count == 0) return;

            if (sender == PlayButton)
            {
                StopSound();

                byte[] bytes = RadioMsgMaker.GenerateRadioMessageWavBytes(MessageTextbox.Text, GetVoiceNameOnlyFromCombobox());

                WaveStream = new MemoryStream(bytes);
                WaveFile = new WaveFileReader(WaveStream);

                WavePlayer = new WaveOutEvent();
                WavePlayer.Init(WaveFile);
                WavePlayer.Play();
                return;
            }

            if (sender == SaveButton)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.InitialDirectory = LastSavePath;
                    sfd.Filter = "PCM Wave files (*.wav)|*.wav";
                    sfd.FileName = "NewRadioMessage.Wav";
                    if (sfd.ShowDialog() != DialogResult.OK) return;
                    File.WriteAllBytes(sfd.FileName, RadioMsgMaker.GenerateRadioMessageWavBytes(MessageTextbox.Text, GetVoiceNameOnlyFromCombobox()));
                    LastSavePath = Path.GetDirectoryName(sfd.FileName);
                }
                return;
            }
        }

        private void StopSound()
        {
            if (WaveStream != null)
            {
                WaveStream.Close();
                WaveStream.Dispose();
            }

            if (WavePlayer != null)
            {
                WavePlayer.Stop();
                WavePlayer.Dispose();
            }

            if (WaveFile != null)
            {
                WaveFile.Close();
                WaveFile.Dispose();
            }
        }

        private string GetVoiceNameOnlyFromCombobox()
        {
            string voiceStr = VoiceComboBox.SelectedItem.ToString();
            return voiceStr.Substring(0, voiceStr.IndexOf(","));
        }

        private void SpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            RadioMsgMaker.Speed = SpeedTrackBar.Value;
        }

        private void PitchTrackBar_Scroll(object sender, EventArgs e)
        {
            RadioMsgMaker.Pitch = PitchTrackBar.Value;
        }
    }
}
