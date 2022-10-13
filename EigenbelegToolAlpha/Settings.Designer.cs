namespace EigenbelegToolAlpha
{
    partial class Settings
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
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_SettingsInternalNumber = new System.Windows.Forms.TextBox();
            this.textBox_SettingsEigenbelegNummer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 18);
            this.label8.TabIndex = 40;
            this.label8.Text = "Interne Nummer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 41;
            this.label1.Text = "EB Nummer";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(129, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 29);
            this.button1.TabIndex = 64;
            this.button1.Text = "Änderungen übernehmen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_SettingsInternalNumber
            // 
            this.textBox_SettingsInternalNumber.Location = new System.Drawing.Point(171, 52);
            this.textBox_SettingsInternalNumber.Name = "textBox_SettingsInternalNumber";
            this.textBox_SettingsInternalNumber.Size = new System.Drawing.Size(110, 20);
            this.textBox_SettingsInternalNumber.TabIndex = 65;
            // 
            // textBox_SettingsEigenbelegNummer
            // 
            this.textBox_SettingsEigenbelegNummer.Location = new System.Drawing.Point(171, 82);
            this.textBox_SettingsEigenbelegNummer.Name = "textBox_SettingsEigenbelegNummer";
            this.textBox_SettingsEigenbelegNummer.Size = new System.Drawing.Size(110, 20);
            this.textBox_SettingsEigenbelegNummer.TabIndex = 66;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 229);
            this.Controls.Add(this.textBox_SettingsEigenbelegNummer);
            this.Controls.Add(this.textBox_SettingsInternalNumber);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_SettingsInternalNumber;
        private System.Windows.Forms.TextBox textBox_SettingsEigenbelegNummer;
    }
}