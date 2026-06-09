using Microsoft.Xna.Framework.Input;
using MonoGameExamenVliegtuig.Core.Input;
using MonoGameExamenVliegtuig.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Input
{
    public class SinglePlayerInputService : IPlayerInputService
    {
        
        // strikt scheiden van de input logica van de game logica, zodat we makkelijk kunnen switchen tussen single player en multiplayer
       

        public bool ShouldGoDown()
        {
            return KeyboardFacade.IsKeyDown(Keys.Down, Keys.S);
        }

        public bool ShouldGoLeft()
        {
            return KeyboardFacade.IsKeyDown(Keys.Left, Keys.Q);
        }

        public bool ShouldGoRight()
        {
            return KeyboardFacade.IsKeyDown(Keys.Right, Keys.D);
        }

        public bool ShouldGoUp()
        {
            return KeyboardFacade.IsKeyDown(Keys.Up, Keys.Z);
        }

        public bool shutDown()
        {
            return KeyboardFacade.IsKeyDown(Keys.X);
        }
    }
}
