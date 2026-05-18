using MonoGameExamenVliegtuig.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Movementstrategies
{
    public interface IPlaneMovementStratagy
    {
        void update(EnemyPlaneSprite plane);
    }
}
