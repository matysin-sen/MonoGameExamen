using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameExamenVliegtuig.Core.Assets;
using MonoGameExamenVliegtuig.Factories;
using MonoGameExamenVliegtuig.Input;
using MonoGameExamenVliegtuig.Objects.Base;
using MonoGameExamenVliegtuig.States;
using MonoGameExamenVliegtuig.States.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Objects
{
    public class GameContext
    {
        // We houden bij welke staat de huidige is. Afhankelijk van de staat, zullen we andere dingen doen in de update en draw methodes.
        public AbstractState CurrentState { get; private set; }

        public PlayerSprite Player { get;  set; }
        public PlayerSprite Player2 { get;  set; }
        public bool IsMultiplayer { get; set; } = false; // bijhouden of we in multiplayer modus zitten of niet, zodat we kunnen bepalen of we player 2 moeten updaten en tekenen

        public List<EnemySprite> Enemies { get; set; }

        public List<TreeSprite> Trees { get; set; }

        public List<HouseSprite> Houses { get; set; }

        public AssetsManager AssetsManager { get; }

        public Vector2 BackgroundPosition { get; set; }

        public GameSettings gameSettings { get;}
        public int Score { get; set; } = 0;

        public GameContext(Game game)
        {
            BackgroundPosition = new Vector2(0, 0);
            Enemies = new List<EnemySprite>();
            Trees = new List<TreeSprite>();
            Houses = new List<HouseSprite>();

            AssetsManager = new AssetsManager(game);

            // Dit moet na LoadContent want we hebben de texture nodig
            Player = PlayerFactory.CreatePlayerInVerticalCenter(AssetsManager.GetTexture(AssetsNames.PLAYER_TEXTURE),
                                                                GameSettings.PLAYER_SPEED,
                                                                GameSettings.PLAYER_SCALE,
                                                                new PlayerInputService(this));

            CurrentState = new MenuState(this);
        }
        public void ChangeState(AbstractState newActiveState)
        {
            CurrentState = newActiveState;
        }

        public void Update(GameTime gameTime)
        {
            CurrentState.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            CurrentState.Draw(gameTime, spriteBatch);
        }
    }
}
