using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeUtilitiesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: need something to read the led blinky files and compare with the roms to make sure they are all in there
            //-----First task:
            //get list of roms in C:\Emulators\_roms\mame (*.zip)++++++++++++++++
            //compare with
            //C:\Emulators\LEDBlinky_6_5_0_1\LEDBlinky\colors.ini
            //C:\Emulators\LEDBlinky_6_5_0_1\LEDBlinky\controls.ini
            //C:\Emulators\LEDBlinky_6_5_0_1\LEDBlinky\LEDBlinkyControls.xml
            //make sure to compare all the files to each other as well
            //check for color inconsistences between Colors.ini and LEDBlinkyControls.xml
            //report all of this
            //colors.ini + controls.ini + ledblinkycontrols.xml + *.cfg of rom --> check the controls and the button mappings
            //-----

            string LEDBlinkyDirectory = ConfigurationManager.AppSettings["LEDBlinkyDirectory"].TrimEnd('\\');

            //INFO: get list of roms in C:\Emulators\_roms\mame (*.zip)
            List<string> mameRomNames = Functions.Roms.Get.Filenames(Models.Roms.RomType.MAME);

            //INFO: get list of rom cfgs in C:\Emulators\MAME\cfg
            List<string> mameCfgRomNames = new List<string>();
            string CFGDirectory_MAME = ConfigurationManager.AppSettings["CFGDirectory_MAME"].TrimEnd('\\');
            if (Directory.Exists(CFGDirectory_MAME))
            {
                mameCfgRomNames = Functions.Roms.Get.MAMECFGRomNames(CFGDirectory_MAME);
            }

            //INFO: colors ini file parsing
            string ColorsIniFile = ConfigurationManager.AppSettings["ColorsIniFile"].Trim();
            string filePathColorsINI = LEDBlinkyDirectory + @"\" + ColorsIniFile;
            Dictionary<string, List<Dictionary<string, object>>> ColorsINI = new Dictionary<string, List<Dictionary<string, object>>>();
            if (File.Exists(filePathColorsINI))
            {
                ColorsINI = Functions.INI.ExtractData(filePathColorsINI);                
            }

            //INFO: controls ini file parsing
            string ControlsIniFile = ConfigurationManager.AppSettings["ControlsIniFile"].Trim();
            string filePathControlsINI = LEDBlinkyDirectory + @"\" + ControlsIniFile;
            Dictionary<string, List<Dictionary<string, object>>> ControlsINI = new Dictionary<string, List<Dictionary<string, object>>>();
            if (File.Exists(filePathColorsINI))
            {
                ControlsINI = Functions.INI.ExtractData(filePathControlsINI);
            }

            //INFO: LEDBlinkyControls.xml --> this is the first place it'll check for colors
            string LEDBlinkyControlsFile = ConfigurationManager.AppSettings["LEDBlinkyControlsFile"].Trim();
            string filePathLEDBlinkyControlsXML = LEDBlinkyDirectory + @"\" + LEDBlinkyControlsFile;
            Dictionary<string, List<Dictionary<string, object>>> LEDBlinkyControlsXML = new Dictionary<string, List<Dictionary<string, object>>>();
            List<string> LEDBlinkyControlsRoms = new List<string>();
            if (File.Exists(filePathLEDBlinkyControlsXML))
            {
                //INFO: validate xml file
                bool b = Functions.XML.ValidateFile(filePathLEDBlinkyControlsXML);

                if (b)
                {
                    //TODO: get roms
                    LEDBlinkyControlsRoms = Functions.XML.LEDBlinkyControls.ExtractData.RomNames(filePathLEDBlinkyControlsXML);
                    //LEDBlinkyControlsXML = Functions.XML.LEDBlinkyControls.ExtractData(filePathLEDBlinkyControlsXML);
                }
            }

            Reports.Roms.Compare(mameRomNames, mameCfgRomNames, ColorsINI, ControlsINI, LEDBlinkyControlsRoms);

            Reports.Buttons.Get.Mappings("mk2r21", mameRomNames, mameCfgRomNames, ColorsINI, ControlsINI, filePathLEDBlinkyControlsXML);
        }
    }
}
