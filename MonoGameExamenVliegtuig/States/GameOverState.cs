using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameExamenVliegtuig.Objects;
using MonoGameExamenVliegtuig.States.Base;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.States
{
    public class GameOverState : AbstractState
    {
        public GameOverState(GameContext context) : base(context)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (IsKeyDown(Keys.Escape))
            {
                Context.ChangeState(new MenuState(Context));
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //todo score weergeven en highscore weergeven
            spriteBatch.DrawString(Context.AssetsManager.GetFont(AssetsNames.GAME_FONT), "Game Over. druk op Escape om terug te keren naar het menu.", Vector2.Zero, Color.White);
        }
    }
}
