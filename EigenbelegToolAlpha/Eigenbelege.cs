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
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using _Excel = Microsoft.Office.Interop.Excel;

namespace EigenbelegToolAlpha
{
    public partial class Eigenbelege : Form
    {
        public Eigenbelege()
        {
            InitializeComponent();
            ShowEigenbelege();
        }

        //SQL Verbindung zu Datenbank
        private SqlConnection databaseConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\lenna\Documents\Eigenbelege.mdf;Integrated Security = True; Connect Timeout = 30");
        public string path = "";
        public string destPath = "mainfile.xlsx";
        public static string pdfSaveDestPath = "";
        public int lastSelectedProductKey;
        public static string imagesFolderPath = "";

        private void Hauptmenü_Load(object sender, EventArgs e)
        {

        }

        private void dataImport()
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;
            Microsoft.Office.Interop.Excel.Range xlRange;

            int xlrow;
            string strFileName;
            //Excel Datei aussuchen
            

            openFD.Filter = "Excel Office |*.xls; *xlsx";
            openFD.ShowDialog();
            strFileName = openFD.FileName;

            if (destPath != "")
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(strFileName);
                xlWorksheet = xlWorkbook.Worksheets["Tabelle1"];
                xlRange = xlWorksheet.UsedRange;

                //row 2 weil erst da die daten anfangen
                for (xlrow = 2; xlrow <= xlRange.Rows.Count; xlrow++)
                {
                    // Hier je nachdem wie viele Spalten benutzt werden
                    string zwischenwertTest = xlRange.Cells[xlrow, 1].Text;
                    string query = string.Format("insert into Eigenbelege values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", 
                        xlRange.Cells[xlrow, 1].Text, xlRange.Cells[xlrow, 2].Text, xlRange.Cells[xlrow, 3].Text, xlRange.Cells[xlrow,4].Text,
                        xlRange.Cells[xlrow, 5].Text, xlRange.Cells[xlrow, 6].Text, xlRange.Cells[xlrow, 7].Text, xlRange.Cells[xlrow, 8].Text);

                    ExecuteQuery(query);

                }
                xlWorkbook.Close();
                xlApp.Quit();

            }
            ShowEigenbelege();

        }


        private void ShowEigenbelege()
        {
            databaseConnection.Open();

            string query = "select * from Eigenbelege";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, databaseConnection);

            //Datensatz
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            //Daten anzeigen im Grid
            eigenbelegeDGV.DataSource = dataSet.Tables[0];

            //Column verstecken

            eigenbelegeDGV.Columns[0].Visible = false;


            databaseConnection.Close();
        }

        private void ExecuteQuery(string query)
        {
            databaseConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, databaseConnection);
            sqlCommand.ExecuteNonQuery();
            databaseConnection.Close();
        }

        private void ClearAllFields()
        {
            textBox_eigenbelegArticle.Text = "";
            textBox_eigenbelegDateBought.Text = "";
            textBox_eigenbelegNumber.Text = "";
            textBox_eigenbelegPaymentMethod.Text = "";
            textBox_eigenbelegPlatform.Text = "";
            textBox_eigenbelegSellerAdress.Text = "";
            textBox_eigenbelegSellerName.Text = "";
            textBox_eigenbelegTransactionAmount.Text = "";
        }





        private void button1_Click(object sender, EventArgs e)
        {
            dataImport();
        }




        private void button2_Click(object sender, EventArgs e)
        {
            dataImport();
        }

        


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void eigenbelegeDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox_eigenbelegNumber.Text = eigenbelegeDGV.SelectedRows[0].Cells[1].Value.ToString();
            textBox_eigenbelegSellerName.Text = eigenbelegeDGV.SelectedRows[0].Cells[2].Value.ToString();
            textBox_eigenbelegDateBought.Text = eigenbelegeDGV.SelectedRows[0].Cells[3].Value.ToString();
            textBox_eigenbelegTransactionAmount.Text = eigenbelegeDGV.SelectedRows[0].Cells[4].Value.ToString();
            textBox_eigenbelegArticle.Text = eigenbelegeDGV.SelectedRows[0].Cells[5].Value.ToString();
            textBox_eigenbelegPlatform.Text = eigenbelegeDGV.SelectedRows[0].Cells[6].Value.ToString();
            textBox_eigenbelegPaymentMethod.Text = eigenbelegeDGV.SelectedRows[0].Cells[7].Value.ToString();
            textBox_eigenbelegSellerAdress.Text = eigenbelegeDGV.SelectedRows[0].Cells[8].Value.ToString();

            lastSelectedProductKey = (int)eigenbelegeDGV.SelectedRows[0].Cells[0].Value;

        }

        private void btn_ClearFields_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void btn_eigenbelegCreate_Click(object sender, EventArgs e)
        {
            if (textBox_eigenbelegArticle.Text == ""
                || textBox_eigenbelegDateBought.Text == ""
                || textBox_eigenbelegNumber.Text == ""
                || textBox_eigenbelegPaymentMethod.Text == ""
                || textBox_eigenbelegPlatform.Text == ""
                || textBox_eigenbelegSellerAdress.Text == ""
                || textBox_eigenbelegSellerName.Text == ""
                || textBox_eigenbelegTransactionAmount.Text == "")
            {
                MessageBox.Show("Bitte alle Felder ausfüllen.");
                return;
            }

            //alte Variablen
            //int eigenbelegNumber = int.Parse(textBox_eigenbelegNumber.Text);
            //float transactionAmount = float.Parse(textBox_eigenbelegTransactionAmount.Text);


            string eigenbelegNumber = textBox_eigenbelegNumber.Text;
            string sellerName = textBox_eigenbelegSellerName.Text;
            string dateBought = textBox_eigenbelegDateBought.Text;
            string transactionAmount = textBox_eigenbelegTransactionAmount.Text;
            string article = textBox_eigenbelegArticle.Text;
            string platform = textBox_eigenbelegPlatform.Text;
            string paymentMethod = textBox_eigenbelegPaymentMethod.Text;
            string sellerAddress = textBox_eigenbelegSellerAdress.Text;

            string query = string.Format("insert into Eigenbelege values('{0}','{1}','{2}',{3},'{4}','{5}','{6}','{7}')",eigenbelegNumber, sellerName, dateBought, transactionAmount, article, platform, paymentMethod, sellerAddress);

            ExecuteQuery(query);
            ClearAllFields();
            ShowEigenbelege();



        }

        private void btn_eigenbelegRemove_Click(object sender, EventArgs e)
        {
            if (lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst einen Eintrag aus");
                return;
            }
            string query = string.Format("delete from eigenbelege where Id={0};", lastSelectedProductKey);
            ExecuteQuery(query);

            ClearAllFields();
            ShowEigenbelege();
        }

        private void btn_eigenbelegEdit_Click(object sender, EventArgs e)
        {
            if (lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus");
                return;
            }

            string eigenbelegNumber = textBox_eigenbelegNumber.Text;
            string sellerName = textBox_eigenbelegSellerName.Text;
            string dateBought = textBox_eigenbelegDateBought.Text;
            string transactionAmount = textBox_eigenbelegTransactionAmount.Text;
            string article = textBox_eigenbelegArticle.Text;
            string platform = textBox_eigenbelegPlatform.Text;
            string paymentMethod = textBox_eigenbelegPaymentMethod.Text;
            string sellerAddress = textBox_eigenbelegSellerAdress.Text;

            string query = string.Format("update eigenbelege set Eigenbelegnummer = '{0}',Verkäufername = '{1}',Kaufdatum = '{2}',Kaufbetrag = '{3}',Artikel = '{4}',Plattform = '{5}',Zahlungsmethode = '{6}',Adresse = '{7}' where Id={8}"
                , eigenbelegNumber, sellerName, dateBought, transactionAmount, article, platform, paymentMethod, sellerAddress, lastSelectedProductKey);

            ExecuteQuery(query);
            ShowEigenbelege();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (eigenbelegeDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bitte wähle zuerst mind. einen Eintrag aus.");
                return;
            }

            if (File.ReadAllText("config.txt") == "")
            {
                MessageBox.Show("Du hast noch keinen Speicherpfad angegeben.");
                return;
            }


            for (int i = 0; i < eigenbelegeDGV.SelectedRows.Count; i++)
            {
                string eigenbelegNumber = eigenbelegeDGV.SelectedRows[i].Cells[1].Value.ToString();
                string sellerName = eigenbelegeDGV.SelectedRows[i].Cells[2].Value.ToString();
                string dateBought = eigenbelegeDGV.SelectedRows[i].Cells[3].Value.ToString();
                string transactionAmount = eigenbelegeDGV.SelectedRows[i].Cells[4].Value.ToString();
                string article = eigenbelegeDGV.SelectedRows[i].Cells[5].Value.ToString();
                string platform = eigenbelegeDGV.SelectedRows[i].Cells[6].Value.ToString();
                string paymentMethod = eigenbelegeDGV.SelectedRows[i].Cells[7].Value.ToString();
                string sellerAddress = eigenbelegeDGV.SelectedRows[i].Cells[8].Value.ToString();
                if (platform == "/")
                {
                    pdfDocumentStorno.CreateDocument(eigenbelegNumber, sellerName, dateBought, transactionAmount, article, platform, paymentMethod, sellerAddress);
                }
                else
                {
                    pdfDocument.CreateDocument(eigenbelegNumber, sellerName, dateBought, transactionAmount, article, platform, paymentMethod, sellerAddress);
                } 
            }
            MessageBox.Show("PDF-Dokumente wurden erfolgreich erstellt.");
        }

        private void eigenbelegeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            pdfSaveDestPath = folderBrowserDialog1.SelectedPath;
            File.WriteAllText("config.txt", pdfSaveDestPath);
        }

        private void btn_SelectAllRows_Click(object sender, EventArgs e)
        {
            if (eigenbelegeDGV.AreAllCellsSelected(true) == true)
            {
                eigenbelegeDGV.ClearSelection();
                return;
            }
            eigenbelegeDGV.SelectAll();
        }

        private void btn_DeleteAll_Click(object sender, EventArgs e)
        {
            string query = "delete from eigenbelege";
            ExecuteQuery(query);
            ShowEigenbelege();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (eigenbelegeDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bitte wähle zuerst mind. einen Eintrag aus.");
                return;
            }

            if (File.ReadAllText("config.txt") == "")
            {
                MessageBox.Show("Du hast noch keinen Speicherpfad angegeben.");
                return;
            }



            for (int i = 0; i < eigenbelegeDGV.SelectedRows.Count; i++)
            {
                string eigenbelegNumber = eigenbelegeDGV.SelectedRows[i].Cells[1].Value.ToString();
                string sellerName = eigenbelegeDGV.SelectedRows[i].Cells[2].Value.ToString();
                string dateBought = eigenbelegeDGV.SelectedRows[i].Cells[3].Value.ToString();
                string transactionAmount = eigenbelegeDGV.SelectedRows[i].Cells[4].Value.ToString();
                string article = eigenbelegeDGV.SelectedRows[i].Cells[5].Value.ToString();
                string platform = eigenbelegeDGV.SelectedRows[i].Cells[6].Value.ToString();
                string paymentMethod = eigenbelegeDGV.SelectedRows[i].Cells[7].Value.ToString();
                string sellerAddress = eigenbelegeDGV.SelectedRows[i].Cells[8].Value.ToString();
                pdfDocumentStorno.CreateDocument(eigenbelegNumber, sellerName, dateBought, transactionAmount, article, platform, paymentMethod, sellerAddress);
            }

            MessageBox.Show("Dein Storno-Eigenbeleg wurde erfolgreich erstellt.");
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            imagesFolderPath = folderBrowserDialog1.SelectedPath;
            File.WriteAllText("config2.txt", imagesFolderPath);
        }

    
        private void btn_ImageLocPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            imagesFolderPath = folderBrowserDialog1.SelectedPath;
            File.WriteAllText("config2.txt", imagesFolderPath);
        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            Reparaturen reparaturen = new Reparaturen();
            reparaturen.Show();
            this.Hide();
        }
    }
}
