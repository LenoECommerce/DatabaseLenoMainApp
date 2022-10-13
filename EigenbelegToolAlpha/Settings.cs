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

namespace EigenbelegToolAlpha
{
    public partial class Settings : Form
    {
        public string valueIntern = File.ReadAllText("config3.txt");
        public string valueEigenbelegNumber = File.ReadAllText("config4.txt");

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            textBox_SettingsEigenbelegNummer.Text = valueEigenbelegNumber;
            textBox_SettingsInternalNumber.Text = valueIntern;
            lbl_currentPathModellTemplate.Text = File.ReadAllText("modell.txt");
            lbl_currentPathDisplayTemplate.Text = File.ReadAllText("display.txt");
            lbl_currentPathPlatinenTemplate.Text = File.ReadAllText("platinen.txt");
            lbl_currentPathSonstigesTemplate.Text = File.ReadAllText("sonstiges.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText("config3.txt",textBox_SettingsInternalNumber.Text);
            File.WriteAllText("config4.txt", textBox_SettingsEigenbelegNummer.Text);
            MessageBox.Show("Deine Einstellungen wurden gespeichert.");
            this.Hide();
        }

        private void btn_SetTemplateModell_Click(object sender, EventArgs e)
        {
            
        }

        private void lbl_currentPathModellTemplate_Click(object sender, EventArgs e)
        {
            openFD.ShowDialog();
            string selectedFileName = openFD.SafeFileName;
            string selectedFile = Path.GetFullPath(selectedFileName);
            File.WriteAllText("modell.txt", selectedFile);
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
    }
}
