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

        public static void CreateItemTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS items (" +
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
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public static void AddItem(Item item)
        {
            string sql = "INSERT INTO items (code, desc, unit, qty, engest, avgbid, awdbid) VALUES (@p0,@p1,@p3,@p3,@p4,@p5,@p6)";

            CreateItemTable();
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
    }
}
