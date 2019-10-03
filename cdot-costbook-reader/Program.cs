using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cdot_costbook_reader
{
    class Program
    {
        static void Main(string[] args)
        {
            // Welcome user and get filepath
            Console.WriteLine("Welcome.  Please enter the path of a CDOT cost data book .txt file");
            string filepath = Console.ReadLine();

            // Convert filepath to array of lines
            string[] filepath_array = Helpers.TextFileToArray(filepath);

            // Get the lines with item headers in filepath array
            string[] itemLines_array = Helpers.GetItemLines(filepath_array);

            // Get Yearly cost info lines
            string[] annualCostLines_array = Helpers.GetItemAverageLines(filepath_array);
            
            
            // Create Item object for each item in cost book
            List<Item> itemList = new List<Item>();
            for (int i = 0; i < itemLines_array.Length; i++)
            {
                Item newItem = Helpers.CreateItemObject(itemLines_array[i]);
                newItem = Helpers.AddItemCostInfo(newItem, annualCostLines_array[i]);
                itemList.Add(newItem);
            }

            // Insert items into database table
            foreach (Item item in itemList)
            {
                Database.AddItem(item);
                Console.WriteLine("Item: {0}, Desc: {1}, Unit: {2}" +
                    "\nYearly Average Info:" +
                    "\nQTY: {3}, Eng. Est.: {4}, Avg Bid: {5}, Awd Bid: {6}" +
                    "\n",
                    item.Code, item.Desc, item.Unit, item.Qty, item.EngEst, item.AvgBid, item.AwdBid);
            }

            /*
            // Print Item Data
            foreach (Item item in itemList)
            {
                Console.WriteLine("Item: {0}, Desc: {1}, Unit: {2}" +
                    "\nYearly Average Info:" +
                    "\nQTY: {3}, Eng. Est.: {4}, Avg Bid: {5}, Awd Bid: {6}" +
                    "\n",
                    item.Code, item.Desc, item.Unit, item.Qty, item.EngEst, item.AvgBid, item.AwdBid);
            }
            */


            // Wait for user to close program
            Console.WriteLine("Press Any Key to exit!");
            Console.ReadLine();
        }
    }
}
