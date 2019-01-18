using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArcadeUtilitiesConsole.Functions
{
    public class INI
    {
        public static Dictionary<string, List<Dictionary<string, object>>> ExtractData(string file)
        {
            Dictionary<string, List<Dictionary<string, object>>> data = new Dictionary<string, List<Dictionary<string, object>>>();

            string line;
            StreamReader sr = new StreamReader(file);

            string recordKey = string.Empty;
            List<Dictionary<string, object>> recordWhole = new List<Dictionary<string, object>>();
            Dictionary<string, object> recordPart = new Dictionary<string, object>();

            Regex checkRecordKey = new Regex(@"^\[[\w\s\-]+\]$");

            while ((line = sr.ReadLine()) != null)
            {
                if (line.Trim() == string.Empty) continue;
                //INFO: regex to make sure it has a beginning '[' and an end ']' --> this is the recordKey
                if (checkRecordKey.IsMatch(line.Trim()))
                {
                    if (recordWhole.Count > 0) data.Add(recordKey, recordWhole);
                    //INFO: this will make a new recordkey, new record whole, unitl we find the next one.
                    recordKey = line.Trim().TrimStart('[').TrimEnd(']');
                    recordWhole = new List<Dictionary<string, object>>();
                }
                else
                {
                    //INFO: this is for a record part
                    recordPart = new Dictionary<string, object>();
                    string field = string.Empty;
                    string value = string.Empty;

                    //INFO: split from the first '=' sign
                    //INFO: if there is only one '=', split
                    if (line.Count(a => a == '=') == 1)
                    {
                        string[] lineSplit = line.Split('=');
                        field = lineSplit[0].Trim();
                        value = lineSplit[1].Trim();
                    }
                    else //INFO: if there is more than one '=' use the first one
                    {
                        value = line.Substring(line.IndexOf('=') + 1);
                        field = line.Replace(value, string.Empty).TrimEnd('=');
                    }

                    recordPart.Add(field.Trim(), value.Trim());
                    field = null;
                    value = null;
                    recordWhole.Add(recordPart);
                    recordPart = null;
                }
            }

            //INFO: this is for the last record
            if (recordWhole.Count > 0) data.Add(recordKey, recordWhole);

            recordWhole = null;
            recordKey = null;
            file = null;

            return data;
        }
    }
}
