using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RPG.Map;

namespace RPG.Manager
{
    class ManagerMap
    {
        // FIELD 
        private List<Tile> _tiles;
        private string _mapName;

        // CONSTRUCTOR 
        public ManagerMap(string mapName)
        {
            _tiles = new List<Tile>();
            _mapName = mapName;
        }

        // METHOD 
        public void LoadContent(ContentManager content)
        {
            var tiles = new List<Tile>();
            XMLSerialization.LoadXML(out tiles, string.Format("Content\\{0}_map.xml", _mapName));
            if(tiles != null)
            {
                _tiles = tiles;
                _tiles.Sort((n, i) => n.ZPos > i.ZPos ? 1 : 0);

                foreach(var tile in _tiles)
                {
                    tile.LoadContent(content);
                }
            }
        }

        // GAME ENGINE 
        public void Update(double gameTime)
        {
            foreach (var tile in _tiles)
            {
                tile.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in _tiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
