namespace EigenbelegToolAlpha
{
    partial class Eigenbelege
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Eigenbelege));
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_foundPath = new System.Windows.Forms.Label();
            this.eigenbelegeDGV = new System.Windows.Forms.DataGridView();
            this.btn_eigenbelegCreate = new System.Windows.Forms.Button();
            this.btn_eigenbelegEdit = new System.Windows.Forms.Button();
            this.btn_eigenbelegRemove = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.openFD = new System.Windows.Forms.OpenFileDialog();
            this.btn_settings = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_SelectAllRows = new System.Windows.Forms.Button();
            this.btn_DeleteAll = new System.Windows.Forms.Button();
            this.btn_ImageLocPath = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_PushToRep = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_SwitchToRelatedReparatur = new System.Windows.Forms.Button();
            this.btn_settings2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.eigenbelegeDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 755);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "PayPal Daten Import";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_foundPath
            // 
            this.lbl_foundPath.AutoSize = true;
            this.lbl_foundPath.Location = new System.Drawing.Point(47, 373);
            this.lbl_foundPath.Name = "lbl_foundPath";
            this.lbl_foundPath.Size = new System.Drawing.Size(0, 13);
            this.lbl_foundPath.TabIndex = 1;
            // 
            // eigenbelegeDGV
            // 
            this.eigenbelegeDGV.AllowUserToAddRows = false;
            this.eigenbelegeDGV.AllowUserToDeleteRows = false;
            this.eigenbelegeDGV.AllowUserToResizeColumns = false;
            this.eigenbelegeDGV.AllowUserToResizeRows = false;
            this.eigenbelegeDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.eigenbelegeDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.eigenbelegeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eigenbelegeDGV.Location = new System.Drawing.Point(61, 193);
            this.eigenbelegeDGV.Name = "eigenbelegeDGV";
            this.eigenbelegeDGV.ReadOnly = true;
            this.eigenbelegeDGV.RowHeadersVisible = false;
            this.eigenbelegeDGV.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.eigenbelegeDGV.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.eigenbelegeDGV.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.eigenbelegeDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eigenbelegeDGV.Size = new System.Drawing.Size(1153, 533);
            this.eigenbelegeDGV.TabIndex = 5;
            this.eigenbelegeDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eigenbelegeDGV_CellClick);
            this.eigenbelegeDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eigenbelegeDGV_CellContentClick);
            // 
            // btn_eigenbelegCreate
            // 
            this.btn_eigenbelegCreate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_eigenbelegCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eigenbelegCreate.Location = new System.Drawing.Point(77, 151);
            this.btn_eigenbelegCreate.Name = "btn_eigenbelegCreate";
            this.btn_eigenbelegCreate.Size = new System.Drawing.Size(121, 26);
            this.btn_eigenbelegCreate.TabIndex = 22;
            this.btn_eigenbelegCreate.Text = "Erstellen";
            this.btn_eigenbelegCreate.UseVisualStyleBackColor = false;
            this.btn_eigenbelegCreate.Click += new System.EventHandler(this.btn_eigenbelegCreate_Click);
            // 
            // btn_eigenbelegEdit
            // 
            this.btn_eigenbelegEdit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_eigenbelegEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eigenbelegEdit.Location = new System.Drawing.Point(221, 151);
            this.btn_eigenbelegEdit.Name = "btn_eigenbelegEdit";
            this.btn_eigenbelegEdit.Size = new System.Drawing.Size(121, 26);
            this.btn_eigenbelegEdit.TabIndex = 23;
            this.btn_eigenbelegEdit.Text = "Bearbeiten";
            this.btn_eigenbelegEdit.UseVisualStyleBackColor = false;
            this.btn_eigenbelegEdit.Click += new System.EventHandler(this.btn_eigenbelegEdit_Click);
            // 
            // btn_eigenbelegRemove
            // 
            this.btn_eigenbelegRemove.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_eigenbelegRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eigenbelegRemove.Location = new System.Drawing.Point(368, 151);
            this.btn_eigenbelegRemove.Name = "btn_eigenbelegRemove";
            this.btn_eigenbelegRemove.Size = new System.Drawing.Size(121, 26);
            this.btn_eigenbelegRemove.TabIndex = 24;
            this.btn_eigenbelegRemove.Text = "Löschen";
            this.btn_eigenbelegRemove.UseVisualStyleBackColor = false;
            this.btn_eigenbelegRemove.Click += new System.EventHandler(this.btn_eigenbelegRemove_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(77, 52);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 26);
            this.button3.TabIndex = 26;
            this.button3.Text = "Eigenbeleg erstellen";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openFD
            // 
            this.openFD.FileName = "openFD";
            // 
            // btn_settings
            // 
            this.btn_settings.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_settings.ForeColor = System.Drawing.Color.Black;
            this.btn_settings.Location = new System.Drawing.Point(1012, 84);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Size = new System.Drawing.Size(98, 26);
            this.btn_settings.TabIndex = 27;
            this.btn_settings.Text = "Einstellungen";
            this.btn_settings.UseVisualStyleBackColor = false;
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // btn_SelectAllRows
            // 
            this.btn_SelectAllRows.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_SelectAllRows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectAllRows.ForeColor = System.Drawing.Color.Black;
            this.btn_SelectAllRows.Location = new System.Drawing.Point(535, 151);
            this.btn_SelectAllRows.Name = "btn_SelectAllRows";
            this.btn_SelectAllRows.Size = new System.Drawing.Size(134, 26);
            this.btn_SelectAllRows.TabIndex = 28;
            this.btn_SelectAllRows.Text = "Alles auswählen";
            this.btn_SelectAllRows.UseVisualStyleBackColor = false;
            this.btn_SelectAllRows.Click += new System.EventHandler(this.btn_SelectAllRows_Click);
            // 
            // btn_DeleteAll
            // 
            this.btn_DeleteAll.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_DeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteAll.ForeColor = System.Drawing.Color.Black;
            this.btn_DeleteAll.Location = new System.Drawing.Point(698, 151);
            this.btn_DeleteAll.Name = "btn_DeleteAll";
            this.btn_DeleteAll.Size = new System.Drawing.Size(134, 26);
            this.btn_DeleteAll.TabIndex = 29;
            this.btn_DeleteAll.Text = "Alles löschen";
            this.btn_DeleteAll.UseVisualStyleBackColor = false;
            this.btn_DeleteAll.Click += new System.EventHandler(this.btn_DeleteAll_Click);
            // 
            // btn_ImageLocPath
            // 
            this.btn_ImageLocPath.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_ImageLocPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ImageLocPath.ForeColor = System.Drawing.Color.Black;
            this.btn_ImageLocPath.Location = new System.Drawing.Point(1012, 52);
            this.btn_ImageLocPath.Name = "btn_ImageLocPath";
            this.btn_ImageLocPath.Size = new System.Drawing.Size(98, 26);
            this.btn_ImageLocPath.TabIndex = 32;
            this.btn_ImageLocPath.Text = "Bilderpfad";
            this.btn_ImageLocPath.UseVisualStyleBackColor = false;
            this.btn_ImageLocPath.Click += new System.EventHandler(this.btn_ImageLocPath_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(1116, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 26);
            this.button2.TabIndex = 33;
            this.button2.Text = "Fenster";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_3);
            // 
            // btn_PushToRep
            // 
            this.btn_PushToRep.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_PushToRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PushToRep.ForeColor = System.Drawing.Color.Black;
            this.btn_PushToRep.Location = new System.Drawing.Point(221, 52);
            this.btn_PushToRep.Name = "btn_PushToRep";
            this.btn_PushToRep.Size = new System.Drawing.Size(134, 26);
            this.btn_PushToRep.TabIndex = 35;
            this.btn_PushToRep.Text = "Als Reparatur erfassen";
            this.btn_PushToRep.UseVisualStyleBackColor = false;
            this.btn_PushToRep.Click += new System.EventHandler(this.btn_PushToRep_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(1116, 84);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 26);
            this.button5.TabIndex = 37;
            this.button5.Text = "Aktualisieren";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // btn_SwitchToRelatedReparatur
            // 
            this.btn_SwitchToRelatedReparatur.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_SwitchToRelatedReparatur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SwitchToRelatedReparatur.ForeColor = System.Drawing.Color.Black;
            this.btn_SwitchToRelatedReparatur.Location = new System.Drawing.Point(368, 52);
            this.btn_SwitchToRelatedReparatur.Name = "btn_SwitchToRelatedReparatur";
            this.btn_SwitchToRelatedReparatur.Size = new System.Drawing.Size(134, 26);
            this.btn_SwitchToRelatedReparatur.TabIndex = 38;
            this.btn_SwitchToRelatedReparatur.Text = "Zu Reparatur springen";
            this.btn_SwitchToRelatedReparatur.UseVisualStyleBackColor = false;
            this.btn_SwitchToRelatedReparatur.Click += new System.EventHandler(this.btn_SwitchToRelatedReparatur_Click);
            // 
            // btn_settings2
            // 
            this.btn_settings2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_settings2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_settings2.ForeColor = System.Drawing.Color.Black;
            this.btn_settings2.Location = new System.Drawing.Point(1012, 114);
            this.btn_settings2.Name = "btn_settings2";
            this.btn_settings2.Size = new System.Drawing.Size(202, 26);
            this.btn_settings2.TabIndex = 41;
            this.btn_settings2.Text = "Einstellungen Nummern";
            this.btn_settings2.UseVisualStyleBackColor = false;
            this.btn_settings2.Click += new System.EventHandler(this.btn_settings2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Atlanta", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(72, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 28);
            this.label2.TabIndex = 44;
            this.label2.Text = "Erweiterte Funktionen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Atlanta", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(72, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 28);
            this.label1.TabIndex = 45;
            this.label1.Text = "Hauptfunktionen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Atlanta", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1069, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 28);
            this.label3.TabIndex = 46;
            this.label3.Text = "Einstellungen";
            // 
            // Eigenbelege
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1264, 814);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_settings2);
            this.Controls.Add(this.btn_SwitchToRelatedReparatur);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btn_PushToRep);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_ImageLocPath);
            this.Controls.Add(this.btn_DeleteAll);
            this.Controls.Add(this.btn_SelectAllRows);
            this.Controls.Add(this.btn_settings);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_eigenbelegRemove);
            this.Controls.Add(this.btn_eigenbelegEdit);
            this.Controls.Add(this.btn_eigenbelegCreate);
            this.Controls.Add(this.eigenbelegeDGV);
            this.Controls.Add(this.lbl_foundPath);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Eigenbelege";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eigenbelege";
            this.Load += new System.EventHandler(this.Hauptmenü_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eigenbelegeDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_foundPath;
        private System.Windows.Forms.DataGridView eigenbelegeDGV;
        private System.Windows.Forms.Button btn_eigenbelegCreate;
        private System.Windows.Forms.Button btn_eigenbelegEdit;
        private System.Windows.Forms.Button btn_eigenbelegRemove;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFD;
        private System.Windows.Forms.Button btn_settings;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_SelectAllRows;
        private System.Windows.Forms.Button btn_DeleteAll;
        private System.Windows.Forms.Button btn_ImageLocPath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_PushToRep;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btn_SwitchToRelatedReparatur;
        private System.Windows.Forms.Button btn_settings2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}

