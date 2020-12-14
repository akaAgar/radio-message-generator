namespace RadioMessageGenerator.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
            this.SaveTTSButton = new System.Windows.Forms.Button();
            this.MessageTextbox = new System.Windows.Forms.TextBox();
            this.VoiceComboBox = new System.Windows.Forms.ComboBox();
            this.SpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.RadioFXTrackBar = new System.Windows.Forms.TrackBar();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.VoiceLabel = new System.Windows.Forms.Label();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.RadioFXLabel = new System.Windows.Forms.Label();
            this.PlayTTSButton = new System.Windows.Forms.Button();
            this.PitchLabel = new System.Windows.Forms.Label();
            this.PitchTrackBar = new System.Windows.Forms.TrackBar();
            this.PlayFileButton = new System.Windows.Forms.Button();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.TLP_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadioFXTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PitchTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // TLP_Main
            // 
            this.TLP_Main.ColumnCount = 3;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.TLP_Main.Controls.Add(this.SaveTTSButton, 2, 12);
            this.TLP_Main.Controls.Add(this.MessageTextbox, 0, 1);
            this.TLP_Main.Controls.Add(this.VoiceComboBox, 0, 3);
            this.TLP_Main.Controls.Add(this.SpeedTrackBar, 0, 5);
            this.TLP_Main.Controls.Add(this.RadioFXTrackBar, 0, 7);
            this.TLP_Main.Controls.Add(this.MessageLabel, 0, 0);
            this.TLP_Main.Controls.Add(this.VoiceLabel, 0, 2);
            this.TLP_Main.Controls.Add(this.SpeedLabel, 0, 4);
            this.TLP_Main.Controls.Add(this.RadioFXLabel, 0, 6);
            this.TLP_Main.Controls.Add(this.PlayTTSButton, 1, 12);
            this.TLP_Main.Controls.Add(this.PitchLabel, 0, 8);
            this.TLP_Main.Controls.Add(this.PitchTrackBar, 0, 9);
            this.TLP_Main.Controls.Add(this.PlayFileButton, 1, 11);
            this.TLP_Main.Controls.Add(this.SaveFileButton, 2, 11);
            this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 13;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TLP_Main.Size = new System.Drawing.Size(620, 357);
            this.TLP_Main.TabIndex = 0;
            // 
            // SaveTTSButton
            // 
            this.SaveTTSButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveTTSButton.Location = new System.Drawing.Point(463, 320);
            this.SaveTTSButton.Name = "SaveTTSButton";
            this.SaveTTSButton.Size = new System.Drawing.Size(154, 34);
            this.SaveTTSButton.TabIndex = 1;
            this.SaveTTSButton.Text = "Save TTS to .wav";
            this.SaveTTSButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveTTSButton.UseVisualStyleBackColor = true;
            this.SaveTTSButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // MessageTextbox
            // 
            this.TLP_Main.SetColumnSpan(this.MessageTextbox, 3);
            this.MessageTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageTextbox.Location = new System.Drawing.Point(3, 23);
            this.MessageTextbox.MaxLength = 4096;
            this.MessageTextbox.Name = "MessageTextbox";
            this.MessageTextbox.Size = new System.Drawing.Size(614, 20);
            this.MessageTextbox.TabIndex = 3;
            this.MessageTextbox.Text = "This is a radio message.";
            // 
            // VoiceComboBox
            // 
            this.TLP_Main.SetColumnSpan(this.VoiceComboBox, 3);
            this.VoiceComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VoiceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VoiceComboBox.FormattingEnabled = true;
            this.VoiceComboBox.Location = new System.Drawing.Point(3, 73);
            this.VoiceComboBox.Name = "VoiceComboBox";
            this.VoiceComboBox.Size = new System.Drawing.Size(614, 21);
            this.VoiceComboBox.Sorted = true;
            this.VoiceComboBox.TabIndex = 8;
            // 
            // SpeedTrackBar
            // 
            this.TLP_Main.SetColumnSpan(this.SpeedTrackBar, 3);
            this.SpeedTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpeedTrackBar.LargeChange = 1;
            this.SpeedTrackBar.Location = new System.Drawing.Point(3, 123);
            this.SpeedTrackBar.Maximum = 6;
            this.SpeedTrackBar.Minimum = -6;
            this.SpeedTrackBar.Name = "SpeedTrackBar";
            this.SpeedTrackBar.Size = new System.Drawing.Size(614, 24);
            this.SpeedTrackBar.TabIndex = 9;
            this.SpeedTrackBar.Value = 2;
            this.SpeedTrackBar.Scroll += new System.EventHandler(this.SpeedTrackBar_Scroll);
            // 
            // RadioFXTrackBar
            // 
            this.TLP_Main.SetColumnSpan(this.RadioFXTrackBar, 3);
            this.RadioFXTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioFXTrackBar.LargeChange = 1;
            this.RadioFXTrackBar.Location = new System.Drawing.Point(3, 173);
            this.RadioFXTrackBar.Maximum = 5;
            this.RadioFXTrackBar.Name = "RadioFXTrackBar";
            this.RadioFXTrackBar.Size = new System.Drawing.Size(614, 24);
            this.RadioFXTrackBar.TabIndex = 10;
            this.RadioFXTrackBar.Value = 5;
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.TLP_Main.SetColumnSpan(this.MessageLabel, 3);
            this.MessageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageLabel.Location = new System.Drawing.Point(3, 3);
            this.MessageLabel.Margin = new System.Windows.Forms.Padding(3);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(614, 14);
            this.MessageLabel.TabIndex = 13;
            this.MessageLabel.Text = "Message";
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VoiceLabel
            // 
            this.VoiceLabel.AutoSize = true;
            this.TLP_Main.SetColumnSpan(this.VoiceLabel, 3);
            this.VoiceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VoiceLabel.Location = new System.Drawing.Point(3, 53);
            this.VoiceLabel.Margin = new System.Windows.Forms.Padding(3);
            this.VoiceLabel.Name = "VoiceLabel";
            this.VoiceLabel.Size = new System.Drawing.Size(614, 14);
            this.VoiceLabel.TabIndex = 14;
            this.VoiceLabel.Text = "Voice";
            this.VoiceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.TLP_Main.SetColumnSpan(this.SpeedLabel, 3);
            this.SpeedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpeedLabel.Location = new System.Drawing.Point(3, 103);
            this.SpeedLabel.Margin = new System.Windows.Forms.Padding(3);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(614, 14);
            this.SpeedLabel.TabIndex = 15;
            this.SpeedLabel.Text = "Speed";
            this.SpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RadioFXLabel
            // 
            this.RadioFXLabel.AutoSize = true;
            this.TLP_Main.SetColumnSpan(this.RadioFXLabel, 3);
            this.RadioFXLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioFXLabel.Location = new System.Drawing.Point(3, 153);
            this.RadioFXLabel.Margin = new System.Windows.Forms.Padding(3);
            this.RadioFXLabel.Name = "RadioFXLabel";
            this.RadioFXLabel.Size = new System.Drawing.Size(614, 14);
            this.RadioFXLabel.TabIndex = 16;
            this.RadioFXLabel.Text = "Radio FX intensity";
            this.RadioFXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlayTTSButton
            // 
            this.PlayTTSButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayTTSButton.Location = new System.Drawing.Point(303, 320);
            this.PlayTTSButton.Name = "PlayTTSButton";
            this.PlayTTSButton.Size = new System.Drawing.Size(154, 34);
            this.PlayTTSButton.TabIndex = 17;
            this.PlayTTSButton.Text = "Play TTS message";
            this.PlayTTSButton.UseVisualStyleBackColor = true;
            this.PlayTTSButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // PitchLabel
            // 
            this.PitchLabel.AutoSize = true;
            this.TLP_Main.SetColumnSpan(this.PitchLabel, 3);
            this.PitchLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PitchLabel.Location = new System.Drawing.Point(3, 203);
            this.PitchLabel.Margin = new System.Windows.Forms.Padding(3);
            this.PitchLabel.Name = "PitchLabel";
            this.PitchLabel.Size = new System.Drawing.Size(614, 14);
            this.PitchLabel.TabIndex = 18;
            this.PitchLabel.Text = "Pitch";
            this.PitchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PitchTrackBar
            // 
            this.TLP_Main.SetColumnSpan(this.PitchTrackBar, 3);
            this.PitchTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PitchTrackBar.Location = new System.Drawing.Point(3, 223);
            this.PitchTrackBar.Minimum = -10;
            this.PitchTrackBar.Name = "PitchTrackBar";
            this.PitchTrackBar.Size = new System.Drawing.Size(614, 24);
            this.PitchTrackBar.TabIndex = 19;
            this.PitchTrackBar.Scroll += new System.EventHandler(this.PitchTrackBar_Scroll);
            // 
            // PlayFileButton
            // 
            this.PlayFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayFileButton.Location = new System.Drawing.Point(303, 280);
            this.PlayFileButton.Name = "PlayFileButton";
            this.PlayFileButton.Size = new System.Drawing.Size(154, 34);
            this.PlayFileButton.TabIndex = 20;
            this.PlayFileButton.Text = "Play file message";
            this.PlayFileButton.UseVisualStyleBackColor = true;
            this.PlayFileButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveFileButton.Location = new System.Drawing.Point(463, 280);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(154, 34);
            this.SaveFileButton.TabIndex = 21;
            this.SaveFileButton.Text = "Save file to .wav";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 357);
            this.Controls.Add(this.TLP_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Radio Message Maker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RadioMessageMakerForm_FormClosed);
            this.Load += new System.EventHandler(this.Frm_RadioMessageMaker_Load);
            this.TLP_Main.ResumeLayout(false);
            this.TLP_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadioFXTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PitchTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_Main;
        private System.Windows.Forms.Button SaveTTSButton;
        private System.Windows.Forms.TextBox MessageTextbox;
        private System.Windows.Forms.ComboBox VoiceComboBox;
        private System.Windows.Forms.TrackBar SpeedTrackBar;
        private System.Windows.Forms.TrackBar RadioFXTrackBar;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Label VoiceLabel;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label RadioFXLabel;
        private System.Windows.Forms.Button PlayTTSButton;
        private System.Windows.Forms.Label PitchLabel;
        private System.Windows.Forms.TrackBar PitchTrackBar;
        private System.Windows.Forms.Button PlayFileButton;
        private System.Windows.Forms.Button SaveFileButton;
    }
}