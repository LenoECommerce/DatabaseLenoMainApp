using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EigenbelegToolAlpha
{
    public partial class Proofing : Form
    {
        public static MySqlConnection conn;
        public string connString = CRUDQueries.connString;
        public int lastSelectedEntry;
        public string internalNumber = "";
        public string imei = "";
        public string videoLink = "";
        public string nsysCertificate = "";
        public Proofing()
        {
            InitializeComponent();
            ShowProofing();
        }
        public void ShowProofing()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string query = "SELECT * FROM `Proofing`";
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(query, conn);

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            ////Datensatz
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            //Daten anzeigen im Grid
            proofingDGV.DataSource = dataSet.Tables[0];

            proofingDGV.Columns[0].Visible = false;

            //Sortierte Ansicht
            proofingDGV.Sort(proofingDGV.Columns[0], ListSortDirection.Descending);
            conn.Close();
        }

        private void ProofingCreate()
        {
            if (textBox_IMEI.Text == "" ||
               textBox_InternalNumber.Text == "" ||
               textBox_nsysCertificate.Text == "" ||
               textBox_Video.Text == "")
            {
                MessageBox.Show("Bitte füll alle Felder aus.");
                return;
            }
            SetValues();

            string query = string.Format("INSERT INTO `Proofing`(`Intern`,`IMEI`,`Video`,`NSYS-Zertifikat`) VALUES ('{0}','{1}','{2}','{3}')"
           , internalNumber, imei, videoLink, nsysCertificate);
            CRUDQueries.ExecuteQuery(query);
            MessageBox.Show("Der Eintrag wurde erfolgreich erstellt.");
            ShowProofing();
        }

        private void SetValues ()
        {
            imei = textBox_IMEI.Text;
            internalNumber = textBox_InternalNumber.Text;
            nsysCertificate = textBox_nsysCertificate.Text;
            videoLink = textBox_Video.Text;
        }
        private void Proofing_Load(object sender, EventArgs e)
        {

        }

        private void proofingDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_InternalNumber.Text = proofingDGV.SelectedRows[0].Cells[1].Value.ToString();
            textBox_IMEI.Text = proofingDGV.SelectedRows[0].Cells[2].Value.ToString();
            textBox_Video.Text = proofingDGV.SelectedRows[0].Cells[3].Value.ToString();
            textBox_nsysCertificate.Text = proofingDGV.SelectedRows[0].Cells[4].Value.ToString();

            lastSelectedEntry = (int)proofingDGV.SelectedRows[0].Cells[0].Value;
        }

        private void btn_proofingCreate_Click(object sender, EventArgs e)
        {
            ProofingCreate();
        }

        private void btn_proofingEdit_Click(object sender, EventArgs e)
        {
            if (lastSelectedEntry == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus");
                return;
            }
            SetValues();

            try
            {
                string query = string.Format("UPDATE `Proofing` SET `Intern` = '{0}',`IMEI` = '{1}', `Video` = '{2}', `NSYS-Zertifikat` = '{3}' WHERE `Id` = {4}"
                , internalNumber,imei,videoLink,nsysCertificate,lastSelectedEntry);
                MessageBox.Show("Deine Änderungen wurden erfolgreich gespeichert.");
                CRUDQueries.ExecuteQuery(query);
                ShowProofing();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_proofingDelete_Click(object sender, EventArgs e)
        {
            if (lastSelectedEntry == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus");
                return;
            }
            CRUDQueries window = new CRUDQueries();
            window.deleteEntry(lastSelectedEntry, "Proofing");
            ShowProofing();
        }

        private void btn_SyncTableWithNewData_Click(object sender, EventArgs e)
        {
            folderBD.ShowDialog();
            string folderPath = folderBD.SelectedPath;
            string []  filesInDir = Directory.GetFiles(folderPath);
            foreach (var item in filesInDir)
            {
                Proofing proofing = new Proofing();
                foreach (DataGridViewRow row in proofing.proofingDGV.Rows)
                {
                    string fileName = Path.GetFileNameWithoutExtension(item).ToString();
                    GoogleDrive drive = new GoogleDrive(item);
                    string fileLink = GoogleDrive.currentLink;
                    string rowValueIntern = row.Cells[1].Value.ToString();
                    if (rowValueIntern == fileName)
                    {
                        string query = "UPDATE Proofing SET `Video` = '"+fileLink+ "' WHERE `Intern` = '"+ rowValueIntern + "'";
                        CRUDQueries.ExecuteQuery(query);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            ShowProofing();
        }

        private void eigenbelegeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reparaturen window = new Reparaturen();
            window.Show();
            this.Hide();
        }

        private void protokollierungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eigenbelege window = new Eigenbelege();
            window.Show();
            this.Hide();
        }

        private void protokollierungToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Protokollierung window = new Protokollierung();
            window.Show();
            this.Hide();
        }
    }
}
