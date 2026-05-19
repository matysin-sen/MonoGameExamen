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
        private readonly Texture2D[] _enemyTexture;
        private double _elapsedTimeInMs;
        private Random _random;
        private float _currentSpawnIntervalInMs; // om wachttijd op te slaan tussen spawns, kan later gebruikt worden om moeilijkheid aan te passen
        public EnemySpawner(List<EnemySprite> enemies, Texture2D[] enemyTexture)
        {
            _enemies = enemies;
            _enemyTexture = enemyTexture;
            _random = new Random();
            _currentSpawnIntervalInMs = _random.Next(1500, 5501); // kiest tussen 1000ms (1s) en 4000ms (4s) voor de eerste spawn, kan later aangepast worden voor moeilijkheid
        }

        public void Update(GameTime gameTime)
        {
            _elapsedTimeInMs += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_elapsedTimeInMs >= _currentSpawnIntervalInMs)
            {
             
                // TODO: Voeg een limiet toe van 8 haaien tegelijk.

                if (_enemies.Count < 8)
                {
                    // 3. Genereer een willekeurige X-positie tussen 0 en de breedte van je scherm
                    int randomX = _random.Next(0, (int)GraphicsFacade.GetWindowWidth());
                    int randomTextureIndex = _random.Next(0, _enemyTexture.Length);
                    Texture2D selectedTexture = _enemyTexture[randomTextureIndex];

                    
                    _enemies.Add(EnemyFactory.Create(
                    selectedTexture,
                    randomX,
                    -50,
                    GameSettings.PLANE_SPEED,
                    GameSettings.PLANE_SCALE));

                    _elapsedTimeInMs = 0;
                    _currentSpawnIntervalInMs = _random.Next(1500, 5501); // kies opnieuw een willekeurige spawn interval voor de volgende spawn
                }
            }
        }
    }
}
