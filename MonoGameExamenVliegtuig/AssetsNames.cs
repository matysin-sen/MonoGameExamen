using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig
{
    public static class AssetsNames
    {
        // We gebruiken constanten voor de namen van de assets, zodat we geen typefouten kunnen maken bij het opvragen van een asset. We kunnen deze constanten ook gebruiken in de content pipeline, zodat we zeker weten dat de namen overeenkomen.
        public const string PLAYER_TEXTURE = "plane";
        public const string ENEMY_PLANE1_TEXTURE = "enemy_plane1";
        public const string ENEMY_PLANE2_TEXTURE = "enemy_plane2";
        public const string HOUSE_BLUE_TEXTURE = "house_blue";
        public const string HOUSE_RED_TEXTURE = "house_red";
        public const string BACKGROUND_TEXTURE = "background";
        public const string TREE_TEXTURE = "tree";
        public const string TREES_TEXTURE = "trees";
        public const string GAME_FONT = "game-font";

    }
}
