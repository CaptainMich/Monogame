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
using Microsoft.Xna.Framework.Graphics;

// my project import 
using GravityChallenger.GraphicsEngine;
using GravityChallenger.GameEngine;

namespace GravityChallenger.Menu
{
    public abstract class MenuBase 
    {
        // FIELDS
        private Sprite background;
        private Ground ground;

        // CONSTRUCTOR 
        protected MenuBase()
        {
            this.background = new Sprite("background_3", 0, 0);
            this.ground = new Ground();
        }

        // METHODS

        // UPDATE and DRAW
        public virtual void Update()
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch);
            this.ground.Draw(spriteBatch);
        }
    }
}