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
    public partial class EigenbelegFilter : Form
    {
        public EigenbelegFilter()
        {
            InitializeComponent();
        }
        public string filterModell = "";
        public string filterCreated = "";
        public string filterPlatform = "";
        public string[] selectedFilterModell = new string[10];

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_Execute_Click(object sender, EventArgs e)
        {
            filterModell = comboBox_filterModell.Text;
            filterCreated = comboBox_FilterCreated.Text;
            filterPlatform = comboBox_filterPlatform.Text;
            if (filterModell == "Alle")
            {
                selectedFilterModell[0] = "iPhone X";
                selectedFilterModell[1] = "iPhone 11";
            }
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}
