using MonoGameExamenVliegtuig.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Movementstrategies
{
    public interface IPlaneMovementStrategy
    {
        void update(EnemyPlaneSprite plane);
        void update(HouseSprite houseSprite);
        void update(TreeSprite treeSprite);
    }
}
