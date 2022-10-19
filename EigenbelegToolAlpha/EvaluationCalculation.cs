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

namespace EigenbelegToolAlpha
{
    public partial class EvaluationCalculation : Form
    {
        public EvaluationCalculation()
        {
            InitializeComponent();
        }
        public double backMarketGrossSalesVolumeMarginalVat;
        public double backMarketGrossSalesVolumeNormalVat;
        public double backMarketDefferedPayout = 0;
        public double backMarketOutcome;
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
            //foreach (DataGridViewRow row in rep.reparaturenDGV.Rows)
            //{
            //    if (row.Cells[5].Value.Equals(""))
            //    {
            //        foreach (DataGridViewRow row2 in prot.protokollierungDGV.Rows)
            //        {
            //            searchIntern = row.Cells[1].Value.ToString();
            //            if (row2.Cells[3].Value.Equals(searchIntern))
            //            {
            //                importNewIMEI = row2.Cells[2].Value.ToString();
            //                string query = "UPDATE `Reparaturen` SET `IMEI` = '" + importNewIMEI + "' WHERE `Intern` = '" + searchIntern + "'";
            //                CRUDQueries.ExecuteQuery(query);
            //            }
            //        }
            //    }
            //}
            // Der eigentliche Matchingprozess
            foreach (DataGridViewRow row3 in prot.protokollierungDGV.Rows)
            {
                //Überprüfen ob der Datensatz schon in Matching vorhanden ist
                searchOrderID = row3.Cells[1].Value.ToString();
                foreach (DataGridViewRow row4 in match.matchingDGV.Rows)
                {
                    if (row4.Cells[1].Value.Equals(searchOrderID))
                    {
                        MessageBox.Show("Den Eintrag gibt es bereits.");
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
                        string query2 = String.Format("INSERT INTO `Matching`(`Bestellnummer`,`IMEI`,`Intern`,`Kaufbetrag`,`Externe Kosten`,`Marktplatz`,`Besteuerung`,`Monat`,`Zugeordnet?`) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')"
                            , searchOrderID, newIMEI, searchIntern, newAmount.ToString(), newExternalCosts.ToString(), marketplace, taxes, newMonth, related);
                        CRUDQueries.ExecuteQuery(query2);
                        return;
                    }

                }
            }

        }

        private void btn_backmarketInvoicesChecking_Click(object sender, EventArgs e)
        {
            double tempGrossSalesTotal;
            double tempReturnsTotal;
            double tempBackMarketUmsatzDIFF = 0;
            double tempBackMarketUmsatzREG = 0;
            double tempBackMarketErstattungDIFF = 0;
            double tempBackMarketErstattungREG = 0;

            EvaluationsFirstPage eval = new EvaluationsFirstPage();
            string path = eval.lineSearchAndGetValue("BackMarket normal 3:");
            string tempPath = "backmarketdata.txt";
            File.WriteAllText(tempPath,ExtractTextFromPdf(path));

            string[] salesList = new string[1000];
            string[] returnsList = new string[1000];
            string[] allLines = File.ReadAllLines(tempPath);

            string searchValueHeadingGrossSalesList = "MONTANT DES COMMANDES EXPEDIÉES DU";
            string searchValueForGrossSalesList = "... 1";
            string searchValueMainGrossSalesTotal = "Montant des commandes expédiées par le marchand";
            string searchValueForReturnsList = "MONTANT DES COMMANDES REMBOURSÉES AVANT";
            string searchValueMainReturnsTotal = "Commandes remboursées";
            string searchValueDefferedPayout = "Variation de dépôt de garantie";
            string searchValueOutcome = "Montant à créditer";
            //Index herausfinden von Hauptumsatzzeile + Wert Pull
            int indexGrossSalesTotal = findLine(allLines, searchValueMainGrossSalesTotal);
            tempGrossSalesTotal = getValueOfOneLine(indexGrossSalesTotal, allLines, 9, "marchand", "€");
            //Index herausfinden von Hauterstattungen + Wert Pull
            int indexReturnsTotal = findLine(allLines, searchValueMainReturnsTotal)-1;
            tempReturnsTotal = getValueOfOneLine(indexReturnsTotal, allLines, 12, "remboursées", "€");
            //Index von Deffered Payout + Wert Pull
            int indexDefferedPayout = findLine(allLines, searchValueDefferedPayout)-1;
            backMarketDefferedPayout = getValueOfOneLine(indexDefferedPayout, allLines, 9, "garantie", "€");
            //Index von Outcome + Wert Pull
            int indexOutcome = findLine(allLines, searchValueOutcome) - 1;
            backMarketOutcome = getValueOfOneLine(indexOutcome, allLines, 23, "créditer", "€");
            //Index herausfinden von Umsatzlist
            int indexGrossSalesList = findLine(allLines, searchValueHeadingGrossSalesList);
            //Einzelne REG-Umsätze in Array speichern
            int arrayIndex = 0;
            for (int i = indexGrossSalesList + 1; i < allLines.Count(); i++)
            {
                if (allLines[i].Contains(searchValueForGrossSalesList))
                {
                    if(checkReg(allLines,i) == true)
                    {
                        salesList[arrayIndex] = getValueOfOneLine(i, allLines, 6, searchValueForGrossSalesList, "€").ToString();
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
                        returnsList[arrayIndex2] = getValueOfOneLine(i, allLines, 6, searchValueForGrossSalesList, "€").ToString();
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
                tempBackMarketUmsatzREG += Convert.ToDouble(salesList[i]);
            }
            //Alle Werte zusammenrechnen: ErstattungenREG
            for (int i = 0; i < returnsList.Length; i++)
            {
                tempBackMarketErstattungREG += Convert.ToDouble(returnsList[i]);
            }

            tempBackMarketUmsatzDIFF = tempGrossSalesTotal - tempBackMarketUmsatzREG;
            tempBackMarketErstattungDIFF = tempReturnsTotal - tempBackMarketErstattungREG;

            lbl_GrossSalesTotalVolume.Text = tempGrossSalesTotal.ToString();
            lbl_BackMarketUmsatzREG.Text = tempBackMarketUmsatzREG.ToString();  
            lbl_BackMarketUmsatzDIFF.Text = tempBackMarketUmsatzDIFF.ToString();
            lbl_BackMarketErstattungREG.Text = tempBackMarketErstattungREG.ToString();
            lbl_BackMarketErstattungDIFF.Text = tempBackMarketErstattungDIFF.ToString();
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
            if(tempValue.Contains(" "))
            {
                var posSpace = tempValue.IndexOf(" ");
                var length = tempValue.Length;
                string temp1 = tempValue.Substring(0, 1);
                string temp2 = tempValue.Substring(posSpace+1, length - posSpace-1);
                newValue = temp1 + temp2;
            }
            //Erweiterung für Minusbeträge?
            else if (tempValue.Contains("-"))
            {
                var length = tempValue.Length;
                newValue = tempValue.Substring(0, length - 1);
            }

            double value = Convert.ToDouble(newValue);
            return value;
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
    }
}
