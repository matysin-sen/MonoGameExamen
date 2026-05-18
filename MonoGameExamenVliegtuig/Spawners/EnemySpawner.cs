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
        private Random _random;
        public EnemySpawner(List<EnemySprite> enemies, Texture2D enemyTexture)
        {
            _enemies = enemies;
            _enemyTexture = enemyTexture;
            _random = new Random();
        }

        public void Update(GameTime gameTime)
        {
            _elapsedTimeInMs += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_elapsedTimeInMs >= GameSettings.PLANE_SPAWN_TIME_MS)
            {
             
                // TODO: Voeg een limiet toe van 8 haaien tegelijk.

                if (_enemies.Count < 8)
                {
                    // 3. Genereer een willekeurige X-positie tussen 0 en de breedte van je scherm
                    int randomX = _random.Next(0, (int)GraphicsFacade.GetWindowWidth());

                    // Optioneel: Willekeurige snelheid (lost nog een TODO op)
                    // float randomSpeed = _random.Next(1, 4);
                    _enemies.Add(EnemyFactory.Create(
                    _enemyTexture,
                    randomX,
                    -50,
                    GameSettings.PLANE_SPEED,
                    GameSettings.PLANE_SCALE));

                    _elapsedTimeInMs = 0;
                }
            }
        }
    }
}
