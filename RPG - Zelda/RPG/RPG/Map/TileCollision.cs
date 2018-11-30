using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Map
{
    public class TileCollision
    {
        // PROPERTY
        public int XPos { get; set; }
        public int YPos { get; set; }

        public Rectangle Rectangle { get { return new Rectangle(XPos * 50, YPos * 50, 50, 50); }}

        // METHOD 
        public bool Intersect(Rectangle rectangle)
        {
            return Rectangle.Intersects(rectangle);
        }

        // CONSTRUCTOR 
        public TileCollision()
        {
        }
    }
}
