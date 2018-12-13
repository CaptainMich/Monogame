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
        // FIELDS
        private Sprite getReady;
        private List<Pipe> pipes;
        private Bird player;
        protected Ground ground;

        private bool start;        
        private int timer;
        private Random random;

        private bool gameover;
        private bool setRotation;

        // CONSTRUCTOR
        public MenuGame()
            : base()
        {
            switch (Settings.gameMode)
            {
                case GameMODE.SKY:
                    this.background = new Sprite("background_sky", 0, 0);
                    this.ground = new Ground(0, 1100, new Sprite("ground_sky"));
                    this.player = new Bird((int)(150 * Settings.PIXEL_RATIO), (int)(600 * Settings.PIXEL_RATIO),
                                    new AnimatedSprite("bird", 125, 70, 1, SheetOrientation.HORIZONTAL, 20, 20));
                    break;

                case GameMODE.SEA:                    
                    this.background = new Sprite("background_sea", 0, 0);
                    this.ground = new Ground(0, 1100, new Sprite("ground_sea"));
                    this.player = new Bird((int)(150 * Settings.PIXEL_RATIO), (int)(600 * Settings.PIXEL_RATIO),
                                    new AnimatedSprite("submarine", 125, 90, 1, SheetOrientation.HORIZONTAL, 20, 20));
                    break;

                case GameMODE.JUNGLE:
                    this.background = new Sprite("background_jungle", 0, 0);
                    this.ground = new Ground(0, 1100, new Sprite("ground_jungle"));
                    this.player = new Bird((int)(150 * Settings.PIXEL_RATIO), (int)(600 * Settings.PIXEL_RATIO),
                                    new AnimatedSprite("bug", 125, 100, 1, SheetOrientation.HORIZONTAL, 20, 20));
                    break;

                case GameMODE.SPACE:
                    this.background = new Sprite("background_space", 0, 0);
                    this.ground = new Ground(0, 1100, new Sprite("ground_space"));
                    this.player = new Bird((int)(150 * Settings.PIXEL_RATIO), (int)(600 * Settings.PIXEL_RATIO),
                                    new AnimatedSprite("alien", 125, 73, 1, SheetOrientation.HORIZONTAL, 20, 20));
                    break;
                default:
                    this.background = new Sprite("background_sky", 0, 0);
                    this.ground = new Ground(0, 1100, new Sprite("ground_sky"));
                    this.player = new Bird((int)(150 * Settings.PIXEL_RATIO), (int)(600 * Settings.PIXEL_RATIO),
                                    new AnimatedSprite("bird", 125, 70, 1, SheetOrientation.HORIZONTAL, 20, 20));
                    break;
            }

            this.getReady = new Sprite("getready", (int)(80 * Settings.PIXEL_RATIO ), 230);
            this.pipes = new List<Pipe>();
            this.start = false;
            this.gameover = false;
            this.setRotation = false;
            this.timer = 0;
            this.random = new Random();
        }

        // UPDATE & DRAW 
        public override void Update(GameTime gameTime, Input input, Game1 game)
        {
            base.Update(gameTime, input, game);

            if (!gameover)
            {
                this.ground.Update(gameTime, input);
                this.timer += gameTime.ElapsedGameTime.Milliseconds;

                foreach (Pipe pipe in new List<Pipe>(this.pipes))
                {
                    pipe.Update(gameTime, input);
                    if (pipe.ToDelete())
                        this.pipes.Remove(pipe);
                    if (this.player.CollisionWith(pipe))
                    {
                        this.gameover = true;
                        //Resources.Sounds["pipe_hit"].Play();
                        break;
                    }
                }

                if (this.player.CollisionWith(this.ground))
                {
                    this.gameover = true;
                    this.GameOver(gameTime);
                    game.ChangeMenu(MenuState.MAIN);
                }
                else
                    this.player.Update(gameTime, input);

                if (!this.start)
                {
                    if (timer >= 1500)
                    {
                        this.start = true;
                        this.timer = 2000;
                        this.player.ActiveGravity();
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
                                //int topPipeSeaY = this.random.Next(0, 200);
                                //int botPipeSeaY = topPipeSeaY + 700;
                                int topPipeSeaY = this.random.Next(-400, -100);
                                int botPipeSeaY = topPipeSeaY + 1000;
                                this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, topPipeSeaY, PipeType.TOP));
                                this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, botPipeSeaY, PipeType.BOT));
                                break;

                            case GameMODE.JUNGLE:
                                //int topPipeSeaY = this.random.Next(0, 200);
                                //int botPipeSeaY = topPipeSeaY + 700;
                                int topPipeJungleY = this.random.Next(-400, -100);
                                int botPipeJungleY = topPipeJungleY + 1000;
                                this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, topPipeJungleY, PipeType.TOP));
                                this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, botPipeJungleY, PipeType.BOT));
                                break;

                            case GameMODE.SPACE:
                                //int topPipeSeaY = this.random.Next(0, 200);
                                //int botPipeSeaY = topPipeSeaY + 700;
                                int topPipeSpaceY = this.random.Next(-400, -100);
                                int botPipeSpaceY = topPipeSpaceY + 1000;
                                this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, topPipeSpaceY, PipeType.TOP));
                                this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, botPipeSpaceY, PipeType.BOT));
                                break;


                            default:
                                int topPipeY = this.random.Next(-400, -100);
                                int botPipeY = topPipeY + 1000;
                                this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, topPipeY, PipeType.TOP));
                                this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, botPipeY, PipeType.BOT));
                                break;
                        }

                    }
                }
            }

            else if (!this.setRotation)
            {
                if (!this.player.CollisionWith(this.ground))
                    this.player.Update(gameTime, null);
                else
                {
                    this.GameOver(gameTime);
                    game.ChangeMenu(MenuState.MAIN);
                }
            }
            else
            {
                /*this.retryButton.Update(gameTime, input);
                if (this.retryButton.IsPressed())
                    game.ChangeMenu(Menu.GAME);
                this.menuButton.Update(gameTime, input);
                if (this.menuButton.IsPressed())
                    game.ChangeMenu(Menu.MAIN);*/
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch);            
            foreach (Pipe pipe in this.pipes)
                pipe.Draw(spriteBatch);
            if (!this.start)
                this.getReady.Draw(spriteBatch);
            this.ground.Draw(spriteBatch);
            this.player.Draw(spriteBatch);
        }

        // METHODS
        public void GameOver(GameTime gameTime)
        {
            //Resources.Sounds["pipe_hit2"].Play();
            this.player.SetMaxRotation();
            this.setRotation = true;
            this.player.Update(gameTime, null);

            /*int medalIndex = -1;

            if (score >= 40)
                medalIndex = 0;
            else if (score >= 30)
                medalIndex = 3;
            else if (score >= 20)
                medalIndex = 2;
            else if (score >= 10)
                medalIndex = 1;

            this.medal.SetIndex(medalIndex);

            this.highscore = HighScore.GetHighScore();

            if (this.score > this.highscore)
            {
                this.newHighscore = true;
                this.highscore = this.score;
                HighScore.SetHighScore(this.score);
            }*/
        }


    }
}