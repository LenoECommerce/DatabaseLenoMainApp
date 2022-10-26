using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;


namespace EigenbelegToolAlpha
{
    public partial class Settings : Form
    {
        public string valueIntern = CRUDQueries.ExecuteQueryWithResult("Config", "Nummer", "Typ", "InterneNummer").ToString();
        public string valueEigenbelegNumber = CRUDQueries.ExecuteQueryWithResult("Config", "Nummer", "Typ", "Eigenbelegnummer").ToString();
        public string folderLocation;

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            textBox_SettingsEigenbelegNummer.Text = valueEigenbelegNumber;
            textBox_SettingsInternalNumber.Text = valueIntern;
            string modellTemplate = CRUDQueries.ExecuteQueryWithResultString("ConfigUser","TemplateModell","Nutzer",File.ReadAllText("user.txt"));
            lbl_currentPathModellTemplate.Text = modellTemplate;
            //lbl_currentPathDisplayTemplate.Text = File.ReadAllText("display.txt");
            //lbl_currentPathPlatinenTemplate.Text = File.ReadAllText("platinen.txt");
            //lbl_currentPathSonstigesTemplate.Text = File.ReadAllText("sonstiges.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUDQueries.ExecuteQuery("UPDATE `Config` SET `Nummer` = '" + valueEigenbelegNumber + "' WHERE `Typ` = 'Eigenbelegnummer'");
            CRUDQueries.ExecuteQuery("UPDATE `Config` SET `Nummer` = '" + valueIntern + "' WHERE `Typ` = 'InterneNummer'");
            MessageBox.Show("Deine Einstellungen wurden gespeichert.");
            this.Hide();
        }

        private void btn_SetTemplateModell_Click(object sender, EventArgs e)
        {
            
        }

        private void lbl_currentPathModellTemplate_Click(object sender, EventArgs e)
        {
            openFD.ShowDialog();
            string selectedFileName = openFD.FileName;
            //string selectedFile = Path.GetFullPath(selectedFileName);
            File.WriteAllText("modell.txt", selectedFileName);
            lbl_currentPathModellTemplate.Text = File.ReadAllText("modell.txt");
        }

        private void lbl_currentPathDisplayTemplate_Click(object sender, EventArgs e)
        {
            openFD2.ShowDialog();
            string selectedFileName = openFD2.SafeFileName;
            string selectedFile = Path.GetFullPath(selectedFileName);
            File.WriteAllText("display.txt", selectedFile);
            lbl_currentPathDisplayTemplate.Text = File.ReadAllText("display.txt");
        }

        private void lbl_currentPathPlatinenTemplate_Click(object sender, EventArgs e)
        {
            openFD3.ShowDialog();
            string selectedFileName = openFD3.SafeFileName;
            string selectedFile = Path.GetFullPath(selectedFileName);
            File.WriteAllText("platinen.txt", selectedFile);
            lbl_currentPathPlatinenTemplate.Text = File.ReadAllText("display.txt");
        }

        private void lbl_currentPathSonstigesTemplate_Click(object sender, EventArgs e)
        {
            openFD4.ShowDialog();
            string selectedFileName = openFD4.SafeFileName;
            string selectedFile = Path.GetFullPath(selectedFileName);
            File.WriteAllText("sonstiges.txt", selectedFile);
            lbl_currentPathSonstigesTemplate.Text = File.ReadAllText("sonstiges.txt");
        }

        private void btn_LocationTemplates_Click(object sender, EventArgs e)
        {
            
        }
    }
}
