using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeUtilitiesConsole.Functions
{
    public class LaunchBox
    {
        /*  C:\Emulators\MAME\artwork\gtfore06\default.lay
         *  1920/1080 --> 1920/1200
         *  16/9 --> 16/10
         *  1440 --> 1600
         *  1080 --> 1200
         *  1340 --> 1500
         *  980 --> 1100
         *  810 --> 900
         *  555 --> 510
         *  290 --> 210
         *  240 --> 160
         *  <bounds x="602" y="63" width="715" height="954" />
         *  <bounds x="573" y="24" width="773" height="1032" />
         *  width - total screen width, divided by 2
         */

        //mame.ini --> hlsl_snap_width           1920
        //mame.ini --> hlsl_snap_height          1200

        public static bool UpdateArtworkRatios()
        {
            bool b = true;

            //string ArtworkDirectory_MAME = ConfigurationManager.AppSettings["ArtworkDirectory_MAME"].TrimEnd('\\');
            //string[] defaultLayFiles = Directory.GetFiles(ArtworkDirectory_MAME, "*.*", SearchOption.AllDirectories);

            //foreach (string file in defaultLayFiles)
            //{
            //    string filePath = Path.GetDirectoryName(file);
            //    if (filePath == ArtworkDirectory_MAME) continue;

            //    string fileName = Path.GetFileNameWithoutExtension(file);
            //    string fileNameExtension = Path.GetExtension(file);
            //    string newFileName = fileName + "_1920x1080";

            //    if (!fileName.Contains("_1920"))
            //    {
            //        File.Move(file, filePath.TrimEnd('\\') + "\\" + newFileName + fileNameExtension);
            //    }

            //    if (fileName.ToLower() == "default")
            //    {
            //        if (!File.Exists(filePath.TrimEnd('\\') + "\\" + fileName + fileNameExtension))
            //        {
            //            File.Copy(filePath.TrimEnd('\\') + "\\" + newFileName + fileNameExtension, filePath.TrimEnd('\\') + "\\" + fileName + fileNameExtension);
            //        }
            //    }
            //}

            //TODO: read the directories, find all art1_whatever, find the different ratios, rename the lay file to the resolution of the monitor
            //if it doesnt exist, check the lay file, see if you can create one, or rename/backup files in there so it doesnt default to any

            //string[] defaultLayFiles = Directory.GetDirectories(ArtworkDirectory_MAME, "default.lay", SearchOption.AllDirectories);
            //foreach(string defaultLayFile in defaultLayFiles)
            //{
            //    //TODO: read the file, find the values, update the values based on witch ratio
            //    //need to read all values and see if there are some that where not touched/in the hash, log them
            //    //write out all changes
            //    //this is XML

            //    if(Functions.XML.ValidateFile(defaultLayFile))
            //    {

            //    }
            //    else
            //    {
            //        //TODO: its no valid
            //    }

            //}



            return b;
        }
    }
}
