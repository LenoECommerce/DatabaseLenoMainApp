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
    public partial class ReparaturCreate : Form
    {
        public ReparaturCreate()
        {
            InitializeComponent();
        }

        private void ReparaturCreate_Load(object sender, EventArgs e)
        {
            textBox_ReparaturenInternalNumber.Text = File.ReadAllText("config3.txt");
            comboBox_ReparaturenReparaturStatus.Text = "Entgegengenommen";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tempInternalNumber = textBox_ReparaturenInternalNumber.Text;
            string tempDateBought = textBox_reparaturenDateBought.Text;
            string tempDevice = textBox_reparaturenDevice.Text;
            string tempTransactionAmount = textBox_reparaturenTransactionAmount.Text;
            string tempMake = comboBox_reparaturenMake.Text;
            string tempStorage = comboBox__reparaturenStorage.Text;
            string tempDefect = textBox__reparaturenDefect.Text;
            string tempImei = textBox__reparaturenIMEI.Text;
            string tempExternalCosts = textBox_reparaturenExternalCosts.Text;
            string tempComment = textBox_reparaturenComment.Text;
            string tempNotifications = textBox_reparaturenComment.Text;
            string tempTested = comboBox_ReparaturenGetestet.Text;
            string tempStatus = comboBox_ReparaturenReparaturStatus.Text;
            string tempSource = textBox_reparaturenSource.Text;
            string tempRiskLevel = textBox_reparaturenRiskLevel.Text;
            string tempWorthIt = textBox_reparaturenWorthIt.Text;
            string tempReferenceToEB = textBox_reparaturenReferenceToEB.Text;

            string query = string.Format("INSERT INTO `Reparaturen`(`Intern`,`Kaufdatum`,`Geraet`,`Kaufbetrag`,`IMEI`,`Marke`,`Speicher`,`Defekt`,`ExterneKosten`,`Kommentar`,`Meldungen?`,`Getestet?`,`Reparaturstatus`,`Quelle`,`Risikostufe`,`LohntSich?`,`EBReferenz`) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')"
            ,tempInternalNumber, tempDateBought, tempDevice, tempTransactionAmount, tempImei, tempMake, tempStorage, tempDefect, tempExternalCosts, tempComment, tempNotifications, tempTested, tempStatus, tempSource, tempRiskLevel, tempWorthIt, tempReferenceToEB);

            Reparaturen.ExecuteQuery(query);
            MessageBox.Show("Dein Eintrag wurde erfolgreich erstellt.");
            Reparaturen window = new Reparaturen();
            window.ShowReparaturen();
            this.Close();
        }

        private void textBox_reparaturenTransactionAmount_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
