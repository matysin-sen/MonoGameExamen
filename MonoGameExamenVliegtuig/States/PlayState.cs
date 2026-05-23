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
        private readonly HouseSpawner _houseSpawner;
        private readonly TreeSpawners _treeSpawners;

        public PlayState(GameContext context)
            : base(context)
        {
            _enemySpawner = new EnemySpawner(
                context.Enemies,
                new Texture2D[]
                 {
                     context.AssetsManager.GetTexture(AssetsNames.ENEMY_PLANE1_TEXTURE),
                     context.AssetsManager.GetTexture(AssetsNames.ENEMY_PLANE2_TEXTURE)
                 }); //kiest hier random een van de 2 textures voor de vijanden, en geeft deze mee aan de spawner, zodat deze ze kan gebruiken om nieuwe vijanden te maken
            _houseSpawner = new HouseSpawner(
                context.Houses,
                 new Texture2D[]
                 {
                     context.AssetsManager.GetTexture(AssetsNames.HOUSE_BLUE_TEXTURE),
                     context.AssetsManager.GetTexture(AssetsNames.HOUSE_RED_TEXTURE)
                 }); 
            _treeSpawners = new TreeSpawners(
                context.Trees,
               new Texture2D[]
        {
            context.AssetsManager.GetTexture(AssetsNames.TREE_TEXTURE),
            context.AssetsManager.GetTexture(AssetsNames.TREES_TEXTURE)
        });

        }

        public override void Update(GameTime gameTime)
        {
            
            UpdateBackgroundPosition();

            Context.Player.Update();
            
            if (Context.IsMultiplayer== true && Context.Player2 != null)// kijken of multiplayer aan staat, zo ja, update dan ook de tweede speler
            {
                Context.Player2.Update();
            }

            foreach (var enemy in Context.Enemies)
                enemy.Update();

            _houseSpawner.Update(gameTime);

            foreach (var house in Context.Houses)
                house.Update();
            _treeSpawners.Update(gameTime);
            foreach (var tree in Context.Trees)
                tree.Update();

            // Verwijder huizen die het scherm gepasseerd zijn
           int ontwekenhuizen= Context.Houses.RemoveAll(house => house.Position.Y > GraphicsFacade.GetWindowHeight());
            Context.Score += ontwekenhuizen; // Tel 1 punt op voor elk ontweken huis

            int ontwekenbomen= Context.Trees.RemoveAll(tree => tree.Position.Y > GraphicsFacade.GetWindowHeight());
            Context.Score += ontwekenbomen; // Tel 1 punt op voor elk ontweken boom
           int ontwekenvliegtuigen= Context.Enemies.RemoveAll(enemy => enemy.Position.Y > GraphicsFacade.GetWindowHeight());// ruimt alle vlietuigen op die onder het scherm zijn, zodat ze niet oneindig in de lijst blijven staan
            Context.Score += ontwekenvliegtuigen; // Tel 1 punt op voor elk ontweken vliegtuig

            _enemySpawner.Update(gameTime);
            _houseSpawner.Update(gameTime);
            _treeSpawners.Update(gameTime); 
            // --- Controleer botsingen met Vijanden ---
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
            // --- Controleer botsingen met Huizen ---
            foreach (var house in Context.Houses)
            {
                // Maak een hitbox rondom het huis
                Rectangle houseRect = new Rectangle(
                    (int)house.Position.X,
                    (int)house.Position.Y,
                    (int)(house.Texture.Width * house.Scale),
                    (int)(house.Texture.Height * house.Scale)
                );

                // Controleer of de speler het huis raakt
                if (playerRect.Intersects(houseRect))
                {
                    Context.ChangeState(new GameOverState(Context));
                    break; // Stop met zoeken, je bent toch al af
                }
            }

            // --- Controleer botsingen met Bomen ---
            foreach (var tree in Context.Trees)
            {
                // Maak een hitbox rondom de boom
                Rectangle treeRect = new Rectangle(
                    (int)tree.Position.X,
                    (int)tree.Position.Y,
                    (int)(tree.Texture.Width * tree.Scale),
                    (int)(tree.Texture.Height * tree.Scale)
                );

                // Controleer of de speler de boom raakt
                if (playerRect.Intersects(treeRect))
                {
                    Context.ChangeState(new GameOverState(Context));
                    break; // Stop met zoeken
                }
            }
           
            if(Context.IsMultiplayer == true && Context.Player2 != null)// kijken of multiplayer aan staat, zo ja, check dan ook de botsingen voor de tweede speler en kijk ook of player2 niet null is, omdat deze anders nog niet is gemaakt in het begin van het spel, en je dan een null reference error krijgt
            {
                Rectangle player2Rect = new Rectangle(
                (int)Context.Player2.Position.X,
                (int)Context.Player2.Position.Y,
                (int)(Context.Player2.Texture.Width * Context.Player2.Scale),
                (int)(Context.Player2.Texture.Height * Context.Player2.Scale)
            );
                foreach (var enemy in Context.Enemies)
                {
                    Rectangle enemyRect = new Rectangle(
                        (int)enemy.Position.X,
                        (int)enemy.Position.Y,
                        (int)(enemy.Texture.Width * enemy.Scale),
                        (int)(enemy.Texture.Height * enemy.Scale)
                    );
                    if (player2Rect.Intersects(enemyRect))
                    {
                        Context.ChangeState(new GameOverState(Context));
                        break;
                    }
                }
                foreach (var house in Context.Houses)
                {
                    Rectangle houseRect = new Rectangle(
                        (int)house.Position.X,
                        (int)house.Position.Y,
                        (int)(house.Texture.Width * house.Scale),
                        (int)(house.Texture.Height * house.Scale)
                    );
                    if (player2Rect.Intersects(houseRect))
                    {
                        Context.ChangeState(new GameOverState(Context));
                        break;
                    }
                }
                foreach (var tree in Context.Trees)
                {
                    Rectangle treeRect = new Rectangle(
                        (int)tree.Position.X,
                        (int)tree.Position.Y,
                        (int)(tree.Texture.Width * tree.Scale),
                        (int)(tree.Texture.Height * tree.Scale)
                    );
                    if (player2Rect.Intersects(treeRect))
                    {
                        Context.ChangeState(new GameOverState(Context));
                        break;
                    }
                }
            }


            if (WasKeyJustPressed(Keys.Escape))
                Context.ChangeState(new PauseMenuState(Context, this));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            

            var backgroundTexture = Context.AssetsManager.GetTexture(AssetsNames.BACKGROUND_TEXTURE);
            spriteBatch.Draw(backgroundTexture,
                             Context.BackgroundPosition,
                             GameSettings.BACKGROUND_SCALE);

            Vector2 background2Position = new Vector2(Context.BackgroundPosition.X, Context.BackgroundPosition.Y - backgroundTexture.Height * GameSettings.BACKGROUND_SCALE);
            spriteBatch.Draw(backgroundTexture,
                             background2Position,
                             GameSettings.BACKGROUND_SCALE);
            // moet ervoor anders vliegt de speler over de achtergrond heen, terwijl die eronder hoort te zijn
            foreach (var house in Context.Houses)
                house.Draw(spriteBatch);
            foreach (var tree in Context.Trees)
                tree.Draw(spriteBatch);
            foreach (var enemySprite in Context.Enemies)
                enemySprite.Draw(spriteBatch);

            Context.Player.Draw(spriteBatch);

            if (Context.IsMultiplayer == true && Context.Player2 != null)// kijken of multiplayer aan staat, zo ja, teken dan ook de tweede speler
            {
                Context.Player2.Draw(spriteBatch);
            }

            SpriteFont font = Context.AssetsManager.GetFont(AssetsNames.GAME_FONT);

            // Teken de tekst linksboven in de hoek (X=10, Y=10)
            spriteBatch.DrawString(font, "Score: " + Context.Score, new Vector2(10, 10), Color.White);
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
