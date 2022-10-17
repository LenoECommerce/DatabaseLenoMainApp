using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PdfSharp.Internal;
using Microsoft.Office.Interop.Excel;
using MySqlX.XDevAPI.Relational;
using MySqlX.XDevAPI.Common;

namespace EigenbelegToolAlpha
{
    public partial class Reparaturen : Form
    {
        //SQL Verbindung zu Datenbank
        public static MySqlConnection conn;
        public static string connString = "SERVER=sql11.freesqldatabase.com;PORT=3306;Initial Catalog='sql11525524';username=sql11525524;password=d3ByMHVgie";
        public static int lastSelectedProductKey;
        public static string internalNumber = "";
        public static string dateBought = "";
        public static string device = "";
        public static string make = "";
        public static string storage = "";
        public static string defect = "";
        public static string transactionAmount = "";
        public static string imei = "";
        public static string externalCosts = "";
        public static string comment = "";
        public static string source = "";
        public static string riskLevel = "";
        public static string worthIt = "";
        public static string referenceToEB = "";
        public static string notifications = "";
        public static string tested = "";
        public static string state = "";
        public static string maindefects = "";
        public static string color = "";
        public static string taxes = "";
        public static string condition = "";




        public Reparaturen()
        {
            InitializeComponent();
            ShowReparaturen();
        }

        public void ShowReparaturen()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string query = "SELECT * FROM `Reparaturen`";
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(query, conn);

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            ////Datensatz
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            //Daten anzeigen im Grid
            reparaturenDGV.DataSource = dataSet.Tables[0];
            //Column verstecken
            reparaturenDGV.Columns[0].Visible = false;
            //Sortierte Ansicht
            reparaturenDGV.Sort(reparaturenDGV.Columns[1], ListSortDirection.Descending);
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

        public static double ExecuteQueryWithResult(string query)
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //zwischenspeichern und danach umformen um Fehlerquelle zu vermeiden
                var firstValueGetBack = cmd.ExecuteScalar();
                double result = Convert.ToDouble(firstValueGetBack);
                conn.Close();
                return result;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static string ExecuteQueryWithResultForManualDataImport(string query)
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //zwischenspeichern und danach umformen um Fehlerquelle zu vermeiden
                var firstValueGetBack = cmd.ExecuteScalar();
                var result = firstValueGetBack;
                conn.Close();
                if(result != null)
                {
                    return result.ToString();
                }
                return "";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }




        public void SelectReparaturFromEigenbelege(string relatedNumber)
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in reparaturenDGV.Rows)
            {
                if (row.Cells[21].Value.Equals(relatedNumber))
                {
                    rowIndex = row.Index;
                }   
            }
            if (rowIndex != -1)
            {
                reparaturenDGV.ClearSelection();
                reparaturenDGV.Rows[rowIndex].Selected = true;
            }
            else
            {
                MessageBox.Show("Es konnte kein Eintrag gefunden werden.");
            }

        }


        private void reparaturenDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            internalNumber = reparaturenDGV.SelectedRows[0].Cells[1].Value.ToString();
            dateBought = reparaturenDGV.SelectedRows[0].Cells[2].Value.ToString();
            device = reparaturenDGV.SelectedRows[0].Cells[3].Value.ToString();
            transactionAmount = reparaturenDGV.SelectedRows[0].Cells[4].Value.ToString();
            imei = reparaturenDGV.SelectedRows[0].Cells[5].Value.ToString();
            make = reparaturenDGV.SelectedRows[0].Cells[6].Value.ToString();
            color = reparaturenDGV.SelectedRows[0].Cells[7].Value.ToString();
            storage = reparaturenDGV.SelectedRows[0].Cells[8].Value.ToString();
            taxes = reparaturenDGV.SelectedRows[0].Cells[9].Value.ToString();
            condition = reparaturenDGV.SelectedRows[0].Cells[10].Value.ToString();
            defect = reparaturenDGV.SelectedRows[0].Cells[11].Value.ToString();
            maindefects = reparaturenDGV.SelectedRows[0].Cells[12].Value.ToString();
            externalCosts = reparaturenDGV.SelectedRows[0].Cells[13].Value.ToString();
            comment = reparaturenDGV.SelectedRows[0].Cells[14].Value.ToString();
            notifications = reparaturenDGV.SelectedRows[0].Cells[15].Value.ToString();
            tested = reparaturenDGV.SelectedRows[0].Cells[16].Value.ToString();
            state = reparaturenDGV.SelectedRows[0].Cells[17].Value.ToString();
            source = reparaturenDGV.SelectedRows[0].Cells[18].Value.ToString();
            riskLevel = reparaturenDGV.SelectedRows[0].Cells[19].Value.ToString();
            worthIt = reparaturenDGV.SelectedRows[0].Cells[20].Value.ToString();
            referenceToEB = reparaturenDGV.SelectedRows[0].Cells[21].Value.ToString();


            lastSelectedProductKey = (int)reparaturenDGV.SelectedRows[0].Cells[0].Value;

        }

        private bool checkIfSelected()
        {
            if (lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst einen Eintrag aus");
                return false;
            }
            else
            {
                return true;
            }
        }



        private void btn_settings_Click(object sender, EventArgs e)
        {
            Eigenbelege eigenbelege = new Eigenbelege();
            eigenbelege.Show();
            this.Hide();
        }

        private void btn_reparaturenDelete_Click(object sender, EventArgs e)
        {
            if (checkIfSelected() == false)
            {
                return;
            }
            string query = string.Format("DELETE FROM `Reparaturen` WHERE `Id` = {0} ;", lastSelectedProductKey);
            ExecuteQuery(query);

            ShowReparaturen();
        }

        

        private void btn_SelectAllRows_Click(object sender, EventArgs e)
        {
            if (reparaturenDGV.AreAllCellsSelected(true) == true)
            {
                reparaturenDGV.ClearSelection();
                return;
            }
            reparaturenDGV.SelectAll();
        }

        private void btn_DeleteAll_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM `Reparaturen`";
            ExecuteQuery(query);
            ShowReparaturen();
        }

        private void btn_reparaturenEdit_Click(object sender, EventArgs e)
        {
            if (checkIfSelected() == false)
            {
                return;
            }
            using (var form = new ReparaturenEdit())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ShowReparaturen();
                }
            }
        }

        private void Reparaturen_Load(object sender, EventArgs e)
        {
            ShowReparaturen();
        }

        private void reparaturenDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowReparaturen();
        }

        private void btn_reparaturenCreate_Click(object sender, EventArgs e)
        {
            using (var form = new ReparaturCreate())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ShowReparaturen();
                }
            }
        }

        internal class GetReparaturenDGV : DataGridView
        {
        }

        private void btn_SwitchToRelatedEigenbeleg_Click(object sender, EventArgs e)
        {
            if (checkIfSelected() == false)
            {
                return;
            }
            Eigenbelege eigenbelege = new Eigenbelege();
            eigenbelege.Show();
            this.Hide();
            eigenbelege.SelectEigenbelegeFromReparatur(referenceToEB);
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            Settings window = new Settings();
            window.Show();
        }

        public void BrotherPrintThisModell(int quantityOfCopies)
        {
            if (checkIfSelected() == false)
            {
                return;
            }
            try
            {
                string internPrefix = "";
                string zero = "0";
                string barcodeSKU = "APL/10.1/B64C/DIFF";
                string path = "";
                try
                {
                    path = File.ReadAllText("modell.txt");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bitte setze in den Einstellungen dein Template fest; Fehlermeldung:"+ex.Message);
                }
                
                //Abfrage wie lang interne Nummer, dann prefix anpassen!
                int lengthIntern = internalNumber.Length;
                int freeDigits = 5 - lengthIntern;
                for (int i = 0; i < freeDigits; i++)
                {
                    internPrefix = internPrefix + "0";
                }

                //SKU Generator in andere Klasse auslagern!
                SKUGeneration newObject = new SKUGeneration();
                barcodeSKU = newObject.SKUGenerationMethod(device, color, condition, taxes, storage);

                string barcodeIMEICombo = internPrefix + internalNumber + "/" + imei;
                

                bpac.Document doc = new bpac.Document();
                doc.Open(path);
                bool test = doc.SetPrinter("Brother QL-600", true);

                var temp = doc.GetBarcodeIndex("SKU");
                var temp2 = doc.GetBarcodeIndex("IMEICombo");
                doc.SetBarcodeData(temp, barcodeSKU);
                doc.SetBarcodeData(temp2, barcodeIMEICombo);

                doc.StartPrint("", bpac.PrintOptionConstants.bpoDefault);
                doc.PrintOut(1, bpac.PrintOptionConstants.bpoDefault);
                doc.EndPrint();
                doc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print Error: " + ex.Message);
            }
        }

        private void platinenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hauptetikettToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrotherPrintThisModell(1);
        }

        private void btn_WorkWithSpecificReparatur_Click(object sender, EventArgs e)
        {
            using (var form = new WorkWithSpecificRep())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    int rowIndex = -1;
                    foreach (DataGridViewRow row in reparaturenDGV.Rows)
                    {
                        if (row.Cells[5].Value.Equals(form.matchingValue))
                        {
                            rowIndex = row.Index;
                        }
                    }
                    if (rowIndex != -1)
                    {
                        reparaturenDGV.ClearSelection();
                        reparaturenDGV.Rows[rowIndex].Selected = true;
                    }
                    else
                    {
                        MessageBox.Show("Es konnte kein Eintrag gefunden werden.");
                    }
                }
            }
        }

        private void etikettenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;
            Microsoft.Office.Interop.Excel.Range xlRange;

            int xlrow ;
            string strFileName;
            //Excel Datei aussuchen
            openFD.ShowDialog();
            strFileName = openFD.FileName;

            
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(strFileName);
                xlWorksheet = xlWorkbook.Worksheets["Tabelle1"];
                xlRange = xlWorksheet.UsedRange;

            //row 2 weil erst da die daten anfange
            for (xlrow = 2; xlrow <= xlRange.Rows.Count; xlrow++)
            {

                string tempIntern = xlRange.Cells[xlrow, 1].Text;
                string tempDate = xlRange.Cells[xlrow, 2].Text;
                string tempDevice = xlRange.Cells[xlrow, 3].Text;
                string tempDefect = xlRange.Cells[xlrow, 4].Text;
                string tempAmount = xlRange.Cells[xlrow, 5].Text;
                string tempExternalCosts = xlRange.Cells[xlrow, 6].Text;
                string tempReference = xlRange.Cells[xlrow, 7].Text;
                string tempIMEI = xlRange.Cells[xlrow, 8].Text;
                string tempSource = xlRange.Cells[xlrow, 9].Text;


                //in Datenbank einfügen 1 Mal

                string query = string.Format("INSERT INTO `Reparaturen` (`Intern`, `Kaufdatum`,`Geraet`,`Kaufbetrag`,`IMEI`,`Defekt`,`ExterneKosten`,`EBReferenz`) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')"
                                , tempIntern, tempDate, tempDevice, tempAmount, tempIMEI, tempDefect, tempExternalCosts, tempReference);
                ExecuteQuery(query);
                ShowReparaturen();
                //Suchen Datum
                foreach (DataGridViewRow row in reparaturenDGV.Rows)
                {
                    if (row.Cells[21].Value.Equals(tempReference))
                    {
                        string query2 = "SELECT `Kaufdatum` FROM `Eigenbelege` WHERE `Eigenbelegnummer`= '" + tempReference + "'";
                        var result = ExecuteQueryWithResultForManualDataImport(query2).ToString();
                        if (result != "0" & result != null & result != "")
                        {
                            tempDate = result;
                        }
                    }
                }
                //IMEI Übernahme
                if (tempIMEI.Contains("-"))
                {
                    var length = tempIMEI.Length;
                    tempIMEI = tempIMEI.Substring(6, length - 6);
                }

                //Quelle
                if (tempSource == "1")
                {
                    tempSource = "B2B";
                }
                else
                {
                    foreach (DataGridViewRow row in reparaturenDGV.Rows)
                    {
                        if (row.Cells[21].Value.Equals(tempReference))
                        {
                            string query2 = "SELECT `Plattform` FROM `Eigenbelege` WHERE `Eigenbelegnummer`= '" + tempReference + "'";
                            var result = ExecuteQueryWithResultForManualDataImport(query2);
                            if (result != "0" & result != null & result != "")
                            {
                                tempSource = result;
                            }
                            string query3 = "SELECT `Plattform` FROM `Eigenbelege` WHERE `Eigenbelegnummer`= '" + tempReference + "'";
                            var result2 = ExecuteQueryWithResultForManualDataImport(query3);
                            if (result2 != "0" & result2 != null & result2 != "")
                            {
                                tempSource = result2;
                            }
                        }
                    }
                }
                //2. Datenanpassung!
                ShowReparaturen();
                string querySecond = string.Format("UPDATE `Reparaturen` SET `Kaufdatum` = '{0}',`IMEI` = '{1}',`Quelle` = '{2}' WHERE `Intern` = {3}"
                                , tempDate, tempIMEI, tempSource, tempIntern);
                ExecuteQuery(querySecond);
            }
                xlWorkbook.Close();
                xlApp.Quit();
                ShowReparaturen();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "";
            ExecuteQuery(query);
        }

        private void eigenbelegeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eigenbelege eigenbelege = new Eigenbelege();
            eigenbelege.Show();
            this.Hide();
        }

        private void protokollierungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Protokollierung window = new Protokollierung();
            window.Show();
            this.Hide();
        }
    }
}
