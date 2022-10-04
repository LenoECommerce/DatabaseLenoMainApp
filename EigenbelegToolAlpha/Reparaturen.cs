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
        public static SqlConnection databaseConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\lenna\Documents\Eigenbelege.mdf;Integrated Security = True; Connect Timeout = 30");
        public static int lastSelectedProductKey;
        public static string internalNumber = "";
        public static string dateBought = "";
        public static string device = "";
        public static string make = "";
        public static string storage = "";
        public static string color = "";
        public static string defect = "";
        public static string transactionAmount = "";
        public static string imei = "";
        public static string externalCosts = "";
        public static string comment = "";
        public static string source = "";
        public static string riskLevel = "";
        public static string worthIt = "";
        public static string referenceToEB = "";
        public Reparaturen()
        {
            InitializeComponent();
            ShowReparaturen();
        }

        private void ShowReparaturen()
        {
            databaseConnection.Open();

            string query = "select * from Reparaturen";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, databaseConnection);

            //Datensatz
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            //Daten anzeigen im Grid
            reparaturenDGV.DataSource = dataSet.Tables[0];

            //Column verstecken

            reparaturenDGV.Columns[0].Visible = false;


            databaseConnection.Close();
        }

        public static void ExecuteQuery(string query)
        {
            databaseConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, databaseConnection);
            sqlCommand.ExecuteNonQuery();
            databaseConnection.Close();
        }




        private void reparaturenDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            internalNumber = reparaturenDGV.SelectedRows[0].Cells[1].Value.ToString();
            dateBought = reparaturenDGV.SelectedRows[0].Cells[2].Value.ToString();
            device = reparaturenDGV.SelectedRows[0].Cells[3].Value.ToString();
            make = reparaturenDGV.SelectedRows[0].Cells[4].Value.ToString();
            storage = reparaturenDGV.SelectedRows[0].Cells[5].Value.ToString();
            color = reparaturenDGV.SelectedRows[0].Cells[6].Value.ToString();
            defect = reparaturenDGV.SelectedRows[0].Cells[7].Value.ToString();
            transactionAmount = reparaturenDGV.SelectedRows[0].Cells[8].Value.ToString();
            imei = reparaturenDGV.SelectedRows[0].Cells[9].Value.ToString();
            externalCosts = reparaturenDGV.SelectedRows[0].Cells[10].Value.ToString();
            comment = reparaturenDGV.SelectedRows[0].Cells[11].Value.ToString();
            source = reparaturenDGV.SelectedRows[0].Cells[12].Value.ToString();
            riskLevel = reparaturenDGV.SelectedRows[0].Cells[13].Value.ToString();
            worthIt = reparaturenDGV.SelectedRows[0].Cells[14].Value.ToString();
            referenceToEB = reparaturenDGV.SelectedRows[0].Cells[15].Value.ToString();


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
            string query = string.Format("delete from reparturen where Id={0};", lastSelectedProductKey);
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
            string query = "delete from Reparaturen";
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
    }
}
