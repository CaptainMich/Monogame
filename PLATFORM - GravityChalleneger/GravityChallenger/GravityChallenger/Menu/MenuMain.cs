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
    public class MenuMain : MenuBase
    {
        // FIELDS
        private Sprite logo;
        private MyButton startButton;
        private MyButton quitButton;

        // CONSTRUCTOR
        public MenuMain() 
            : base()
        {
            ///this.logo = new Sprite("logo", (Settings.SCREEN_WIDTH - 96) / 2, 75);
            this.startButton = new MyButton((Settings.SCREEN_WIDTH)/4, 420, 0);
            this.quitButton = new MyButton((Settings.SCREEN_WIDTH)/4, 620, 2);
        }

        // METHODS

        // UPDATE and DRAW
        public override void Update(GameTime gameTime, Input input, Game1 game)
        {
            this.startButton.Update(gameTime, input);
            this.quitButton.Update(gameTime, input);

            base.Update(gameTime, input, game);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            //this.logo.Draw(spriteBatch);
            this.startButton.Draw(spriteBatch);
            this.quitButton.Draw(spriteBatch);
        }
    }
}