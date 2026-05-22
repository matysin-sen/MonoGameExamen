using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Core.Scores
{
    public class ScoreData
    {
        public List<int> SingleplayerScores { get; set; } = new List<int>();
        public List<int> MultiplayerScores { get; set; } = new List<int>();
    }
}
