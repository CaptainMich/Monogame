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

// my project import 
using GravityChallenger.GraphicsEngine;
using Microsoft.Xna.Framework.Graphics;
using GravityChallenger.Global;
using Microsoft.Xna.Framework;

namespace GravityChallenger.GameEngine
{
    class MyButton : GameObject
    {
        // FIELDS
        private bool isPressed;

        // PROPERTIES

        // CONSTRUCTORS
        public MyButton(int x, int y, int index)
            : base(x, y, new AnimatedSprite("menu_buttons_1", 700, 200, index, SheetOrientation.VERTICAL, 50, 50))
        {
            this.isPressed = false;
        }

        // UPDATE & DRAW
        public override void Update(GameTime game, Input input)
        {
            if (this.hitbox.Contains(input.GetPosition()))
            {
                this.isPressed = true;
                Console.WriteLine("Button Pressed");
                // Resources.Sounds["button_click"].Play();
            }


            if (input.IsPressed())
                this.sprite.SetColor(Color.Gray);
            else
                this.sprite.SetColor(Color.White);


            base.Update(game, input);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        // METHODS

        public bool IsPressed()
        {
            bool result = this.isPressed;

            if (this.isPressed)
                this.isPressed = false;

            return result;
        }
    }
}