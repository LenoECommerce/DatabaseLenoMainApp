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
            string color = comboBox_reparaturenColor.Text;
            string defect = textBox__reparaturenDefect.Text;
            string transactionAmount = textBox_reparaturenTransactionAmount.Text;
            string imei = textBox__reparaturenIMEI.Text;
            string externalCosts = textBox_reparaturenExternalCosts.Text;
            string comment = textBox_reparaturenComment.Text;
            string source = textBox_reparaturenSource.Text;
            string riskLevel = textBox_reparaturenRiskLevel.Text;
            string worthIt = textBox_reparaturenWorthIt.Text;
            string referenceToEB = textBox_reparaturenReferenceToEB.Text;

            string query = string.Format("update Reparaturen set Intern = '{0}', Kaufdatum = '{1}', Gerät = '{2}', Marke = '{3}', Speicher = '{4}', Farbe = '{5}', Defekt = '{6}', Kaufbetrag = '{7}', IMEI = '{8}', ExterneKosten = '{9}', Kommentar = '{10}', Quelle = '{11}', Risikostufe = '{12}', Lohntsich = '{13}', EBReferenz = '{14}' where Id={15}"
                ,internalNumber, dateBought, device, make, storage, color, defect, transactionAmount, imei, externalCosts, comment, source, riskLevel, worthIt, referenceToEB, Reparaturen.lastSelectedProductKey);

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
            comboBox_reparaturenColor.Text = Reparaturen.color;
            textBox__reparaturenDefect.Text = Reparaturen.defect;
            textBox_reparaturenTransactionAmount.Text = Reparaturen.transactionAmount;
            textBox__reparaturenIMEI.Text = Reparaturen.imei;
            textBox_reparaturenExternalCosts.Text = Reparaturen.externalCosts;
            textBox_reparaturenComment.Text = Reparaturen.comment;
            textBox_reparaturenSource.Text = Reparaturen.source;
            textBox_reparaturenRiskLevel.Text = Reparaturen.riskLevel;
            textBox_reparaturenWorthIt.Text = Reparaturen.worthIt;
            textBox_reparaturenReferenceToEB.Text = Reparaturen.referenceToEB;
        }
    }
}
