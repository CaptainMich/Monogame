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
using GravityChallenger.GraphicsEngine;
using GravityChallenger.Global;


namespace GravityChallenger.GameEngine
{
    public abstract class GameObject
    {
        // FIELDS
        private Rectangle hitbox;
        private Sprite sprite;

        // CONSTRUCTION
        protected GameObject(int x, int y, Sprite sprite)
        {
            Point textureSize = sprite.GetTextureSize();
            this.hitbox = new Rectangle(x * Settings.PIXEL_RATIO, y * Settings.PIXEL_RATIO, textureSize.X, textureSize.Y);
            this.sprite = sprite;
            this.sprite.Update(x, y);
        }

        // METHODS

        // UPDATE & DRAW
        public virtual void Update()
        {
            this.sprite.Update(this.hitbox.X / Settings.PIXEL_RATIO, this.hitbox.Y / Settings.PIXEL_RATIO);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }
    }
}