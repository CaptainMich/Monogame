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

namespace GravityChallenger.GameEngine
{
    public class Ground : GameObject
    {
        // FIELDS

        // PROPERTIES 

        // CONSTRUCTORS 
        public Ground()
            : base(0, 1000, new Sprite("ground"))
        {
        }

        // UPDATE & DRAW

        // METHODS
    }
}