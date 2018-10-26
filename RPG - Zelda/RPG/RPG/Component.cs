using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    abstract class Component
    {
        // FIELD 
        private BaseObject _baseObject;

        // PROPERTY 
        public abstract ComponentType ComponentType { get; }


        // METHOD
        public void Initialize(BaseObject baseObject)
        {
            _baseObject = baseObject;
        }

        public int GetOwnerID()
        {
            return _baseObject.ID;
        }

        public void RemoveMe()
        {
            _baseObject.RemoveComponent(this);
        }

        public TComponentType GetComponent<TComponentType>(ComponentType componentType) where TComponentType : Component
        {
            return _baseObject.GetComponent<TComponentType>(componentType);
        }

        // GAME ENGINE
        public abstract void Update(double gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);


    }
}
