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

        private void EvaluationsFirstPage_Load(object sender, EventArgs e)
        { 
            string result = "";
            string [] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                if (line.Contains("BackMarket normal 1:"))
                {

                    var length = line.Length;
                    var posDoublePoint = line.IndexOf(":");
                    result = line.Substring(21, length-21);
                    lbl_BackMarketNormal1.Text = result;
                }
            }
        }

        private void lbl_BackMarketNormal1_Click(object sender, EventArgs e)
        {
            openFD.ShowDialog();
            string newPath = openFD.FileName;
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (line.Contains("BackMarket normal 1:"))
                { 
                    var length = line.Length;
                    var posDoublePoint = line.IndexOf(":");
                    line.Insert(posDoublePoint+1,newPath);
                    lbl_BackMarketNormal1.Text = newPath;
                }
            }


        }
    }
}
