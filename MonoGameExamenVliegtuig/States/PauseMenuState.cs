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
        public PlayState PreviousState { get; init; }// Property to hold a reference to the previous state of the game, allowing the pause menu to return to the previous state when unpaused
        public PauseMenuState(GameContext context, PlayState previousState) : base(context)
        {
            PreviousState = previousState;
        }
        public override void Update(GameTime gameTime)// Method called every frame to update the game logic for the pause menu state, such as handling input to unpause the game
        {
            if (WasKeyJustPressed(Keys.Escape))
                Context.ChangeState(PreviousState);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)// Method called every frame to draw the pause menu on the screen, including the previous state in the background and a message prompting the player to press escape to unpause
        {
            PreviousState.Draw(gameTime, spriteBatch);

           
            spriteBatch.DrawString(Context.AssetsManager.GetFont(AssetsNames.GAME_FONT), "-- Pause --", new Vector2(100, 100), Color.White);
            spriteBatch.DrawString(Context.AssetsManager.GetFont(AssetsNames.GAME_FONT), $"Druk op escape \nom door te doen", new Vector2(50, 200), Color.White);// dit is voor aan te tonen dat het op meerdere manieren kan
        }
    }
}
