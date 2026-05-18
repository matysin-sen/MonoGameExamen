using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameExamenVliegtuig.Core.Input;
using MonoGameExamenVliegtuig.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.States.Base
{
    public abstract class AbstractState
    {
        protected GameContext Context { get; init; }// Property to hold a reference to the main game context, allowing derived states to access game resources and functionality
        
        public AbstractState(GameContext context)
        {
            Context = context;
        }

        public abstract void Update(GameTime gameTime); // Abstract method to be implemented by derived states for updating game logic, such as handling input, moving objects, etc.

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);// Abstract method to be implemented by derived states for drawing game objects on the screen.

        protected bool IsKeyDown(Keys key1, Keys key2)// Method to check if either of the two specified keys is currently pressed down
            => IsKeyDown(key1) || IsKeyDown(key2);
        
        protected bool IsKeyDown(Keys key)// Method to check if a specific key is currently pressed down
        => Keyboard.GetState().IsKeyDown(key);

        protected bool WasKeyJustPressed(Keys key)// Method to check if a specific key was just pressed in the current frame (i.e., it is currently down but was not down in the previous frame)
        => KeyboardFacade.WasKeyJustPressed(key);

    }
}
