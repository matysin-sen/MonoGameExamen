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
    public class MenuState : AbstractState
    {
        public MenuState(GameContext context) : base(context)
        {
        }

        

        public override void Update(GameTime gameTime)
        {
            if (IsKeyDown(Keys.NumPad1))// 1 speler
            {
                Context.ChangeState(new PlayState(Context));
            }
            if (IsKeyDown(Keys.NumPad2))// 2 spelers
            {
                Context.ChangeState(new PlayState(Context));
            }
            if (IsKeyDown(Keys.NumPad3))//topscores
            {
                Context.ChangeState(new PlayState(Context));
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // 1. Teken de achtergrond van het spel
            var bgTexture = Context.AssetsManager.GetTexture(AssetsNames.BACKGROUND_TEXTURE);
            spriteBatch.Draw(bgTexture, Vector2.Zero, GameSettings.BACKGROUND_SCALE);

            // 2. Haal het lettertype op
            SpriteFont font = Context.AssetsManager.GetFont(AssetsNames.GAME_FONT);

            // 3. Definieer de teksten (ik heb ze iets korter en krachtiger gemaakt)
            string title = "- MENU -";
            string text1 = "Druk op 1: 1 Speler";
            string text2 = "Druk op 2: 2 Spelers";
            string text3 = "Druk op 3: Topscores";

            // 4. Centreer en teken de Titel (bovenaan)
            Vector2 titleSize = font.MeasureString(title);
            float titleX = (400 - titleSize.X) / 2f;
            spriteBatch.DrawString(font, title, new Vector2(titleX, 150), Color.Yellow);

            // 5. Centreer en teken Optie 1
            Vector2 size1 = font.MeasureString(text1);
            float x1 = (400 - size1.X) / 2f; // 400 is je schermbreedte
            spriteBatch.DrawString(font, text1, new Vector2(x1, 250), Color.White);

            // 6. Centreer en teken Optie 2
            Vector2 size2 = font.MeasureString(text2);
            float x2 = (400 - size2.X) / 2f;
            spriteBatch.DrawString(font, text2, new Vector2(x2, 300), Color.White);

            // 7. Centreer en teken Optie 3
            Vector2 size3 = font.MeasureString(text3);
            float x3 = (400 - size3.X) / 2f;
            spriteBatch.DrawString(font, text3, new Vector2(x3, 350), Color.White);
        }
    }
}