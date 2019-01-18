﻿using System;
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
            //-----

            string LEDBlinkyDirectory = ConfigurationManager.AppSettings["LEDBlinkyDirectory"].TrimEnd('\\');

            //INFO: get list of roms in C:\Emulators\_roms\mame (*.zip)
            List<string> mameRomNames = Functions.Roms.Get.Filenames(Models.Roms.RomType.MAME);

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
        }
    }
}
