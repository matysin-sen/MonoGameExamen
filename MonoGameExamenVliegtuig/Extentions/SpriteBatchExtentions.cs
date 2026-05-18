using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Extentions
{
    internal static class SpriteBatchExtentions
    {
        public static void Draw(this SpriteBatch spriteBatch, Texture2D texture, Vector2 vector)
        {
            spriteBatch.Draw(texture, vector, Color.White);
        }
        public static void Draw(this SpriteBatch spriteBatch, Texture2D texture, Vector2 vector, float scale)
        {
            spriteBatch.Draw(texture, vector, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
    }
}
