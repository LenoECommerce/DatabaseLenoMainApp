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
using MySql.Data.MySqlClient;
using System.Collections;

namespace EigenbelegToolAlpha
{
    public partial class Eigenbelege : Form
    {
        public Eigenbelege()
        {
            InitializeComponent();
            ShowEigenbelege();
        }

        //SQL Verbindung zu 
        public static MySqlConnection conn;
        public static string connString = "SERVER=sql11.freesqldatabase.com;PORT=3306;Initial Catalog='sql11525524';username=sql11525524;password=d3ByMHVgie";

        public string path = "";
        public string destPath = "mainfile.xlsx";
        public static string pdfSaveDestPath = "";
        public static int lastSelectedProductKey;
        public static string imagesFolderPath = "";

        public static string eigenbelegNumber = "";
        public static string sellerName = "";
        public static string reference = "";
        public static string model = "";
        public static string dateBought= "";
        public static string transactionAmount= "";
        public static string mail = "";
        public static string platform = "";
        public static string paymentMethod = "";
        public static string address = "";
        public static string created = "";
        public static string arrived = "";
        public static string transactionText = "";
        public static string storage = "";
        public static string defect = "";

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


        public void ShowEigenbelege()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string query = "SELECT * FROM `Eigenbelege`";
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(query, conn);

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            ////Datensatz
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            //Daten anzeigen im Grid
            eigenbelegeDGV.DataSource = dataSet.Tables[0];

            //Column verstecken

            eigenbelegeDGV.Columns[0].Visible = false;
            conn.Close();
        }

        public static void ExecuteQuery(string query)
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public static void dataSync(string destTable,string syncModel, string syncTransactionAmount, string syncStorage, string syncEigenbelegNumber)
        {
            //Abfrage welche Tabelle geupdatet wird
            if (destTable == "Reparaturen")
            {
                string query = string.Format("UPDATE `" + destTable + "` SET `Geraet` = '{0}', `Kaufbetrag` = '{1}', `Speicher` = '{2}' WHERE `EBReferenz` = {3}",
                           syncModel, syncTransactionAmount, syncStorage, syncEigenbelegNumber);
                ExecuteQuery(query);
            }
            else
            {
                string query = string.Format("UPDATE `" + destTable + "` SET `Modell` = '{0}', `Kaufbetrag` = '{1}', `Speicher` = '{2}' WHERE `Eigenbelegnummer` = {3}",
                           syncModel, syncTransactionAmount, syncStorage, syncEigenbelegNumber);
                ExecuteQuery(query);
            }
            
        }

        private void PayPalDataImport()
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            dataImport();
        }


        private void eigenbelegeDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            eigenbelegNumber = eigenbelegeDGV.SelectedRows[0].Cells[1].Value.ToString();
            sellerName = eigenbelegeDGV.SelectedRows[0].Cells[2].Value.ToString();
            reference = eigenbelegeDGV.SelectedRows[0].Cells[3].Value.ToString();
            model = eigenbelegeDGV.SelectedRows[0].Cells[4].Value.ToString();
            dateBought = eigenbelegeDGV.SelectedRows[0].Cells[5].Value.ToString();
            transactionAmount = eigenbelegeDGV.SelectedRows[0].Cells[6].Value.ToString();
            mail = eigenbelegeDGV.SelectedRows[0].Cells[7].Value.ToString();
            platform = eigenbelegeDGV.SelectedRows[0].Cells[8].Value.ToString();
            paymentMethod = eigenbelegeDGV.SelectedRows[0].Cells[9].Value.ToString();
            address = eigenbelegeDGV.SelectedRows[0].Cells[10].Value.ToString();
            created = eigenbelegeDGV.SelectedRows[0].Cells[11].Value.ToString();
            arrived = eigenbelegeDGV.SelectedRows[0].Cells[12].Value.ToString();
            transactionText = eigenbelegeDGV.SelectedRows[0].Cells[13].Value.ToString();
            storage = eigenbelegeDGV.SelectedRows[0].Cells[14].Value.ToString();

            lastSelectedProductKey = (int)eigenbelegeDGV.SelectedRows[0].Cells[0].Value;

        }

        private void btn_eigenbelegCreate_Click(object sender, EventArgs e)
        {
            using (var form = new EigenbelegCreate())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ShowEigenbelege();
                }
            }
        }

        private void btn_eigenbelegRemove_Click(object sender, EventArgs e)
        {
            if (lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst einen Eintrag aus");
                return;
            }
            string query = string.Format("DELETE FROM `Eigenbelege` WHERE `Id` = {0} ;", lastSelectedProductKey);
            ExecuteQuery(query);
            ShowEigenbelege();
        }

        private void btn_eigenbelegEdit_Click(object sender, EventArgs e)
        {
            if (lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus");
                return;
            }
            using (var form = new EigenbelegEdit())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ShowEigenbelege();
                }
            }


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
            string query = "DELETE FROM `Eigenbelege`";
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

        private void button4_Click(object sender, EventArgs e)
        {
            PayPalDataImport();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btn_PushToRep_Click(object sender, EventArgs e)
        {
            if (eigenbelegeDGV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bitte wähle zuerst mind. einen Eintrag aus.");
                return;
            }


            ////Abfrage ob PayPal Datenimport
            //if (transactionText.Contains("Ebay Kleinanzeigen"))
            //{
            //    var posTrenn2 = transactionText.IndexOf("trenn2");
            //    var defekt = transactionText.IndexOf("defekt");
            //    defect = transactionText.Substring(posTrenn2+7,defekt-posTrenn2-7);
            //}



            int intern = Convert.ToInt32(File.ReadAllText("config3.txt"))+1;
            File.WriteAllText("config3.txt",intern.ToString());


            string query = string.Format("INSERT INTO `Reparaturen`(`Intern`,`Kaufdatum`,`Geraet`,`Kaufbetrag`,`Speicher`,`Defekt`,`Reparaturstatus`,`Quelle`,`EBReferenz`) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')"
            , intern.ToString(), dateBought, model, transactionAmount, storage, defect, "Entgegengenommen" ,platform, eigenbelegNumber);
            
            ExecuteQuery(query);
            MessageBox.Show("Die Reparatur wurde erfolgreich erfasst.");
            ShowEigenbelege();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ShowEigenbelege();
        }

        public void btn_SwitchToRelatedReparatur_Click(object sender, EventArgs e)
        {
            if (lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst einen Eintrag aus");
                return;
            }
            Reparaturen reparaturen = new Reparaturen();
            reparaturen.Show();
            this.Hide();
            reparaturen.SelectReparaturFromEigenbelege(eigenbelegNumber);
        }

        public void SelectEigenbelegeFromReparatur (string relatedNumber)
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in eigenbelegeDGV.Rows)
            {
                if (row.Cells[1].Value.Equals(relatedNumber))
                {
                    rowIndex = row.Index;
                }
            }
            eigenbelegeDGV.ClearSelection();
            eigenbelegeDGV.Rows[rowIndex].Selected = true;
        }

        private void btn_settings2_Click(object sender, EventArgs e)
        {
            Settings window = new Settings();
            window.Show();
        }
    }
}
