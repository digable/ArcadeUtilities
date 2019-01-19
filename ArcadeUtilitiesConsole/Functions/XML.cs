using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ArcadeUtilitiesConsole.Functions
{
    class XML
    {
        public static bool ValidateFile(string file)
        {
            bool b = true;

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);
                doc = null;
            }
            catch(Exception ex)
            {
                b = false;
            }

            file = null;

            return b;
        }
        public class LEDBlinkyControls
        {
            //TODO: need to figure a way to validate xml files when this class is called
            public class ExtractData
            {
                public static List<string> RomNames(string file)
                {
                    List<string> l = new List<string>();

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(file);

                    //INFO: path --> root--><dat><emulator emuname="MAME" emuDesc="MAME Defaults and Control Overrides">
                    XmlNode mameNode = xmlDoc.SelectSingleNode(@"//dat/emulator[@emuname='MAME']");
                    XmlNodeList roms = mameNode.SelectNodes(@"controlGroup");
                    foreach(XmlNode rom in roms)
                    {
                        XmlAttributeCollection ac = rom.Attributes;
                        string groupName = ac.GetNamedItem("groupName").Value;
                        l.Add(groupName);

                    }

                    //INFO: sort the rom names
                    l.Sort();

                    //then get the nodes below called <controlGroup groupName="DEFAULT"
                    //groupname is the rom name
                    return l;
                }
            }
        }
    }
}
