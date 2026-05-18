using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public PlayerSprite Player { get; private set; }

        public List<EnemySprite> Enemies { get; set; }

        public List<TreeSprite> trees { get; set; }

        public List<HouseSprite> houses { get; set; }

        public AssetsManager AssetsManager { get; }

        public Vector2 BackgroundPosition { get; set; }

        public GameSettings gameSettings { get;}

        public GameContext(Game game, GameSettings settings)
        {
            BackgroundPosition = new Vector2(0, 0);
            Enemies = new List<EnemySprite>();

            AssetsManager = new AssetsManager(game);

            // Dit moet na LoadContent want we hebben de texture nodig
            Player = PlayerFactory.CreatePlayerInVerticalCenter(AssetsManager.GetTexture(AssetsNames.PLAYER_TEXTURE),
                                                                Const.PLAYER_SPEED,
                                                                Const.PLAYER_SCALE,
                                                                new PlayerInputService());

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
