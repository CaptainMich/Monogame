﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.Components
{
    class Animation : Component
    {
        // FIELD 
        private State _currentState;
        public Direction _currentDirection;
        private double _counter;
        private int _animationIndex;
        private int _width;
        private int _height;

        // PROPERTY
        public override ComponentType ComponentType
        {
            get { return ComponentType.Animation; }
        }

        public Rectangle TextureRectangle { get; private set; }

        // METHOD
        public Animation(int width, int height)
        {
            _width = width;
            _height = height;
            _counter = 0;
            _animationIndex = 0;
            _currentState = State.Standing;
        }

        public void ChangeState()
        {
            _currentState = State.Standing;

            switch (_currentDirection)
            {
                case Direction.Left:
                    TextureRectangle = new Rectangle(_width * _animationIndex, 0, _width, _height);
                    break;
                case Direction.Down:
                    TextureRectangle = new Rectangle(_width * _animationIndex, _height, _width, _height);
                    break;
                case Direction.Right:
                    TextureRectangle = new Rectangle(_width * _animationIndex, _height * 2, _width, _height);
                    break;
                case Direction.Up:
                    TextureRectangle = new Rectangle(_width * _animationIndex, _height * 3,_width, _height);
                    break;
            }

            switch(_animationIndex)
            {
                case 0:
                    _animationIndex = 1;
                    break;
                case 1:
                    _animationIndex = 2;
                    break;
                case 2:
                    _animationIndex = 3;
                    break;
                case 3:
                    _animationIndex = 4;
                    break;
                case 4:
                    _animationIndex = 0;
                    break;
            }

            //_animationIndex = _animationIndex == 0 ? 1 : 0;
        }

        public void ResetCounter(State state, Direction direction)
        {
            if(_currentDirection != direction)
            {
                _counter = 300;
                _animationIndex = 0;
            }

            _currentState = state;
            _currentDirection = direction;
        }

        // GAME ENGINE
        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public override void Update(double gameTime)
        {
            switch (_currentState)
            {
                case State.Walking:
                    _counter += gameTime;
                    if(_counter > 150)                              // modify to change player animation switching velocity
                    {
                        ChangeState();
                        _counter = 0;
                    }
                    break;
            }
        }
    }
}
