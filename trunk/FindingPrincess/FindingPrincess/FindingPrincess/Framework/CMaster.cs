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


namespace FindingPrincess.Framework
{
    class CMaster : CAnimatedObject
    {
        private DirFace m_DirFace;
        private CSprite Master_Move;
        private CSprite Master_Stand;
        private CSprite Master_Attack1_1;
        private CSprite Master_Attack1_2;
        private CSprite Master_Attack1_3;
        private CSprite Master_Attack1_4;
        private CSprite Master_Attack2_1;
        private CSprite Master_Attack2_2;
        private CSprite Master_Attack3_1;
        private CSprite Master_Attack3_2;
        private CSprite Master_Attack4;
        private CSprite Master_Attack5;
        private CSprite Master_Hit;
        private CSprite Master_Die;
        protected List<CSprite> m_SkillList;
        protected int m_CurrentSkill = 0;
        int[] Dam;
        protected List<CEffect> m_ListHitEffect;
        private CEffect m_EffectMasterAttack1_Hit;
        private CEffect m_EffectMasterAttack2_Hit;
        private CEffect m_EffectMasterAttack3_Hit;
        private CEffect m_EffectMasterAttack4_Hit;
        private CEffect m_EffectMasterAttack5_Hit;
        private Vector2 Master_Velocity;
        protected CItem m_Item;
        public CMaster(IDObject _ID, float _PosX, float _PosY, float _VelocX, float _VelocY, float _AccelX, float _AccelY, DirFace _DirFace)
            : base(_ID, _PosX, _PosY, _VelocX, _VelocY, _AccelX, _AccelY)
        {
            HP = 400;
            MAX_HP = HP;
            m_DirFace = _DirFace;
            Master_Velocity = new Vector2(_VelocX, _VelocY);
            States = Object_States.Stand;
            m_SkillList = new List<CSprite>();
            m_ListHitEffect = new List<CEffect>();
        }
        public override void Init(ContentManager _CM)
        {
            Master_Move = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Master_Move));
            Master_Stand = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Master_Stand));
            Master_Attack1_1 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Master_Attack1_1));
            Master_Attack1_2 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Master_Attack1_2));
            Master_Attack1_3 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Master_Attack1_3));
            Master_Attack1_4 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Master_Attack1_4));
            
            Master_Attack2_1 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Master_Attack2_1));
            Master_Attack2_2 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Master_Attack2_2));
            Master_Attack3_1 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Master_Attack3_1));
            Master_Attack3_2 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Master_Attack3_2));
            Master_Attack4 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Master_Attack4));
            Master_Attack5 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Master_Attack5));
            Master_Hit = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Master_Hit));
            Master_Die = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Master_Die));
            m_EffectMasterAttack1_Hit = new CEffect(IDEffect.Effect_Master_Attack1_Hit);
            m_EffectMasterAttack1_Hit.Init(IDResource.Effect_Master_Attack1_Hit); 
           
            m_EffectMasterAttack2_Hit = new CEffect(IDEffect.Effect_Master_Attack2_Hit);
            m_EffectMasterAttack2_Hit.Init(IDResource.Effect_Master_Attack2_Hit);
            m_EffectMasterAttack3_Hit = new CEffect(IDEffect.Effect_Master_Attack1_Hit);
            m_EffectMasterAttack3_Hit.Init(IDResource.Effect_Master_Attack1_Hit);
            m_EffectMasterAttack4_Hit = new CEffect(IDEffect.Effect_Master_Attack4_Hit);
            m_EffectMasterAttack4_Hit.Init(IDResource.Effect_Master_Attack4_Hit);

            m_EffectMasterAttack5_Hit = new CEffect(IDEffect.Effect_Boss_Attack1_Hit);
            m_EffectMasterAttack5_Hit.Init(IDResource.Effect_Boss_Attack3_Hit);
            m_ListHitEffect.Add(m_EffectMasterAttack1_Hit);
            m_ListHitEffect.Add(m_EffectMasterAttack2_Hit);
            m_ListHitEffect.Add(m_EffectMasterAttack3_Hit);
            m_ListHitEffect.Add(m_EffectMasterAttack4_Hit);
            m_ListHitEffect.Add(m_EffectMasterAttack5_Hit);

            m_SkillList.Add(Master_Attack1_1);
            m_SkillList.Add(Master_Attack2_1);
            m_SkillList.Add(Master_Attack3_1);
            m_SkillList.Add(Master_Attack4);
            m_SkillList.Add(Master_Attack5);
            Dam = new int[m_SkillList.Count];
            Dam[0] = 100;
            Dam[1] = 10;
            Dam[2] = 30;
            Dam[3] = 50;
            Dam[4] = 100;
            m_CurSprite = Master_Stand;
            m_Item = new CItem(IDObject.Item, 0.0f, 0.0f, EItem_Name.Gold_1);
            m_Item.Init(_CM);
            m_Item.m_CurSprite.Scale = 1.5f;
            base.Init(_CM);
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            for (int i = 0; i < m_ListEffect.Count; i++)
            {
                m_ListEffect[i].Draw(_spriteBatch);
            }
            if (IsVisible == true)
                base.Draw(_spriteBatch);
            else m_Item.Draw(_spriteBatch);
        }
        public override void UpdateAnimation(GameTime _gameTime)
        {
            if (m_Item.States == Object_States.Die)
                States = Object_States.Die;
            if ((Position.X - Global.Player_Positon.X > 300) && (m_CurSprite._IDResource == IDResource.Master_Stand) && (m_CurSprite.Animation.CurFrame == 0))
            {
                return;
            }
            if ((States != Object_States.Die) && (IsVisible = true))
            {
                m_CurSprite.Update(_gameTime);
            }
            if ((HP <= 0) && (States != Object_States.Die))
            {
                States = Object_States.Before_Die;
            }
            if (States == Object_States.Before_Die)
            {
                m_CurSprite = Master_Die;
                if (m_CurSprite.Animation.Loop >= 1)
                {
                    IsVisible = false;
                    m_Item.Position = new Vector2(Position.X+100, Position.Y);
                    //States = Object_States.Die;
                }
            }
            if (States == Object_States.Attacking)
            {
                if ((m_CurSprite._IDResource == IDResource.Master_Attack1_1) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    m_CurSprite = Master_Attack1_2;
                }
                if ((m_CurSprite._IDResource == IDResource.Master_Attack1_2) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    m_CurSprite = Master_Attack1_3;
                }
                if ((m_CurSprite._IDResource == IDResource.Master_Attack1_3) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    m_CurSprite = Master_Attack1_4;
                }
                if ((m_CurSprite._IDResource == IDResource.Master_Attack1_4) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    States = Object_States.Move;
                }
                if ((m_CurSprite._IDResource == IDResource.Master_Attack2_1) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    m_CurSprite = Master_Attack2_2;
                }
                if ((m_CurSprite._IDResource == IDResource.Master_Attack2_2) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    States = Object_States.Move;
                }
                if ((m_CurSprite._IDResource == IDResource.Master_Attack3_1) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    m_CurSprite = Master_Attack3_2;
                }
                if ((m_CurSprite._IDResource == IDResource.Master_Attack3_2) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    States = Object_States.Move;
                }
                if ((m_CurSprite._IDResource == IDResource.Master_Attack4) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    States = Object_States.Move;
                }
                if ((m_CurSprite._IDResource == IDResource.Master_Attack5) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    States = Object_States.Move;
                }
            }
            if (States == Object_States.Move)
            {
                  if (m_CurSprite.Animation.Loop >= 3)
                  {
                      m_CurSprite.Animation.Loop = 0;
                      m_CurSprite.Animation.CurFrame = 0;
                      States = Object_States.Attacking;
                      Random _random = new Random();
                      m_CurrentSkill = _random.Next(0, m_SkillList.Count);
                      m_CurSprite = m_SkillList[m_CurrentSkill];
                  }
                  else
                m_CurSprite = Master_Move;
            }
            if (States == Object_States.Stand)
            {
                if (m_CurSprite.Animation.Loop >= 10)
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    States = Object_States.Move;
                }
                else
                    m_CurSprite = Master_Stand;
            }
            if (States == Object_States.Hit)
            {
                if ((m_CurSprite != Master_Hit)&&(m_CurSprite != Master_Move))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                }
                m_CurSprite = Master_Hit;
                if (m_CurSprite.Animation.Loop >= 1)
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    States = Object_States.Move;
                }
            }
            if (m_DirFace == DirFace.Right)
                m_CurSprite._Effect = SpriteEffects.FlipHorizontally;
            else
                m_CurSprite._Effect = SpriteEffects.None;
            
            
        }
        public override void UpdateMovement(GameTime _gameTime)
        {
            if (States == Object_States.Move)
            {
                if (m_DirFace == DirFace.Left)
                {
                    Velocity = new Vector2(-Master_Velocity.X, Velocity.Y);
                }
                else
                {
                    Velocity = new Vector2(Master_Velocity.X, Velocity.Y);
                }
            } 
            else Velocity = new Vector2(0.0f, Velocity.Y);
            if (Velocity.Y > 1.2f)
            {
                Velocity = new Vector2(Velocity.X, 0.0f);
            }

            if (((Global.Player_Positon.X - Position.X) > m_CurSprite.Width ) && (m_CurSprite == Master_Hit))
            {
                if ((m_CurSprite.Animation.Loop == 0) && (m_CurSprite.Animation.CurFrame == m_CurSprite.Animation.FrameEnd))
                {
                    m_DirFace = DirFace.Right;
                    return;
                }
            }
            else
            {
                if (((Position.X - Global.Player_Positon.X) > 0) && (m_CurSprite == Master_Hit))
                {
                    if ((m_CurSprite.Animation.Loop == 0) && (m_CurSprite.Animation.CurFrame == m_CurSprite.Animation.FrameEnd))
                    {
                        m_DirFace = DirFace.Left;
                        return;
                    }
                }
            }
            base.UpdateMovement(_gameTime);
        }
        public override void UpdateCollision(ref CObject _Object)
        {
            #region Collision Brick and Base Brick
            if ((_Object.ID == IDObject.Brick) || (_Object.ID == IDObject.BaseBrick) || (_Object.ID == IDObject.Barrel) )
            {
                if(CheckCollision(_Object))
                {
                    CollisionDir _Dir = this.getCollisionDir(this, _Object);
                    
                    if (_Dir == CollisionDir.Bottom)
                    {
                        Velocity = new Vector2(-Velocity.X, 0.0f);
                        Position = new Vector2(this.Position.X, _Object.Position.Y - this.Bound.Height + 4);
                    }
                    if (_Dir == CollisionDir.Left)
                    {
                        if (States == Object_States.Attacking)
                        {
                            return;
                        }
                        if (_Object.ID == IDObject.Barrel)
                            Position = new Vector2(_Object.Position.X + _Object.Bound.Width + 75 - 47, Position.Y);
                        else Position = new Vector2(_Object.Position.X + _Object.Bound.Width, Position.Y);
                        m_DirFace = DirFace.Right;
                    }
                    if (_Dir == CollisionDir.Right)
                    {
                        if(States == Object_States.Attacking)
                        {
                            return;
                        }
                        if (_Object.ID == IDObject.Barrel)
                            Position = new Vector2(_Object.Position.X - this.Bound.Width + 25, Position.Y);
                        else Position = new Vector2(_Object.Position.X - this.Bound.Width, Position.Y);

                        if (States == Object_States.Attacking)
                            Position = new Vector2(Position.X - CurSprite.Width, Position.Y);
                        m_DirFace = DirFace.Left;
                    }
                    if (_Dir == CollisionDir.Top)
                    {
                        if (States == Object_States.Attacking) 
                        {
                            Position = new Vector2(this.Position.X, _Object.Position.Y + _Object.Bound.Height + 10);
                        
                        }
                        else
                            Position = new Vector2(this.Position.X, _Object.Position.Y + _Object.Bound.Height);
                        Velocity = new Vector2(Master_Velocity.X, 0);
                    }
                    Position = new Vector2(Position.X, 462);
                }
                else
                {
                    if (((Global.Player_Positon.X - Position.X) <= (200 + m_CurSprite.Width)) && ((Global.Player_Positon.X - Position.X) > 0) && (m_CurSprite == Master_Move))
                    {
                        if ((m_CurSprite.Animation.Loop == 0) && (m_CurSprite.Animation.CurFrame == m_CurSprite.Animation.FrameEnd))
                        {
                            m_DirFace = DirFace.Right;
                            return;
                        }
                    }
                    else
                    {
                        if (((Position.X - Global.Player_Positon.X) <= (200 + 80)) && ((Position.X - Global.Player_Positon.X) > 0) && (m_CurSprite == Master_Move))
                        {
                            if ((m_CurSprite.Animation.Loop == 0) && (m_CurSprite.Animation.CurFrame == m_CurSprite.Animation.FrameEnd))
                            {
                                m_DirFace = DirFace.Left;
                                return;
                            }
                        }
                    }
                }
            }
            #endregion
            if ((IsVisible == false) && (m_Item.States != Object_States.Die))
            {
                m_Item.UpdateCollision(ref _Object);
                return;
            }
            #region Collsion with Player
            if (_Object.ID == IDObject.Player)
            {
                if (CheckCollision(_Object))
                {
                    CollisionDir _Dir = this.getCollisionDir(this, _Object);
                    if (States == Object_States.Attacking)
                    {
                        bool GetDam = true;
                        for (int i = 0; i < ListEffect.Count; i++)
                        {
                            if (ListEffect[i].ID == m_ListHitEffect[m_CurrentSkill].ID)
                            {
                                GetDam = false;
                                return;
                            }
                            else GetDam = true;
                        }

                        if (GetDam == true)
                        {
                            int min = 0;
                            int max = 0;
                            if (m_CurSprite == Master_Attack1_3)
                            {
                                min = 3;
                                max = 7;
                            }
                            if (m_CurSprite == Master_Attack1_4)
                            {
                                min = 0;
                                max = 1;
                            }
                            if (m_CurSprite == Master_Attack2_1)
                            {
                                min = 3;
                                max = 17;
                            }
                            if (m_CurSprite == Master_Attack2_2)
                            {
                                min = 0;
                                max = 9;
                            }
                            if (m_CurSprite == Master_Attack3_2)
                            {
                                min = 0;
                                max = 3;
                            }
                            if (m_CurSprite == Master_Attack4)
                            {
                                min = 4;
                                max = 17;
                            }
                            if (m_CurSprite == Master_Attack5)
                            {
                                min = 8;
                                max = 15;
                            }
                            if (max == 0)
                                return;
                            if ((States == Object_States.Attacking) && (m_CurSprite.Animation.CurFrame >= min) && (m_CurSprite.Animation.CurFrame <= max))
                            {
                                ListEffect.Add((m_ListHitEffect[m_CurrentSkill]));
                                m_ListEffect[m_ListEffect.Count - 1].Position = _Object.Position;
                                if (m_ListEffect[m_ListEffect.Count - 1].ID == IDEffect.Effect_Master_Attack1_Hit)
                                    m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(_Object.Position.X - 50, _Object.Position.Y - 50);
                                _Object.HP -= Dam[m_CurrentSkill];
                            }
                        }
                    }
                }
            }
            #endregion
                base.UpdateCollision(ref _Object);
        }

        public override void Update(GameTime _gameTime)
        {
            if ((IsVisible == false) && (m_Item.States != Object_States.Die))
            {
                m_Item.Update(_gameTime);
                return;
            }
            for (int i = 0; i < m_ListEffect.Count; i++)
            {
                m_ListEffect[i].CurSprite.Position = Global.Player_Positon;
                m_ListEffect[i].Update(_gameTime);
                if (m_ListEffect[i].CurSprite.Animation.Loop >= 1)
                {
                    m_ListEffect[i].CurSprite.Animation.Loop = 0;
                    m_ListEffect[i].CurSprite.Animation.CurFrame = 0;
                    m_ListEffect.Remove(m_ListEffect[i]);
                }
            }
            
            UpdateAnimation(_gameTime);
            UpdateMovement(_gameTime);
            base.Update(_gameTime);
            
        }
        public override Rectangle Bound
        {
            get
            {
                if ((m_CurSprite == Master_Attack1_3)||(m_CurSprite == Master_Attack1_4))
                {
                    Rectangle X_Rect;
                    X_Rect.X = (int)(Position.X - 295);
                    X_Rect.Y = (int)(Position.Y-100);
                    X_Rect.Width = (int)((Size.X * m_CurSprite.Scale) + 590);
                    X_Rect.Height = (int)(((Size.Y) * m_CurSprite.Scale+100));
                    return X_Rect;
                }
                if ((m_CurSprite == Master_Attack2_1) || (m_CurSprite == Master_Attack2_2))
                {
                    Rectangle X_Rect;
                    if (m_DirFace == DirFace.Left)
                    {
                        X_Rect.Width = (int)((Size.X * m_CurSprite.Scale)+130);
                        X_Rect.X = (int)(Position.X - 200);
                    }
                    else
                    {
                        X_Rect.Width = (int)((Size.X * m_CurSprite.Scale) + 170);
                        X_Rect.X = (int)(Position.X );
                    }
                    X_Rect.Y = (int)(Position.Y);

                    X_Rect.Height = (int)(((Size.Y) * m_CurSprite.Scale));
                    return X_Rect;
                }
                if ((m_CurSprite == Master_Attack3_2) && (m_CurSprite.Animation.CurFrame >= 0) && (m_CurSprite.Animation.CurFrame <= 3))
                {
                    Rectangle X_Rect;
                    if (m_DirFace == DirFace.Left)
                    {
                        X_Rect.Width = (int)((Size.X * m_CurSprite.Scale) + 400);
                        X_Rect.X = (int)(Position.X - 500);
                    }
                    else
                    {
                        X_Rect.Width = (int)((Size.X * m_CurSprite.Scale) + 550);
                        X_Rect.X = (int)(Position.X);
                    }
                    X_Rect.Y = (int)(Position.Y);

                    X_Rect.Height = (int)(((Size.Y) * m_CurSprite.Scale));
                    return X_Rect;
                }
                if ((m_CurSprite == Master_Attack4) && (m_CurSprite.Animation.CurFrame >= 4) && (m_CurSprite.Animation.CurFrame <= 17))
                {
                    Rectangle X_Rect;
                    if (m_DirFace == DirFace.Left)
                    {
                        X_Rect.Width = (int)((Size.X * m_CurSprite.Scale) + 200);
                        X_Rect.X = (int)(Position.X - 200);
                    }
                    else
                    {
                        X_Rect.Width = (int)((Size.X * m_CurSprite.Scale) + 200);
                        X_Rect.X = (int)(Position.X);
                    }
                    X_Rect.Y = (int)(Position.Y);

                    X_Rect.Height = (int)(((Size.Y) * m_CurSprite.Scale));
                    return X_Rect;
                }
                if ((m_CurSprite == Master_Attack5) && (m_CurSprite.Animation.CurFrame >= 6) && (m_CurSprite.Animation.CurFrame <= 15))
                {
                    Rectangle X_Rect;
                    if (m_DirFace == DirFace.Left)
                    {
                        X_Rect.Width = (int)((Size.X * m_CurSprite.Scale) + 75);
                        X_Rect.X = (int)(Position.X - 75);
                    }
                    else
                    {
                        X_Rect.Width = (int)((Size.X * m_CurSprite.Scale) + 65);
                        X_Rect.X = (int)(Position.X);
                    }
                    X_Rect.Y = (int)(Position.Y);

                    X_Rect.Height = (int)(((Size.Y) * m_CurSprite.Scale));
                    return X_Rect;
                }
                else return base.Bound;
            }
        }
    }
}
