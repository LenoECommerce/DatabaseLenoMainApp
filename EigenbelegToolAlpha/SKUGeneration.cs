using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace EigenbelegToolAlpha
{
    public class SKUGeneration
    {
        public string finalText = "";
        public string category = "APL/";
        public string modell = "";
        public string color = "";
        public string condition = "";
        public string tax = "";
        public string storage = "";

        Dictionary<string, string> modelleDictionary = new Dictionary<string, string>
        {
            { "iPhone 6S", "6" },
            { "iPhone 6S Plus", "6.1" },
            { "iPhone 7", "7" },
            { "iPhone 7 Plus", "7.1" },
            { "iPhone 8", "8" },
            { "iPhone 8 Plus", "8.1" },
            { "iPhone SE 2020", "2" },
            { "iPhone X", "10" },
            { "iPhone XR", "9" },
            { "iPhone XS", "10.1" },
            { "iPhone XS Max", "10.2" },
            { "iPhone 11", "11" },
            { "iPhone 11 Pro", "11.1" },
            { "iPhone 11 Pro Max", "11.2" },
            { "iPhone 12", "12" },
            { "iPhone 12 Mini", "12.0" },
            { "iPhone 12 Pro", "12.1" },
            { "iPhone 12 Pro Max", "12.2" },
            { "iPhone 13", "13" },
            { "iPhone 13 Mini", "13.0" },
            { "iPhone 13 Pro", "13.1" },
            { "iPhone 13 Pro Max", "13.2" },
        };

        Dictionary<string, string> conditionsDictionary = new Dictionary<string, string>
        {
            { "Wie Neu", "A" },
            { "Sehr Gut", "B" },
            { "Gut", "C" },
        };

        Dictionary<string, string> taxTypeDictionary = new Dictionary<string, string>
        {
            { "Regelbesteuerung", "REG" },
            { "Differenzbesteuerung", "DIFF" },
        };

        Dictionary<string, string> storageDictionary = new Dictionary<string, string>
        {
            { "16 GB", "16" },
            { "32 GB", "32" },
            { "64 GB", "64" },
            { "128 GB", "128" },
            { "256 GB", "256" },
            { "512 GB", "512" },
            { "1000 GB", "1000" },
        };

        Dictionary<string, string> colorsDictionary = new Dictionary<string, string>
        {
            { "Schwarz / Grau", "B" },
            { "Rosa / Rosegold", "RO" },
            { "Jetblack", "JB" },
            { "Weiß", "W" },
            { "Rot", "RE" },
            { "Blau", "BL" },
            { "Violett", "VI" },
            { "Gelb", "YE" },
            { "Grün", "GR" },
            { "Gold", "GO" },
            { "Silber", "SI" },
        };


        public string SKUGenerationMethod(string valueModell, string valueColor, string valueCondition, string valueTax, string valueStorage)
        {
            try
            {
                modell = modelleDictionary[valueModell];
                color = colorsDictionary[valueColor];
                storage = storageDictionary[valueStorage];
                condition = conditionsDictionary[valueCondition];
                tax = taxTypeDictionary[valueTax];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finalText = category + modell + color + storage + condition + "/" + tax;
            return finalText;
        }




    }
}
