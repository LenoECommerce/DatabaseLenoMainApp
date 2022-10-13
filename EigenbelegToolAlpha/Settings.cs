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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText("config3.txt",textBox_SettingsInternalNumber.Text);
            File.WriteAllText("config4.txt", textBox_SettingsEigenbelegNummer.Text);
            MessageBox.Show("Deine Einstellungen wurden gespeichert.");
            this.Hide();
        }
    }
}
