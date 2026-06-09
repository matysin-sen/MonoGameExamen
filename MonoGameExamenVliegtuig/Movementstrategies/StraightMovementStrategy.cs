using MonoGameExamenVliegtuig.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Movementstrategies
{
    public class StraightMovementStrategy : IPlaneMovementStrategy
    {
        //gebruik stategy parttern om de gedrag van de enemys te veranderen zonder dat de enymy class zelf hoeft te veranderen en weet hoe hij beweegt
        public void update(EnemyPlaneSprite plane)
        {
                plane.UpdatePositionY(plane.Speed);
        }

        public void update(HouseSprite houseSprite)
        {
            houseSprite.UpdatePositionY(houseSprite.Speed);
        }

        public void update(TreeSprite treeSprite)
        {
            treeSprite.UpdatePositionY(treeSprite.Speed);
        }
    }
}
