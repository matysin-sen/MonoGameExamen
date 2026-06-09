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
    // gebruiken factory pattern om enemys te maken, voor minder duplicatie en meer variatie
    public static class EnemyFactory
    {
       
            public static EnemyPlaneSprite Create(Texture2D texture, float x, float y, float speed, float scale, IPlaneMovementStrategy movementStrategy)
            {
                return Create(texture, new Vector2(x, y), speed, scale, movementStrategy);
            }
        

        public static EnemyPlaneSprite Create(Texture2D texture, Vector2 position, float speed, float scale, IPlaneMovementStrategy movementStrategy)
        {

            return new EnemyPlaneSprite(texture, position,speed, movementStrategy,scale);
        }

        public static HouseSprite CreateHouse(Texture2D houseTexture, float x, float y, float hOUSE_SPEED, float hOUSE_SCALE, IPlaneMovementStrategy movementStrategy)
        {

            
            return CreateHouse(houseTexture, new Vector2(x, y), hOUSE_SPEED, hOUSE_SCALE, movementStrategy);
        }
        public static HouseSprite CreateHouse(Texture2D texture, Vector2 position, float speed, float scale, IPlaneMovementStrategy movementStrategy)
        {
            return new HouseSprite(texture, position, speed, movementStrategy, scale);
        }

        public static TreeSprite CreateTree(Texture2D treeTexture, float x, float y, float tREES_SPEED, float tREES_SCALE, IPlaneMovementStrategy movementStrategy)
        {
            return CreateTree(treeTexture, new Vector2(x, y), tREES_SPEED, tREES_SCALE, movementStrategy);
        }

        public static TreeSprite CreateTree(Texture2D texture, Vector2 position, float speed, float scale , IPlaneMovementStrategy movementStrategy)
        {
            return new TreeSprite(texture, position, speed, movementStrategy, scale);
        }
    }
}
