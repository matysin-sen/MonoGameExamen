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
            plane.UpdatePositionX(-plane.Speed * 2);
        }
    }
}
