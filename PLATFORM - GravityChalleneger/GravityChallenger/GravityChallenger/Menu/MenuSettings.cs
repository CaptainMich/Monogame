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


// my project import 
using GravityChallenger.GraphicsEngine;
using GravityChallenger.GameEngine;
using GravityChallenger.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravityChallenger.Menu
{
    class MenuSettings : MenuBase
    {

        // FIELDS
        private MyButton skyModeButton;
        private MyButton seaModeButton;
        private MyButton jungleModeButton;
        private MyButton spaceModeButton;
        private MyButton menuButton;
        private MyButton quitButton;

        // CONSTRUCTOR
        public MenuSettings()
            : base()
        {
            this.skyModeButton = new MyButton(38, 420, 
                new AnimatedSprite("menu_buttons", 312, 110, 8, SheetOrientation.VERTICAL, 0, 0));
            this.seaModeButton = new MyButton(370, 420, 
                new AnimatedSprite("menu_buttons", 312, 110, 6, SheetOrientation.VERTICAL, 0, 0));
            this.jungleModeButton = new MyButton(38, 550, 
                new AnimatedSprite("menu_buttons", 312, 110, 9, SheetOrientation.VERTICAL, 0, 0));
            this.spaceModeButton = new MyButton(370, 550,
                new AnimatedSprite("menu_buttons", 312, 110, 7, SheetOrientation.VERTICAL, 0, 0));
            this.menuButton = new MyButton(38, 680,
                new AnimatedSprite("menu_buttons", 312, 110, 0, SheetOrientation.VERTICAL, 0, 0));
            this.quitButton = new MyButton(370, 680, 
                new AnimatedSprite("menu_buttons", 312, 110, 2, SheetOrientation.VERTICAL, 0, 0));
        }

        // METHODS

        // UPDATE and DRAW
        public override void Update(GameTime gameTime, Input input, Game1 game)
        {
            this.skyModeButton.Update(gameTime, input);
            this.seaModeButton.Update(gameTime, input);
            this.jungleModeButton.Update(gameTime, input);
            this.spaceModeButton.Update(gameTime, input);
            this.menuButton.Update(gameTime, input);
            this.quitButton.Update(gameTime, input);

            if (this.skyModeButton.IsPressed())
                Settings.gameMode = GameMODE.SKY;
            if (this.seaModeButton.IsPressed())
                Settings.gameMode = GameMODE.SEA;
            if (this.jungleModeButton.IsPressed())
                Settings.gameMode = GameMODE.JUNGLE;
            if (this.spaceModeButton.IsPressed())
                Settings.gameMode = GameMODE.SPACE;
            if (this.quitButton.IsPressed())
                game.Exit();
            if (this.menuButton.IsPressed())
                game.ChangeMenu(MenuState.MAIN);


            Console.WriteLine("{0}", Settings.gameMode);

            base.Update(gameTime, input, game);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);           
            this.skyModeButton.Draw(spriteBatch);
            this.seaModeButton.Draw(spriteBatch);
            this.jungleModeButton.Draw(spriteBatch);
            this.spaceModeButton.Draw(spriteBatch);
            this.menuButton.Draw(spriteBatch);
            this.quitButton.Draw(spriteBatch);
        }
    }
}
