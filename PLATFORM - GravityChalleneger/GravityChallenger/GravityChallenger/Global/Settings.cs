using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GravityChallenger.Global
{
    public class Settings
    {
        public static int PIXEL_RATIO = 1;

        // public static int SCREEN_WIDTH = 800 * PIXEL_RATIO;
        // public static int SCREEN_HEIGHT = 480 * PIXEL_RATIO;

        public static bool IS_FULLSCREEN = false;

        public static Color BACKGROUND_COLOR = Color.CornflowerBlue;
    }
}