using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace cdot_costbook_reader
{
    class Database
    {
        private static string connString = "Data Source=CostData.db;Version=3;";

        public static void CreateDatabaseFile(string dbName)
        {
            SQLiteConnection.CreateFile(dbName);
        }

        public static void CreateItemTable(string tableName)
        {
            string sql = "CREATE TABLE IF NOT EXISTS @p0 (" +
                "id INTEGER PRIMARY KEY," +
                "code TEXT," +
                "desc TEXT," +
                "unit TEXT," +
                "qty REAL," +
                "engest REAL," +
                "avgbid REAL," +
                "awdbid REAL" +
                ")";

            SQLiteConnection conn = new SQLiteConnection(connString);
            conn.Open();
            SQLiteCommand comm = new SQLiteCommand(sql, conn);
            comm.Parameters.AddWithValue("@p0", tableName);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public static void AddItem(Item item)
        {
            string sql = "INSERT INTO items_2018 (code, desc, unit, qty, engest, avgbid, awdbid) VALUES (@p0,@p1,@p2,@p3,@p4,@p5,@p6)";

            // CreateItemTable("items_2018");

            SQLiteConnection conn = new SQLiteConnection(connString);
            conn.Open();

            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.Parameters.AddWithValue("@p0", item.Code);
            command.Parameters.AddWithValue("@p1", item.Desc);
            command.Parameters.AddWithValue("@p2", item.Unit);
            command.Parameters.AddWithValue("@p3", item.Qty);
            command.Parameters.AddWithValue("@p4", item.EngEst);
            command.Parameters.AddWithValue("@p5", item.AvgBid);
            command.Parameters.AddWithValue("@p6", item.AwdBid);

            command.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Item> ReadItemTable(string year)
        {
            // Initialize empty list of Item objects
            string sql = @"SELECT * FROM iteams_" + year;

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                // OPen the connection
                conn.Open();

                // Start by using the command
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        List<Item> itemList = new List<Item>();

                        while (reader.Read())
                        {
                            // Add Items to the list using the data reader
                            itemList.Add(new Item
                            {
                                Code = reader.GetString(0),
                                Desc = reader.GetString(1),
                                Unit = reader.GetString(2),
                                Qty = reader.GetFloat(3),
                                EngEst = reader.GetFloat(4),
                                AvgBid = reader.GetFloat(5),
                                AwdBid = reader.GetFloat(6)
                            });
                        }

                        // Close the connection and return the list
                        conn.Close();
                        return itemList;
                    }
                }
            }
        }
    }
}
