using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Input
{
    public interface IPlayerInputService
    {
        public bool ShouldGoRight();
        public bool ShouldGoLeft();
        public bool ShouldGoUp();
        public bool ShouldGoDown();

        public bool shutDown();
    }
}
