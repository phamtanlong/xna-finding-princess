using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FindingPrincess.Sence;

namespace FindingPrincess.Object
{
    // used to know what object to know how to solve when have a collision
    public enum IDObject
    {
        TER_LEFT = 1,
        TER = 2,
        TER_RIGHT = 3
    }

    public enum IDStatus
    {
        ALIVE,
        DEAD,
        BEFORE_DIE,
        NEW
    }

    // used to make an object in game
    public abstract class GameObject
    {
        protected IDObject _IDObject;
        protected Animation _curAnimation;
        protected Vector2 _position = Vector2.Zero;
        protected bool _isAlive = true;
        protected bool _isVisiable = true;
        protected IDStatus _status = IDStatus.ALIVE;
        protected IDirect _direct = IDirect.LEFT;

#region  Properties.......

        public virtual IDObject IDObj
        {
            get { return _IDObject; }
            set { _IDObject = value; }
        }

        public virtual Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public virtual bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        public virtual bool IsVisiable
        {
            get { return _isVisiable; }
            set { _isVisiable = value; }
        }

        public virtual Animation CurAnimation
        {
            get { return _curAnimation; }
            set { _curAnimation = value; }
        }

        public virtual Rectangle Bound
        {
            get 
            {
                return new Rectangle(
                    (int)_position.X, 
                    (int)_position.Y, 
                    (int)_curAnimation.Size.X, 
                    (int)_curAnimation.Size.Y);
            }
        }

        public IDStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public IDirect Direct
        {
            get { return _direct; }
            set { _direct = value; }
        }

#endregion

        public virtual void Update(GameTime gametime)
        {
            
        }

        public virtual void UpdateCollision(GameObject _otherObject, ECollision _dir)
        {

        }

        public virtual void UpdateAnimation(GameTime gametime)
        {
            _curAnimation.Update(gametime);
        }


        public virtual void Draw(SpriteBatch _sb)
        {
            _curAnimation.DirectFace = _direct;
            _curAnimation.Draw(_sb, _position);
        }

    }
}
