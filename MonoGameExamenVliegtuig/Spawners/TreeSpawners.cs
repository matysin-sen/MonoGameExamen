using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameExamenVliegtuig.Core.Graphics;
using MonoGameExamenVliegtuig.Factories;
using MonoGameExamenVliegtuig.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Spawners
{
    public class TreeSpawners
    {
        private readonly List<TreeSprite> _trees;
        private readonly Texture2D[] _treeTexture;//stop ze hier in de array om te kunnen randomizen welke boom er gespawned wordt
        private double _elapsedTimeInMs;
        private Random _random;
        private float _currentSpawnIntervalInMs; // om wachttijd op te slaan tussen spawns, kan later gebruikt worden om moeilijkheid aan te passen
        public TreeSpawners(List<TreeSprite> trees, Texture2D[] treeTexture)
        {
            _trees = trees;
            _treeTexture = treeTexture;
            _random = new Random();
            _currentSpawnIntervalInMs = _random.Next(750, 3501); // kiest tussen 750ms (0.75s) en 3500ms (3.5s) voor de eerste spawn, kan later aangepast worden voor moeilijkheid
        }

        public void Update(GameTime gameTime)
        {
            _elapsedTimeInMs += gameTime.ElapsedGameTime.TotalMilliseconds;

            // Spawn bijvoorbeeld elke 2000 milliseconden (2 seconden) een boom
            if (_elapsedTimeInMs >= _currentSpawnIntervalInMs)
            {
                int randomX = _random.Next(0, (int)GraphicsFacade.GetWindowWidth());
                int randomTextureIndex = _random.Next(0, _treeTexture.Length);// Random index voor de boom texture
                Texture2D selectedTreeTexture = _treeTexture[randomTextureIndex]; // Geselecteerde boom texture

                // Maak een nieuw huis aan op een random X-positie, bovenaan buiten het scherm (-50)
                // Let op: check even of jouw TreeSprite constructor hiermee overeenkomt!
                _trees.Add(EnemyFactory.CreateTree(
                    selectedTreeTexture,
                    randomX,
                    -50,
                    GameSettings.TREES_SPEED, // Snelheid gelijk aan de achtergrond
                    GameSettings.TREES_SCALE));                          // Scale

                _elapsedTimeInMs = 0;
                _currentSpawnIntervalInMs = _random.Next(750, 3501); // Kies een nieuwe random spawn interval voor de volgende boom
            }
        }
    }
}
