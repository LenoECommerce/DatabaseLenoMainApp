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




        public void SelectReparaturFromEigenbelege(string relatedNumber)
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in reparaturenDGV.Rows)
            {
                if (row.Cells[17].Value.Equals(relatedNumber))
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
            storage = reparaturenDGV.SelectedRows[0].Cells[7].Value.ToString();
            defect = reparaturenDGV.SelectedRows[0].Cells[8].Value.ToString();
            maindefects = reparaturenDGV.SelectedRows[0].Cells[9].Value.ToString();
            externalCosts = reparaturenDGV.SelectedRows[0].Cells[10].Value.ToString();
            comment = reparaturenDGV.SelectedRows[0].Cells[11].Value.ToString();
            notifications = reparaturenDGV.SelectedRows[0].Cells[12].Value.ToString();
            tested = reparaturenDGV.SelectedRows[0].Cells[13].Value.ToString();
            state = reparaturenDGV.SelectedRows[0].Cells[14].Value.ToString();
            source = reparaturenDGV.SelectedRows[0].Cells[15].Value.ToString();
            riskLevel = reparaturenDGV.SelectedRows[0].Cells[16].Value.ToString();
            worthIt = reparaturenDGV.SelectedRows[0].Cells[17].Value.ToString();
            referenceToEB = reparaturenDGV.SelectedRows[0].Cells[18].Value.ToString();


            lastSelectedProductKey = (int)reparaturenDGV.SelectedRows[0].Cells[0].Value;

        }


        private void btn_settings_Click(object sender, EventArgs e)
        {
            Eigenbelege eigenbelege = new Eigenbelege();
            eigenbelege.Show();
            this.Hide();
        }

        private void btn_reparaturenDelete_Click(object sender, EventArgs e)
        {
            if (lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst einen Eintrag aus");
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
            if (lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst einen Eintrag aus.");
                return;
            }
            ReparaturenEdit reparaturenEdit = new ReparaturenEdit();
            reparaturenEdit.Show();
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
            ReparaturCreate reparaturenCreate= new ReparaturCreate();
            reparaturenCreate.Show();
        }

        internal class GetReparaturenDGV : DataGridView
        {
        }

        private void btn_SwitchToRelatedEigenbeleg_Click(object sender, EventArgs e)
        {
            if (lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst einen Eintrag aus");
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
    }
}
