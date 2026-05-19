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
        private readonly Texture2D _treeTexture;
        private double _elapsedTimeInMs;
        private Random _random;

        public TreeSpawners(List<TreeSprite> trees, Texture2D treeTexture)
        {
            _trees = trees;
            _treeTexture = treeTexture;
            _random = new Random();
        }

        public void Update(GameTime gameTime)
        {
            _elapsedTimeInMs += gameTime.ElapsedGameTime.TotalMilliseconds;

            // Spawn bijvoorbeeld elke 2000 milliseconden (2 seconden) een boom
            if (_elapsedTimeInMs >= 2000)
            {
                int randomX = _random.Next(0, (int)GraphicsFacade.GetWindowWidth());

                // Maak een nieuw huis aan op een random X-positie, bovenaan buiten het scherm (-50)
                // Let op: check even of jouw TreeSprite constructor hiermee overeenkomt!
                _trees.Add(EnemyFactory.CreateTree(
                    _treeTexture,
                    randomX,
                    -50,
                    GameSettings.TREES_SPEED, // Snelheid gelijk aan de achtergrond
                    GameSettings.TREES_SCALE));                          // Scale

                _elapsedTimeInMs = 0;
            }
        }
    }
}
