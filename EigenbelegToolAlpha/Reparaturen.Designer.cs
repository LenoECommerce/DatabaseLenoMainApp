namespace EigenbelegToolAlpha
{
    partial class Reparaturen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reparaturen));
            this.btn_settings = new System.Windows.Forms.Button();
            this.reparaturenDGV = new System.Windows.Forms.DataGridView();
            this.btn_DeleteAll = new System.Windows.Forms.Button();
            this.btn_SelectAllRows = new System.Windows.Forms.Button();
            this.btn_reparaturenEdit = new System.Windows.Forms.Button();
            this.btn_reparaturenCreate = new System.Windows.Forms.Button();
            this.btn_reparaturenDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.reparaturenDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_settings
            // 
            this.btn_settings.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_settings.ForeColor = System.Drawing.Color.Black;
            this.btn_settings.Location = new System.Drawing.Point(1143, 29);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Size = new System.Drawing.Size(98, 26);
            this.btn_settings.TabIndex = 28;
            this.btn_settings.Text = "Fenster";
            this.btn_settings.UseVisualStyleBackColor = false;
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // reparaturenDGV
            // 
            this.reparaturenDGV.AllowUserToAddRows = false;
            this.reparaturenDGV.AllowUserToDeleteRows = false;
            this.reparaturenDGV.AllowUserToResizeColumns = false;
            this.reparaturenDGV.AllowUserToResizeRows = false;
            this.reparaturenDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.reparaturenDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.reparaturenDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reparaturenDGV.Location = new System.Drawing.Point(54, 306);
            this.reparaturenDGV.Name = "reparaturenDGV";
            this.reparaturenDGV.ReadOnly = true;
            this.reparaturenDGV.RowHeadersVisible = false;
            this.reparaturenDGV.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.reparaturenDGV.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.reparaturenDGV.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.reparaturenDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reparaturenDGV.Size = new System.Drawing.Size(1153, 432);
            this.reparaturenDGV.TabIndex = 29;
            this.reparaturenDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.reparaturenDGV_CellClick);
            this.reparaturenDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.reparaturenDGV_CellContentClick);
            // 
            // btn_DeleteAll
            // 
            this.btn_DeleteAll.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_DeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteAll.ForeColor = System.Drawing.Color.Black;
            this.btn_DeleteAll.Location = new System.Drawing.Point(232, 103);
            this.btn_DeleteAll.Name = "btn_DeleteAll";
            this.btn_DeleteAll.Size = new System.Drawing.Size(134, 26);
            this.btn_DeleteAll.TabIndex = 31;
            this.btn_DeleteAll.Text = "Alles löschen";
            this.btn_DeleteAll.UseVisualStyleBackColor = false;
            this.btn_DeleteAll.Click += new System.EventHandler(this.btn_DeleteAll_Click);
            // 
            // btn_SelectAllRows
            // 
            this.btn_SelectAllRows.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_SelectAllRows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectAllRows.ForeColor = System.Drawing.Color.Black;
            this.btn_SelectAllRows.Location = new System.Drawing.Point(71, 103);
            this.btn_SelectAllRows.Name = "btn_SelectAllRows";
            this.btn_SelectAllRows.Size = new System.Drawing.Size(134, 26);
            this.btn_SelectAllRows.TabIndex = 30;
            this.btn_SelectAllRows.Text = "Alles auswählen";
            this.btn_SelectAllRows.UseVisualStyleBackColor = false;
            this.btn_SelectAllRows.Click += new System.EventHandler(this.btn_SelectAllRows_Click);
            // 
            // btn_reparaturenEdit
            // 
            this.btn_reparaturenEdit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_reparaturenEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reparaturenEdit.Location = new System.Drawing.Point(232, 29);
            this.btn_reparaturenEdit.Name = "btn_reparaturenEdit";
            this.btn_reparaturenEdit.Size = new System.Drawing.Size(134, 26);
            this.btn_reparaturenEdit.TabIndex = 34;
            this.btn_reparaturenEdit.Text = "Bearbeiten";
            this.btn_reparaturenEdit.UseVisualStyleBackColor = false;
            this.btn_reparaturenEdit.Click += new System.EventHandler(this.btn_reparaturenEdit_Click);
            // 
            // btn_reparaturenCreate
            // 
            this.btn_reparaturenCreate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_reparaturenCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reparaturenCreate.Location = new System.Drawing.Point(71, 29);
            this.btn_reparaturenCreate.Name = "btn_reparaturenCreate";
            this.btn_reparaturenCreate.Size = new System.Drawing.Size(134, 26);
            this.btn_reparaturenCreate.TabIndex = 32;
            this.btn_reparaturenCreate.Text = "Erstellen";
            this.btn_reparaturenCreate.UseVisualStyleBackColor = false;
            // 
            // btn_reparaturenDelete
            // 
            this.btn_reparaturenDelete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_reparaturenDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reparaturenDelete.Location = new System.Drawing.Point(389, 29);
            this.btn_reparaturenDelete.Name = "btn_reparaturenDelete";
            this.btn_reparaturenDelete.Size = new System.Drawing.Size(134, 26);
            this.btn_reparaturenDelete.TabIndex = 35;
            this.btn_reparaturenDelete.Text = "Löschen";
            this.btn_reparaturenDelete.UseVisualStyleBackColor = false;
            this.btn_reparaturenDelete.Click += new System.EventHandler(this.btn_reparaturenDelete_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(1143, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 26);
            this.button1.TabIndex = 36;
            this.button1.Text = "Aktualisieren";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Reparaturen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1264, 814);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_reparaturenDelete);
            this.Controls.Add(this.btn_reparaturenEdit);
            this.Controls.Add(this.btn_reparaturenCreate);
            this.Controls.Add(this.btn_DeleteAll);
            this.Controls.Add(this.btn_SelectAllRows);
            this.Controls.Add(this.reparaturenDGV);
            this.Controls.Add(this.btn_settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Reparaturen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reparaturen";
            this.Load += new System.EventHandler(this.Reparaturen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reparaturenDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_settings;
        public System.Windows.Forms.DataGridView reparaturenDGV;
        private System.Windows.Forms.Button btn_DeleteAll;
        private System.Windows.Forms.Button btn_SelectAllRows;
        private System.Windows.Forms.Button btn_reparaturenEdit;
        private System.Windows.Forms.Button btn_reparaturenCreate;
        private System.Windows.Forms.Button btn_reparaturenDelete;
        private System.Windows.Forms.Button button1;
    }
}