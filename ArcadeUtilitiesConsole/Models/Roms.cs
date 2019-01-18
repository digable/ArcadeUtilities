using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ArcadeUtilitiesConsole.Models
{
    class Roms
    {
        public string Directory { get; set; }
        public List<string> FileExtensions { get; set; } = new List<string>();
        public RomType romType { get; set; }

        //generic
        private string P_extensions { get; set; }

        //specific 
        private string P_romsDirectory_MAME = ConfigurationManager.AppSettings["RomsDirectory_MAME"];
        private string P_extensions_MAME = ConfigurationManager.AppSettings["extensions_MAME"];

        public Roms(RomType romType)
        {
            switch(romType)
            {
                case RomType.MAME:
                    Directory = P_romsDirectory_MAME.ToLower().Trim();
                    P_extensions = P_extensions_MAME.Trim();
                    break;
                default:
                    break;
            }

            //FileExtensions
            if (P_extensions.Contains(";"))
            {
                FileExtensions = P_extensions.Split(';').Select(a => a != null ? a.Trim() : null).ToList();
            }
            else FileExtensions.Add(P_extensions);
            FileExtensions.Remove(string.Empty);
            P_extensions = null;
        }

        public enum RomType
        {
            MAME = 0
        }
    }
}
