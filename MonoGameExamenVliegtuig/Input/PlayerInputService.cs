using Microsoft.Xna.Framework.Input;
using MonoGameExamenVliegtuig.Core.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Input
{
    public class PlayerInputService: IPlayerInputService
    {
        public bool ShouldGoRight()
        {
            return KeyboardFacade.IsKeyDown(Keys.Right, Keys.D);
        }

        public bool ShouldGoLeft()
        {
            return KeyboardFacade.IsKeyDown(Keys.Left, Keys.Q);
        }

        public bool ShouldGoUp()
        {
            return KeyboardFacade.IsKeyDown(Keys.Up, Keys.Z);
        }

        public bool ShouldGoDown()
        {
            return KeyboardFacade.IsKeyDown(Keys.Down, Keys.S);
        }
    }
}
