using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows;

namespace QuizGame
{
    // Handles highscores saving and reading, the program stores the 10 highest score
    static class ScoreHandler
    {
        // Returns the list of top 10 scores from the database
        public static List<ScoreEntry> LoadScores()
        {
            using(IDbConnection connection = new SQLiteConnection(GetConnectionString()))
            {
                string sqlCommand = "SELECT * FROM Scores ORDER BY Prize LIMIT 10;";
                var output = connection.Query<ScoreEntry>(sqlCommand, new DynamicParameters());
                return output.ToList();
            }
        }

        // Add a new entry to the database
        public static void AddAndSaveScore(ScoreEntry data)
        {
            using (IDbConnection connection = new SQLiteConnection(GetConnectionString()))
            {
                string sqlCommand = "INSERT INTO Scores(Name, Prize, Timestamp, Helps) VALUES (@Name, @Prize, @Timestamp, @Helps)";

                try
                {
                    connection.Execute(sqlCommand, data);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Returns the connection string
        private static string GetConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
