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

            // Get and Print the line numbers for each item
            string[] itemLines_array = Helpers.GetItemLines(filepath_array);

            // Create new Items for each item in cost book
            for (int i = 0; i < itemLines_array.Length; i++)
            {
                Helpers.CreateItemObject(itemLines_array[i]);
            }


            /* 
            // Print the text file in the console
            for (int i = 0; i < filepath_array.Length; i++)
            {
                Console.WriteLine(filepath_array[i]);
            }
            
            
            for (int i = 0; i < itemLines_array.Length; i++)
            {
                Console.WriteLine(itemLines_array[i]);
            }
            */

            // Wait for user to close program
            Console.WriteLine("Press Any Key to exit!");
            Console.ReadLine();
        }
    }
}
