using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeUtilitiesConsole.Functions
{
    class Roms
    {
        public class Get
        {
            public static List<string> Filenames(Models.Roms.RomType rType)
            {
                Models.Roms r = new Models.Roms(rType);
                return Filenames(r);
            }

            public static List<string> Filenames(Models.Roms r)
            {
                List<string> l = new List<string>();

                foreach (string ext in r.FileExtensions)
                {
                    string[] files = Directory.GetFiles(r.Directory, "*." + ext, SearchOption.TopDirectoryOnly);
                    if (files.Length > 0) l.AddRange(files.Select(a => Path.GetFileNameWithoutExtension(a)).ToArray());
                }

                l.Sort();

                return l;
            }

        }
    }
}
