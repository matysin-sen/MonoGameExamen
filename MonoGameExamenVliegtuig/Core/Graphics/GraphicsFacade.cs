using Microsoft.Xna.Framework;
using MonoGameExamenVliegtuig.Core.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Core.Graphics
{
    public static class GraphicsFacade
    {
        // static want er is er maar 1
        private static GraphicsDeviceManager _graphics;


        public static void Initialize(Game game)
        {
            _graphics = new GraphicsDeviceManager(game);
        }
        public static void Initialize(Game game,int width, int height)
        {
            Initialize(game);
            ChangeResolution(width, height);
       
        }



        public static void ChangeResolution(int width, int height)
        {
            GraphicsFacadeNotInitializedException.ThrowIfNull(_graphics);

            _graphics.PreferredBackBufferHeight = height;
            _graphics.PreferredBackBufferWidth = width;

            _graphics.ApplyChanges();
        }

        public static float GetWindowVerticalCenter()
        {
            GraphicsFacadeNotInitializedException.ThrowIfNull(_graphics);

            // * is a lot faster than /
            return _graphics.PreferredBackBufferHeight * 0.5f;
        }

        public static float GetWindowWidth()
        {
            GraphicsFacadeNotInitializedException.ThrowIfNull(_graphics);

            return _graphics.PreferredBackBufferWidth;
        }

        public static float GetWindowHeight()
        {
            GraphicsFacadeNotInitializedException.ThrowIfNull(_graphics);

            return _graphics.PreferredBackBufferHeight;
        }

        public static float GetWindowHorizontalCenter()
        {
            GraphicsFacadeNotInitializedException.ThrowIfNull(_graphics);

            
            return _graphics.PreferredBackBufferWidth * 0.5f;
        }
    }
}

