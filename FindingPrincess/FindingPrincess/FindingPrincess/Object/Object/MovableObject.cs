using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FindingPrincess.Object
{
    public abstract class MovableObject : GameObject
    {
        #region Const......
        public const float _STEP_MOVE = 0.1f;
        public const float _STEP_JUMP = 1.5f;
        #endregion

        protected Vector2 _oldPosition;
        protected Vector2   _velocity;
        protected Vector2   _accel;

        #region Propertiess.....

        public Vector2 OldPosition
        {
            get { return _oldPosition; }
            set { _oldPosition = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Vector2 Accel
        {
            get { return _accel; }
            set { _accel = value; }
        }

        #endregion

        public MovableObject(
            Vector2 __position,
            Vector2 __velocity,
            Vector2 __accel)
        {
            _position = __position;
            _oldPosition = Vector2.Zero;
            _velocity = __velocity;
            _accel = __accel;
        }

        public override void Update(GameTime gametime)
        {
            UpdateDirect();
            UpdateMovement(gametime);
            UpdateAnimation(gametime);
        }

        public virtual void UpdateMovement(GameTime gametime)
        {
            _oldPosition = _position;
            
            _position.X += _velocity.X * gametime.ElapsedGameTime.Milliseconds;
            _position.Y += _velocity.Y * gametime.ElapsedGameTime.Milliseconds;

            ////////////////////////Tính toán vận tốc theo thời gian//////////////////////////

            _velocity.X *= (1 - _accel.X);
            _velocity.Y += _accel.Y * gametime.ElapsedGameTime.Milliseconds;

            ///////////////////////// Đoạn này để giới hạn trong màn hình thôi///////////
            if (_position.X < 0) _position.X = 0;
            if (_position.X > 800) _position.X = 800;
            if (_position.Y > 600) _position.Y = 600;
        }

        public virtual void UpdateDirect()
        {
            if (_velocity.X > 0)
                _direct = IDirect.RIGHT;
            else if (_velocity.X < 0)
                _direct = IDirect.LEFT;
        }

        public virtual void Stand()
        {
            _velocity.X = 0;
            _velocity.Y = 0;
        }

        public virtual void MoveLeft()
        {
            _velocity.X = - _STEP_MOVE;
        }

        public virtual void MoveRight()
        {
            _velocity.X = _STEP_MOVE;
        }

        public virtual void JumpUp()
        {
            _velocity.Y = - _STEP_JUMP;
        }
        
        public virtual void Dispose()
        {
            _curAnimation.Dispose();
        }


    }
}
