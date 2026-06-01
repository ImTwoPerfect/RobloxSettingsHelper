namespace RobloxSettingsHelper
{
    partial class StartupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupForm));
            fontCheck = new CheckBox();
            mngFontsBtn = new Button();
            clientSettingsCheck = new CheckBox();
            fpsUnlockCheck = new CheckBox();
            texturesCheck = new CheckBox();
            setFflagsBtn = new Button();
            saveBtn = new Button();
            exitBtn = new Button();
            fpsCapLabel = new Label();
            fpsCapTxt = new RichTextBox();
            SuspendLayout();
            // 
            // fontCheck
            // 
            fontCheck.AutoSize = true;
            fontCheck.FlatAppearance.BorderSize = 0;
            fontCheck.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fontCheck.ForeColor = SystemColors.ControlLightLight;
            fontCheck.Location = new Point(14, 14);
            fontCheck.Margin = new Padding(4, 3, 4, 3);
            fontCheck.Name = "fontCheck";
            fontCheck.Size = new Size(65, 24);
            fontCheck.TabIndex = 0;
            fontCheck.Text = "Font";
            fontCheck.UseVisualStyleBackColor = true;
            fontCheck.CheckedChanged += fontCheck_CheckedChanged;
            fontCheck.MouseEnter += fontCheck_MouseEnter;
            fontCheck.MouseLeave += fontCheck_MouseLeave;
            // 
            // mngFontsBtn
            // 
            mngFontsBtn.BackColor = SystemColors.MenuHighlight;
            mngFontsBtn.FlatAppearance.BorderSize = 0;
            mngFontsBtn.FlatStyle = FlatStyle.Flat;
            mngFontsBtn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mngFontsBtn.Location = new Point(261, 14);
            mngFontsBtn.Margin = new Padding(4, 3, 4, 3);
            mngFontsBtn.Name = "mngFontsBtn";
            mngFontsBtn.Size = new Size(142, 28);
            mngFontsBtn.TabIndex = 1;
            mngFontsBtn.Text = "Manage Fonts";
            mngFontsBtn.UseVisualStyleBackColor = false;
            mngFontsBtn.Click += button1_Click;
            // 
            // clientSettingsCheck
            // 
            clientSettingsCheck.AutoSize = true;
            clientSettingsCheck.FlatAppearance.BorderSize = 0;
            clientSettingsCheck.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clientSettingsCheck.Location = new Point(14, 48);
            clientSettingsCheck.Margin = new Padding(4, 3, 4, 3);
            clientSettingsCheck.Name = "clientSettingsCheck";
            clientSettingsCheck.Size = new Size(141, 24);
            clientSettingsCheck.TabIndex = 2;
            clientSettingsCheck.Text = "ClientSettings";
            clientSettingsCheck.UseVisualStyleBackColor = true;
            clientSettingsCheck.CheckedChanged += clientSettingsCheck_CheckedChanged;
            clientSettingsCheck.MouseEnter += clientSettingsCheck_MouseEnter;
            clientSettingsCheck.MouseLeave += clientSettingsCheck_MouseLeave;
            // 
            // fpsUnlockCheck
            // 
            fpsUnlockCheck.AutoSize = true;
            fpsUnlockCheck.FlatAppearance.BorderSize = 0;
            fpsUnlockCheck.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fpsUnlockCheck.Location = new Point(14, 83);
            fpsUnlockCheck.Margin = new Padding(4, 3, 4, 3);
            fpsUnlockCheck.Name = "fpsUnlockCheck";
            fpsUnlockCheck.Size = new Size(122, 24);
            fpsUnlockCheck.TabIndex = 3;
            fpsUnlockCheck.Text = "Unlock FPS";
            fpsUnlockCheck.UseVisualStyleBackColor = true;
            fpsUnlockCheck.CheckedChanged += fpsUnlockCheck_CheckedChanged;
            fpsUnlockCheck.MouseEnter += fpsUnlockCheck_MouseEnter;
            fpsUnlockCheck.MouseLeave += fpsUnlockCheck_MouseLeave;
            // 
            // texturesCheck
            // 
            texturesCheck.AutoSize = true;
            texturesCheck.FlatAppearance.BorderSize = 0;
            texturesCheck.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            texturesCheck.Location = new Point(14, 118);
            texturesCheck.Margin = new Padding(4, 3, 4, 3);
            texturesCheck.Name = "texturesCheck";
            texturesCheck.Size = new Size(140, 24);
            texturesCheck.TabIndex = 4;
            texturesCheck.Text = "Dark Textures";
            texturesCheck.UseVisualStyleBackColor = true;
            texturesCheck.MouseEnter += texturesCheck_MouseEnter;
            texturesCheck.MouseLeave += texturesCheck_MouseLeave;
            // 
            // setFflagsBtn
            // 
            setFflagsBtn.BackColor = SystemColors.MenuHighlight;
            setFflagsBtn.FlatAppearance.BorderSize = 0;
            setFflagsBtn.FlatStyle = FlatStyle.Flat;
            setFflagsBtn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            setFflagsBtn.Location = new Point(261, 48);
            setFflagsBtn.Margin = new Padding(4, 3, 4, 3);
            setFflagsBtn.Name = "setFflagsBtn";
            setFflagsBtn.Size = new Size(142, 28);
            setFflagsBtn.TabIndex = 5;
            setFflagsBtn.Text = "Set FFlags";
            setFflagsBtn.UseVisualStyleBackColor = false;
            setFflagsBtn.Click += button2_Click;
            // 
            // saveBtn
            // 
            saveBtn.BackColor = SystemColors.MenuHighlight;
            saveBtn.FlatAppearance.BorderSize = 0;
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveBtn.Location = new Point(14, 162);
            saveBtn.Margin = new Padding(4, 3, 4, 3);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(186, 36);
            saveBtn.TabIndex = 6;
            saveBtn.Text = "Update";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += button3_Click;
            // 
            // exitBtn
            // 
            exitBtn.BackColor = Color.Firebrick;
            exitBtn.FlatAppearance.BorderSize = 0;
            exitBtn.FlatStyle = FlatStyle.Flat;
            exitBtn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitBtn.Location = new Point(218, 162);
            exitBtn.Margin = new Padding(4, 3, 4, 3);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(186, 36);
            exitBtn.TabIndex = 7;
            exitBtn.Text = "Exit";
            exitBtn.UseVisualStyleBackColor = false;
            exitBtn.Click += button4_Click;
            // 
            // fpsCapLabel
            // 
            fpsCapLabel.AutoSize = true;
            fpsCapLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fpsCapLabel.Location = new Point(170, 84);
            fpsCapLabel.Name = "fpsCapLabel";
            fpsCapLabel.Size = new Size(85, 20);
            fpsCapLabel.TabIndex = 9;
            fpsCapLabel.Text = "Max FPS:";
            // 
            // fpsCapTxt
            // 
            fpsCapTxt.BackColor = SystemColors.MenuHighlight;
            fpsCapTxt.BorderStyle = BorderStyle.None;
            fpsCapTxt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fpsCapTxt.ForeColor = SystemColors.ControlLightLight;
            fpsCapTxt.Location = new Point(261, 83);
            fpsCapTxt.MaxLength = 4;
            fpsCapTxt.Multiline = false;
            fpsCapTxt.Name = "fpsCapTxt";
            fpsCapTxt.ScrollBars = RichTextBoxScrollBars.None;
            fpsCapTxt.Size = new Size(142, 24);
            fpsCapTxt.TabIndex = 10;
            fpsCapTxt.Text = "";
            fpsCapTxt.MouseClick += fpsCapTxt_MouseClick;
            fpsCapTxt.TextChanged += richTextBox1_TextChanged;
            fpsCapTxt.KeyPress += fpsCapTxt_KeyPress;
            // 
            // StartupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(418, 211);
            Controls.Add(fpsCapTxt);
            Controls.Add(fpsCapLabel);
            Controls.Add(exitBtn);
            Controls.Add(saveBtn);
            Controls.Add(setFflagsBtn);
            Controls.Add(texturesCheck);
            Controls.Add(fpsUnlockCheck);
            Controls.Add(clientSettingsCheck);
            Controls.Add(mngFontsBtn);
            Controls.Add(fontCheck);
            ForeColor = SystemColors.ControlLightLight;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StartupForm";
            Text = "RobloxSettingsHelper";
            Load += StartupForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox fontCheck;
        private System.Windows.Forms.Button mngFontsBtn;
        private System.Windows.Forms.CheckBox clientSettingsCheck;
        private System.Windows.Forms.CheckBox fpsUnlockCheck;
        private System.Windows.Forms.CheckBox texturesCheck;
        private System.Windows.Forms.Button setFflagsBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button exitBtn;
        private Label fpsCapLabel;
        private RichTextBox fpsCapTxt;
    }
}