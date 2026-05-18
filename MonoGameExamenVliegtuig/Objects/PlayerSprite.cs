using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameExamenVliegtuig.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Objects
{
    public class PlayerSprite : Sprite
    {
        private IPlayerInputService _inputService;

        public PlayerSprite(Texture2D texture, Vector2 position, float speed, float scale,
                            IPlayerInputService inputService)
            : base(texture, position, speed, scale)
        {
            _inputService = inputService;
        }

        public override void Update()
        {
            if (_inputService.ShouldGoRight())
                UpdatePositionX(+Speed);

            if (_inputService.ShouldGoLeft())
                UpdatePositionX(-Speed);

            if (_inputService.ShouldGoUp())
                UpdatePositionY(-Speed);

            if (_inputService.ShouldGoDown())
                UpdatePositionY(+Speed);
        }
    }
}
