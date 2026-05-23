using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameExamenVliegtuig.Core.Repository;
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
        public List<int> Scores;
        public GameOverState(GameContext context) : base(context)
        {
            ScoreRepository repository = new ScoreRepository(Context.ConnectionString);

            if (Context.IsMultiplayer)//checken of we in multiplayer modus zitten, zodat we de juiste score kunnen updaten
            {
                repository.UpdateScoreMultiplayer(Context.Score);
                Scores = repository.GetHighScoresMultiplayer();
            }
            else
            {
                repository.UpdateScoreSingleplayer(Context.Score);
                Scores = repository.GetHighScoresSingleplayer();
            }
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
            Vector2 gameOverSize = font.MeasureString(gameOverText);
            Vector2 scoreSize = font.MeasureString(scoreText);
            Vector2 escapeSize = font.MeasureString(escapeText);
            float titleX = (400 - gameOverSize.X) / 2f;
            float scoreX = (400 - scoreSize.X) / 2f;
            float escapeX = (400 - escapeSize.X) / 2f;
            spriteBatch.DrawString(font, gameOverText, new Vector2(titleX, 150), Color.Yellow);
            spriteBatch.DrawString(font, escapeText, new Vector2(escapeX, 200), Color.White);
            spriteBatch.DrawString(font, scoreText, new Vector2(scoreX, 250), Color.White);
            if (Context.IsMultiplayer)
            {
                for (int i = 0; i < Scores.Count; i++)
                {
                    string highScoreText = $"High Score {i + 1}: {Scores[i]}";
                    Vector2 highScoreSize = font.MeasureString(highScoreText);
                    float highScoreX = (400 - highScoreSize.X) / 2f;
                    spriteBatch.DrawString(font, highScoreText, new Vector2(highScoreX, 300 + i * 30), Color.White);
                }
            }
            else
            {
                for (int i = 0; i < Scores.Count; i++)
                {
                    string highScoreText = $"High Score {i + 1}: {Scores[i]}";
                    Vector2 highScoreSize = font.MeasureString(highScoreText);
                    float highScoreX = (400 - highScoreSize.X) / 2f;
                    spriteBatch.DrawString(font, highScoreText, new Vector2(highScoreX, 300 + i * 30), Color.White);
                }

            }

        }
    }
}
