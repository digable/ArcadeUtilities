using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArcadeUtilitiesConsole.Functions
{
    class MAME
    {
        public static void UpdateScreenResolution()
        {
            //TODO: need to update mame ini to the correct screen resolution
            //open @"C:\Emulators\MAME\.218b\mame.ini" file
            //find "hlsl_snap_width" and "hlsl_snap_height", count spaces inbetween the field and the resolution value
            //rewrite the file with the new resolution
            string tempFile = @"C:\Emulators\MAME\.218b\mame.ini.temp";
            string file = @"C:\Emulators\MAME\.218b\mame.ini";

            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add("hlsl_snap_width", "1920");
            fields.Add("hlsl_snap_height", "1200");

            if (File.Exists(tempFile)) File.Delete(file);
            StreamWriter sw = new StreamWriter(tempFile, true);

            string line;
            StreamReader sr = new StreamReader(file);
            while ((line = sr.ReadLine()) != null)
            {
                foreach(string field in fields.Keys)
                {
                    Regex checkField = new Regex(@"^(" + field + ")");
                    if(checkField.IsMatch(line))
                    {
                        //TODO: need to update the line with new value
                        line = "";
                    }
                }
                
                //write the line to the new file
                sw.WriteLine(line);
            }
            
        }
    }
}
