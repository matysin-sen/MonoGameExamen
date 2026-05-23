using Microsoft.Extensions.Configuration;
using MonoGameExamenVliegtuig.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Core.Scores
{
    public class ScoreManager
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreManager(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }
        // Deze methoden zijn verantwoordelijk voor het ophalen, invoegen en bijwerken van scores in de database via de IScoreRepository-interface.
        public List<int> GetHighScoresSingleplayer()
        {
            return _scoreRepository.GetHighScoresSingleplayer();
        }
        public List<int> GetHighScoresMultiplayer()
        {
            return _scoreRepository.GetHighScoresMultiplayer();
        }

        public void InsertScoreSingleplayer(int score)
        {
            _scoreRepository.InsertScoreSingleplayer(score);
        }

        public void InsertScoreMultiplayer(int score)
        {
            _scoreRepository.InsertScoreMultiplayer(score);
        }

        public void UpdateScoreSingleplayer(int score)
        {
            _scoreRepository.UpdateScoreSingleplayer(score);
        }

        public void UpdateScoreMultiplayer(int score)
        {
            _scoreRepository.UpdateScoreMultiplayer(score);
        }
    }
}
