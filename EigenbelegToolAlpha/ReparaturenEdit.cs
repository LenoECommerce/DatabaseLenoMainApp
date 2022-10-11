using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EigenbelegToolAlpha
{
    public partial class ReparaturenEdit : Form
    {
        public ReparaturenEdit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string internalNumber = textBox_ReparaturenInternalNumber.Text;
            string dateBought = textBox_reparaturenDateBought.Text;
            string device = textBox_reparaturenDevice.Text;
            string make = comboBox_reparaturenMake.Text;
            string storage = comboBox__reparaturenStorage.Text;
            string defect = textBox__reparaturenDefect.Text;
            string transactionAmount = textBox_reparaturenTransactionAmount.Text;
            string imei = textBox__reparaturenIMEI.Text;
            string externalCosts = textBox_reparaturenExternalCosts.Text;
            string comment = textBox_reparaturenComment.Text;
            string source = textBox_reparaturenSource.Text;
            string riskLevel = textBox_reparaturenRiskLevel.Text;
            string worthIt = textBox_reparaturenWorthIt.Text;
            string referenceToEB = textBox_reparaturenReferenceToEB.Text;
            string notifications = comboBox_ReparaturenMeldungen.Text;
            string tested = comboBox_ReparaturenGetestet.Text;
            string state = comboBox_ReparaturenReparaturStatus.Text;


            string query = string.Format("UPDATE `Reparaturen` SET `Intern` = '{0}',`Kaufdatum` = '{1}', `Geraet` = '{2}', `Kaufbetrag` = '{3}', `IMEI` = '{4}', `Marke` = '{5}', `Speicher` = '{6}', `Defekt` = '{7}', `ExterneKosten` = '{8}', `Kommentar` = '{9}', `Meldungen?` = '{10}', `Getestet?` = '{11}', `Reparaturstatus` = '{12}', `Quelle` = '{13}', `Risikostufe` = '{14}', `LohntSich?` = '{15}', `EBReferenz` = '{16}' WHERE `Id` = {17}"
                , internalNumber, dateBought, device, transactionAmount, imei, make, storage, defect, externalCosts, comment, notifications, tested, state, source, riskLevel, worthIt, referenceToEB, Reparaturen.lastSelectedProductKey);

            Reparaturen.ExecuteQuery(query);
            MessageBox.Show("Deine Änderungen wurden erfolgreich gespeichert.");
            this.Close();
        }

        private void ReparaturenEdit_Load(object sender, EventArgs e)
        {
            textBox_ReparaturenInternalNumber.Text = Reparaturen.internalNumber;
            textBox_reparaturenDateBought.Text = Reparaturen.dateBought;
            textBox_reparaturenDevice.Text = Reparaturen.device;
            comboBox_reparaturenMake.Text = Reparaturen.make;
            comboBox__reparaturenStorage.Text = Reparaturen.storage;
            textBox__reparaturenDefect.Text = Reparaturen.defect;
            textBox_reparaturenTransactionAmount.Text = Reparaturen.transactionAmount;
            textBox__reparaturenIMEI.Text = Reparaturen.imei;
            textBox_reparaturenExternalCosts.Text = Reparaturen.externalCosts;
            textBox_reparaturenComment.Text = Reparaturen.comment;
            textBox_reparaturenSource.Text = Reparaturen.source;
            textBox_reparaturenRiskLevel.Text = Reparaturen.riskLevel;
            textBox_reparaturenWorthIt.Text = Reparaturen.worthIt;
            textBox_reparaturenReferenceToEB.Text = Reparaturen.referenceToEB;
            comboBox_ReparaturenGetestet.Text = Reparaturen.tested;
            comboBox_ReparaturenMeldungen.Text = Reparaturen.notifications;
            comboBox_ReparaturenReparaturStatus.Text = Reparaturen.state;

        }

        private void comboBox_reparaturenColor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox__reparaturenStorage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_reparaturenMake_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_reparaturenReferenceToEB_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_reparaturenWorthIt_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_reparaturenRiskLevel_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_reparaturenSource_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_reparaturenComment_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_reparaturenExternalCosts_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox__reparaturenIMEI_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_reparaturenTransactionAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox__reparaturenDefect_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_reparaturenDevice_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_reparaturenDateBought_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_ReparaturenInternalNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
