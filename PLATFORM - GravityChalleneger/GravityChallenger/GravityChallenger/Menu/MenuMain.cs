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
        private MyButton scoreButton;
        private MyButton settingsButton;

        // CONSTRUCTOR
        public MenuMain() 
            : base()
        {
            this.background = new Sprite("background_sea", 0, 0);
            this.logo = new Sprite("logo", (Settings.SCREEN_WIDTH) / 12, 50);
            this.startButton = new MyButton((Settings.SCREEN_WIDTH)/12, 720, 4);
            this.scoreButton = new MyButton((Settings.SCREEN_WIDTH) / 2, 715, 1);
            this.settingsButton = new MyButton((Settings.SCREEN_WIDTH) / 12, 850, 5);
            this.quitButton = new MyButton((Settings.SCREEN_WIDTH)/2, 845, 2);
        }

        // METHODS

        // UPDATE and DRAW
        public override void Update(GameTime gameTime, Input input, Game1 game)
        {
            this.startButton.Update(gameTime, input);
            this.scoreButton.Update(gameTime, input);
            this.settingsButton.Update(gameTime, input);
            this.quitButton.Update(gameTime, input);

            if (this.startButton.IsPressed())
                game.ChangeMenu(MenuState.GAME);
            if (this.quitButton.IsPressed())
                game.Exit();

            base.Update(gameTime, input, game);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.background.Draw(spriteBatch);
            this.logo.Draw(spriteBatch);
            this.startButton.Draw(spriteBatch);
            this.scoreButton.Draw(spriteBatch);
            this.settingsButton.Draw(spriteBatch);
            this.quitButton.Draw(spriteBatch);
        }
    }
}