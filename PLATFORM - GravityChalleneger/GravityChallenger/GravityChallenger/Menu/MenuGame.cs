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
using GravityChallenger.GameEngine;
using GravityChallenger.Global;

namespace GravityChallenger.Menu
{
    public class MenuGame : MenuBase
    {
        private const int HOLE_HEIGHT = 50;

        // FIELDS
        private List<Pipe> pipes;
        private bool start;
        private int timer;
        private Random random;

        // CONSTRUCTOR
        public MenuGame()
            : base()
        {
            this.background = new Sprite("background_sky", 0, 0);
            this.ground = new Ground(0, 1000);
            this.pipes = new List<Pipe>();
            this.start = false;
            this.timer = 0;
            this.random = new Random();
        }

        // UPDATE & DRAW 
        public override void Update(GameTime gameTime, Input input, Game1 game)
        {
            base.Update(gameTime, input, game);

            this.ground.Update(gameTime, input);
            this.timer += gameTime.ElapsedGameTime.Milliseconds;

            foreach (Pipe pipe in new List<Pipe>(this.pipes))
            {
                pipe.Update(gameTime, input);
           
            }

            if (!this.start)
            {               
                if (timer >= 3000)
                {
                    this.start = true;
                    this.timer = 2000;
                }
            }
            else
            {
                if (this.timer >= 2000)
                {
                    this.timer = 0;

                    int topPipeY = this.random.Next(-400, -100);
                    int botPipeY = topPipeY + 1000;

                    this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, topPipeY, PipeType.TOP));
                    this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, botPipeY, PipeType.BOT));
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch);            
            foreach (Pipe pipe in this.pipes)
                pipe.Draw(spriteBatch);
            this.ground.Draw(spriteBatch);

        }
    }
}