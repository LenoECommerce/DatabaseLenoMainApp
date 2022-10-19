using MySql.Data.MySqlClient;
using SautinSoft.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace EigenbelegToolAlpha
{
    public partial class Protokollierung : Form
    {
        public static MySqlConnection conn;
        public static string connString = "SERVER=sql11.freesqldatabase.com;PORT=3306;Initial Catalog='sql11525524';username=sql11525524;password=d3ByMHVgie";
        public string orderID = "";
        public string imei = "";
        public string internalNumber = "";
        public string marketplace = "";
        public string month = "";
        public string scanDate = "";
        public int lastSelectedEntry;
        public Protokollierung()
        {
            InitializeComponent();
            ShowProtokollierung();
        }

        public void ShowProtokollierung()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string query = "SELECT * FROM `Protokollierung`";
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(query, conn);

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            ////Datensatz
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            //Daten anzeigen im Grid
            protokollierungDGV.DataSource = dataSet.Tables[0];

            protokollierungDGV.Columns[0].Visible = false;

            //Sortierte Ansicht
            protokollierungDGV.Sort(protokollierungDGV.Columns[0], ListSortDirection.Descending);
            conn.Close();
        }

        private void protokollierungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eigenbelege window = new Eigenbelege();
            window.Show();
            this.Hide();

        }

        private void eigenbelegeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reparaturen window = new Reparaturen();
            window.Show();
            this.Hide();
        }

        private void btn_reparaturenCreate_Click(object sender, EventArgs e)
        {
            if (textBox_IMEI.Text == "" || 
                textBox_InternalNumber.Text == "" ||
                textBox_OrderID.Text == "" ||
                comboBox_Marketplace.Text == "")
            {
                MessageBox.Show("Bitte füll alle Felder aus.");
                return;
            }
            orderID = textBox_OrderID.Text;
            imei = textBox_IMEI.Text;
            internalNumber = textBox_InternalNumber.Text;
            marketplace = comboBox_Marketplace.Text;
            month = comboBox_Months.Text;
            scanDate = textBox_ScanDate.Text;


            string query = string.Format("INSERT INTO `Protokollierung`(`Bestellnummer`,`IMEI`,`Intern`,`Marktplatz`,`Monat`,`Scandatum`) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')"
           , orderID,imei,internalNumber,marketplace,month,scanDate);  
            CRUDQueries.ExecuteQuery(query);
            MessageBox.Show("Der Eintrag wurde erfolgreich erstellt.");
            ShowProtokollierung();
        }

        private void textBox_OrderID_TextChanged(object sender, EventArgs e)
        {
            //Abfrage welche Plattform
            if (textBox_OrderID.Text.Contains("-"))
            {
                comboBox_Marketplace.Text = "Ebay";
            }
            else
            {
                comboBox_Marketplace.Text = "BackMarket";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new ProtokollierungScan())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var giveBackValue = form.scanInput;
                    var length = giveBackValue.ToString().Length;
                    textBox_IMEI.Text = giveBackValue.ToString().Substring(6,length-6);
                    textBox_InternalNumber.Text = giveBackValue.ToString().Substring(0, 5);

                    string orderIDValue = form.orderIDInput;
                    if (orderIDValue != "")
                    {
                        string first = orderIDValue.Substring(0, 2);
                        string second = orderIDValue.Substring(3, 5);
                        string third = orderIDValue.Substring(9, 5);
                        textBox_OrderID.Text = first + "-" + second + "-" + third;
                    }

                }
            }
        }

        private void protokollierungDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_OrderID.Text = protokollierungDGV.SelectedRows[0].Cells[1].Value.ToString();
            textBox_IMEI.Text = protokollierungDGV.SelectedRows[0].Cells[2].Value.ToString();
            textBox_InternalNumber.Text = protokollierungDGV.SelectedRows[0].Cells[3].Value.ToString();
            comboBox_Marketplace.Text = protokollierungDGV.SelectedRows[0].Cells[4].Value.ToString();
            comboBox_Months.Text = protokollierungDGV.SelectedRows[0].Cells[5].Value.ToString();
            textBox_ScanDate.Text = protokollierungDGV.SelectedRows[0].Cells[6].Value.ToString();

            lastSelectedEntry = (int)protokollierungDGV.SelectedRows[0].Cells[0].Value;
        }

        private void btn_protokollierungDelete_Click(object sender, EventArgs e)
        {
            if (lastSelectedEntry == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus");
                return;
            }
            CRUDQueries window = new CRUDQueries();
            window.deleteEntry(lastSelectedEntry,"Protokollierung");
            ShowProtokollierung();
        }

        private void Protokollierung_Load(object sender, EventArgs e)
        {
            textBox_ScanDate.Text = DateTime.Now.ToString().Substring(0,10);
        }

        private void btn_protokollierungEdit_Click(object sender, EventArgs e)
        {
            if (lastSelectedEntry == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus");
                return;
            }
            orderID = textBox_OrderID.Text;
            imei = textBox_IMEI.Text;
            internalNumber = textBox_InternalNumber.Text;
            marketplace = comboBox_Marketplace.Text;
            month = comboBox_Months.Text;
            scanDate = textBox_ScanDate.Text;

            try
            {
                string query = string.Format("UPDATE `Protokollierung` SET `Bestellnummer` = '{0}',`IMEI` = '{1}', `Intern` = '{2}', `Marktplatz` = '{3}', `Monat` = '{4}', `Scandatum` = '{5}' WHERE `Id` = {6}"
                ,orderID, imei, internalNumber, marketplace, month, scanDate, lastSelectedEntry);
                MessageBox.Show("Deine Änderungen wurden erfolgreich gespeichert.");
                CRUDQueries.ExecuteQuery(query);
                ShowProtokollierung();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;
            Microsoft.Office.Interop.Excel.Range xlRange;

            int xlrow = 2;
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

                string orderID = xlRange.Cells[xlrow, 1].Text;
                string imei = xlRange.Cells[xlrow,2].Text;
                string internalNumber = xlRange.Cells[xlrow, 3].Text;
                string marketplace = xlRange.Cells[xlrow, 4].Text;
                string month = xlRange.Cells[xlrow, 5].Text;

                //in Datenbank einfügen

                string query = string.Format("INSERT INTO `Protokollierung` (`Bestellnummer`, `IMEI`,`Intern`,`Marktplatz`,`Monat`) VALUES ('{0}','{1}','{2}','{3}','{4}')"
                            , orderID, imei, internalNumber, marketplace, month);
                    CRUDQueries.ExecuteQuery(query);

                }

                xlWorkbook.Close();
                xlApp.Quit();
            
            ShowProtokollierung();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM `Protokollierung`";
            CRUDQueries.ExecuteQuery(query);
            ShowProtokollierung();
        }

        private void btn_Evaluation_Click(object sender, EventArgs e)
        {
            EvaluationsFirstPage window = new EvaluationsFirstPage();
            window.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CRUDQueries window = new CRUDQueries();
            window.Backup();
        }
    }
}
