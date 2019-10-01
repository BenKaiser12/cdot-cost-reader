using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cdot_costbook_reader
{
    public class Helpers
    {
        public static string[] TextFileToArray(string filepath)
        {
            string[] filepath_array = System.IO.File.ReadAllLines(filepath);
            return filepath_array;
        }

        public static string[] GetItemLines(string[] filepath_array)
        {
            List<string> itemList = new List<string>();
            string[] itemLines_array;

            for (int i = 0; i < filepath_array.Length; i++)
            {
                if (filepath_array[i].StartsWith("=")) {
                    itemList.Add(filepath_array[i]);                    
                }
            }
            itemLines_array = itemList.ToArray();
            return itemLines_array;
        }

        public static Item CreateItemObject(string line)
        {
            Item newItem = new Item();
            

            //regex patterns
            string itemCode_pat = @"[0-9]{3}-[0-9]{5}";
            string itemDesc_pat = @"\b\w+[A-Za-z]\b\s.*?(\b\w+[A-Za-z]\b\s)";
            string itemUnit_pat = @"(\b\w+[A-Za-z]\b\s){1,}(?=[=])"

            // Regex for Item Code
            Regex regex_code = new Regex(itemCode_pat);
            Match m_c = regex_code.Match(line);
            newItem.ItemCode = m_c.ToString();


            // Regex for Item Name
            Regex regex = new Regex(itemDesc_pat);
            Match m = regex.Match(line);
            newItem.ItemName = m.ToString().TrimEnd(' ');

            // Regex for Item Unit
            Regex regex_unit = new Regex(itemUnit_pat);
            Match m_u = regex_unit.Match(line);
            newItem.Unit = m_u.ToString().TrimEnd(' ');
            
            return newItem;
        }
    }
}
