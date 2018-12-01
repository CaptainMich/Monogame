using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// my project import 
using GravityChallenger.Global;

namespace GravityChallenger.GraphicsEngine
{
    public class Sprite
    {
        // FIELDS
        private Vector2 position;
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Color color;

        // SETTER
        public void SetColor(Color color)
        {
            this.color = color;
        }

        // CONSTRUCTOR
        public Sprite(float x, float y, string imgKey)
        {
            this.position = new Vector2(x, y);
            this.texture = Resources.Images[imgKey];
            this.sourceRectangle = Rectangle.Empty;
            this.color = Color.White;
        }

        public Sprite(float x, float y, string imgKey, Rectangle sourceRect)
        {
            this.position = new Vector2(x, y);
            this.texture = Resources.Images[imgKey];
            this.sourceRectangle = sourceRect;
            this.color = Color.White;
        }

        // METHODS


        // UPDATE and DRAW
        public void Draw(SpriteBatch spriteBatch)
        {
            if (sourceRectangle.Equals(Rectangle.Empty))
                spriteBatch.Draw(this.texture, this.position, this.color);
            else
                spriteBatch.Draw(this.texture, this.position, this.sourceRectangle, this.color);
        }
    }
}