using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameExamenVliegtuig.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Core.Objects
{
    public class Sprite
    {
        
        protected const float NO_SCALE = 1f;//

        public Texture2D Texture { get; init; }//initialiseren de texture2d
        public Vector2 Position { get; private set; }
        public float Speed { get; init; }
        public float Scale { get; init; }
       
        public Sprite(Texture2D texture, Vector2 position, float speed, float scale = NO_SCALE)
        {
            Texture = texture;
            Position = position;
            Speed = speed;
            Scale = scale;
        }
        
        public virtual void Update()
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Scale);
        }

        public void UpdatePosition(float xChange, float yChange)
        {
            Position = Position with
            {
                X = Position.X + xChange,
                Y = Position.Y + yChange
            };
        }

        public void UpdatePositionX(float xChange)
            => UpdatePosition(xChange, 0);

        public void UpdatePositionY(float yChange)
            => UpdatePosition(0, yChange);
    }
}
