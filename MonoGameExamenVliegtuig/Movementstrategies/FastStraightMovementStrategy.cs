using MonoGameExamenVliegtuig.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Movementstrategies
{
    public class FastStraightMovementStrategy : IPlaneMovementStratagy
    {
        public void update(EnemyPlaneSprite plane)
        {
            plane.UpdatePositionY(plane.Speed * 2);
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
