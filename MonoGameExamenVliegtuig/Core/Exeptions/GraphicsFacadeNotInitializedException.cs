using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Core.Exeptions
{
    public class GraphicsFacadeNotInitializedException : Exception
    {
        //deze klasse is een custom exception die wordt gegooid wanneer de GraphicsFacade niet correct is geïnitialiseerd 
        public static void ThrowIfNull(GraphicsDeviceManager graphics)
        {
            if (graphics == null)
                throw new GraphicsFacadeNotInitializedException();
        }
    }
}
