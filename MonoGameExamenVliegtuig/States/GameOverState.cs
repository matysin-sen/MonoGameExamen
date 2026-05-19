using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameExamenVliegtuig.Extentions;
using MonoGameExamenVliegtuig.Objects;
using MonoGameExamenVliegtuig.States.Base;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.States
{
    public class GameOverState : AbstractState
    {
        public GameOverState(GameContext context) : base(context)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (IsKeyDown(Keys.Escape))
            {
                Context.ChangeState(new MenuState(Context));
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //todo score weergeven en highscore weergeven

            var bgTexture = Context.AssetsManager.GetTexture(AssetsNames.BACKGROUND_TEXTURE);
            spriteBatch.Draw(bgTexture, Vector2.Zero, GameSettings.BACKGROUND_SCALE);

            // 2. Haal het lettertype op
            SpriteFont font = Context.AssetsManager.GetFont(AssetsNames.GAME_FONT);

            string gameOverText = "Game Over";
            string scoreText = $"Score: {Context.Score}";
            string escapeText = "Press ESC to return to menu";
            // string highScoreText = $"High Score: {Context.HighScore}"; top 5 moet weergeven 
            Vector2 gameOverSize = font.MeasureString(gameOverText);
            Vector2 scoreSize = font.MeasureString(scoreText);
            Vector2 escapeSize = font.MeasureString(escapeText);
            float titleX = (400 - gameOverSize.X) / 2f;
            float scoreX = (400 - scoreSize.X) / 2f;
            float escapeX = (400 - escapeSize.X) / 2f;
            spriteBatch.DrawString(font, gameOverText, new Vector2(titleX, 150), Color.Yellow);
            spriteBatch.DrawString(font, scoreText, new Vector2(scoreX, 200), Color.White);
            spriteBatch.DrawString(font, escapeText, new Vector2(escapeX, 250), Color.White);
        }
    }
}
