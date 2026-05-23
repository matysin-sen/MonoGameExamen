using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameExamenVliegtuig.Core.Graphics;
using MonoGameExamenVliegtuig.Core.Repository;
using MonoGameExamenVliegtuig.Extentions;
using MonoGameExamenVliegtuig.Objects;
using MonoGameExamenVliegtuig.States.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.States
{
    public class TopScoreState : AbstractState
    {
        private List<int> SingleplayerScores;
        private List<int> MultiplayerScores;
        private float textsize = 0.5f;
        public TopScoreState(GameContext context) : base(context)
        {
            ScoreRepository repisitory = new ScoreRepository(context.ConnectionString);
            SingleplayerScores = repisitory.GetHighScoresSingleplayer();
            MultiplayerScores = repisitory.GetHighScoresMultiplayer();
          
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var bgTexture = Context.AssetsManager.GetTexture(AssetsNames.BACKGROUND_TEXTURE);
            spriteBatch.Draw(bgTexture, Vector2.Zero, GameSettings.BACKGROUND_SCALE);
            SpriteFont font = Context.AssetsManager.GetFont(AssetsNames.GAME_FONT);
            
            string title = "- TOP SCORES -";
            Vector2 titleSize = font.MeasureString(title);
            spriteBatch.DrawString(font, title, new Vector2((GraphicsFacade.GetWindowWidth() - titleSize.X) / 2, 50), Color.White);     
            // Teken singleplayer scores
            string singleplayerTitle = "Singleplayer:";
            Vector2 singleplayerTitleSize = font.MeasureString(singleplayerTitle);
            spriteBatch.DrawString(font, singleplayerTitle, new Vector2(80, 150), Color.White,0f, Vector2.Zero, textsize, SpriteEffects.None, 0f);
            for (int i = 0; i < SingleplayerScores.Count; i++)//kan hier ook een methode maken die de scores tekent, aangezien dit ook voor multiplayer scores gebeurt
            {
                string scoreText = $"{i + 1}. {SingleplayerScores[i]}";
                spriteBatch.DrawString(font, scoreText, new Vector2(100, 200 + i * 30), Color.White, 0f, Vector2.Zero, textsize, SpriteEffects.None, 0f);
            }
            // Teken multiplayer scores
            string multiplayerTitle = "Multiplayer:";
            Vector2 multiplayerTitleSize = font.MeasureString(multiplayerTitle);
            spriteBatch.DrawString(font, multiplayerTitle, new Vector2(250, 150), Color.White, 0f, Vector2.Zero, textsize, SpriteEffects.None, 0f);
            for (int i = 0; i < MultiplayerScores.Count; i++)
            {
                string scoreText = $"{i + 1}. {MultiplayerScores[i]}";
                spriteBatch.DrawString(font, scoreText, new Vector2(300, 200 + i * 30), Color.White, 0f, Vector2.Zero, textsize, SpriteEffects.None, 0f);
            }
            // Instructie om terug te keren naar het menu
            string escapeText = "Press ESC to return to menu";
            Vector2 escapeTextSize = font.MeasureString(escapeText);
            spriteBatch.DrawString(font, escapeText, new Vector2((GraphicsFacade.GetWindowWidth() - escapeTextSize.X)/100, GraphicsFacade.GetWindowHeight() - 50), Color.White, 0f, Vector2.Zero, 0.65f, SpriteEffects.None, 0f);

        }

        public override void Update(GameTime gameTime)
        {
            // Ga terug naar het hoofdmenu als de speler op ESCAPE of BACKSPACE drukt
            if (WasKeyJustPressed(Keys.Escape) || WasKeyJustPressed(Keys.Back))
            {
                Context.ChangeState(new MenuState(Context));
            }
        }
    }
}
