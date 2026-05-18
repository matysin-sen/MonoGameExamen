using Microsoft.Xna.Framework;
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

            public static void Initialize(GraphicsDeviceManager graphics)
            {
                _graphics = graphics;
            }

            public static int ScreenWidth
                => _graphics.PreferredBackBufferWidth;

            public static int ScreenHeight
                => _graphics.PreferredBackBufferHeight;

            public static void SetResolution(int width, int height)
            {
                _graphics.PreferredBackBufferWidth = width;
                _graphics.PreferredBackBufferHeight = height;
                _graphics.ApplyChanges();
            }
        }
    }

