using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameExamenVliegtuig.Core.Assets
{
    public class AssetsManager
    {
        private ContentManager _content;

        private Dictionary<string, Texture2D> _textures
            = new();        //dictionary want we willen de namen er uit halen en dat dan specifieke ding laden

        public AssetsManager(ContentManager content)
        {
            _content = content;
        }

        public Texture2D GetTexture(string name)
        {
            if (!_textures.ContainsKey(name))
            {
                _textures[name] =
                    _content.Load<Texture2D>(name);
            }

            return _textures[name];
        }
    }
}
