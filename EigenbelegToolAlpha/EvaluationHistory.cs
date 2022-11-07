﻿using MySql.Data.MySqlClient;
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
    public partial class EvaluationHistory : Form
    {
        public string currentYear = "2022";
        public EvaluationHistory()
        {
            InitializeComponent();
            ShowEvaluations();
        }
        public static MySqlConnection conn;
        public string connString = CRUDQueries.connString;
        public void ShowEvaluations ()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string query = "SELECT * FROM `Evaluations`";
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(query, conn);

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            ////Datensatz
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            //Daten anzeigen im Grid
            evaluationsDGV.DataSource = dataSet.Tables[0];

            evaluationsDGV.Columns[0].Visible = false;

            //Sortierte Ansicht
            //evaluationsDGV.Sort(evaluationsDGV.Columns[1], ListSortDirection.Descending);

            for (int i = 0; i <= evaluationsDGV.Rows.Count-1; i++)
            {
                if (evaluationsDGV.Rows[i].Cells[2].Value.ToString() != currentYear)
                {
                    evaluationsDGV.Rows[i].Visible = false;
                }
            }

            conn.Close();
        }
        private void EvaluationHistory_Load(object sender, EventArgs e)
        {

        }

        private void combobox_SelectedYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentYear = combobox_SelectedYear.SelectedItem.ToString();
        }
    }
}
