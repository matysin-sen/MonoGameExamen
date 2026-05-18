using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameExamenVliegtuig.Core.Graphics;
using MonoGameExamenVliegtuig.Input;
using MonoGameExamenVliegtuig.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Factories
{
    public class PlayerFactory
    {
        public static PlayerSprite CreatePlayerInVerticalCenter(Texture2D texture, float speed, float scale, IPlayerInputService inputService)
        {
            return CreatePlayer(texture, GraphicsFacade.GetWindowVerticalCenter(), speed, scale, inputService);
        }

        public static PlayerSprite CreatePlayer(Texture2D texture, float y, float speed, float scale, IPlayerInputService inputService)
        {
            return new PlayerSprite(texture,
                                    new Vector2(0, y),
                                    speed,
                                    scale,
                                    inputService);
        }
    }
}
