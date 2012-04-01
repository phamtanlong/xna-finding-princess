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
using FindingPrincess.Sence;


namespace FindingPrincess.Framework
{
    class CBoss : CAnimatedObject
    {
        private DirFace m_DirFace;
        private CSprite Boss_Move;
        private CSprite Boss_Stand;
        private CSprite Boss_Attack1_1;
        private CSprite Boss_Attack1_2;
        private CSprite Boss_Attack2_1;
        private CSprite Boss_Attack2_2;
        private CSprite Boss_Attack3;
        private CSprite Boss_Attack4_1;
        private CSprite Boss_Attack4_2;
        private CSprite Boss_Attack4_3;
        private CSprite Boss_Attack4_4;
        private CSprite Boss_Hit;
        private CSprite Boss_Die1;
        private CSprite Boss_Die2;
        private CSprite Boss_Die3;
        private CSprite Boss_Transform1;
        private CSprite Boss_Transform2;
        private CSprite Boss_Stand2;
        protected List<CSprite> m_SkillList;
        protected int m_CurrentSkill = 0;
        int[] Dam;
        protected List<CEffect> m_ListHitEffect;
        private CEffect m_EffectBossAttack1_Hit;
        private CEffect m_EffectBossAttack2_Hit;
        private CEffect m_EffectBossAttack3_Hit;
        private CEffect m_EffectBossAttack4_Hit;

        private Vector2 Boss_Velocity;
        protected CItem m_Item;
        public CBoss(IDObject _ID, float _PosX, float _PosY, float _VelocX, float _VelocY, float _AccelX, float _AccelY, DirFace _DirFace)
            : base(_ID, _PosX, _PosY, _VelocX, _VelocY, _AccelX, _AccelY)
        {
            HP = 2000;
            MAX_HP = HP;
            m_DirFace = _DirFace;
            Boss_Velocity = new Vector2(_VelocX, _VelocY);
            States = Object_States.Transform;
            m_SkillList = new List<CSprite>();
            m_ListHitEffect = new List<CEffect>();
        }
        public override void Init(ContentManager _CM)
        {
            Boss_Move = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Move));
            Boss_Stand = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Stand));
            Boss_Attack1_1 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Attack1_1));
            Boss_Attack1_2 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Attack1_2));
            Boss_Attack2_1 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Attack2_1));
            Boss_Attack2_2 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Attack2_2));
            Boss_Attack3   = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Attack3));
            Boss_Attack4_1 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Attack4_1));
            Boss_Attack4_2 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Attack4_2));
            Boss_Attack4_3 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Attack4_3));
            Boss_Attack4_4 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Attack4_4));
            Boss_Hit = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Hit));
            Boss_Die1 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Die1));
            Boss_Die2 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Die2));
            Boss_Die3 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Die3));
            Boss_Transform1 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Transform1));
            Boss_Transform2 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Transform2));
            Boss_Stand2 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Boss_Stand2));
            m_EffectBossAttack1_Hit = new CEffect(IDEffect.Effect_Boss_Attack1_Hit);
            m_EffectBossAttack1_Hit.Init(IDResource.Effect_Boss_Attack1_Hit);
            m_EffectBossAttack2_Hit = new CEffect(IDEffect.Effect_Boss_Attack2_Hit);
            m_EffectBossAttack2_Hit.Init(IDResource.Effect_Boss_Attack2_Hit);
            m_EffectBossAttack3_Hit = new CEffect(IDEffect.Effect_Boss_Attack3_Hit);
            m_EffectBossAttack3_Hit.Init(IDResource.Effect_Boss_Attack3_Hit);
            m_EffectBossAttack4_Hit = new CEffect(IDEffect.Effect_Boss_Attack4_Hit);
            m_EffectBossAttack4_Hit.Init(IDResource.Effect_Boss_Attack4_Hit);
            m_ListHitEffect.Add(m_EffectBossAttack1_Hit);
            m_ListHitEffect.Add(m_EffectBossAttack2_Hit);
            m_ListHitEffect.Add(m_EffectBossAttack3_Hit);
            m_ListHitEffect.Add(m_EffectBossAttack4_Hit);
            
            Boss_Hit.Scale = 1.2f;
            Boss_Move.Scale = 1.2f;
            Boss_Stand.Scale = 1.2f;

            Boss_Attack1_1.Scale = 1.2f;
            Boss_Attack1_2.Scale = 1.2f;
            Boss_Attack2_1.Scale = 1.2f;
            Boss_Attack2_2.Scale = 1.2f;
            Boss_Attack3.Scale = 1.2f;
            Boss_Attack4_1.Scale = 1.2f;
            Boss_Attack4_2.Scale = 1.2f;
            Boss_Attack4_3.Scale = 1.2f;
            Boss_Attack4_4.Scale = 1.2f;
            Boss_Die1.Scale = 1.2f;
            Boss_Die2.Scale = 1.2f;
            Boss_Die3.Scale = 1.2f;
            Boss_Transform1.Scale = 1.2f;
            Boss_Transform2.Scale = 1.2f;
            
            m_SkillList.Add(Boss_Attack1_1);
            m_SkillList.Add(Boss_Attack2_1);
            m_SkillList.Add(Boss_Attack3);
            m_SkillList.Add(Boss_Attack4_1);
            Dam = new int[m_SkillList.Count];
            Dam[0] = 70;
            Dam[1] = 80;
            Dam[2] = 90;
            Dam[3] = 100;
            m_CurSprite = Boss_Transform1;
            m_Item = new CItem(IDObject.Item, 0.0f, 0.0f, EItem_Name.Key);
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
            if((Position.X - Global.Player_Positon.X > 200)&&(m_CurSprite._IDResource == IDResource.Boss_Transform1)&&(m_CurSprite.Animation.CurFrame == 0))
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
                m_CurSprite = Boss_Die1;
            }
            if (States == Object_States.Before_Die)
            {
                if ((m_CurSprite._IDResource == IDResource.Boss_Die1) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite = Boss_Die2;
                }
                if ((m_CurSprite._IDResource == IDResource.Boss_Die2) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite = Boss_Die3;
                }
                if ((m_CurSprite._IDResource == IDResource.Boss_Die3) && (m_CurSprite.Animation.Loop >= 1))
                {
                    IsVisible = false;
                    //if(m_DirFace == DirFace.Right)
                    m_Item.Position = new Vector2(Position.X + Bound.Width / 2, Position.Y + 100);
                    //else m_Item.Position = new Vector2(Position.X, Position.Y);
                    //States = Object_States.Die;
                }     
            }
            if (States == Object_States.Transform)
            {
                if ((m_CurSprite._IDResource == IDResource.Boss_Transform1) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    m_CurSprite = Boss_Transform2;
                }
                if ((m_CurSprite._IDResource == IDResource.Boss_Transform2) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    States = Object_States.Stand;
                    m_CurSprite = Boss_Stand;
                }
            }
            if (States == Object_States.Attacking)
            {
                if ((m_CurSprite._IDResource == IDResource.Boss_Attack1_1) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    m_CurSprite = Boss_Attack1_2;
                }
                if ((m_CurSprite._IDResource == IDResource.Boss_Attack1_2) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    States = Object_States.Move;
                }
                if ((m_CurSprite._IDResource == IDResource.Boss_Attack2_1) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    m_CurSprite = Boss_Attack2_2;
                }
                if ((m_CurSprite._IDResource == IDResource.Boss_Attack2_2) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    States = Object_States.Move;
                }
                if ((m_CurSprite._IDResource == IDResource.Boss_Attack3) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    States = Object_States.Move;
                }
                if ((m_CurSprite._IDResource == IDResource.Boss_Attack4_1) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    m_CurSprite = Boss_Attack4_2;
                }
                if ((m_CurSprite._IDResource == IDResource.Boss_Attack4_2) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    m_CurSprite = Boss_Attack4_3;
                }
                if ((m_CurSprite._IDResource == IDResource.Boss_Attack4_3) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    m_CurSprite = Boss_Attack4_4;
                }
                if ((m_CurSprite._IDResource == IDResource.Boss_Attack4_4) && (m_CurSprite.Animation.Loop >= 1))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    States = Object_States.Move;
                }
            }
            if (States == Object_States.Move)
            {
                if (m_CurSprite.Animation.Loop >= 1)
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    States = Object_States.Attacking;
                    Random _random = new Random();
                    m_CurrentSkill = _random.Next(0,m_SkillList.Count);
                    m_CurSprite = m_SkillList[m_CurrentSkill];
                }
                else
                    m_CurSprite = Boss_Move;
            }
            if (States == Object_States.Stand)
            {
                if (m_CurSprite.Animation.Loop >= 1)
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    States = Object_States.Move;
                }
                else
                    m_CurSprite = Boss_Stand;
            }
            if (States == Object_States.Hit)
            {
                if ((m_CurSprite != Boss_Hit)&&(m_CurSprite != Boss_Move))
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                }
                m_CurSprite = Boss_Hit;
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
                    Velocity = new Vector2(-Boss_Velocity.X, Velocity.Y);
                }
                else
                {
                    Velocity = new Vector2(Boss_Velocity.X, Velocity.Y);
                }
            } 
            else Velocity = new Vector2(0.0f, Velocity.Y);
            if (Velocity.Y > 1.2f)
            {
                Velocity = new Vector2(Velocity.X, 0.0f);
            }

            if (((Global.Player_Positon.X - Position.X) > m_CurSprite.Width ) && (m_CurSprite == Boss_Hit))
            {
                if ((m_CurSprite.Animation.Loop == 0) && (m_CurSprite.Animation.CurFrame == m_CurSprite.Animation.FrameEnd))
                {
                    m_DirFace = DirFace.Right;
                    return;
                }
            }
            else
            {
                if (((Position.X - Global.Player_Positon.X) > 0) && (m_CurSprite == Boss_Hit))
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
            if ((_Object.ID == IDObject.Brick) || (_Object.ID == IDObject.BaseBrick) || (_Object.ID == IDObject.Barrel))
            {
                if(CheckCollision(_Object))
                {
                    CollisionDir _Dir = this.getCollisionDir(this, _Object);
                    
                    if (_Dir == CollisionDir.Bottom)
                    {
                        Velocity = new Vector2(-Velocity.X, 0.0f);
                        Position = new Vector2(this.Position.X, _Object.Position.Y - this.Bound.Height + 1);
                    }
                    if (_Dir == CollisionDir.Left)
                    {
                        if (States == Object_States.Attacking)
                        {
                            return;
                        }
                        Velocity = new Vector2(0.0f, Velocity.Y);
                        if (_Object.ID == IDObject.Barrel)
                            Position = new Vector2(_Object.Position.X + _Object.Bound.Width + 75 - 47, Position.Y);
                        else Position = new Vector2(_Object.Position.X + _Object.Bound.Width, Position.Y);
                        m_DirFace = DirFace.Right;
                    }
                    if (_Dir == CollisionDir.Right)
                    {
                        if (States == Object_States.Attacking)
                        {
                            return;
                        }
                        Velocity = new Vector2(0.0f, Velocity.Y);
                        if (_Object.ID == IDObject.Barrel)
                            Position = new Vector2(_Object.Position.X - this.Bound.Width + 25, Position.Y);
                        else Position = new Vector2(_Object.Position.X - this.Bound.Width, Position.Y);

                        m_DirFace = DirFace.Left;
                    }
                    if (_Dir == CollisionDir.Top)
                    {
                        Position = new Vector2(this.Position.X, _Object.Position.Y + _Object.Bound.Height);
                    }
                    //if((m_CurSprite == Boss_Attack4_1) || (m_CurSprite == Boss_Attack4_2) || (m_CurSprite == Boss_Attack4_3) || (m_CurSprite == Boss_Attack4_4))
                    Position = new Vector2(Position.X, 203);
                }
                else
                {
                    if (((Global.Player_Positon.X - Position.X) <= (200 + m_CurSprite.Width)) && ((Global.Player_Positon.X - Position.X) > 0) && (m_CurSprite == Boss_Move))
                    {
                        if ((m_CurSprite.Animation.Loop == 0) && (m_CurSprite.Animation.CurFrame == m_CurSprite.Animation.FrameEnd))
                        {
                            m_DirFace = DirFace.Right;
                            return;
                        }
                    }
                    else
                    {
                        if (((Position.X - Global.Player_Positon.X) <= (200 + 80)) && ((Position.X - Global.Player_Positon.X) > 0) && (m_CurSprite == Boss_Move))
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
                if(CheckCollision(_Object))
                {   
                    CollisionDir _Dir = this.getCollisionDir(this, _Object);
                    if (States == Object_States.Attacking)
                    {
                     /*   if (_Dir == CollisionDir.Left)
                        {
                            m_DirFace = DirFace.Left;
                        }
                        if (_Dir == CollisionDir.Right)
                        {
                            m_DirFace = DirFace.Right;
                        } */
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
                            if (m_CurSprite == Boss_Attack1_1)
                            {
                                min = 10;
                                max = 15;
                            }
                            if (m_CurSprite == Boss_Attack2_1)
                            {
                                min = 10;
                                max = 11;
                            }
                            if (m_CurSprite == Boss_Attack2_2)
                            {
                                min = 0;
                                max = 4;
                            }
                            if (m_CurSprite == Boss_Attack3)
                            {
                                min = 8;
                                max = 15;
                            }
                            if (m_CurSprite == Boss_Attack4_2)
                            {
                                min = 7;
                                max = 9;
                            }
                            if (m_CurSprite == Boss_Attack4_3)
                            {
                                min = 0;
                                max = 7;
                            }
                            if (max == 0)
                                return;
                            if ((States == Object_States.Attacking) && (m_CurSprite.Animation.CurFrame >= min) && (m_CurSprite.Animation.CurFrame <= max))
                            {
                                ListEffect.Add((m_ListHitEffect[m_CurrentSkill]));
                                m_ListEffect[m_ListEffect.Count - 1].Position = _Object.Position;
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
                if ((m_CurSprite == Boss_Attack1_1) && (m_CurSprite.Animation.CurFrame >= 10) && (m_CurSprite.Animation.CurFrame <= 15))
                {
                    Rectangle X_Rect;
                    X_Rect.Width = (int)((Size.X * m_CurSprite.Scale) + 200);
                    X_Rect.X = (int)(Position.X - 100);
                    X_Rect.Y = (int)(Position.Y);

                    X_Rect.Height = (int)(((Size.Y) * m_CurSprite.Scale));
                    return X_Rect;
                }
                if ((m_CurSprite == Boss_Attack2_1) || (m_CurSprite == Boss_Attack2_2))
                {
                    Rectangle X_Rect;
                    X_Rect.Width = (int)((Size.X * m_CurSprite.Scale) + 180);
                    X_Rect.X = (int)(Position.X - 90);
                    X_Rect.Y = (int)(Position.Y);

                    X_Rect.Height = (int)(((Size.Y) * m_CurSprite.Scale));
                    return X_Rect;
                }
                if ((m_CurSprite == Boss_Attack3) && (m_CurSprite.Animation.CurFrame >= 8) && (m_CurSprite.Animation.CurFrame <= 15))
                {
                    Rectangle X_Rect;
                    if (m_DirFace == DirFace.Left)
                    {
                        X_Rect.Width = (int)((Size.X * m_CurSprite.Scale));
                        X_Rect.X = (int)(Position.X - 50);
                    }
                    else
                    {
                        X_Rect.Width = (int)((Size.X * m_CurSprite.Scale));
                        X_Rect.X = (int)(Position.X + 50);
                    }
                    X_Rect.Y = (int)(Position.Y);
                    X_Rect.Height = (int)(((Size.Y) * m_CurSprite.Scale));
                    return X_Rect;
                }
                if ((m_CurSprite == Boss_Attack4_3) && (m_CurSprite.Animation.CurFrame >= 0) && (m_CurSprite.Animation.CurFrame <= 8))
                {
                    Rectangle X_Rect;
                    if (m_DirFace == DirFace.Left)
                    {
                        X_Rect.Width = (int)((Size.X * m_CurSprite.Scale) + 350);
                        X_Rect.X = (int)(Position.X - 200);
                    }
                    else
                    {
                        X_Rect.Width = (int)((Size.X * m_CurSprite.Scale) + 300);
                        X_Rect.X = (int)(Position.X - 100);
                    }
                    X_Rect.Y = (int)(Position.Y + 300);

                    X_Rect.Height = (int)(((Size.Y) * m_CurSprite.Scale) - 300);
                    return X_Rect;
                }
                else return base.Bound;
            }
        }
    }
}
