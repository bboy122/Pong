using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna;
using Microsoft.Xna.Framework.Input;
//This class will manage all keyboard events within the pong game

namespace Pong
{
    class Keyboard
    {

        //Member variable
        public KeyboardState CurrentKeyboardState;
        public KeyboardState LastKeyboardState;

        public void Update()
        {
        //Update the current and last state of the keyboard

            LastKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();

        }
        public bool IsKeyPress(Keys keys)
        {
            return CurrentKeyboardState.IsKeyDown(keys);
        }

        public bool IsNewKeyPress(Keys key)
        {
            return (LastKeyboardState.IsKeyUp(key) && CurrentKeyboardState.IsKeyDown(key));
        }










    }
}
