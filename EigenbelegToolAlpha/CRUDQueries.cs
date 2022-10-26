using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;
using System.IO;

namespace EigenbelegToolAlpha
{
    public class CRUDQueries
    {
        public static MySqlConnection conn;
        public static string connString = "SERVER=sql11.freesqldatabase.com;PORT=3306;Initial Catalog='sql11525524';username=sql11525524;password=d3ByMHVgie";
        public string saveLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public string fileName = @"\\Backup for " + DateTime.Today.ToString().Substring(0,10)+".sql";

        public void Backup()
        {
            if (File.Exists(saveLocation + fileName) == true)
            {
                return;
            }
            else
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(saveLocation + fileName);
                            conn.Close();
                        }
                    }
                }
                MessageBox.Show("Es wurde erfolgreich ein BackUp für heute erstellt.");
            }
        }
        public static int ExecuteQueryWithResult(string table, string searchingColumn, string getValueOfWhere, string equalValue)
        {
            string query = "SELECT `"+searchingColumn+"` FROM `"+table+ "` WHERE `"+getValueOfWhere+ "` = '"+equalValue+"'";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //zwischenspeichern und danach umformen um Fehlerquelle zu vermeiden
                var firstValueGetBack = cmd.ExecuteScalar();
                int result = Convert.ToInt32(firstValueGetBack);
                conn.Close();
                return result;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
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
        public void deleteEntry(int lastSelectedEntry, string table)
        {
            if (lastSelectedEntry == 0)
            {
                MessageBox.Show("Bitte wähle zuerst einen Eintrag aus");
                return;
            }
            string query = string.Format("DELETE FROM `"+table+"` WHERE `Id` = {0} ;", lastSelectedEntry);
            ExecuteQuery(query);
        }

    }
}
