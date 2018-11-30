using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPG.Manager;

namespace RPG.Components
{
    class Collision : Component
    {
        // FIELD 
        private ManagerMap _managerMap;

        // PROPERTY
        public override ComponentType ComponentType
        {
            get { return ComponentType.Collision; }
        }

        // CONSTRUCTOR
        public Collision(ManagerMap managerMap)
        {
            _managerMap = managerMap;
        }

        // GAME ENGINE
        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        public override void Update(double gameTime)
        {
        }

        // METHOD
        public bool CheckCollision(Rectangle rectangle)
        {
            return _managerMap.CheckCollision(rectangle);
        }
    }
}
