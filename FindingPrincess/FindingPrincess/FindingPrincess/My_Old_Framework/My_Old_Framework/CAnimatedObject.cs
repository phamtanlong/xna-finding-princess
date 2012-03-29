using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

public enum DirFace
{
    Left,
    Right
}

enum Object_States
{
    Stand,
    Move,
    Attacking,
    Jumping,
    Hit,
    Die,
}

namespace FindingPrincess.Framework
{
    class CAnimatedObject:CObject
    {
        protected Vector2 m_Velocity;
        protected Vector2 m_Accel;

        #region Get and Set

        public Vector2 Velocity
        {
            get { return m_Velocity; }
            set { m_Velocity = value; }
        }
        public Vector2 Accel
        {
            get { return m_Accel; }
            set { m_Accel = value; }
        }
        #endregion
        public CAnimatedObject(IDObject _ID, float _PosX, float _PosY, float _VelocX, float _VelocY, float _AccelX, float _AccelY):base(_ID, _PosX, _PosY)
        {
            m_Velocity = new Vector2(_VelocX, _VelocY);
            m_Accel = new Vector2(_AccelX, _AccelY);
            m_ListEffect = new List<CEffect>();
        }
        virtual public void UpdateMovement(GameTime _gameTime)
        {
            Position += new Vector2(m_Velocity.X * _gameTime.ElapsedGameTime.Milliseconds, m_Velocity.Y * _gameTime.ElapsedGameTime.Milliseconds);
            //Accel = new Vector2(Accel.X, 0.004f);
            //m_Velocity.X += m_Accel.X * _gameTime.ElapsedGameTime.Milliseconds;
            m_Velocity.Y += m_Accel.Y * _gameTime.ElapsedGameTime.Milliseconds;            
            
        }
        public override void UpdateCollision(CObject _Object)
        {
            base.UpdateCollision(_Object);
        }
        public override void Update(GameTime _GameTime)
        {
            base.Update(_GameTime);
        }
        public override void UpdateAnimation(GameTime _GameTime)
        {
            base.UpdateAnimation(_GameTime);
        }
        public override void Draw(SpriteBatch _SpriteBatch)
        {
            base.Draw(_SpriteBatch);
        }
    }
}
