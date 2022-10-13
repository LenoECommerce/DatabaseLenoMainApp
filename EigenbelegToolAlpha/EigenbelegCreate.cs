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
    public partial class EigenbelegCreate : Form
    {
        public EigenbelegCreate()
        {
            InitializeComponent();

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string tempEigenbelegNumber = textBox_eigenbelegNumber.Text;
            string tempSellerName = textBox_eigenbelegSellerName.Text;
            string tempReference = textBox_eigenbelegReference.Text;
            string tempModel = textBox_eigenbelegModel.Text;
            string tempDateBought = textBox_eigenbelegDateBought.Text;
            string tempTransactionAmount = textBox_eigenbelegTransactionAmount.Text;
            string tempMail = textBox_eigenbelegMail.Text;
            string tempPlatform = comboBox_eigenbelegPlatform.Text;
            string tempPaymentMethod = comboBox_eigenbelegPaymentMethod.Text;
            string tempAddress = textBox_eigenbelegAdress.Text;
            string tempCreated = comboBox_eigenbelegCreated.Text;
            string tempArrived = comboBox_eigenbelegArrived.Text;
            string tempTransactionText = textBox_eigenbelegTransactionText.Text;
            string tempEigenbelegStorage = comboBox_eigenbelegStorage.Text;



            string query = string.Format("INSERT INTO `Eigenbelege`(`Eigenbelegnummer`,`Verkaeufername`,`Referenz`,`Modell`,`Kaufdatum`,`Kaufbetrag`,`E-Mail`,`Plattform`,`Zahlungsmethode`,`Adresse`,`Erstellt?`,`Angekommen?`,`Transaktionstext`,`Speicher`) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')"
           , tempEigenbelegNumber,tempSellerName,tempReference,tempModel,tempDateBought,tempTransactionAmount,tempMail,tempPlatform,tempPaymentMethod,tempAddress,tempCreated,tempArrived,tempTransactionText, tempEigenbelegStorage);
            
            Eigenbelege.ExecuteQuery(query);
            MessageBox.Show("Dein Eintrag wurde erfolgreich erstellt.");
            Eigenbelege window = new Eigenbelege();
            window.ShowEigenbelege();
            this.Close();
        }

        private void EigenbelegCreate_Load(object sender, EventArgs e)
        {
            textBox_eigenbelegNumber.Text = File.ReadAllText("config4.txt");
            comboBox_eigenbelegArrived.Text = "Ja";
            comboBox_eigenbelegCreated.Text = "Nein";
        }
    

        private void comboBox_eigenbelegPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_eigenbelegPlatform.Text.Equals("BackMarket"))
            {
                EigenbelegBuyBackPriceCalculation window = new EigenbelegBuyBackPriceCalculation();
                window.Show();
                this.Hide();
            }
        }

        private void textBox_eigenbelegTransactionAmount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
