using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.Components
{
    class Sprite : Component
    {
        // FIELD 
        private Texture2D _texture;
        private int _width;
        private int _height;
        private Vector2 _position;

        // PROPERTY
        public override ComponentType ComponentType
        {
            get { return ComponentType.Sprite; }
        }


        // CONSTRUCTOR 
        public Sprite(Texture2D texture, int width, int height, Vector2 position)
        {
            _texture = texture;
            _width = width;
            _height = height;
            _position = position;
        }

        // METHOD 
        public void Move(float x, float y)
        {
            _position = new Vector2(_position.X + x, _position.Y + y);
        }

        // GAME ENGINE 
        public override void Update(double gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle((int)_position.X, (int)_position.Y, _width, _height), Color.White);
        }

    }
}
