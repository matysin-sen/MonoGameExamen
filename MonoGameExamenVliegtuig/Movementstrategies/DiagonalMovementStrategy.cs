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
        public void update(EnemyPlaneSprite plane)
        {
           plane.UpdatePosition(plane.Speed*0.25F, plane.Speed);
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
