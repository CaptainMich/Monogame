using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using RPG.MyEventArgs;

namespace RPG.Manager
{
    class ManagerInput
    {
        // FIELD
        private KeyboardState _keyState;
        private KeyboardState _lastKeyState;
        private Keys _lastKey;
        public static event EventHandler<NewInputEventArgs> _fireNewInput;
        private double _counter;
        private static double _cooldown;

        // PROPERTY
        public static event EventHandler<NewInputEventArgs> FireNewInput
        {
            add { _fireNewInput += value; }
            remove { _fireNewInput -= value; }
        }

        public static bool ThrottleInput { get; set; }
        public static bool LockMovement { get; set; }


        // CONSTRUCTOR 
        public ManagerInput()
        {
            ThrottleInput = false;
            LockMovement = false;
            _cooldown = 0;
        }

        // GAME ENGINE
        public void Update(double gameTime)
        {
            if(_cooldown > 0)
            {
                _cooldown += gameTime;
                if (_counter > gameTime)
                {
                    _cooldown = 0;
                    _counter = 0;
                }
                else
                {
                    return;
                }
            }

            ComputerControlls(gameTime);
        }

        public void ComputerControlls(double gameTime)
        {
            _keyState = Keyboard.GetState();
            
            if(_keyState.IsKeyUp(_lastKey) && _lastKey != Keys.None)
            {
                if(_fireNewInput != null)
                {
                    _fireNewInput(this, new NewInputEventArgs(Input.None));
                }
            }

            CheckKeyState(Keys.A, Input.Left);
            CheckKeyState(Keys.D, Input.Right);
            CheckKeyState(Keys.W, Input.Up);
            CheckKeyState(Keys.S, Input.Down);

            _lastKeyState = _keyState;
        }


        private void CheckKeyState(Keys key, Input fireInput)
        {
            if(_keyState.IsKeyDown(key))
            {
                if(!ThrottleInput || (ThrottleInput && _lastKeyState.IsKeyUp(key)))
                {
                    if(_fireNewInput != null)
                    {
                        _fireNewInput(this, new NewInputEventArgs(fireInput));
                        _lastKey = key;
                    }
                }
            }
        }
    }
}
