using MonoGameExamenVliegtuig.Core.Interface;
using MonoGameExamenVliegtuig.Core.Scores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonoGameExamenVliegtuig.Core.Scores
{
    public class ScoreManager
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreManager(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        // We geven nu een lijst van Scores terug in plaats van alleen ints
        public List<Score> GetHighScoresSingleplayer()
        {
            return _scoreRepository.GetHighScoresSingleplayer();
        }

        public List<Score> GetHighScoresMultiplayer()
        {
            return _scoreRepository.GetHighScoresMultiplayer();
        }

        // De Manager zorgt voor de creatie van het Score-object
        public void AddScore(int scoreValue, bool isMultiplayer)
        {

            if (isMultiplayer)
                _scoreRepository.UpdateScoreMultiplayer(scoreValue);
            else
                _scoreRepository.UpdateScoreSingleplayer(scoreValue);
        }
    }
}