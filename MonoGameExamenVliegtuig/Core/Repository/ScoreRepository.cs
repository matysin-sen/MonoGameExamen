using MonoGameExamenVliegtuig.Core.Interface;
using System;
using System.Collections.Generic;
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

        public void GetHighScoresSingleplayer()
        {
            //todo connectie maken met database en de top 5 scores ophalen
        }

        public void GetHighScoresMultiplayer()
        {
            //todo connectie maken met database en de top 5 scores ophalen
        }

        public void UpdateScoreSingleplayer(int score)
        {
            //todo connectie maken met database en de score opslaan
        }

        public void UpdateScoreMultiplayer(int score)
        {
            //todo connectie maken met database en de score opslaan
        }

        
    }
}
