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
        protected GameContext Context { get; init; }
        
        public AbstractState(GameContext context)
        {
            Context = context;
        }

        public abstract void Update(GameTime gameTime); 

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        protected bool IsKeyDown(Keys key1, Keys key2)
            => IsKeyDown(key1) || IsKeyDown(key2);
        
        protected bool IsKeyDown(Keys key)
        => Keyboard.GetState().IsKeyDown(key);

        protected bool WasKeyJustPressed(Keys key)
        => KeyboardFacade.WasKeyJustPressed(key);

    }
}
