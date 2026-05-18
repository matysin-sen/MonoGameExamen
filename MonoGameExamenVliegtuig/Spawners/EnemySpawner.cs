using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameExamenVliegtuig.Core.Graphics;
using MonoGameExamenVliegtuig.Factories;
using MonoGameExamenVliegtuig.Objects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Spawners
{
    public class EnemySpawner
    {
        private readonly List<EnemySprite> _enemies;
        private readonly Texture2D _enemyTexture;
        private double _elapsedTimeInMs;

        public EnemySpawner(List<EnemySprite> enemies, Texture2D enemyTexture)
        {
            _enemies = enemies;
            _enemyTexture = enemyTexture;
        }

        public void Update(GameTime gameTime)
        {
            _elapsedTimeInMs += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_elapsedTimeInMs >= GameSettings.PLANE_SPAWN_TIME_MS)
            {
                // TODO: Spawn elke haai op een random hoogte, nu spawnen ze altijd in het midden van het scherm.
                // TODO: Geef een haai ook verschillende snelheden (bv. random tussen 1 en 3).
                // TODO: Voeg een limiet toe van 8 haaien tegelijk.
                _enemies.Add(EnemyFactory.Create(
                    _enemyTexture,
                    GraphicsFacade.GetWindowWidth(),
                    GraphicsFacade.GetWindowVerticalCenter(),
                    GameSettings.PLANE_SPEED,
                    GameSettings.PLANE_SCALE));

                _elapsedTimeInMs = 0;
            }
        }
    }
}
