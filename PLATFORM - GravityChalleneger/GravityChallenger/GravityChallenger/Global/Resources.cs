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
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace GravityChallenger.Global
{
    public class Resources
    {
        public static Dictionary<string, Texture2D> Images ;
        public static Dictionary<string, SoundEffect> Sounds;

        public static void LoadImages(ContentManager content)
        {
            Images = new Dictionary<string, Texture2D>();

            List<string> graphics = new List<string>()
            {
                "background", 
                "character",
                "game_buttons",
                "gameover",
                "get_ready",
                "ground",
                "logo",
                "medals",
                "menu_buttons",
                "new",
                "numbers_large",
                "numbers_small",
                "pipe_bot",
                "pipe_top",
                "score_box",
            };

            foreach (string img in graphics)
                Images.Add(img, content.Load<Texture2D>("Graphics/" + img));
        }

        public static void LoadSounds(ContentManager content)
        {
            Sounds = new Dictionary<string, SoundEffect>();

            List<string> sounds = new List<string>()
            {
                "button_click",
                "button_hover",
                "flap",
                "flap2",
                "pipe_hit",
                "pipe_hit2",
                "pipe_pass"
            };

            foreach (string s in sounds)
                Images.Add(s, content.Load<Texture2D>("Sounds/" + s));
        }

    }
}