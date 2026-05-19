using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameExamenVliegtuig.Movementstrategies;
using MonoGameExamenVliegtuig.Objects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Objects
{
    public class TreeSprite : EnemySprite
    {
        private IPlaneMovementStratagy _movementStrategy;
       
    
        public TreeSprite(Texture2D texture, Vector2 position, float speed, IPlaneMovementStratagy movementStrategy, float scale = 1) : base(texture, position, speed, scale)
        {
            _movementStrategy = movementStrategy;
        }

        public override void Update()
        {
            _movementStrategy.update(this);
        }
    }
}
