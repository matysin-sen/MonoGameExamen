using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameExamenVliegtuig.Core.Graphics;
using MonoGameExamenVliegtuig.Core.Input;
using MonoGameExamenVliegtuig.Objects;
using MonoGameExamenVliegtuig.States;
using MonoGameExamenVliegtuig.States.Base;
using System;
using System.Runtime.Serialization;

namespace MonoGameExamenVliegtuig
{
    public class Game1 : Game
    {
      private GameContext _gameContext;
        private SpriteBatch _spriteBatch;

       
        int score = 0;
       

        
        public Game1()// Constructor for the Game1 class
        {
            GraphicsFacade.Initialize(this, width: 400, height: 650);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()// Method called when the game initializes(starts)
        {
            // TODO: Add your initialization logic here

            _gameContext = new GameContext(this);

            base.Initialize();
        }

        protected override void LoadContent()// Method called when the game loads content images, sounds, etc.
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
              base.LoadContent();
        }

        protected override void Update(GameTime gameTime)// Method called every frame to update the game logic, such as handling input, moving objects, etc.
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.X))
                Exit();

            KeyboardFacade.Update();  
            _gameContext.Update(gameTime);

            base.Update(gameTime);

            

        }
      

        protected override void Draw(GameTime gameTime)// Method called every frame to draw the game objects on the screen.
        {
          GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _gameContext.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        
    }
}
