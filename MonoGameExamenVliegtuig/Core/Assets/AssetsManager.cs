using Microsoft.Xna.Framework;
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
        private ContentManager _contentManager;

        private Dictionary<string, Texture2D> _textures
            = new();        //dictionary want we willen de namen er uit halen en dat dan specifieke ding laden
       
        private  Dictionary<string, SpriteFont> _fontAssets;

        public AssetsManager(Game game)
        {
            _contentManager = game.Content;
            _fontAssets = new Dictionary<string, SpriteFont>();
            _textures = new Dictionary<string, Texture2D>();
        }

        public Texture2D GetTexture(string name)
        {
            if (!_textures.ContainsKey(name))
            {
                _textures[name] =
                    _contentManager.Load<Texture2D>(name);
            }

            return _textures[name];
        }

        public SpriteFont GetFont(string name)
        {
            if (!_fontAssets.TryGetValue(name, out var font))
            {
                font = _contentManager.Load<SpriteFont>(name);
                _fontAssets.Add(name, font);
            }

            return font;
        }
    }
}
