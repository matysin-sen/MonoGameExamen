using MonoGameExamenVliegtuig.Core.Scores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Core.Interface
{
    public interface IScoreRepository
    {
        List<Score> GetHighScoresSingleplayer();
        List<Score> GetHighScoresMultiplayer();
        void InsertScoreSingleplayer(Score score);
        void InsertScoreMultiplayer(Score score);
        void UpdateScoreSingleplayer(int score);
        void UpdateScoreMultiplayer(int score);
        public List<Score> GetHighScores(string mode);
        public void Dispose();
    }
}
