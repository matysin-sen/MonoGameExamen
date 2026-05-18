using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameExamenVliegtuig.States.Base;
using System.Runtime.Serialization;

namespace MonoGameExamenVliegtuig
{
    public class Game1 : Game
    {
        // const voor game configuratie
   






        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _backgroundSprite;
        private Texture2D _playerSprite;
        private Texture2D _enemySprite1;
        private Texture2D _enemySprite2;
        private Texture2D _houseSpriteB;
        private Texture2D _houseSpriteR;
        private Texture2D _treeSprite;
        private Texture2D _treesSprite;
        private SpriteFont _gameFont;

        private AbstractState _currentState;// Variable to hold the current state of the game, allowing for state management and transitions between different game states (e.g., menu, gameplay, game over)

        Vector2 _enemyPosition1 = new Vector2(100, 100);// Position of the enemy plane
        const int enemyRadius = 16;// Radius of the enemy plane for collision detection
        MouseState mouseState;// Variable to store the current state of the mouse
        int score = 0;
        bool mouseReleased = true;// Variable to track if the mouse button has been released

        public void ChangeState(AbstractState newActiveState)
        {
            _currentState = newActiveState;
        }
        public Game1()// Constructor for the Game1 class
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 600;// Set the preferred width of the game window
            _graphics.PreferredBackBufferHeight = 800;// Set the preferred height of the game window
            _graphics.ApplyChanges();// Apply the changes to the graphics settings
        }

        protected override void Initialize()// Method called when the game initializes(starts)
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()// Method called when the game loads content images, sounds, etc.
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _backgroundSprite = Content.Load<Texture2D>("background");// Load the background sprite from the Content folder
            _playerSprite = Content.Load<Texture2D>("plane");
            _enemySprite1 = Content.Load<Texture2D>("enemy_plane1");
            _enemySprite2 = Content.Load<Texture2D>("enemy_plane2");
            _houseSpriteB = Content.Load<Texture2D>("house_blue");
            _houseSpriteR = Content.Load<Texture2D>("house_red");
            _treeSprite = Content.Load<Texture2D>("tree");
            _treesSprite = Content.Load<Texture2D>("trees");
            _gameFont = Content.Load<SpriteFont>("game-font");
        }

        protected override void Update(GameTime gameTime)// Method called every frame to update the game logic, such as handling input, moving objects, etc.
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            // TODO: Add your update logic here
            mouseState = Mouse.GetState();// Get the current state of the mouse

            if(mouseState.LeftButton == ButtonState.Pressed && mouseReleased == true)// Check if the left mouse button is pressed
            {
               mouseReleased = false;
            }
            if(mouseState.LeftButton == ButtonState.Released)// Check if the left mouse button is released
            {
                mouseReleased = true;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)// Method called every frame to draw the game objects on the screen.
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();// Begin the sprite batch to start drawing sprites
            _spriteBatch.Draw(_backgroundSprite, new Vector2(0, 0), Color.White);// Draw the background sprite at position (0, 0) with white color tint
            _spriteBatch.DrawString(_gameFont, "Test message", new Vector2(100, 100), Color.White);// Draw the score text at position (100, 100) with white color
            _spriteBatch.Draw(_enemySprite1, _enemyPosition1, Color.White);// Draw the enemy plane sprite at its position with white color tint
            _spriteBatch.Draw(_playerSprite, new Vector2(0, 0), Color.White);// Draw the player sprite at position (0, 0) with white color tint
            // TODO: Add your drawing code here
            _spriteBatch.End();// End the sprite batch to finish drawing sprites

            base.Draw(gameTime);
        }
    }
}
