using Microsoft.Data.SqlClient;
using MonoGameExamenVliegtuig.Core.Interface;
using MonoGameExamenVliegtuig.Core.Scores;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Core.Repository
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly string _connectionstring;

        public ScoreRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }
        
        public List<int> GetHighScoresSingleplayer()
        {
            List<int> scores = new List<int>();
            string sql = "SELECT TOP 5 Score FROM HighScoreSingleplayer ORDER BY Score DESC";

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int score = reader.GetInt32(0);// Haalt kolomindex 0 op als 32-bits integer
                        scores.Add(score); // Voeg de score toe aan de lijst
                    }
                }
            }
            return scores;
        }


        public List<int> GetHighScoresMultiplayer()
        {
            List<int> scores = new List<int>();
            string sql = "SELECT TOP 5 Score FROM HighScoreMultiplayer ORDER BY Score DESC";

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int score = reader.GetInt32(0);
                        scores.Add(score);
                    }
                }
            }
            return scores;
        }

        public void InsertScoreSingleplayer(int score)
        {
           
            string sql = "INSERT INTO HighScoreSingleplayer (Score) VALUES (@Score)";

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Score", score);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void InsertScoreMultiplayer(int score)
        {
            
            string sql = "INSERT INTO HighScoreMultiplayer (Score) VALUES (@Score)";

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Score", score);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void UpdateScoreSingleplayer(int Score)
        {
            List<int> scores = GetHighScoresSingleplayer();

            // Als er nog geen 5 scores in de database zitten, doen we gewoon een INSERT
            if (scores.Count < 5)
            {
               InsertScoreSingleplayer(Score);
                return;
            }
            
            else
            {
                int lowestScore = scores.Min();// gebruiken dat hier omdat de lijst al gesorteerd is van hoog naar laag, dus de laagste score is de laatste in de lijst
                if (Score > lowestScore)
                {
                    //Als de nieuwe score hoger is dan de laagste score in de database, doen we een UPDATE
                    //gebruik van TOP (1) in de SQL query om alleen de eerste rij te updaten die voldoet aan de voorwaarde, zodat we niet per ongeluk meerdere rijen updaten als er meerdere dezelfde scores zijn
                    string sqlUpdate = @"UPDATE TOP (1) HighScoreSingleplayer SET Score = @NewScore WHERE Score = @OldScore";
                    using (SqlConnection connection = new SqlConnection(_connectionstring))
                    {
                        SqlCommand command = new SqlCommand(sqlUpdate, connection);
                        command.Parameters.AddWithValue("@NewScore", Score);
                        command.Parameters.AddWithValue("@OldScore", lowestScore);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

            }
            
        }

        public void UpdateScoreMultiplayer(int Score)
        {
            List<int> scores = GetHighScoresMultiplayer();

            
            if (scores.Count < 5)
            {
                InsertScoreMultiplayer(Score);
                return;
            }
        
            else
            {
                int lowestScore = scores.Min();// gebruiken dat hier omdat de lijst al gesorteerd is van hoog naar laag, dus de laagste score is de laatste in de lijst
                if (Score > lowestScore)
                {
                    //Als de nieuwe score hoger is dan de laagste score in de database, doen we een UPDATE
                    //gebruik van TOP (1) in de SQL query om alleen de eerste rij te updaten die voldoet aan de voorwaarde, zodat we niet per ongeluk meerdere rijen updaten als er meerdere dezelfde scores zijn
                    string sqlUpdate = @"UPDATE TOP (1) HighScoreMultiplayer SET Score = @NewScore WHERE Score = @OldScore";
                    using (SqlConnection connection = new SqlConnection(_connectionstring))
                    {
                        SqlCommand command = new SqlCommand(sqlUpdate, connection);
                        command.Parameters.AddWithValue("@NewScore", Score);
                        command.Parameters.AddWithValue("@OldScore", lowestScore);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

            }
        }

    }
}
