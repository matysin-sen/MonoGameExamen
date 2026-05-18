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
    public static class EnemyFactory
    {
       
            public static EnemyPlaneSprite Create(Texture2D texture, float x, float y, float speed, float scale)
            {
                return Create(texture, new Vector2(x, y), speed, scale);
            }
        

        public static EnemyPlaneSprite Create(Texture2D texture, Vector2 position, float speed, float scale)
        {
            // OPGEPAST: De volgende code zal random een movementStrategy genereren, dit is iets wat je meegeeft aan de Create van de Factory en veelal gegenereerd door een klasse
            // Het hier random genereren is puur om het principe te tonen
            var r = Random.Shared.Next(3);
            IPlaneMovementStratagy movementStrategy = null;
            switch (r)
            {
                case 0: movementStrategy = new DiagonalMovementStrategy(); break;
                case 1: movementStrategy = new StraightMovementStrategy(); break;
                case 2: movementStrategy = new FastStraightMovementStrategy(); break;
            }

            return new EnemyPlaneSprite(texture, position,speed, movementStrategy,scale);
        }
    }
}
