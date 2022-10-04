using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

namespace EigenbelegToolAlpha
{
    internal class pdfDocumentStorno
    {
        public static string signaturePath = "Unterschrift.png";
        public static string paymentMethodPath = "paypal.jpg";
        public static string filename = "";

        public static void CreateDocument(string pdfEigenbelegNumber, string pdfSellerName, string pdfDateBought,
             string pdfTransactionAmount, string pdfArticle, string pdfPlatform, string pdfPaymentmethod, string pdfAddress)


        {

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            //New document
            PdfDocument document = new PdfDocument();

            //New pages
            PdfPage page = document.AddPage();
            PdfPage page2 = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);
            XGraphics gfx2 = XGraphics.FromPdfPage(page2);
            XFont heading = new XFont("Arial", 20);
            XFont main = new XFont("Arial", 14);
            XFont subFont = new XFont("Arial", 11);


            //Text schreiben
            // XBrushed means color; xPoint sozusagen X und Y
            // Wichtig!! Position muss absolut sein und nicht dynamisch, mit Algorithmus
            //Drawline: XColor: Code Werte

            gfx.DrawString("Storno-Eigenbeleg", heading, XBrushes.Black, new XPoint(100, 100));
            //Vertikale Lines
            gfx.DrawLine(new XPen(XColor.FromArgb(0, 0, 0)), new XPoint(180, 120), new XPoint(180, 1000));
            //gfx.DrawLine(new XPen(XColor.FromArgb(0, 0, 0)), new XPoint(300, 675), new XPoint(300, 1000));
            //Nr + Betrag
            gfx.DrawString("Nr. " + pdfEigenbelegNumber, main, XBrushes.Black, new XPoint(100, 150));
            gfx.DrawString("Erstattungsbetrag", main, XBrushes.Black, new XPoint(200, 150));
            gfx.DrawString(pdfTransactionAmount , main, XBrushes.Black, new XPoint(400, 150));
            gfx.DrawLine(new XPen(XColor.FromArgb(0, 0, 0)), new XPoint(0, 170), new XPoint(1000, 170));
            //Artikel
            gfx.DrawString("Grund", main, XBrushes.Black, new XPoint(100, 250));
            gfx.DrawString(pdfArticle, subFont, XBrushes.Black, new XPoint(200, 250));
            gfx.DrawLine(new XPen(XColor.FromArgb(0, 0, 0)), new XPoint(0, 575), new XPoint(1000, 575));
            
            //Grund
            gfx.DrawString("Referenz", main, XBrushes.Black, new XPoint(100, 650));
            gfx.DrawString("Dieser Stornoeigenbeleg referiert auf den Eigenbeleg "+pdfSellerName, subFont, XBrushes.Black, new XPoint(200, 650));
            gfx.DrawLine(new XPen(XColor.FromArgb(0, 0, 0)), new XPoint(0, 675), new XPoint(1000, 675));
            //Datum und Unterschrift
            gfx.DrawString("Erstattung", main, XBrushes.Black, new XPoint(100, 700));
            gfx.DrawString(pdfDateBought, subFont, XBrushes.Black, new XPoint(200, 700));
            gfx.DrawLine(new XPen(XColor.FromArgb(0, 0, 0)), new XPoint(0, 725), new XPoint(1000, 725));
            gfx.DrawString("Unterschrift", main, XBrushes.Black, new XPoint(100, 750));


            //Bilder!
            DrawImage(gfx, signaturePath, 200, 750, 280, 80);

            //config2: Speicherort Bilder | config3: Dateiendung

            //Alle Ordner ausgeben im Hauptspeicherort als Array; Durchsuchung anhand eines bestimmten Ordnername
            var pathOfDir = Directory.GetDirectories(File.ReadAllText("config2.txt")).Where(Directory => Directory.Contains(pdfEigenbelegNumber)).ToList();
            //Alle Dateien speichern des Belegs; gerade aufm ersten Index, weil es nur ein Ergebnis gibt!

            var filesInDir = Directory.GetFiles(pathOfDir[0]);

            //Schleife die neue Seite erstellt
            for (int i = 0; i < filesInDir.Length; i++)
            {
                PdfPage pageImage = document.AddPage();
                XGraphics gfx3 = XGraphics.FromPdfPage(pageImage);
                DrawImage(gfx3, filesInDir[i], 50, 50, 500, 800);
            }

            filename = "Eigenbeleg"+pdfEigenbelegNumber + "_" + pdfDateBought + "_" + pdfTransactionAmount;
            document.Save(File.ReadAllText("config.txt") + @"/" +filename+ ".pdf");

        }




        //Methode für Bildererstellung
        public static void DrawImage(XGraphics gfx, string jpegSamplePath, int x, int y, int width, int height)
        {
            if (File.Exists(jpegSamplePath) == false)
            {
                MessageBox.Show("Für den Beleg mit dem Pfad " + jpegSamplePath + " wurde keine Datei gefunden.");
                return;
            }
            XImage image = XImage.FromFile(jpegSamplePath);
            gfx.DrawImage(image, x, y, width, height);
        }


    }
}
