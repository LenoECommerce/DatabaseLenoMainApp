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
    public partial class EvaluationSumUp : Form
    {
        public static double outComeInTotal = EvaluationCalculation.backMarketOutcome + EvaluationCalculation.backMarketPayPalOutcome + EvaluationsFirstPage.ebayOutCome;
        public static double grossSalesInTotal = EvaluationCalculation.backMarketGrossSalesVolumeMarginalVat + EvaluationCalculation.backMarketGrossSalesVolumeNormalVat
                                                + EvaluationCalculation.backMarketPayPalGrossSalesVolumeMarginalVat + EvaluationCalculation.backMarketPayPalGrossSalesVolumeNormalVat
                                                + EvaluationSecondForm.ebayGrossSalesMarginalVat + EvaluationSecondForm.ebayGrossSalesNormalVat
                                                + EvaluationSecondForm.sparepartsGrossSalesMarginalVat + EvaluationSecondForm.sparepartsGrossSalesNormalVat
                                                + EvaluationSecondForm.B2BGrossSalesTotal;
        public static double moreExternalCostsInTotal = EvaluationSecondForm.moreExternalCostsNormalVat + EvaluationSecondForm.moreExternalCostsMarginalVat;
        //Hier wird Spender verändert!
        public static double donorDevices = 934.97;
        public static double inputInTotal = EvaluationCalculation.inputOfGoodsREG + EvaluationCalculation.inputOfGoodsDIFF + EvaluationCalculation.inputOfExternalCosts + moreExternalCostsInTotal + donorDevices;
        public static double moreExternalCostsTaxGetBack = EvaluationSecondForm.moreExternalCostsNormalVat / 1.19 * 0.19;
        public static double taxesInTotal = EvaluationCalculation.taxesHaveToPay- EvaluationsFirstPage.ebayTaxGetBack -moreExternalCostsTaxGetBack;
        public static double rateConsumptionTotal = EvaluationSecondForm.rateConsumptionTotal;
        public static double runningCostsInTotal = EvaluationThirdForm.RunningCostsFinal;
        public static double revenueInTotal = outComeInTotal +EvaluationSecondForm.B2BRevenue- inputInTotal - rateConsumptionTotal - taxesInTotal;
        public static double revenieInTotalAfterRunningCosts = revenueInTotal - runningCostsInTotal;
        public string month = "";
        public EvaluationSumUp()
        {
            InitializeComponent();
            EvaluationsFirstPage eval = new EvaluationsFirstPage();
            EvaluationCalculation eval2 = new EvaluationCalculation();
            month = eval.lineSearchAndGetValue("Monat:", 6);
            lbl_MonthOfEvaluationo.Text = month;
            lbl_grossSalesBackMarketNormalDIFF.Text = EvaluationCalculation.backMarketGrossSalesVolumeMarginalVat.ToString();
            lbl_grossSalesBackMarketNormalREG.Text = EvaluationCalculation.backMarketGrossSalesVolumeNormalVat.ToString();
            lbl_grossSalesBackMarketPayPalDIFF.Text = EvaluationCalculation.backMarketPayPalGrossSalesVolumeMarginalVat.ToString();
            lbl_grossSalesBackMarketPayPalREG.Text = EvaluationCalculation.backMarketPayPalGrossSalesVolumeNormalVat.ToString();
            lbl_grossSalesEbayDIFF.Text = EvaluationSecondForm.ebayGrossSalesMarginalVat.ToString();
            lbl_grossSalesEbayREG.Text = EvaluationSecondForm.ebayGrossSalesNormalVat.ToString();
            lbl_InputOfGoodsREG.Text = EvaluationCalculation.inputOfGoodsREG.ToString();
            lbl_InputOfGoodsDIFF.Text = EvaluationCalculation.inputOfGoodsDIFF.ToString();
            lbl_InputOfExternalCosts.Text = EvaluationCalculation.inputOfExternalCosts.ToString();
            lbl_rateConsumption.Text = rateConsumptionTotal.ToString();
            lbl_sparePartsDIFF.Text = EvaluationSecondForm.sparepartsGrossSalesMarginalVat.ToString();
            lbl_sparePartsREG.Text = EvaluationSecondForm.sparepartsGrossSalesNormalVat.ToString();
            lbl_B2BGrossSales.Text = EvaluationSecondForm.B2BGrossSalesTotal.ToString();
            lbl_B2BRevenue.Text = EvaluationSecondForm.B2BRevenue.ToString();
            string tempNumber = runningCostsInTotal.ToString();
            lbl_RunningCostsTotal.Text = eval2.RoundNumber(tempNumber);
            lbl_InputInTotal.Text = inputInTotal.ToString();
            lbl_TaxesInTotal.Text = taxesInTotal.ToString();
            string tempNumber3 = revenieInTotalAfterRunningCosts.ToString();
            lbl_revenueTotalAfterRunningCosts.Text = eval2.RoundNumber(tempNumber3);
            string tempNumber2 = outComeInTotal.ToString();
            lbl_OutComeInTotal.Text = eval2.RoundNumber(tempNumber2);
            string tempNumber4 = revenueInTotal.ToString();
            lbl_KPIRevenue.Text = eval2.RoundNumber(tempNumber4);
            string tempNumber5 = grossSalesInTotal.ToString();
            lbl_KPIGrossSalesTotal.Text = eval2.RoundNumber(tempNumber5);
            //Spenderwert
            lbl_donorDevices.Text = donorDevices.ToString();
            lbl_MoreExternalCosts.Text = moreExternalCostsInTotal.ToString();

        }

        private void EvaluationSumUp_Load(object sender, EventArgs e)
        {

        }

        private void btn_CreatePDFDocument_Click(object sender, EventArgs e)
        {
            MonthlyReportPDF.CreatePDFFile(month, EvaluationSecondForm.ebayGrossSalesNormalVat.ToString(), EvaluationSecondForm.ebayGrossSalesMarginalVat.ToString(), EvaluationCalculation.backMarketGrossSalesVolumeNormalVat.ToString(),
                                           EvaluationCalculation.backMarketGrossSalesVolumeMarginalVat.ToString(), EvaluationCalculation.backMarketPayPalGrossSalesVolumeNormalVat.ToString(), EvaluationCalculation.backMarketPayPalGrossSalesVolumeMarginalVat.ToString(),
                                           EvaluationSecondForm.sparepartsGrossSalesNormalVat.ToString(), EvaluationSecondForm.sparepartsGrossSalesMarginalVat.ToString(), lbl_OutComeInTotal.Text, lbl_InputOfGoodsREG.Text, lbl_InputOfGoodsDIFF.Text,
                                           lbl_InputOfExternalCosts.Text, lbl_MoreExternalCosts.Text, lbl_donorDevices.Text, lbl_InputInTotal.Text, lbl_rateConsumption.Text, lbl_RunningCostsTotal.Text, lbl_TaxesInTotal.Text,
                                           lbl_B2BGrossSales.Text, lbl_B2BRevenue.Text, lbl_KPIGrossSalesTotal.Text, lbl_KPIRevenue.Text, lbl_revenueTotalAfterRunningCosts.Text);
            //GoogleDrive drive = new GoogleDrive(MonthlyReportPDF.,"pdf");
            MessageBox.Show("Datei erfolgreich erstellt.");
            this.Close();
        }

        private void lbl_MoreExternalCosts_Click(object sender, EventArgs e)
        {

        }
    }
    
}
