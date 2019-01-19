using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeUtilitiesConsole.Reports
{
    class Roms
    {
        //do a complare with the sources, the mame rom list being the master
        public static void Compare( List<string> mameRoms,
                                    Dictionary<string, List<Dictionary<string, object>>> colorsINI,
                                    Dictionary<string, List<Dictionary<string, object>>> controlsINI,
                                    List<string> LEDBlinkyControlsRoms)
        {
            string filename = "rom-compare_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".csv";
            string delimiter = ",";

            string header = "MAME" + delimiter + "Colors.ini" + delimiter + "Controls.ini" + delimiter + "LEDBlinkyControls.xml";

            char[] trimChars = new char[] { '\\' };
            string RomsReport = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).TrimEnd(trimChars) + @"\" + filename;
            //INFO: remove URI format from file path
            RomsReport = RomsReport.Substring(6);
            trimChars = null;


            List<string> colorsINIRoms = new List<string>();
            foreach (string romName in colorsINI.Keys) colorsINIRoms.Add(romName.ToLower());
            
            List<string> controlsINIRoms = new List<string>();
            foreach (string romName in controlsINI.Keys) controlsINIRoms.Add(romName.ToLower());

            StreamWriter sw = new StreamWriter(RomsReport, true);
            sw.WriteLine(header);
            sw.Close();
            sw.Dispose();

            foreach(string mameRomName in mameRoms)
            {
                string romName = mameRomName.ToLower();
                string line = string.Empty;
                line += romName + delimiter;

                if (colorsINIRoms.Contains(romName)) line += "X" + delimiter;
                else line += delimiter;

                if (controlsINIRoms.Contains(romName)) line += "X" + delimiter;
                else line += delimiter;

                if (LEDBlinkyControlsRoms.Contains(romName)) line += "X" + delimiter;
                else line += delimiter;

                sw = new StreamWriter(RomsReport, true);
                sw.WriteLine(line);
                sw.Close();
                sw.Dispose();

                line = null;
            }
        }
    }
}
