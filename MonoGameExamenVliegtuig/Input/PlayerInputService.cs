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
    public class PlayerInputService: IPlayerInputService
    {
        
        public PlayerInputService()
        {
            
        }


        public bool ShouldGoRight()
        {
                return KeyboardFacade.IsKeyDown(Keys.D);
        }

        public bool ShouldGoLeft()
        {
                return KeyboardFacade.IsKeyDown(Keys.Q);

        }

        public bool ShouldGoUp()
        {
            
                return KeyboardFacade.IsKeyDown(Keys.Z);
            
           
        }

        public bool ShouldGoDown()
        {
            
                return KeyboardFacade.IsKeyDown(Keys.S);
            
           
        }

        public bool shutDown()
        {
            return KeyboardFacade.IsKeyDown(Keys.X);
        }
    }
}
