using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RunnerGame.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunnerGame.System
{
    public class InputController
    {
        private TRex _trex;

        private KeyboardState _previousKeyboardState;

        public InputController(TRex trex)
        {
            _trex = trex;
        }
        public void ProcessControls(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            bool isJumpKeyPressed = keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.Space);
            bool wasJumpKeyPressed = _previousKeyboardState.IsKeyDown(Keys.Up) || _previousKeyboardState.IsKeyDown(Keys.Space);

            if (!wasJumpKeyPressed && isJumpKeyPressed)
            {
                if (_trex.State != TRexState.Jumping)
                    _trex.BeginJump();
            }
            else if (_trex.State == TRexState.Jumping && !isJumpKeyPressed)
            {
                _trex.CancelJump();
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                if (_trex.State == TRexState.Jumping || _trex.State == TRexState.Falling)
                    _trex.Drop();
                else
                    _trex.Duck();
            }
            else if (_trex.State == TRexState.Ducking && !keyboardState.IsKeyDown(Keys.Down))
            {
                _trex.GetUp();
            }

            _previousKeyboardState = keyboardState;
        }
    }
}
