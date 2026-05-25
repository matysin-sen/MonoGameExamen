using MonoGameExamenVliegtuig.Core.Exeptions;
using MonoGameExamenVliegtuig.Core.Graphics;
using MonoGameExamenVliegtuig.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Movementstrategies
{
    public class DiagonalMovementStrategy : IPlaneMovementStratagy
    {
        private float richtingX = 1f; // 1f betekent dat het naar rechts gaat, -1f betekent dat het naar links gaat

        public void update(EnemyPlaneSprite plane)
        {
           plane.UpdatePosition((plane.Speed*0.5F)*richtingX, plane.Speed);

            if (plane.Position.X <= 0) // Controleer of het vliegtuig de rand van het scherm heeft bereikt
            {
                richtingX *= 1f; // Verander de richting
            }
            float vliegtuigBreedte = plane.Texture.Width * plane.Scale; // Neem aan dat de breedte van het vliegtuig gelijk is aan de breedte van de texture vermenigvuldigd met de schaal
            if(plane.Position.X >= GraphicsFacade.GetWindowWidth() - vliegtuigBreedte) // Controleer of het vliegtuig de andere rand van het scherm heeft bereikt 
            {
                richtingX = -1f; // Verander de richting
            }
        }

        public void update(HouseSprite houseSprite)
        {
            throw new NotImplementedException();
        }

        public void update(TreeSprite treeSprite)
        {
            throw new NotImplementedException();
        }
    }
}
