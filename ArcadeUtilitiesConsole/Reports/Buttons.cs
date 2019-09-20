using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeUtilitiesConsole.Reports
{
    class Buttons
    {
        public class Get
        {
            public static void Mappings(string romName,
                                        List<string> mameRoms,
                                        List<string> mameCFGRoms,
                                        Dictionary<string, List<Dictionary<string, object>>> colorsINI,
                                        Dictionary<string, List<Dictionary<string, object>>> controlsINI,
                                        string LEDBlinkyControlsRomsFile)
            {
                string filename = "button-compare_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".csv";
                string delimiter = ",";

                string header = "MAME" + delimiter + "MAME_cfg" + delimiter + "Colors.ini" + delimiter + "Controls.ini" + delimiter + "LEDBlinkyControls.xml";

                char[] trimChars = new char[] { '\\' };
                string RomsReport = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).TrimEnd(trimChars) + @"\" + filename;
                //INFO: remove URI format from file path
                RomsReport = RomsReport.Substring(6);
                trimChars = null;


                //string CFGDirectory_MAME = ConfigurationManager.AppSettings["CFGDirectory_MAME"].TrimEnd('\\');
                //if (Directory.Exists(CFGDirectory_MAME))
                //{

                Dictionary<string, string> LEDBlinkyControlRom = Functions.XML.LEDBlinkyControls.ExtractData.Rom(romName, LEDBlinkyControlsRomsFile);
            }
        }
    }
}
