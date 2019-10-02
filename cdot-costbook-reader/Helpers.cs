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
            // Create empty Item object
            Item newItem = new Item();

            //regex pattern
            string pattern = @"(\d{3}-\d{5})|((\w+\s){1,}|([A-Za-z]{1,})-|\(.+\)){1,}(?=[\s|=])";

            // Regex for Item Info
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(line);

            // assign Item Properties
            newItem.Code = matches[0].ToString().TrimEnd(' ');
            newItem.Desc = matches[1].ToString().TrimEnd(' ');
            newItem.Unit = matches[2].ToString().TrimEnd(' ');

            return newItem;
        }
    }
}
