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

enum Monster_Name
{
    SnowMan,

}


namespace FindingPrincess.Framework
{
    class CMonster : CAnimatedObject
    {
        private DirFace m_DirFace;
        private Monster_Name m_Name;
        protected Vector2 Monster_Velocity;
        protected CSprite Monster_Attack;
        protected CSprite Monster_Move;
        protected CSprite Monster_Hit;
        protected CSprite Monster_Die;
        public CMonster(IDObject _ID, float _PosX, float _PosY, float _VelocX, float _VelocY, float _AccelX, float _AccelY, DirFace _DirFace,Monster_Name _Name)
            : base(_ID, _PosX, _PosY, _VelocX, _VelocY, _AccelX, _AccelY)
        {
            m_DirFace = _DirFace;
            States = Object_States.Move;
            m_Name = _Name;
            Monster_Velocity = new Vector2(-_VelocX, _VelocY);
        }
        public override void Init(ContentManager _CM)
        {
            if (m_Name == Monster_Name.SnowMan)
            {
                Monster_Move = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Move));
                Monster_Attack = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Attack));
                Monster_Hit = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Hit));
                Monster_Die = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Die));
            }
            m_CurSprite = Monster_Move;
            //CResourceManager.getInstance().Init(_CM);
            base.Init(_CM);
            //Size = new Vector2(50, 50);
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
        }
        public override void UpdateAnimation(GameTime _gameTime)
        {

            if (m_DirFace == DirFace.Right)
                m_CurSprite._Effect = SpriteEffects.FlipHorizontally;
            else
                m_CurSprite._Effect = SpriteEffects.None;

            if ((Velocity.X == 0.0f) && (States == Object_States.Attacking))
                m_CurSprite = Monster_Attack;
            if (Velocity.X != 0.0f)
                m_CurSprite = Monster_Move;
            if (States == Object_States.Hit)
                m_CurSprite = Monster_Hit;
            if (States == Object_States.Die)
                m_CurSprite = Monster_Die;
            
            if (States != Object_States.Move)
            {
                if ((m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    States = Object_States.Move;
                }
            }
            m_CurSprite.Update(_gameTime);
        }
        public override void UpdateCollision(CObject _Object)
        {
            #region Collision Brick and Base Brick
            if ((_Object.ID == IDObject.Brick) || (_Object.ID == IDObject.BaseBrick) || (_Object.ID == IDObject.Monster) || (_Object.ID == IDObject.Barrel))
            {
                if (this.Collision(_Object) == true)
                {
                    CollisionDir _Dir = this.getCollisionDir(this, _Object);
                  //  Console.WriteLine(_Dir);
                    if (_Dir == CollisionDir.Bottom)
                    {
                        Velocity = new Vector2(Velocity.X, 0.0f);
                        Position = new Vector2(this.Position.X, _Object.Position.Y - this.getBoundingBox().Height + 1);
                    }
                    if (_Dir == CollisionDir.Left)
                    {
                        Velocity = new Vector2(Monster_Velocity.X, Velocity.Y);
                        if (_Object.ID == IDObject.Barrel)
                            Position = new Vector2(_Object.Position.X + _Object.getBoundingBox().Width + 75 - 47, Position.Y);
                        else Position = new Vector2(_Object.Position.X + _Object.getBoundingBox().Width, Position.Y);
                        if (m_DirFace != DirFace.Right)
                            m_DirFace = DirFace.Right;
                    }
                    if (_Dir == CollisionDir.Right)
                    {
                        Velocity = new Vector2(-Monster_Velocity.X, Velocity.Y);
                        if (_Object.ID == IDObject.Barrel)
                            Position = new Vector2(_Object.Position.X - this.getBoundingBox().Width + 25, Position.Y);
                        else Position = new Vector2(_Object.Position.X - this.getBoundingBox().Width, Position.Y);
                        if (m_DirFace != DirFace.Left)
                            m_DirFace = DirFace.Left;
                    }
                    if (_Dir == CollisionDir.Top)
                    {
                        Position = new Vector2(this.Position.X, _Object.Position.Y + _Object.getBoundingBox().Height);
                        Velocity = new Vector2(Monster_Velocity.X, 0);
                    }
                }
            }
            #endregion
            #region Collison Player
            if (_Object.ID == IDObject.Player)
            {
               if (this.Collision(_Object) == true)
                {
                    if (_Object.States == Object_States.Attacking)
                    {
                        if (((_Object.m_CurSprite._IDResource == IDResource.Player_Attack4) || (_Object.m_CurSprite._IDResource == IDResource.Player_Attack2)) && (_Object.m_CurSprite.Animation.CurFrame == 8))
                        {
                            m_CurSprite.Animation.CurFrame = 0;
                            States = Object_States.Hit;
                        }
                    }
                    if (States != Object_States.Hit)
                    {
                        States = Object_States.Attacking;
                        CollisionDir _Dir = this.getCollisionDir(this, _Object);
                        if (_Dir == CollisionDir.Left)
                        {
                            if (m_CurSprite == Monster_Move)
                                m_DirFace = DirFace.Left;
                            if (m_CurSprite.Animation.Loop >= 1)
                            {
                                m_CurSprite.Animation.Loop = 0;
                                if (m_DirFace != DirFace.Left)
                                    m_DirFace = DirFace.Left;
                            }
                        }
                        if (_Dir == CollisionDir.Right)
                        {
                            if (m_CurSprite == Monster_Move)
                                m_DirFace = DirFace.Right;
                            if (m_CurSprite.Animation.Loop >= 1)
                            {
                                m_CurSprite.Animation.Loop = 0;
                                if (m_DirFace != DirFace.Right)
                                    m_DirFace = DirFace.Right;
                                //    m_CurSprite.Animation.CurFrame = 0;
                            }
                        }
                    }
                }

            }
            #endregion
        }

        public override void UpdateMovement(GameTime _gameTime)
        {
            if (States == Object_States.Move)
            {
                if (m_DirFace == DirFace.Left)
                {
                    Velocity = new Vector2(-Monster_Velocity.X, Velocity.Y);
                }
                else
                {
                    Velocity = new Vector2(Monster_Velocity.X, Velocity.Y);
                }
            }
            else Velocity = new Vector2(0.0f, Velocity.Y);
            if (Velocity.Y > 1.2f)
            {
                Velocity = new Vector2(Velocity.X, 0.0f);
            }
            //Position += new Vector2(Velocity.X * _gameTime.ElapsedGameTime.Milliseconds, Velocity.Y * _gameTime.ElapsedGameTime.Milliseconds);
            //m_Velocity.Y += Accel.Y * _gameTime.ElapsedGameTime.Milliseconds;
            base.UpdateMovement(_gameTime);
        }
        public override void Update(GameTime _GameTime)
        {
            UpdateAnimation(_GameTime);
            UpdateMovement(_GameTime);
        }
    }
}
