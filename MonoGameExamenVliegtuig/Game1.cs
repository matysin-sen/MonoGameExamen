using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameExamenVliegtuig.Core.Graphics;
using MonoGameExamenVliegtuig.Core.Input;
using MonoGameExamenVliegtuig.Objects;
using MonoGameExamenVliegtuig.States;
using MonoGameExamenVliegtuig.States.Base;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace MonoGameExamenVliegtuig
{
    public class Game1 : Game
    {
      private GameContext _gameContext;
        private SpriteBatch _spriteBatch;

       

        
        public Game1()
        {
            GraphicsFacade.Initialize(this, width: 400, height: 650);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
           
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            string connectionstring = configuration.GetConnectionString("SQLServerConnection");
            string databaseType = configuration.GetSection("FileSettings")["databaseType"];

           
            _gameContext = new GameContext(this);
            _gameContext.ConnectionString = connectionstring;
            _gameContext.DatabaseType = databaseType;
            base.Initialize();
        }

        protected override void LoadContent()
        {
        
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            
              base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.X))
                Exit();

            KeyboardFacade.Update();  
            _gameContext.Update(gameTime);

            base.Update(gameTime);

            

        }
      

        protected override void Draw(GameTime gameTime)
        {
          GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _gameContext.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        
    }
}
