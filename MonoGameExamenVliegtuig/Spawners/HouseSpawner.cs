using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameExamenVliegtuig.Core.Graphics;
using MonoGameExamenVliegtuig.Factories;
using MonoGameExamenVliegtuig.Objects;
using System;
using System.Collections.Generic;

namespace MonoGameExamenVliegtuig.Spawners
{
    public class HouseSpawner
    {
        private readonly List<HouseSprite> _houses;
        private readonly Texture2D _houseTexture;
        private double _elapsedTimeInMs;
        private Random _random;

        public HouseSpawner(List<HouseSprite> houses, Texture2D houseTexture)
        {
            _houses = houses;
            _houseTexture = houseTexture;
            _random = new Random();
        }

        public void Update(GameTime gameTime)
        {
            _elapsedTimeInMs += gameTime.ElapsedGameTime.TotalMilliseconds;

            // Spawn bijvoorbeeld elke 2000 milliseconden (2 seconden) een huis
            if (_elapsedTimeInMs >= 2000)
            {
                int randomX = _random.Next(0,(int)GraphicsFacade.GetWindowWidth());

                // Maak een nieuw huis aan op een random X-positie, bovenaan buiten het scherm (-50)
                // Let op: check even of jouw HouseSprite constructor hiermee overeenkomt!
                _houses.Add(EnemyFactory.CreateHouse(
                    _houseTexture,
                    randomX,
                    -50,
                    GameSettings.HOUSE_SPEED, // Snelheid gelijk aan de achtergrond
                    GameSettings.HOUSE_SCALE));                          // Scale

                _elapsedTimeInMs = 0;
            }
        }
    }
}
