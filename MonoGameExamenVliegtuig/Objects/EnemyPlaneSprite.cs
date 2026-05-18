using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameExamenVliegtuig.Core.Objects;
using MonoGameExamenVliegtuig.Movementstrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Objects
{
    public class EnemyPlaneSprite : Sprite
    {
        private IPlaneMovementStratagy _movementStrategy;

        public EnemyPlaneSprite(Texture2D texture, Vector2 position, float speed,IPlaneMovementStratagy movementStrategy, float scale = 1) : base(texture, position, speed, scale)
        {
            _movementStrategy = movementStrategy;
        }
        public override void Update(GameTime gameTime)
        {
            _movementStrategy.update(this);
        }
    }
}
