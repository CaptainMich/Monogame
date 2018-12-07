﻿using System;
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
using Microsoft.Xna.Framework;

// my project import 
using GravityChallenger.GraphicsEngine;
using GravityChallenger.GameEngine;
using GravityChallenger.Global;

namespace GravityChallenger.Menu
{
    public abstract class MenuBase 
    {
        // FIELDS
        protected Sprite background;
        protected Ground ground;

        // CONSTRUCTOR 
        protected MenuBase()
        {
            this.background = new Sprite("background", 0, 0);
            this.ground = new Ground();
        }

        // METHODS

        // UPDATE and DRAW
        public virtual void Update(GameTime gameTime, Input input, Game1 game)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch);
            this.ground.Draw(spriteBatch);
        }
    }
}