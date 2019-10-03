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
            string[] itemListCleaned = itemLines_array.Distinct().ToArray();
            return itemListCleaned;
        }

        public static string[] GetItemAverageLines(string[] filepath_array)
        {
            List<string> itemAverageList = new List<string>();
            string[] itemAverageList_array;

            for (int i = 0; i < filepath_array.Length; i++)
            {
                if (filepath_array[i].StartsWith("                                WEIGHTED AVERAGE FOR THE YEAR")) {
                    itemAverageList.Add(filepath_array[i]);
                }
            }
            itemAverageList_array = itemAverageList.ToArray();
            return itemAverageList_array;
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

        public static Item AddItemCostInfo(Item item, string costLine)
        {
            // Get matches collection from cost string
            string pattern = @"\d{1,}\.\d{2}";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(costLine);

            // Insert into Item costs
            item.Qty = matches[0].ToString();
            item.EngEst = matches[1].ToString();
            item.AvgBid = matches[2].ToString();
            item.AwdBid = matches[3].ToString();
            
            return item;
        }
    }
}
