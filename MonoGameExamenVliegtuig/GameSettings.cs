using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig
{
    public class GameSettings
    {
        public const int PLANE_SPAWN_TIME_MS = 1000;// Constant to define the time interval (in milliseconds) for spawning new planes in the game

        public const int PLAYER_SPEED = 5;// Constant to define the speed of the player
        public const float PLAYER_SCALE = 0.5f;// Constant to define the scale of the player sprite, allowing for resizing the player character in the game

        public const int PLANE_SPEED = 2;
        public const float PLANE_SCALE = 0.25F;

        public const int BACKGROUND_SPEED = 2;
        public const float BACKGROUND_SCALE = 0.25F;

        public const int HOUSE_SPEED = 2;
        public const float HOUSE_SCALE = 0.25F;

    }
}
