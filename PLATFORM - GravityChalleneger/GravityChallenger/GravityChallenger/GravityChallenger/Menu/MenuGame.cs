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

namespace GravityChallenger.Menu
{
    public class MenuGame : MenuBase
    {
        // FIELDS

        // CONSTRUCTOR
        public MenuGame()
            : base()
        {

        }

        // UPDATE & DRAW 
        public override void Update(GameTime gameTime, Input input, Game1 game)
        {
            base.Update(gameTime, input, game);

            this.ground.Update(gameTime, input);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}