using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameExamenVliegtuig.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Objects.Base
{
    public class EnemySprite : Sprite
    {
        public EnemySprite(Texture2D texture, Vector2 position, float speed, float scale = 1) : base(texture, position, speed, scale)
        {
        }
    }
}
