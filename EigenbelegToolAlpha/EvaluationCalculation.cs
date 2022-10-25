using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Reflection;
using System.Security.Permissions;

namespace EigenbelegToolAlpha
{
    public partial class EvaluationCalculation : Form
    {
        public EvaluationCalculation()
        {
            InitializeComponent();
            string tempNumber = EvaluationThirdForm.RunningCostsSum.ToString();
            lbl_RunningCostsSum.Text = RoundNumber(tempNumber);
            string tempNumber2 = EvaluationThirdForm.RunningCostsTaxGetBack.ToString();
            lbl_RunningCostsTaxGetBack.Text = RoundNumber(tempNumber2);
            string tempNumber3 = EvaluationThirdForm.RunningCostsFinal.ToString();
            lbl_RunningCostsAtAll.Text = RoundNumber(tempNumber3);
        }
        public static double backMarketGrossSalesVolumeMarginalVat = 0;
        public static double backMarketGrossSalesVolumeNormalVat = 0;
        public static double backMarketReturnsMarginalVat = 0;
        public static double backMarketReturnsNormalVat = 0;
        public static double backMarketDefferedPayout = 0;
        public static double backMarketOutcome;
        public static double backMarketGrossSalesTotal;
        public static double backMarketReturnsTotal;

        public static double backMarketPayPalGrossSalesVolumeTotal = 0;
        public static double backMarketPayPalGrossSalesVolumeMarginalVat = 0;
        public static double backMarketPayPalGrossSalesVolumeNormalVat = 0;
        public static double backMarketPayPalReturnsTotal;
        public static double backMarketPayPalReturnsNormalVat = 0;
        public static double backMarketPayPalReturnsMarginalVat = 0;
        public static double backMarketPayPalOutcome;
        public static double backMarketPayPalFees;

        public static double inputOfGoodsREG = 0;
        public static double inputOfGoodsDIFF = 0;
        public static double inputOfExternalCosts = 0;

        public static double taxesREG = 0;
        public static double taxesDIFF = 0;
        public static double taxesGetBack = 0;
        public static double taxesHaveToPay = 0;

        private void btn_CalcTest_Click(object sender, EventArgs e)
        {
            Protokollierung prot = new Protokollierung();
            Reparaturen rep = new Reparaturen();
            Matching match = new Matching();

            string searchIntern = "";
            string importNewIMEI = "";
            string searchOrderID = "";
            string newIMEI = "";
            double newAmount = 0;
            double newExternalCosts = 0;
            string newMonth = "";
            string marketplace = "";
            string taxes = "";
            string related = "";


            //Abfrage wenn IMEI nicht vorhanden sein sollte!
            foreach (DataGridViewRow row in rep.reparaturenDGV.Rows)
            {
                if (row.Cells[5].Value.Equals(""))
                {
                    foreach (DataGridViewRow row2 in prot.protokollierungDGV.Rows)
                    {
                        searchIntern = row.Cells[1].Value.ToString();
                        if (row2.Cells[3].Value.Equals(searchIntern))
                        {
                            importNewIMEI = row2.Cells[2].Value.ToString();
                            string query = "UPDATE `Reparaturen` SET `IMEI` = '" + importNewIMEI + "' WHERE `Intern` = '" + searchIntern + "'";
                            CRUDQueries.ExecuteQuery(query);
                        }
                    }
                }
            }
            //Der eigentliche Matchingprozess
            foreach (DataGridViewRow row3 in prot.protokollierungDGV.Rows)
            {
                //Überprüfen ob der Datensatz schon in Matching vorhanden ist
                searchOrderID = row3.Cells[1].Value.ToString();
                foreach (DataGridViewRow row4 in match.matchingDGV.Rows)
                {
                    if (row4.Cells[1].Value.Equals(searchOrderID))
                    {
                        //MessageBox.Show("Den Eintrag gibt es bereits.");
                        break;
                    }
                    //Data Pull aus Protokollierung
                    else
                    {
                        searchOrderID = row3.Cells[1].Value.ToString();
                        newIMEI = row3.Cells[2].Value.ToString();
                        searchIntern = row3.Cells[3].Value.ToString();
                        newMonth = row3.Cells[5].Value.ToString();
                        marketplace = row3.Cells[4].Value.ToString();
                        related = "Ja";
                        //Data Pull aus Reparaturen
                        foreach (DataGridViewRow row5 in rep.reparaturenDGV.Rows)
                        {
                            if (!row5.Cells[1].Value.ToString().Equals(searchIntern))
                            {

                            }
                            else if (row5.Cells[1].Value.ToString().Equals(searchIntern))
                            {
                                //Unterscheidung ob € Zeichen vorhanden ist.
                                string tempAmount = row5.Cells[4].Value.ToString();
                                string tempExternalCosts = row5.Cells[13].Value.ToString();
                                if (tempAmount.Contains("€"))
                                {
                                    var length = tempAmount.Length;
                                    newAmount = Convert.ToDouble(tempAmount.Substring(0, length - 1));
                                }
                                if (tempExternalCosts.Contains("€"))
                                {
                                    var length = tempExternalCosts.Length;
                                    newExternalCosts = Convert.ToDouble(tempExternalCosts.Substring(0, length - 1));
                                }
                                taxes = row5.Cells[9].Value.ToString();
                            }
                        }    
                    }
                }
            }
            string query2 = String.Format("INSERT INTO `Matching`(`Bestellnummer`,`IMEI`,`Intern`,`Kaufbetrag`,`Externe Kosten`,`Marktplatz`,`Besteuerung`,`Monat`,`Zugeordnet?`) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')"
                            , searchOrderID, newIMEI, searchIntern, newAmount.ToString(), newExternalCosts.ToString(), marketplace, taxes, newMonth, related);
            CRUDQueries.ExecuteQuery(query2);
            MessageBox.Show("Deine Anfrage wurde bearbeitet");

        }

        private void btn_backmarketInvoicesChecking_Click(object sender, EventArgs e)
        {
            BackMarketNormalInvoicesAlgorithm();
            BackMarketPayPalInvoicesAlgorithm();
            backMarketGrossSalesVolumeNormalVat = backMarketGrossSalesVolumeNormalVat + backMarketPayPalReturnsNormalVat;
            backMarketGrossSalesVolumeMarginalVat = backMarketGrossSalesVolumeMarginalVat + backMarketReturnsMarginalVat;
            backMarketPayPalGrossSalesVolumeMarginalVat = backMarketPayPalGrossSalesVolumeMarginalVat + backMarketPayPalReturnsMarginalVat;
            backMarketPayPalGrossSalesVolumeNormalVat = backMarketPayPalGrossSalesVolumeNormalVat + backMarketPayPalReturnsNormalVat;
            backMarketGrossSalesTotal = backMarketGrossSalesTotal + backMarketReturnsTotal;
        }
        public void BackMarketPayPalInvoicesAlgorithm()
        {
            EvaluationsFirstPage eval = new EvaluationsFirstPage();
            string[] numbers = new string[3] { "1", "2", "3" };
            string pathPreset = "BackMarket PayPal ";
            string buildPath = "";


            string[] salesList = new string[1000];
            string[] returnsList = new string[1000];

            string searchValueHeadingGrossSalesList = "MONTANT DES COMMANDES EXPEDIÉES DU";
            string searchValueForGrossSalesList = " 1 ";
            string searchValueMainGrossSalesTotal = "Montant des commandes expédiées par le marchand";
            string searchValueForReturnsList = "MONTANT DES COMMANDES REMBOURSÉES AVANT";
            string searchValueMainReturnsTotal = "Commandes remboursées";
            string searchValueOutcome = "Montant à créditer";


            //Große Forschleife!
            int arrayIndexer = 0;
            foreach (string number in numbers)
            {
                double tempGrossSalesVolumeMarginalVat = 0;
                double tempGrossSalesVolumeNormalVat = 0;
                double tempReturnsMarginalVat = 0;
                double tempReturnsNormalVat = 0;
                double tempOutcome = 0;
                double tempGrossSalesTotal = 0;
                double tempReturnsTotal = 0;
                buildPath = pathPreset + numbers[arrayIndexer] + ":";
                arrayIndexer++;
                string path = eval.lineSearchAndGetValue(buildPath,20);
                string tempPath = "backmarketdata.txt";
                File.WriteAllText(tempPath, ExtractTextFromPdf(path));
                if (File.Exists(path) != true)
                {
                    break;
                }
                string[] allLines = File.ReadAllLines(tempPath);

                //Index herausfinden von Hauptumsatzzeile + Wert Pull
                int indexGrossSalesTotal = findLine(allLines, searchValueMainGrossSalesTotal);
                tempGrossSalesTotal = getValueOfOneLine(indexGrossSalesTotal, allLines, 9, "marchand", "€");
                //Index herausfinden von Hauterstattungen + Wert Pull
                int indexReturnsTotal = findLine(allLines, searchValueMainReturnsTotal) - 1;
                tempReturnsTotal = getValueOfOneLine(indexReturnsTotal, allLines, 12, "remboursées", "€");
                //Index von Outcome + Wert Pull
                int indexOutcome = findLine(allLines, searchValueOutcome) - 1;
                tempOutcome = getValueOfOneLine(indexOutcome, allLines, 23, "créditer", "€");
                //Index herausfinden von Umsatzlist
                int indexGrossSalesList = findLine(allLines, searchValueHeadingGrossSalesList);
                //Einzelne REG-Umsätze in Array speichern
                int arrayIndex = 0;
                int numberOfAllSales = 0;
                for (int i = indexGrossSalesList + 1; i < allLines.Count(); i++)
                {
                    if (allLines[i].Contains(searchValueForGrossSalesList))
                    {
                        if (checkReg(allLines, i) == true)
                        {
                            salesList[arrayIndex] = getValueOfOneLine(i, allLines, 3, searchValueForGrossSalesList, "€").ToString();
                        }
                        arrayIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
                //Index herausfinden von Returnlist
                int indexReturnList = findLine(allLines, searchValueForReturnsList);
                //Einzelne REG-Umsätze in Array speichern
                int arrayIndex2 = 0;
                for (int i = indexReturnList + 1; i < allLines.Count(); i++)
                {
                    if (allLines[i].Contains(searchValueForGrossSalesList))
                    {
                        if (checkReg(allLines, i) == true)
                        {
                            returnsList[arrayIndex2] = getValueOfOneLine(i, allLines, 3, searchValueForGrossSalesList, "€").ToString();
                        }
                        arrayIndex2++;
                    }
                    else
                    {
                        break;
                    }
                }
                //Alle Werte zusammenrechnen: UmsatzREG
                for (int i = 0; i < salesList.Length; i++)
                {
                    tempGrossSalesVolumeNormalVat += Convert.ToDouble(salesList[i]);
                }
                //Alle Werte zusammenrechnen: ErstattungenREG
                for (int i = 0; i < returnsList.Length; i++)
                {
                    tempReturnsNormalVat += Convert.ToDouble(returnsList[i]);
                }
                //Temp werte zu globalen dazurechnen
                backMarketPayPalGrossSalesVolumeTotal += tempGrossSalesTotal;
                backMarketPayPalGrossSalesVolumeNormalVat += tempGrossSalesVolumeNormalVat;
                backMarketPayPalGrossSalesVolumeMarginalVat += tempGrossSalesTotal - tempGrossSalesVolumeNormalVat;
                backMarketPayPalReturnsTotal += tempReturnsTotal;
                backMarketPayPalReturnsNormalVat += tempReturnsNormalVat;
                backMarketPayPalReturnsMarginalVat += tempReturnsTotal - tempReturnsNormalVat;
                backMarketPayPalFees += tempGrossSalesTotal * 0.029 + (arrayIndex * 0.39);
                backMarketPayPalOutcome += tempOutcome;

            }
            backMarketPayPalOutcome = backMarketPayPalOutcome - backMarketPayPalFees;

            lbl_backMarketPayPalTotalGrossSales.Text = backMarketPayPalGrossSalesVolumeTotal.ToString();
            lbl_backMarketPayPalGrossSalesREG.Text = backMarketPayPalGrossSalesVolumeNormalVat.ToString();
            lbl_backMarketPayPalGrossSalesDIFF.Text = backMarketPayPalGrossSalesVolumeMarginalVat.ToString();
            lbl_backMarketPayPalReturnsREG.Text = backMarketPayPalReturnsNormalVat.ToString();
            lbl_backMarketPayPalReturnsDIFF.Text = backMarketPayPalReturnsMarginalVat.ToString();
            lbl_backMarketPayPalOutcome.Text = backMarketPayPalOutcome.ToString();
            lbl_backMarketPayPalFees.Text = backMarketPayPalFees.ToString();
        }

        public void BackMarketNormalInvoicesAlgorithm()
        {
            EvaluationsFirstPage eval = new EvaluationsFirstPage();
            string[] numbers = new string[3] { "1", "2", "3" };
            string pathPreset = "BackMarket normal ";
            string buildPath = "";

            string[] salesList = new string[1000];
            string[] returnsList = new string[1000];

            string searchValueHeadingGrossSalesList = "MONTANT DES COMMANDES EXPEDIÉES DU";
            string searchValueForGrossSalesList = " 1 ";
            string searchValueMainGrossSalesTotal = "Montant des commandes expédiées par le marchand";
            string searchValueForReturnsList = "MONTANT DES COMMANDES REMBOURSÉES AVANT";
            string searchValueMainReturnsTotal = "Commandes remboursées";
            string searchValueDefferedPayout = "Variation de dépôt de garantie";
            string searchValueOutcomeCheck1 = "Montant à créditer";
            string searchValueOutcomeCheck2 = "Montant dû par le marchand";


            //Große Forschleife!
            int arrayIndexer = 0;
            foreach (string number in numbers)
            {
                double tempGrossSalesVolumeMarginalVat = 0;
                double tempGrossSalesVolumeNormalVat = 0;
                double tempReturnsMarginalVat = 0;
                double tempReturnsNormalVat = 0;
                double tempDefferedPayout = 0;
                double tempOutcome;
                double tempGrossSalesTotal;
                double tempReturnsTotal;
                buildPath = pathPreset + numbers[arrayIndexer] + ":";
                arrayIndexer++;
                string path = eval.lineSearchAndGetValue(buildPath,20);
                string tempPath = "backmarketdata.txt";
                File.WriteAllText(tempPath, ExtractTextFromPdf(path));
                if (File.Exists(path) != true)
                {
                    break;
                }
                string[] allLines = File.ReadAllLines(tempPath);

                //Index herausfinden von Hauptumsatzzeile + Wert Pull
                int indexGrossSalesTotal = findLine(allLines, searchValueMainGrossSalesTotal);
                tempGrossSalesTotal = getValueOfOneLine(indexGrossSalesTotal, allLines, 9, "marchand", "€");
                //Index herausfinden von Hauterstattungen + Wert Pull
                int indexReturnsTotal = findLine(allLines, searchValueMainReturnsTotal) - 1;
                tempReturnsTotal = getValueOfOneLine(indexReturnsTotal, allLines, 12, "remboursées", "€");
                //Deffered Pay Out (Wert Pull + Unterscheidung ob negativ oder positiv!)



                int indexDefferedPayout = findLine(allLines, searchValueDefferedPayout) - 1;
                bool variationDefferedPayout = checkMinusSign(getValueOfOneLineDefferedPayOut(indexDefferedPayout, allLines, 9, "garantie", "€"));
                tempDefferedPayout = getValueOfOneLine(indexDefferedPayout, allLines, 9, "garantie", "€");

                //Deffered Payout | Unterscheidung ob Geld erhalten oder nicht + Unterscheidung ob + oder -
                int indexOutcome = findLine(allLines, searchValueOutcomeCheck1) - 1;
                int indexOutcome2 = findLine(allLines, searchValueOutcomeCheck2) - 1;
                if (variationDefferedPayout == true)
                {
                    if (indexOutcome != -1)
                    {
                        tempOutcome = getValueOfOneLine(indexOutcome, allLines, 23, "créditer", "€") + tempDefferedPayout;
                    }
                    else
                    {
                        tempOutcome = getValueOfOneLine(indexOutcome2, allLines, 23, "marchand", "€");
                        string tempChange = "-" + tempOutcome.ToString();
                        tempOutcome = Convert.ToDouble(tempChange) + tempDefferedPayout;
                    }
                }
                else
                {
                    if (indexOutcome != -1)
                    {
                        tempOutcome = getValueOfOneLine(indexOutcome, allLines, 23, "créditer", "€") - tempDefferedPayout;
                    }
                    else
                    {
                        tempOutcome = getValueOfOneLine(indexOutcome2, allLines, 23, "marchand", "€");
                        string tempChange = "-" + tempOutcome.ToString();
                        tempOutcome = Convert.ToDouble(tempChange) - tempDefferedPayout;
                    }
                }
                

               
                //Index herausfinden von Umsatzlist
                int indexGrossSalesList = findLine(allLines, searchValueHeadingGrossSalesList);
                //Einzelne REG-Umsätze in Array speichern
                int arrayIndex = 0;
                for (int i = indexGrossSalesList + 1; i < allLines.Count(); i++)
                {
                    if (allLines[i].Contains(searchValueForGrossSalesList))
                    {
                        if (checkReg(allLines, i) == true)
                        {
                            salesList[arrayIndex] = getValueOfOneLine(i, allLines, 3, searchValueForGrossSalesList, "€").ToString();
                        }
                        arrayIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
                //Index herausfinden von Returnlist
                int indexReturnList = findLine(allLines, searchValueForReturnsList);
                //Einzelne REG-Returns in Array speichern
                int arrayIndex2 = 0;
                for (int i = indexReturnList + 1; i < allLines.Count(); i++)
                {
                    if (allLines[i].Contains(searchValueForGrossSalesList))
                    {
                        if (checkReg(allLines, i) == true)
                        {
                            returnsList[arrayIndex2] = getValueOfOneLine(i, allLines, 3, searchValueForGrossSalesList, "€").ToString();
                        }
                        arrayIndex2++;
                    }
                    else
                    {
                        break;
                    }
                }
                //Alle Werte zusammenrechnen: UmsatzREG
                for (int i = 0; i < salesList.Length; i++)
                {
                    tempGrossSalesVolumeNormalVat += Convert.ToDouble(salesList[i]);
                }
                //Alle Werte zusammenrechnen: ErstattungenREG
                for (int i = 0; i < returnsList.Length; i++)
                {
                    tempReturnsNormalVat += Convert.ToDouble(returnsList[i]);
                }
                //Temp werte zu globalen dazurechnen
                //Temp werte zu globalen dazurechnen
                backMarketGrossSalesTotal += tempGrossSalesTotal;
                backMarketGrossSalesVolumeNormalVat += tempGrossSalesVolumeNormalVat;
                backMarketGrossSalesVolumeMarginalVat += tempGrossSalesTotal - tempGrossSalesVolumeNormalVat;
                backMarketReturnsTotal += tempReturnsTotal;
                backMarketReturnsNormalVat += tempReturnsNormalVat;
                backMarketReturnsMarginalVat += tempReturnsTotal - tempReturnsNormalVat;
                backMarketOutcome += tempOutcome;
                backMarketDefferedPayout += tempDefferedPayout;
            }

            lbl_GrossSalesTotalVolume.Text = backMarketGrossSalesTotal.ToString();
            lbl_BackMarketUmsatzREG.Text = backMarketGrossSalesVolumeNormalVat.ToString();
            lbl_BackMarketUmsatzDIFF.Text = backMarketGrossSalesVolumeMarginalVat.ToString();
            lbl_BackMarketErstattungREG.Text = backMarketReturnsNormalVat.ToString();
            lbl_BackMarketErstattungDIFF.Text = backMarketReturnsMarginalVat.ToString();
            lbl_BackMarketDefferedPayout.Text = backMarketDefferedPayout.ToString();
            lbl_BackMarketOutcome.Text = backMarketOutcome.ToString();
        }

            public double getValueOfOneLine(int index, string[] array,int lengthOfTheFirstPos, string firstPos, string secondPos)
            {
            string newValue = "";
            string tempSave = array[index].ToString();
            var fullLength = tempSave.Length;
            var posFirst = tempSave.IndexOf(firstPos);
            var posSecond = tempSave.IndexOf(secondPos);
            string tempValue = tempSave.Substring(posFirst + lengthOfTheFirstPos, posSecond - posFirst - lengthOfTheFirstPos-1);
            //Erweiterung für Tausenderbeträge mit Leerzeichen
            if (checkSpaceSign(tempValue) == true)
            {
                if (checkMinusSign(tempValue) == true)
                {
                    var posSpace = tempValue.IndexOf(" ");
                    var length = tempValue.Length;
                    string temp1 = tempValue.Substring(1, 1);
                    string temp2 = tempValue.Substring(posSpace + 1, length - posSpace - 1);
                    tempValue = temp1 + temp2;
                }
                else
                {
                    var posSpace = tempValue.IndexOf(" ");
                    var length = tempValue.Length;
                    string temp1 = tempValue.Substring(0, 1);
                    string temp2 = tempValue.Substring(posSpace + 1, length - posSpace - 1);
                    tempValue = temp1 + temp2;
                }
            }
            if (checkMinusSign(tempValue)==true)
            {
                var length2 = tempValue.Length;
                tempValue = tempValue.Substring(0, length2 - 1);
            }
            if (tempValue == "0,00")
            {
                tempValue = "0";
            }

            newValue = tempValue;
            double value = Convert.ToDouble(newValue);
            return value;
            }
        public string getValueOfOneLineDefferedPayOut(int index, string[] array, int lengthOfTheFirstPos, string firstPos, string secondPos)
        {
            string newValue = "";
            string tempSave = array[index].ToString();
            var fullLength = tempSave.Length;
            var posFirst = tempSave.IndexOf(firstPos);
            var posSecond = tempSave.IndexOf(secondPos);
            string tempValue = tempSave.Substring(posFirst + lengthOfTheFirstPos, posSecond - posFirst - lengthOfTheFirstPos - 1);
            return tempValue;
        }
        public bool checkZeroAmount(string tempValue)
        {
            if (tempValue == "0,00")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkMinusSign(string tempValue)
        {
            if (tempValue.Contains("-"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkSpaceSign(string tempValue)
        {
            if (tempValue.Contains(" "))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkReg (string[] array,int index)
        {
            string tempSave = array[index].ToString();
            if (tempSave.Contains("REG"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int findLine (string[] array, string searchValue)
        {
            int backValue = 0;
            for (int i = 1; i < array.Count(); i++)
            {
                if (array[i].Contains(searchValue))
                {
                    backValue = i + 1;
                    break;
                }
            }
            return backValue;
        }

        public static string ExtractTextFromPdf(string path)
        {
            try
            {
                using (PdfReader reader = new PdfReader(path))
                {
                    StringBuilder text = new StringBuilder();

                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }

                    return text.ToString();
                }
            }
            catch (Exception ex)
            {
                return "";
                MessageBox.Show(ex.Message);
            } 
        }

        private void btn_InputCalculate_Click(object sender, EventArgs e)
        {
            Matching match = new Matching();
            EvaluationsFirstPage eval = new EvaluationsFirstPage();
            string month = eval.lineSearchAndGetValue("Monat:",6);
            string path = "alreadyMatchedDevives.txt";
            string[] devicesList = new string[1000];
            int arrayIndex = 0;
            foreach (DataGridViewRow row in match.matchingDGV.Rows)
            {
                    if (row.Cells[8].Value.ToString() == month)
                    {
                        string tempIntern = row.Cells[3].Value.ToString();
                        if (devicesList.Contains(tempIntern))
                        {
                            MessageBox.Show("Es wurde ein bereits gezählter Eintrag gefunden.");
                        }
                        else
                        {
                            arrayIndex++;
                            devicesList[arrayIndex] = tempIntern;
                            foreach (string device in devicesList)
                            {
                                File.WriteAllLines(path, devicesList);
                            }
                            string checkValue = row.Cells[5].Value.ToString();
                            if (checkValue == "")
                            {
                                inputOfExternalCosts += 0;
                            }
                            else
                            {
                                inputOfExternalCosts += Convert.ToDouble(EuroCheck(checkValue));
                            }
                            string checkTaxValue = Convert.ToString(row.Cells[7].Value);
                            if (CheckTaxesForInputs(checkTaxValue) == true)
                            {
                                string checkValue2 = row.Cells[4].Value.ToString();
                                inputOfGoodsDIFF += Convert.ToDouble(EuroCheck(checkValue2));
                            }
                            else
                            {
                            string checkValue3 = row.Cells[4].Value.ToString();
                            inputOfGoodsREG += Convert.ToDouble(EuroCheck(checkValue3));
                            }
                        }
                }
            }
            lbl_inputOfExternalCosts.Text = inputOfExternalCosts.ToString();
            lbl_inputOfGoodsDIFF.Text = inputOfGoodsDIFF.ToString();
            lbl_inputOfGoodsREG.Text = inputOfGoodsREG.ToString();
        }

        public string EuroCheck (string checkValue)
        {
            if (checkValue.Contains("€"))
            {
                var length = checkValue.Length;
                var newValue = checkValue.Substring(0,length-1);
                return newValue;
            }
            else
            {
                return checkValue;
            }
        }
        public bool CheckTaxesForInputs (string checkValue)
        {
            if (checkValue == "Differenzbesteuerung")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btn_TaxCalculation_Click(object sender, EventArgs e)
        {
            double tempBMNormalREG = backMarketGrossSalesVolumeNormalVat;
            double tempBMPayPalREG = backMarketPayPalGrossSalesVolumeNormalVat;
            double tempEbayREG = EvaluationSecondForm.ebayGrossSalesMarginalVat;
            double tempSparePartsREG = EvaluationSecondForm.sparepartsGrossSalesNormalVat;
            double tempSumREG = tempBMNormalREG+tempBMPayPalREG+tempEbayREG+tempSparePartsREG;

            double tempBMNormalDIFF = backMarketGrossSalesVolumeMarginalVat;
            double tempBMPayPalDIFF = backMarketPayPalGrossSalesVolumeMarginalVat;
            double tempEbayDIFF = EvaluationSecondForm.ebayGrossSalesMarginalVat;
            double tempSparePartsDIFF = EvaluationSecondForm.sparepartsGrossSalesMarginalVat;
            double tempSumDIFF = tempBMNormalDIFF+tempBMPayPalDIFF+tempEbayDIFF+tempSparePartsDIFF;

            double tempInputOfGoodsDIFF = inputOfGoodsDIFF;
            double tempInputOfGoodsREG = inputOfGoodsREG;
            double tempInputExternalCosts = inputOfExternalCosts;
            double tempMoreExternal = 0;
            //Endberechnungen
            double finalREG = tempSumREG/1.19*0.19;
            double finalDIFF = (tempSumDIFF-tempInputOfGoodsDIFF)/1.19*0.19;
            double finalGetBack = tempInputExternalCosts + tempInputOfGoodsREG + tempMoreExternal;
            double finalHaveToPay = finalREG + finalDIFF - finalGetBack;
            //Runden + Label ändern
            string newFinalREG = RoundNumber(finalREG.ToString());
            lbl_TaxesREG.Text = newFinalREG.ToString();
            string newFinalDIFF = RoundNumber(finalDIFF.ToString());
            lbl_TaxesDIFF.Text = newFinalDIFF.ToString();
            string newFinalGetBack = RoundNumber(finalGetBack.ToString());
            lbl_TaxesGetBack.Text = newFinalGetBack.ToString();
            string newFinalHaveToPay = RoundNumber(finalHaveToPay.ToString());
            taxesHaveToPay = Convert.ToDouble(newFinalHaveToPay);
            lbl_TaxesTaxesHaveToPay.Text = newFinalHaveToPay.ToString();
        }

        public string RoundNumber(string tempNumber)
        {
            var length = tempNumber.Length;
            var indexComma = tempNumber.IndexOf(",");
            string preComma = tempNumber.Substring(0, indexComma);
            string afterComma = tempNumber.Substring(indexComma+1,2);
            string newNumber = preComma + "," + afterComma;
            return newNumber;
        }

        private void EvaluationCalculation_Load(object sender, EventArgs e)
        {

        }

        private void btn_ContinueToSumUp_Click(object sender, EventArgs e)
        {
            EvaluationSumUp window = new EvaluationSumUp();
            window.Show();
            this.Hide();
        }
    }
}