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
        private readonly Texture2D[] _houseTexture;//stop ze hier in de array om te kunnen randomizen welk huis er gespawned wordt
        private double _elapsedTimeInMs;
        private Random _random;
        private float _currentSpawnIntervalInMs; // om wachttijd op te slaan tussen spawns, kan later gebruikt worden om moeilijkheid aan te passen
        public HouseSpawner(List<HouseSprite> houses, Texture2D[] houseTexture)
        {
            _houses = houses;
            _houseTexture = houseTexture;
            _random = new Random();
            _currentSpawnIntervalInMs = _random.Next(1000, 4001); // kiest tussen 1000ms (1s) en 4000ms (4s) voor de eerste spawn, kan later aangepast worden voor moeilijkheid
        }

        public void Update(GameTime gameTime)
        {
            _elapsedTimeInMs += gameTime.ElapsedGameTime.TotalMilliseconds;

            // Spawn bijvoorbeeld elke 2000 milliseconden (2 seconden) een huis
            if (_elapsedTimeInMs >= _currentSpawnIntervalInMs)
            {
                int randomX = _random.Next(0,(int)GraphicsFacade.GetWindowWidth());
                int randomTextureIndex = _random.Next(0, _houseTexture.Length);// Random index voor de huis texture
                Texture2D selectedHouseTexture = _houseTexture[randomTextureIndex]; // Geselecteerde huis texture

                // Maak een nieuw huis aan op een random X-positie, bovenaan buiten het scherm (-50)
                // Let op: check even of jouw HouseSprite constructor hiermee overeenkomt!
                _houses.Add(EnemyFactory.CreateHouse(
                    selectedHouseTexture,
                    randomX,
                    -50,
                    GameSettings.HOUSE_SPEED, // Snelheid gelijk aan de achtergrond
                    GameSettings.HOUSE_SCALE));                          // Scale

                _elapsedTimeInMs = 0;

                // Stel een nieuwe willekeurige spawn interval in voor de volgende spawn
                _currentSpawnIntervalInMs = _random.Next(1000, 4001); // Kies opnieuw tussen 1000ms (1s) en 4000ms (4s)
            }
        }
    }
}
