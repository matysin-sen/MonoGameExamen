using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameExamenVliegtuig.Core.Graphics;
using MonoGameExamenVliegtuig.Extentions;
using MonoGameExamenVliegtuig.Objects;
using MonoGameExamenVliegtuig.Spawners;
using MonoGameExamenVliegtuig.States.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.States
{
    public  class PlayState : AbstractState
    {
        private readonly EnemySpawner _enemySpawner;//spawner van enemys

        public PlayState(GameContext context)
            : base(context)
        {
            _enemySpawner = new EnemySpawner(
                context.Enemies,
                context.AssetsManager.GetTexture(AssetsNames.ENEMY_PLANE1_TEXTURE));
               
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Zet the background om naar een sprite
            UpdateBackgroundPosition();

            Context.Player.Update();

            foreach (var enemy in Context.Enemies)
                enemy.Update();

           
            // 1. Maak een onzichtbare rechthoek (hitbox) rondom de speler
            Rectangle playerRect = new Rectangle(
                (int)Context.Player.Position.X,
                (int)Context.Player.Position.Y,
                (int)(Context.Player.Texture.Width * Context.Player.Scale),
                (int)(Context.Player.Texture.Height * Context.Player.Scale)
            );

            // 2. Loop door alle vijanden heen om te kijken of ze de speler raken
            foreach (var enemy in Context.Enemies)
            {
                // Maak een hitbox rondom de huidige vijand
                Rectangle enemyRect = new Rectangle(
                    (int)enemy.Position.X,
                    (int)enemy.Position.Y,
                    (int)(enemy.Texture.Width * enemy.Scale),
                    (int)(enemy.Texture.Height * enemy.Scale)
                );

                // 3. Controleer of de hitbox van de speler die van de vijand raakt (Intersects)
                if (playerRect.Intersects(enemyRect))
                {
                    // Ja! Ze raken elkaar. Verander de status naar GameOver.
                    Context.ChangeState(new GameOverState(Context));

                    // Zodra je af bent, hoef je de andere vliegtuigen niet meer te checken
                    break;
                }
            }
            Context.Enemies.RemoveAll(enemy => enemy.Position.Y > 650);// ruimt alle vlietuigen op die onder het scherm zijn, zodat ze niet oneindig in de lijst blijven staan
            _enemySpawner.Update(gameTime);

            // TODO: Als een object links uit beeld is, dan mag deze uit de lijst. Nu blijven de haaien oneindig in de lijst staan, ook al zijn ze al lang uit beeld.

            if (WasKeyJustPressed(Keys.Escape))
                Context.ChangeState(new PauseMenuState(Context, this));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // TODO: Zet the background om naar een sprite

            var backgroundTexture = Context.AssetsManager.GetTexture(AssetsNames.BACKGROUND_TEXTURE);
            spriteBatch.Draw(backgroundTexture,
                             Context.BackgroundPosition,
                             GameSettings.BACKGROUND_SCALE);

            Vector2 background2Position = new Vector2(Context.BackgroundPosition.X, Context.BackgroundPosition.Y - backgroundTexture.Height * GameSettings.BACKGROUND_SCALE);
            spriteBatch.Draw(backgroundTexture,
                             background2Position,
                             GameSettings.BACKGROUND_SCALE);
            // TODO: We zouden bij het spawned van de haaien een bepaalde random scale kunnen geven aan een specifieke haai, zo zien sommige er groter uit dan anderen. Dit zou het speelveld interessanter maken. Nu hebben alle haaien dezelfde grootte.
            foreach (var enemySprite in Context.Enemies)
                enemySprite.Draw(spriteBatch);

            Context.Player.Draw(spriteBatch);
        }

        private void UpdateBackgroundPosition()
        {
            var bgTexture = Context.AssetsManager.GetTexture(AssetsNames.BACKGROUND_TEXTURE);
            Context.BackgroundPosition = Context.BackgroundPosition with { X = 0 , Y = Context.BackgroundPosition.Y + GameSettings.BACKGROUND_SPEED };
            // Zodra de afbeelding te ver naar beneden is, zet hem weer terug naar boven
            if (Context.BackgroundPosition.Y >= bgTexture.Height * GameSettings.BACKGROUND_SCALE) // 650 is de hoogte van je scherm
            {
                // Zet de achtergrond weer terug naar boven
                Context.BackgroundPosition = Context.BackgroundPosition with { Y = 0 };
            }
        }

    }
}
