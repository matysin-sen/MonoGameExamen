using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Core.Input
{
    public static class KeyboardFacade
    {
      
            private static KeyboardState _previous;
            private static KeyboardState _current;

            public static void Update()
            {
                _previous = _current;
                _current = Keyboard.GetState();
            }
        public static bool IsKeyDown(Keys key1, Keys key2)
           => IsKeyDown(key1) || IsKeyDown(key2);

        public static bool IsKeyDown(Keys key)
                => _current.IsKeyDown(key);

            public static bool WasKeyJustPressed(Keys key)
                => _current.IsKeyDown(key)
                   && !_previous.IsKeyDown(key);
        }
    }

