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
    public class PauseMenuState : AbstractState
    {
        public PlayState PreviousState { get; init; }
        public PauseMenuState(GameContext context, PlayState previousState) : base(context)
        {
            PreviousState = previousState;
        }
        public override void Update(GameTime gameTime)
        {
            if (WasKeyJustPressed(Keys.Escape))
                Context.ChangeState(PreviousState);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            PreviousState.Draw(gameTime, spriteBatch);

           
            spriteBatch.DrawString(Context.AssetsManager.GetFont(AssetsNames.GAME_FONT), "-- Pause --", new Vector2(100, 100), Color.White);
            spriteBatch.DrawString(Context.AssetsManager.GetFont(AssetsNames.GAME_FONT), $"Druk op escape \nom door te doen", new Vector2(50, 200), Color.White);// dit is voor aan te tonen dat het op meerdere manieren kan
        }
    }
}
