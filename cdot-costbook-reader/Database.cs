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
                "id INTEGER PRIMARY KEY" +
                "code TEXT" +
                "desc TEXT" +
                "unit TEXT" +
                "qty TEXT" +
                "engest TEXT" +
                "avgbid TEXT" +
                "awdbid TEXT" +
                ")";

            SQLiteConnection conn = new SQLiteConnection(connString);
            conn.Open();
            SQLiteCommand comm = new SQLiteCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public static void AddItem(Item item)
        {
            string sql = "INSERT INTO items (code, desc, unit, qty, engest, avgbid, awdbid) VALUES (item.code, item.desc, item.unit, item.qty, item.engest, item.avgbid, item.awdbid)";

            CreateItemTable();
            SQLiteConnection conn = new SQLiteConnection(connString);
            conn.Open();
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
