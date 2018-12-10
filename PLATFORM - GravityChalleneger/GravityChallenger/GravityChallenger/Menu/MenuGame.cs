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
        protected Ground ground;

        // CONSTRUCTOR
        public MenuGame()
            : base()
        {
            switch (Settings.gameMode)
            {
                case GameMODE.SKY:
                    this.background = new Sprite("background_sky", 0, 0);
                    this.ground = new Ground(0, 1000, new Sprite("ground_sky"));
                    Console.WriteLine("HERE 1");
                    break;
                case GameMODE.SEA:                    
                    this.background = new Sprite("background_sea", 0, 0);
                    this.ground = new Ground(0, 1000, new Sprite("ground_sea"));
                    Console.WriteLine("HERE 2");
                    break;
                default:
                    break;
            }
            
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
                if (pipe.ToDelete())
                    this.pipes.Remove(pipe);
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

                    switch (Settings.gameMode)
                    {
                        case GameMODE.SKY:
                            int topPipeSkyY = this.random.Next(-400, -100);
                            int botPipeSkyY = topPipeSkyY + 1000;
                            this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, topPipeSkyY, PipeType.TOP));
                            this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, botPipeSkyY, PipeType.BOT));
                            break;

                        case GameMODE.SEA:
                            int topPipeSeaY = this.random.Next(0, 200);
                            int botPipeSeaY = topPipeSeaY + 700;
                            this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, topPipeSeaY, PipeType.TOP));
                            this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, botPipeSeaY, PipeType.BOT));
                            break;
                        default:
                            break;
                    }

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