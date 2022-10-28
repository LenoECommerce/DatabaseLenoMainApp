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
    public partial class ReparaturenFilter : Form
    {
        public ReparaturenFilter()
        {
            InitializeComponent();
        }
        public string filterModel = "";
        public string filterSource = "";
        public string filterRepairState = "";

        private void btn_Execute_Click(object sender, EventArgs e)
        {
            filterModel = comboBox_filterModell.Text;
            filterSource = comboBox_filterSource.Text;
            filterRepairState = comboBox_filterRepairState.Text;
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}
