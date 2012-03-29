using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Collections;

namespace FindingPrincess
{
    public static class CInput
    {
        //Variables
        public static KeyboardState _nowKeyState = Keyboard.GetState();
        public static KeyboardState _lastKeyState;
        public static MouseState _nowMouseState = Mouse.GetState();
        public static MouseState _lastMouseState;

        // Chỉ gọi hàm này 1 lần duy nhất trong Game1.Update()
        // Trong các Class khác chỉ sử dụng chứ ko gọi Update() nữa
        // Nếu ko sai ráng chịu
        public static void Update()
        {
            _lastKeyState = _nowKeyState;
            _nowKeyState = Keyboard.GetState();

            _lastMouseState = _nowMouseState;
            _nowMouseState = Mouse.GetState();
        }

        //////////////////////////////////////////////////////////////////////////
        public static bool KeyReleased(Keys _key)
        {
            return _nowKeyState.IsKeyUp(_key) && _lastKeyState.IsKeyDown(_key);
        }

        public static bool KeyPressed(Keys _key)
        {
            return _nowKeyState.IsKeyDown(_key) && _lastKeyState.IsKeyUp(_key);
        }

        public static bool KeyDown(Keys _key)
        {
            return _nowKeyState.IsKeyDown(_key);
        }
        //////////////////////////////////////////////////////////////////////////
        
        public static bool LeftPressed
        {
            get 
            {
                return _nowMouseState.LeftButton == ButtonState.Pressed && _lastMouseState.LeftButton == ButtonState.Released;
            }
        }

        public static bool RightPressed
        {
            get
            {
                return _nowMouseState.RightButton == ButtonState.Pressed && _lastMouseState.RightButton != ButtonState.Pressed;
            }
        }

        public static bool LeftReleased
        {
            get 
            {
                return _nowMouseState.LeftButton == ButtonState.Released;
            }
        }

        public static bool RightReleased
        {
            get 
            {
                return _nowMouseState.RightButton == ButtonState.Released;
            }
        }

        public static Point MousePoint
        {
            get 
            {
                return new Point(_nowMouseState.X, _nowMouseState.Y);
            }
        }

        public static int ScrollWheel
        {
            get
            {
                return _nowMouseState.ScrollWheelValue;
            }
        }

        public static Keys[] _nowKeys = Keyboard.GetState().GetPressedKeys();
        public static Keys[] _lastKeys;

        public static Keys[] PressedKeys()
        {
            _lastKeys = _nowKeys;
            _nowKeys = _nowKeyState.GetPressedKeys();

            ArrayList _temp = new ArrayList();

            foreach (Keys _k in _nowKeys)
            {
                if (!_lastKeys.Contains(_k))
                {
                    _temp.Add(_k);
                }
            }

            Keys[] _pressedKeys;
            _pressedKeys = new Keys[_temp.Count];
            for (int i = 0; i < _temp.Count; ++i)
            {
                _pressedKeys[i] = (Keys)_temp[i];
            }
            return _pressedKeys;
        }
        
    }
}
