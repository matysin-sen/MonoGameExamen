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
        private readonly GameContext _gameContext;
        public PlayerInputService(GameContext gameContext)
        {
            _gameContext = gameContext;
        }


        public bool ShouldGoRight()
        {
            if(_gameContext.IsMultiplayer == true)
            {
                return KeyboardFacade.IsKeyDown(Keys.D);
            }
            else
            {
                return KeyboardFacade.IsKeyDown(Keys.Right, Keys.D);
            }
            
        }

        public bool ShouldGoLeft()
        {
            if (_gameContext.IsMultiplayer == true)
            {
                return KeyboardFacade.IsKeyDown(Keys.Q);
            }
            else
            {
                return KeyboardFacade.IsKeyDown(Keys.Left, Keys.Q);
            }
               
        }

        public bool ShouldGoUp()
        {
            if (_gameContext.IsMultiplayer == true)
            {
                return KeyboardFacade.IsKeyDown(Keys.Z);
            }
            else
            {
                return KeyboardFacade.IsKeyDown(Keys.Up, Keys.Z);
            }
        }

        public bool ShouldGoDown()
        {
            if (_gameContext.IsMultiplayer == true)
            {
                return KeyboardFacade.IsKeyDown(Keys.S);
            }
            else
            {
                return KeyboardFacade.IsKeyDown(Keys.Down, Keys.S);
            }
        }

        public bool shutDown()
        {
            return KeyboardFacade.IsKeyDown(Keys.X);
        }
    }
}
