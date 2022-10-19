using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EigenbelegToolAlpha
{
    public partial class EvaluationSecondForm : Form
    {
        public double ebayGrossSalesMarginalVat;
        public double ebayGrossSalesNormalVat;
        public double sparepartsGrossSalesMarginalVat;
        public double sparepartsGrossSalesNormalVat;
        public double B2BGrossSalesMarginalVat;
        public double B2BGrossSalesNormalVat;
        public double rateConsumptionCables;
        public double rateConsumptionNeutralPackages;
        public double rateConsumptionCartons;
        public EvaluationSecondForm()
        {
            InitializeComponent();
        }

        private void btn_ContinueWithEvaluation3_Click(object sender, EventArgs e)
        {
            try
            {
                ebayGrossSalesMarginalVat = Convert.ToDouble(textBox_EbayGrossSalesMarginalVat.Text);
                ebayGrossSalesNormalVat = Convert.ToDouble(textBox_EbayGrossSalesNormalVat.Text);
                sparepartsGrossSalesMarginalVat = Convert.ToDouble(textBox_SparePartsGrossSalesMarginalVa.Text);
                sparepartsGrossSalesNormalVat = Convert.ToDouble(textBox_SparePartsGrossSalesNormalVat.Text);
                B2BGrossSalesMarginalVat = Convert.ToDouble(textBox_B2BGrossSalesMarginalVat.Text);
                B2BGrossSalesNormalVat = Convert.ToDouble(textBox_B2BGrossSalesNormalVat.Text);
                rateConsumptionCables = Convert.ToDouble(textBox_rateConsumptionCables.Text);
                rateConsumptionNeutralPackages = Convert.ToDouble(textBox_rateConsumptionNeutralPackages.Text);
                rateConsumptionCartons = Convert.ToDouble(textBox_rateConsumptionCartons.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            EvaluationThirdForm frm = new EvaluationThirdForm();
            frm.Show();
            this.Hide();
        }
    }
}
