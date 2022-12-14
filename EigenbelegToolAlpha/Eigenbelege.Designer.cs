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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_SelectAllRows = new System.Windows.Forms.Button();
            this.btn_DeleteAll = new System.Windows.Forms.Button();
            this.btn_PushToRep = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_SwitchToRelatedReparatur = new System.Windows.Forms.Button();
            this.btn_settings2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fensterwechselToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eigenbelegeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.protokollierungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proofingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sucheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auswertungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_folderInstaCreate = new System.Windows.Forms.Button();
            this.btn_buybackPriceAdaptions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eigenbelegeDGV)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 773);
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
            this.eigenbelegeDGV.Location = new System.Drawing.Point(61, 225);
            this.eigenbelegeDGV.Name = "eigenbelegeDGV";
            this.eigenbelegeDGV.ReadOnly = true;
            this.eigenbelegeDGV.RowHeadersVisible = false;
            this.eigenbelegeDGV.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.eigenbelegeDGV.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.eigenbelegeDGV.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.eigenbelegeDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eigenbelegeDGV.Size = new System.Drawing.Size(1153, 533);
            this.eigenbelegeDGV.TabIndex = 5;
            this.eigenbelegeDGV.TabStop = false;
            this.eigenbelegeDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eigenbelegeDGV_CellClick);
            this.eigenbelegeDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.eigenbelegeDGV_CellContentClick);
            // 
            // btn_eigenbelegCreate
            // 
            this.btn_eigenbelegCreate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_eigenbelegCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eigenbelegCreate.Location = new System.Drawing.Point(79, 179);
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
            this.btn_eigenbelegEdit.Location = new System.Drawing.Point(223, 179);
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
            this.btn_eigenbelegRemove.Location = new System.Drawing.Point(370, 179);
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
            this.button3.Location = new System.Drawing.Point(79, 80);
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
            // btn_SelectAllRows
            // 
            this.btn_SelectAllRows.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_SelectAllRows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectAllRows.ForeColor = System.Drawing.Color.Black;
            this.btn_SelectAllRows.Location = new System.Drawing.Point(919, 179);
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
            this.btn_DeleteAll.Location = new System.Drawing.Point(1082, 179);
            this.btn_DeleteAll.Name = "btn_DeleteAll";
            this.btn_DeleteAll.Size = new System.Drawing.Size(134, 26);
            this.btn_DeleteAll.TabIndex = 29;
            this.btn_DeleteAll.Text = "Alles löschen";
            this.btn_DeleteAll.UseVisualStyleBackColor = false;
            this.btn_DeleteAll.Click += new System.EventHandler(this.btn_DeleteAll_Click);
            // 
            // btn_PushToRep
            // 
            this.btn_PushToRep.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_PushToRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PushToRep.ForeColor = System.Drawing.Color.Black;
            this.btn_PushToRep.Location = new System.Drawing.Point(223, 80);
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
            this.button5.Location = new System.Drawing.Point(1082, 113);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(134, 27);
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
            this.btn_SwitchToRelatedReparatur.Location = new System.Drawing.Point(370, 80);
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
            this.btn_settings2.Location = new System.Drawing.Point(1082, 80);
            this.btn_settings2.Name = "btn_settings2";
            this.btn_settings2.Size = new System.Drawing.Size(134, 27);
            this.btn_settings2.TabIndex = 41;
            this.btn_settings2.Text = "Einstellungen";
            this.btn_settings2.UseVisualStyleBackColor = false;
            this.btn_settings2.Click += new System.EventHandler(this.btn_settings2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Atlanta", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(74, 37);
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
            this.label1.Location = new System.Drawing.Point(74, 136);
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
            this.label3.Location = new System.Drawing.Point(1071, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 28);
            this.label3.TabIndex = 46;
            this.label3.Text = "Einstellungen";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(1080, 776);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(134, 26);
            this.button4.TabIndex = 47;
            this.button4.Text = "Manueller Datenimport";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fensterwechselToolStripMenuItem,
            this.sucheToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.auswertungenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 48;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fensterwechselToolStripMenuItem
            // 
            this.fensterwechselToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eigenbelegeToolStripMenuItem,
            this.protokollierungToolStripMenuItem,
            this.proofingToolStripMenuItem,
            this.serviceToolStripMenuItem});
            this.fensterwechselToolStripMenuItem.Image = global::EigenbelegToolAlpha.Properties.Resources.windowsvg;
            this.fensterwechselToolStripMenuItem.Name = "fensterwechselToolStripMenuItem";
            this.fensterwechselToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.fensterwechselToolStripMenuItem.Text = "Fensterwechsel";
            // 
            // eigenbelegeToolStripMenuItem
            // 
            this.eigenbelegeToolStripMenuItem.Name = "eigenbelegeToolStripMenuItem";
            this.eigenbelegeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eigenbelegeToolStripMenuItem.Text = "Reparaturen";
            this.eigenbelegeToolStripMenuItem.Click += new System.EventHandler(this.eigenbelegeToolStripMenuItem_Click);
            // 
            // protokollierungToolStripMenuItem
            // 
            this.protokollierungToolStripMenuItem.Name = "protokollierungToolStripMenuItem";
            this.protokollierungToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.protokollierungToolStripMenuItem.Text = "Protokollierung";
            this.protokollierungToolStripMenuItem.Click += new System.EventHandler(this.protokollierungToolStripMenuItem_Click);
            // 
            // proofingToolStripMenuItem
            // 
            this.proofingToolStripMenuItem.Name = "proofingToolStripMenuItem";
            this.proofingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.proofingToolStripMenuItem.Text = "Proofing";
            this.proofingToolStripMenuItem.Click += new System.EventHandler(this.proofingToolStripMenuItem_Click);
            // 
            // serviceToolStripMenuItem
            // 
            this.serviceToolStripMenuItem.Name = "serviceToolStripMenuItem";
            this.serviceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.serviceToolStripMenuItem.Text = "Service";
            this.serviceToolStripMenuItem.Click += new System.EventHandler(this.serviceToolStripMenuItem_Click);
            // 
            // sucheToolStripMenuItem
            // 
            this.sucheToolStripMenuItem.Image = global::EigenbelegToolAlpha.Properties.Resources.suche;
            this.sucheToolStripMenuItem.Name = "sucheToolStripMenuItem";
            this.sucheToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.sucheToolStripMenuItem.Text = "Suche";
            this.sucheToolStripMenuItem.Click += new System.EventHandler(this.sucheToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Image = global::EigenbelegToolAlpha.Properties.Resources.filter;
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.filterToolStripMenuItem.Text = "Filter";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // auswertungenToolStripMenuItem
            // 
            this.auswertungenToolStripMenuItem.Image = global::EigenbelegToolAlpha.Properties.Resources.evaluations;
            this.auswertungenToolStripMenuItem.Name = "auswertungenToolStripMenuItem";
            this.auswertungenToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.auswertungenToolStripMenuItem.Text = "Auswertungen";
            this.auswertungenToolStripMenuItem.Click += new System.EventHandler(this.auswertungenToolStripMenuItem_Click);
            // 
            // btn_folderInstaCreate
            // 
            this.btn_folderInstaCreate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_folderInstaCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_folderInstaCreate.ForeColor = System.Drawing.Color.Black;
            this.btn_folderInstaCreate.Location = new System.Drawing.Point(527, 80);
            this.btn_folderInstaCreate.Name = "btn_folderInstaCreate";
            this.btn_folderInstaCreate.Size = new System.Drawing.Size(134, 26);
            this.btn_folderInstaCreate.TabIndex = 49;
            this.btn_folderInstaCreate.Text = "Ordner Insta Create";
            this.btn_folderInstaCreate.UseVisualStyleBackColor = false;
            this.btn_folderInstaCreate.Click += new System.EventHandler(this.btn_folderInstaCreate_Click);
            // 
            // btn_buybackPriceAdaptions
            // 
            this.btn_buybackPriceAdaptions.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_buybackPriceAdaptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buybackPriceAdaptions.ForeColor = System.Drawing.Color.Black;
            this.btn_buybackPriceAdaptions.Location = new System.Drawing.Point(688, 80);
            this.btn_buybackPriceAdaptions.Name = "btn_buybackPriceAdaptions";
            this.btn_buybackPriceAdaptions.Size = new System.Drawing.Size(134, 26);
            this.btn_buybackPriceAdaptions.TabIndex = 50;
            this.btn_buybackPriceAdaptions.Text = "BuyBack Price Adaption";
            this.btn_buybackPriceAdaptions.UseVisualStyleBackColor = false;
            this.btn_buybackPriceAdaptions.Click += new System.EventHandler(this.btn_buybackPriceAdaptions_Click);
            // 
            // Eigenbelege
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1264, 814);
            this.Controls.Add(this.btn_buybackPriceAdaptions);
            this.Controls.Add(this.btn_folderInstaCreate);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_settings2);
            this.Controls.Add(this.btn_SwitchToRelatedReparatur);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btn_PushToRep);
            this.Controls.Add(this.btn_DeleteAll);
            this.Controls.Add(this.btn_SelectAllRows);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_eigenbelegRemove);
            this.Controls.Add(this.btn_eigenbelegEdit);
            this.Controls.Add(this.btn_eigenbelegCreate);
            this.Controls.Add(this.eigenbelegeDGV);
            this.Controls.Add(this.lbl_foundPath);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Eigenbelege";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eigenbelege";
            this.Load += new System.EventHandler(this.Hauptmenü_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eigenbelegeDGV)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_foundPath;
        public System.Windows.Forms.DataGridView eigenbelegeDGV;
        private System.Windows.Forms.Button btn_eigenbelegCreate;
        private System.Windows.Forms.Button btn_eigenbelegEdit;
        private System.Windows.Forms.Button btn_eigenbelegRemove;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFD;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_SelectAllRows;
        private System.Windows.Forms.Button btn_DeleteAll;
        private System.Windows.Forms.Button btn_PushToRep;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btn_SwitchToRelatedReparatur;
        private System.Windows.Forms.Button btn_settings2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fensterwechselToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eigenbelegeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem protokollierungToolStripMenuItem;
        private System.Windows.Forms.Button btn_folderInstaCreate;
        private System.Windows.Forms.Button btn_buybackPriceAdaptions;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proofingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auswertungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sucheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceToolStripMenuItem;
    }
}

