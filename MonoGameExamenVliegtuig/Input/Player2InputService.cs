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
    public class Player2InputService : IPlayerInputService
    {
        private readonly GameContext _gameContext;

        public Player2InputService(GameContext gameContext)
        {
            _gameContext = gameContext;
        }
        public bool ShouldGoRight()
        {
            return KeyboardFacade.IsKeyDown(Keys.Right);
        }

        public bool ShouldGoLeft()
        {
            return KeyboardFacade.IsKeyDown(Keys.Left);
        }

        public bool ShouldGoUp()
        {
            return KeyboardFacade.IsKeyDown(Keys.Up);
        }

        public bool ShouldGoDown()
        {
            return KeyboardFacade.IsKeyDown(Keys.Down);
        }
        public bool shutDown() => false;
    }
}
