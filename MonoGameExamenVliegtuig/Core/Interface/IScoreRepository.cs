using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Core.Interface
{
    public interface IScoreRepository
    {
        List<int> GetHighScoresSingleplayer();
        List<int> GetHighScoresMultiplayer();
        void InsertScoreSingleplayer(int score);
        void InsertScoreMultiplayer(int score);
        void UpdateScoreSingleplayer(int Score);
        void UpdateScoreMultiplayer(int Score);
    }
}
