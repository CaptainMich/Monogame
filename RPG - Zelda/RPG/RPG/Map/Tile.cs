using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Map
{
    public class Tile
    {
        // FIELD 
        private Texture2D _texture;
        private const int Width = 50 ;
        private const int Height = 50;
        public List<TileFrame> TileFrames;
        private double _counter;
        private int _animationIndex;

        // PROPERTY
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int ZPos { get; set; }

        public string TextureName { get; set; }
        public int AnimationSpeed { get; set; }

        // CONSTRUCTOR
        public Tile()
        {

        }

        public Tile(int xPos, int yPos, int zPos, List<TileFrame> tileFrames, int animationSpeed, string textureName)
        {
            XPos = xPos;
            YPos = yPos;
            ZPos = zPos;

            TileFrames = tileFrames;
            TextureName = textureName;
            AnimationSpeed = animationSpeed;
            _animationIndex = 0;
        }

        // METHOD 
        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>(TextureName);
        }

        // GAME ENGINE
        public void Update(double gameTime)
        {
            if (TileFrames.Count <= 1)
                return;

            _counter += gameTime;
            if(_counter > AnimationSpeed)
            {
                _counter = 0;
                _animationIndex++;
                if(_animationIndex >= TileFrames.Count)
                {
                    _animationIndex = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle(XPos * Width, YPos * Height, Width, Height), 
                            new Rectangle(TileFrames[_animationIndex].TextureXPos * (Width+1) + 1 , TileFrames[_animationIndex].TextureYPos * (Height + 1) + 1,
                            Width, Height), Color.White);
        }

    }
}
