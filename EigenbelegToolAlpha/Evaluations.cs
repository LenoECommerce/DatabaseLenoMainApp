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
using System.Windows.Forms.VisualStyles;
using MySqlX.XDevAPI.Common;

namespace EigenbelegToolAlpha
{
    public partial class EvaluationsFirstPage : Form
    {
        public EvaluationsFirstPage()
        {
            InitializeComponent();
        }
        public string fileName = "Evaluation_config.txt";
        public string newPath = "";
        string result = "";
        private void EvaluationsFirstPage_Load(object sender, EventArgs e)
        {
            lbl_BackMarketNormal1.Text = lineSearchAndGetValue("BackMarket normal 1:");
            lbl_BackMarketNormal2.Text = lineSearchAndGetValue("BackMarket normal 2:");
            lbl_BackMarketNormal3.Text = lineSearchAndGetValue("BackMarket normal 3:");
            lbl_BackMarketPayPal1.Text = lineSearchAndGetValue("BackMarket PayPal 1:");
            lbl_BackMarketPayPal2.Text = lineSearchAndGetValue("BackMarket PayPal 2:");
            lbl_BackMarketPayPal3.Text = lineSearchAndGetValue("BackMarket PayPal 3:");
        }

        public void lineSearchAndInsert(string searchValue)
        {
            string[] lines = File.ReadAllLines(fileName);
            int lineToEdit = 2;
            string lineToWrite = newPath;
            
            for (int i = 1; i < lines.Count(); i++)
            {
                    if (lines[i].Contains(searchValue))
                    {
                         lineToEdit = i+1;
                    }
            }

            //Neuen Path eintragen
            string line = null;
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int currentLine = 1; currentLine <= lines.Length; ++currentLine)
                {
                    if (currentLine == lineToEdit)
                    {
                        writer.WriteLine(searchValue+lineToWrite);
                    }
                    else
                    {
                        writer.WriteLine(lines[currentLine - 1]);
                    }
                }
            }

         
        }

        public string lineSearchAndGetValue(string searchValue)
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (line.Contains(searchValue))
                {
                    var length = line.Length;
                    var posDoublePoint = line.IndexOf(":");
                    result = line.Substring(20, length - 20);
                    return result;
                }
            }
            return "";
        }

        public string getOpenFileDialog ()
        {
            openFD.ShowDialog();
            return openFD.FileName;
        }

        private void lbl_BackMarketNormal1_Click(object sender, EventArgs e)
        {
            newPath = getOpenFileDialog();
            lineSearchAndInsert("BackMarket normal 1:");
            lbl_BackMarketNormal1.Text = newPath;
        }
        private void lbl_BackMarketNormal2_Click(object sender, EventArgs e)
        {
            newPath = getOpenFileDialog();
            lineSearchAndInsert("BackMarket normal 2:");
            lbl_BackMarketNormal2.Text = newPath;
        }

        private void lbl_BackMarketNormal3_Click(object sender, EventArgs e)
        {
            newPath = getOpenFileDialog();
            lineSearchAndInsert("BackMarket normal 3:");
            lbl_BackMarketNormal3.Text = newPath;
        }

        private void lbl_BackMarketPayPal1_Click(object sender, EventArgs e)
        {
            newPath = getOpenFileDialog();
            lineSearchAndInsert("BackMarket PayPal 1:");
            lbl_BackMarketPayPal1.Text = newPath;
        }

        private void lbl_BackMarketPayPal2_Click(object sender, EventArgs e)
        {
            newPath = getOpenFileDialog();
            lineSearchAndInsert("BackMarket PayPal 2:");
            lbl_BackMarketPayPal2.Text = newPath;
        }

        private void lbl_BackMarketPayPal3_Click(object sender, EventArgs e)
        {
            newPath = getOpenFileDialog();
            lineSearchAndInsert("BackMarket PayPal 3:");
            lbl_BackMarketPayPal3.Text = newPath;
        }

        private void lbl_ebayReport_Click(object sender, EventArgs e)
        {
            newPath = getOpenFileDialog();
            lineSearchAndInsert("Ebay Report:");
            lbl_ebayReport.Text = newPath;
        }

        private void lbl_paypalReport_Click(object sender, EventArgs e)
        {
            newPath = getOpenFileDialog();
            lineSearchAndInsert("PayPal Report:");
            lbl_paypalReport.Text = newPath;
        }

        private void btn_ContinueWithEvaluation2_Click(object sender, EventArgs e)
        {
            EvaluationSecondForm frm = new EvaluationSecondForm();
            frm.Show();
            this.Hide();
        }
    }
}
