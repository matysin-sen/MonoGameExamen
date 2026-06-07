using LiteDB;
using MonoGameExamenVliegtuig.Core.Interface;
using MonoGameExamenVliegtuig.Core.Scores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonoGameExamenVliegtuig.Core.Repository
{
    public class ScoreRepository : IScoreRepository, IDisposable
    {
        private const string DatabasePath = "scores.db";
        // Gebruik Lazy zoals in de cursus om de verbinding pas te openen bij gebruik
        private static Lazy<LiteDatabase> _liteDBScores;

        // Eén collectie "PuntJes" zoals vereist
        private ILiteCollection<Score> PuntJes => _liteDBScores.Value.GetCollection<Score>("PuntJes");

        public ScoreRepository()
        {
            _liteDBScores = new Lazy<LiteDatabase>(() => new LiteDatabase(DatabasePath));
        }

        // Helper methode om de top 5 op te halen
        public List<Score> GetHighScores(string mode)
        {
            return PuntJes.Query()
                          .Where(s => s.Mode == mode)
                          .OrderByDescending(s => s.Value)
                          .Limit(5)
                          .ToList();
        }

        public List<Score> GetHighScoresSingleplayer() => GetHighScores("singleplayer");
        public List<Score> GetHighScoresMultiplayer() => GetHighScores("multiplayer");

        public void InsertScoreSingleplayer(Score score)
        {
            score.Mode = "singleplayer";
            PuntJes.Insert(score);
        }

        public void InsertScoreMultiplayer(Score score)
        {
            score.Mode = "multiplayer";
            PuntJes.Insert(score);
        }

        public void UpdateScoreSingleplayer(int scoreValue)
        {
            var topScores = GetHighScores("singleplayer");
            // Logica: bij < 5 toevoegen, anders de kleinste vervangen
            if (topScores.Count < 5)
            {
                InsertScoreSingleplayer(new Score { Value = scoreValue });
            }
            else if (scoreValue > topScores.Last().Value)
            {
                PuntJes.Delete(topScores.Last().Id);
                InsertScoreSingleplayer(new Score { Value = scoreValue });
            }
        }

        public void UpdateScoreMultiplayer(int scoreValue)
        {
            var topScores = GetHighScores("multiplayer");
            if (topScores.Count < 5)
            {
                InsertScoreMultiplayer(new Score { Value = scoreValue });
            }
            else if (scoreValue > topScores.Last().Value)
            {
                PuntJes.Delete(topScores.Last().Id);
                InsertScoreMultiplayer(new Score { Value = scoreValue });
            }
        }

        public void Dispose()
        {
            if (_liteDBScores.IsValueCreated)
            {
                _liteDBScores.Value.Dispose();
            }
        }
    }
}