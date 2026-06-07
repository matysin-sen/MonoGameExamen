using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Core.Scores
{
    public class Score
    {
        public int Value { get; set; }
        public string Mode { get; set; }

        public int Id { get; set; }// nodig voor liteDB

        public Score()
        {
          
        }
    }
}
