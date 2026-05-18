using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameExamenVliegtuig.Movementstrategies;
using MonoGameExamenVliegtuig.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Factories
{
    public class EnemyFactory
    {
       
            public EnemyPlaneSprite Create(Texture2D texture, float x, float y, float speed, float scale)
            {
                return new EnemyPlaneSprite(texture, new Vector2(x, y), speed, scale);
            }
        

        public EnemyPlaneSprite Create(Texture2D texture, float x, float y, float speed, float scale)
        {
            IPlaneMovementStratagy movementStrategy;


            if (Random.Shared.Next(2) == 0)
            {
                movementStrategy = new StraightMovementStrategy();
            }
            else
            {
                movementStrategy = new DiagonalMovementStrategy();
            }

            return new EnemyPlaneSprite(texture, new Vector2(x, y), movementStrategy);
        }
    }
}
