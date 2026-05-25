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

        public static HouseSprite CreateHouse(Texture2D houseTexture, float x, float y, float hOUSE_SPEED, float hOUSE_SCALE)
        {

            
            return CreateHouse(houseTexture, new Vector2(x, y), hOUSE_SPEED, hOUSE_SCALE);
        }
        public static HouseSprite CreateHouse(Texture2D texture, Vector2 position, float speed, float scale)
        {
           
         
            IPlaneMovementStratagy movementStrategy = new StraightMovementStrategy();

            return new HouseSprite(texture, position, speed, movementStrategy, scale);
        }

        public static TreeSprite CreateTree(Texture2D treeTexture, float x, float y, float tREES_SPEED, float tREES_SCALE)
        {
            return CreateTree(treeTexture, new Vector2(x, y), tREES_SPEED, tREES_SCALE);
        }

        public static TreeSprite CreateTree(Texture2D texture, Vector2 position, float speed, float scale)
        {


            IPlaneMovementStratagy movementStrategy = new StraightMovementStrategy();

            return new TreeSprite(texture, position, speed, movementStrategy, scale);
        }
    }
}
