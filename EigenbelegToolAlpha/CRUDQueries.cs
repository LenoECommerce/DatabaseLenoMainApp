using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EigenbelegToolAlpha
{
    public class CRUDQueries
    {
        public static MySqlConnection conn;
        public static string connString = "SERVER=sql11.freesqldatabase.com;PORT=3306;Initial Catalog='sql11525524';username=sql11525524;password=d3ByMHVgie";

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
