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
    public class MenuState : AbstractState
    {
        public MenuState(GameContext context) : base(context)
        {
        }

        

        public override void Update(GameTime gameTime)
        {
            if (IsKeyDown(Keys.NumPad1))// 1 speler
            {
                Context.ChangeState(new PlayState(Context));
            }
            if (IsKeyDown(Keys.NumPad2))// 2 spelers
            {
                Context.ChangeState(new PlayState(Context));
            }
            if (IsKeyDown(Keys.NumPad3))//topscores
            {
                Context.ChangeState(new PlayState(Context));
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Context.AssetsManager.GetFont(AssetsNames.GAME_FONT), "Menu. druk op 1 om 1 speler te starten.", Vector2.Zero, Color.White);
            spriteBatch.DrawString(Context.AssetsManager.GetFont(AssetsNames.GAME_FONT), "Menu. druk op 2 om 2 spelers te starten.", Vector2.One * 20, Color.White);
            spriteBatch.DrawString(Context.AssetsManager.GetFont(AssetsNames.GAME_FONT), "Menu. druk op 3 om de topscores te bekijken.", Vector2.One * 40, Color.White);
        }
    }
}