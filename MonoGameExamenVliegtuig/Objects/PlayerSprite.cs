using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameExamenVliegtuig.Core.Graphics;
using MonoGameExamenVliegtuig.Core.Objects;
using MonoGameExamenVliegtuig.Input;
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
            float spelerBreedte = Texture.Width * Scale;
            float spelerHoogte = Texture.Height * Scale;
            // heb dit nodig voor te weten als de speler tegen de rand van het scherm aan zit, zodat hij niet verder kan bewegen in die richting
            if (_inputService.ShouldGoRight()&& Position.X < GraphicsFacade.GetWindowWidth() - spelerBreedte)
                UpdatePositionX(+Speed);

            if (_inputService.ShouldGoLeft() && Position.X > 0)//zorgt ervoor dat de speler niet voorbij de linkerkant kan 0 omdat dat volledig links is
                UpdatePositionX(-Speed);

            if (_inputService.ShouldGoUp() && Position.Y > 0)//zet dit hier omdat het private setter zijnt en ik dus niet zomaar kan zeggen Position.Y-- ofzo
                UpdatePositionY(-Speed);

            if (_inputService.ShouldGoDown() && Position.Y < GraphicsFacade.GetWindowHeight() - spelerHoogte)
                UpdatePositionY(+Speed);

            if(_inputService.shutDown())
                Environment.Exit(0);//sluit het spel af
                                 
          

        }
    }
}
