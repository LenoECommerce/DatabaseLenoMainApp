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
            { "6S", "6" },
            { "6S Plus", "6.1" },
            { "7", "7" },
            { "7 Plus", "7.1" },
            { "8", "8" },
            { "8 Plus", "8.1" },
            { "SE 2020", "2" },
            { "X", "10" },
            { "XR", "9" },
            { "XS", "10.1" },
            { "XS Max", "10.2" },
            { "11", "11" },
            { "11 Pro", "11.1" },
            { "11 Pro Max", "11.2" },
            { "12", "12" },
            { "12 Mini", "12.0" },
            { "12 Pro", "12.1" },
            { "12 Pro Max", "12.2" },
            { "13", "13" },
            { "13 Mini", "13.0" },
            { "13 Pro", "13.1" },
            { "13 Pro Max", "13.2" },
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
