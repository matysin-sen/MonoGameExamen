using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameExamenVliegtuig.Objects;
using MonoGameExamenVliegtuig.States.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.States
{
    public class TopScoreState : AbstractState
    {
        private List<int> SingleplayerScores;
        private List<int> MultiplayerScores;
  
        public TopScoreState(GameContext context) : base(context)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
