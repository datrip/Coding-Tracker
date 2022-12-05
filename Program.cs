using System.Data.SQLite;
using System.Configuration;
using System.Collections.Specialized;
using System;
using System.Text;

namespace Coding_Tracker // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var conn = ConfigurationManager.ConnectionStrings["Coding-Tracking"].ConnectionString;
            {


                using (var connection = new SQLiteConnection(conn))
                {

                    connection.Open();
                    var tableCmd = connection.CreateCommand();

                    tableCmd.CommandText =
                        @"CREATE TABLE IF NOT EXISTS coding_tracker (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        StartTime TEXT,
                        EndTime TEXT,
                        Duration TEXT
                        )";

                    tableCmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
    }
}