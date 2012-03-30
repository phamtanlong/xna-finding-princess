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
    class CPlayer : CAnimatedObject
    {
        DirFace m_DirFace;
        protected int m_Level = 7;
        protected List<CSprite> m_SkillList;
        protected List<Keys> m_KeySkillList;
        protected int m_CurrentSkill = 0;

        protected CSprite Player_Stand;
        protected CSprite Player_Move;
        protected CSprite Player_Jump;
        protected CSprite Player_Die;

        #region Effect        
        protected CEffect m_EffectHeroAttack1_Ball;
        protected CEffect m_EffectHeroAttack2_Ball;
        protected CEffect m_EffectHeroAttack3_Ball;

        protected CEffect m_EffectHeroAttack4_Ball1_Lv1;
        protected CEffect m_EffectHeroAttack4_Ball2_Lv1;
        protected CEffect m_EffectHeroAttack4_Ball3_Lv1;
        protected CEffect m_EffectHeroAttack4_Ball4_Lv1;
        protected CEffect m_EffectHeroAttack4_Ball5_Lv1;
        protected CEffect m_EffectHeroAttack4_Ball6_Lv1;

        protected CEffect m_EffectHeroAttack4_Ball_Lv3;
        protected CEffect m_EffectHeroAttack4_Ball1_Lv3;
        protected CEffect m_EffectHeroAttack4_Ball2_Lv3;
        protected CEffect m_EffectHeroAttack4_Ball3_Lv3;
        protected CEffect m_EffectHeroAttack4_Ball4_Lv3;
        protected CEffect m_EffectHeroAttack4_Ball5_Lv3;
        protected CEffect m_EffectHeroAttack4_Ball6_Lv3;

        protected CEffect m_EffectHeroAttack5_Effect1;
        protected CEffect m_EffectHeroAttack5_Effect2;
        protected CEffect m_EffectHeroAttack5_Effect3;
        protected CEffect m_EffectHeroAttack5_Effect4;
        protected CEffect m_EffectHeroAttack5_Effect5;
        protected CEffect m_EffectHeroAttack5_Effect6;
        protected CEffect m_EffectHeroAttack5_Effect7;

        protected CEffect m_EffectHeroAttack1_Hit;
        protected CEffect m_EffectHeroAttack2_Hit;
        protected CEffect m_EffectHeroAttack3_Hit;
        #endregion

        public CPlayer(IDObject _ID, float _PosX, float _PosY, float _VelocX, float _VelocY, float _AccelX, float _AccelY)
            : base(_ID, _PosX, _PosY, _VelocX, _VelocY, _AccelX, _AccelY)
        {
            m_DirFace = DirFace.Right;
            States = Object_States.Stand;
            m_SkillList = new List<CSprite>();
            m_KeySkillList = new List<Keys>();
        }
        public override void Init(ContentManager _CM)
        {
            Mana = 250;
            HP = 500;
            MAX_HP = HP;
            MAX_MANA = Mana;

            Player_Stand = new CSprite (CResourceManager.getInstance().getSprite(IDResource.Player_Stand));
            Player_Move = new CSprite (CResourceManager.getInstance().getSprite(IDResource.Player_Move));
            Player_Jump = new CSprite (CResourceManager.getInstance().getSprite(IDResource.Player_Jump));
            Player_Die = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Player_Die));
            m_SkillList.Add(CResourceManager.getInstance().getSprite(IDResource.Player_Attack1));
            m_SkillList.Add(CResourceManager.getInstance().getSprite(IDResource.Player_Attack2));
            m_SkillList.Add(CResourceManager.getInstance().getSprite(IDResource.Player_Attack3));
            m_SkillList.Add(CResourceManager.getInstance().getSprite(IDResource.Player_Attack4));
            m_SkillList.Add(CResourceManager.getInstance().getSprite(IDResource.Player_Attack5));
            
            m_KeySkillList.Add(Keys.Z);
            m_KeySkillList.Add(Keys.X);
            m_KeySkillList.Add(Keys.C);
            m_KeySkillList.Add(Keys.V);
            m_KeySkillList.Add(Keys.Space);
            m_EffectHeroAttack1_Ball = new CEffect(IDEffect.Effect_Hero_Attack1_Ball);
            m_EffectHeroAttack1_Ball.Init(IDResource.Effect_Hero_Attack1_Ball);
            m_EffectHeroAttack2_Ball = new CEffect(IDEffect.Effect_Hero_Attack2_Ball);
            m_EffectHeroAttack2_Ball.Init(IDResource.Effect_Hero_Attack2_Ball);
            m_EffectHeroAttack3_Ball = new CEffect(IDEffect.Effect_Hero_Attack3_Ball);
            m_EffectHeroAttack3_Ball.Init(IDResource.Effect_Hero_Attack3_Ball);
            //m_EffectHeroAttack2_Ball.CurSprite.Scale = 1.2f;
            m_EffectHeroAttack4_Ball1_Lv1 = new CEffect(IDEffect.Effect_Hero_Attack4_Ball1_Lv1);
            m_EffectHeroAttack4_Ball1_Lv1.Init(IDResource.Effect_Hero_Attack4_Ball1_Lv1);
            m_EffectHeroAttack4_Ball2_Lv1 = new CEffect(IDEffect.Effect_Hero_Attack4_Ball2_Lv1);
            m_EffectHeroAttack4_Ball2_Lv1.Init(IDResource.Effect_Hero_Attack4_Ball2_Lv1);
            m_EffectHeroAttack4_Ball3_Lv1 = new CEffect(IDEffect.Effect_Hero_Attack4_Ball3_Lv1);
            m_EffectHeroAttack4_Ball3_Lv1.Init(IDResource.Effect_Hero_Attack4_Ball3_Lv1);
            m_EffectHeroAttack4_Ball4_Lv1 = new CEffect(IDEffect.Effect_Hero_Attack4_Ball4_Lv1);
            m_EffectHeroAttack4_Ball4_Lv1.Init(IDResource.Effect_Hero_Attack4_Ball4_Lv1);
            m_EffectHeroAttack4_Ball5_Lv1 = new CEffect(IDEffect.Effect_Hero_Attack4_Ball5_Lv1);
            m_EffectHeroAttack4_Ball5_Lv1.Init(IDResource.Effect_Hero_Attack4_Ball5_Lv1);
            m_EffectHeroAttack4_Ball6_Lv1 = new CEffect(IDEffect.Effect_Hero_Attack4_Ball6_Lv1);
            m_EffectHeroAttack4_Ball6_Lv1.Init(IDResource.Effect_Hero_Attack4_Ball6_Lv1);

            m_EffectHeroAttack4_Ball_Lv3 = new CEffect(IDEffect.Effect_Hero_Attack4_Ball_Lv3);
            m_EffectHeroAttack4_Ball_Lv3.Init(IDResource.Effect_Hero_Attack4_Ball_Lv3);
            m_EffectHeroAttack4_Ball1_Lv3 = new CEffect(IDEffect.Effect_Hero_Attack4_Ball1_Lv3);
            m_EffectHeroAttack4_Ball1_Lv3.Init(IDResource.Effect_Hero_Attack4_Ball1_Lv3);
            m_EffectHeroAttack4_Ball2_Lv3 = new CEffect(IDEffect.Effect_Hero_Attack4_Ball2_Lv3);
            m_EffectHeroAttack4_Ball2_Lv3.Init(IDResource.Effect_Hero_Attack4_Ball2_Lv3);
            m_EffectHeroAttack4_Ball3_Lv3 = new CEffect(IDEffect.Effect_Hero_Attack4_Ball3_Lv3);
            m_EffectHeroAttack4_Ball3_Lv3.Init(IDResource.Effect_Hero_Attack4_Ball3_Lv3);
            m_EffectHeroAttack4_Ball4_Lv3 = new CEffect(IDEffect.Effect_Hero_Attack4_Ball4_Lv3);
            m_EffectHeroAttack4_Ball4_Lv3.Init(IDResource.Effect_Hero_Attack4_Ball4_Lv3);
            m_EffectHeroAttack4_Ball5_Lv3 = new CEffect(IDEffect.Effect_Hero_Attack4_Ball5_Lv3);
            m_EffectHeroAttack4_Ball5_Lv3.Init(IDResource.Effect_Hero_Attack4_Ball5_Lv3);
            m_EffectHeroAttack4_Ball6_Lv3 = new CEffect(IDEffect.Effect_Hero_Attack4_Ball6_Lv3);
            m_EffectHeroAttack4_Ball6_Lv3.Init(IDResource.Effect_Hero_Attack4_Ball6_Lv3);


            m_EffectHeroAttack5_Effect1 = new CEffect(IDEffect.Effect_Hero_Attack5_Effect1);
            m_EffectHeroAttack5_Effect1.Init(IDResource.Effect_Hero_Attack5_Effect1);
            m_EffectHeroAttack5_Effect2 = new CEffect(IDEffect.Effect_Hero_Attack5_Effect2);
            m_EffectHeroAttack5_Effect2.Init(IDResource.Effect_Hero_Attack5_Effect2);
            m_EffectHeroAttack5_Effect3 = new CEffect(IDEffect.Effect_Hero_Attack5_Effect3);
            m_EffectHeroAttack5_Effect3.Init(IDResource.Effect_Hero_Attack5_Effect3);
            m_EffectHeroAttack5_Effect4 = new CEffect(IDEffect.Effect_Hero_Attack5_Effect4);
            m_EffectHeroAttack5_Effect4.Init(IDResource.Effect_Hero_Attack5_Effect4);
            m_EffectHeroAttack5_Effect5 = new CEffect(IDEffect.Effect_Hero_Attack5_Effect5);
            m_EffectHeroAttack5_Effect5.Init(IDResource.Effect_Hero_Attack5_Effect5);
            m_EffectHeroAttack5_Effect6 = new CEffect(IDEffect.Effect_Hero_Attack5_Effect6);
            m_EffectHeroAttack5_Effect6.Init(IDResource.Effect_Hero_Attack5_Effect6);
            m_EffectHeroAttack5_Effect7 = new CEffect(IDEffect.Effect_Hero_Attack5_Effect7);
            m_EffectHeroAttack5_Effect7.Init(IDResource.Effect_Hero_Attack5_Effect7);


            m_EffectHeroAttack1_Hit = new CEffect(IDEffect.Effect_Hero_Attack1_Hit);
            m_EffectHeroAttack1_Hit.Init(IDResource.Effect_Hero_Attack1_Hit);
            m_EffectHeroAttack2_Hit = new CEffect(IDEffect.Effect_Hero_Attack2_Hit);
            m_EffectHeroAttack2_Hit.Init(IDResource.Effect_Hero_Attack2_Hit);
            m_EffectHeroAttack3_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
            m_EffectHeroAttack3_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);
            m_CurSprite = Player_Move;
            base.Init(_CM);
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            for (int i = 0; i < m_ListEffect.Count; i++)
            {
                m_ListEffect[i].Draw(_spriteBatch);
            }
            
            _spriteBatch.Draw(_helthBar, Position - new Vector2(10, 30), Color.White);
            Vector2 _vec = Position - new Vector2(10, 30) + new Vector2(1, 1);
            _spriteBatch.Draw(_mana, new Rectangle((int)_vec.X, (int)_vec.Y, (int)(_mana.Width * (float)Mana / (float)MAX_MANA), _mana.Height), Color.White);
            
            base.Draw(_spriteBatch);
        }
        public override void UpdateAnimation(GameTime _gameTime)
        {
            if (States != Object_States.Die)
            {
                m_CurSprite.Update(_gameTime);
            }
            if ((HP <= 0) && (States != Object_States.Die))
            {
                States = Object_States.Before_Die;
            }
            if (States == Object_States.Before_Die)
            {
                m_CurSprite = Player_Die;
                if (m_CurSprite.Animation.Loop >= 1)
                {
                    States = Object_States.Die;
                }
            }
            if ((m_CurSprite.Animation.Loop >= 1)&&(States == Object_States.Attacking))
            {
                m_CurSprite.Animation.Loop = 0;
                Velocity = new Vector2(Velocity.X, 0.01f);
                States = Object_States.Stand;
            }

            if (States == Object_States.Jumping)
                m_CurSprite = Player_Jump;
            if (States == Object_States.Move)
                m_CurSprite = Player_Move;
            if (States == Object_States.Stand)
                m_CurSprite = Player_Stand;

            if (m_DirFace == DirFace.Right)
                m_CurSprite._Effect = SpriteEffects.FlipHorizontally;
            else
                m_CurSprite._Effect = SpriteEffects.None;
        }
        public void UpdateAttacking(GameTime _gameTime)
        {
            if (States == Object_States.Attacking)
            {
                m_CurSprite = m_SkillList[m_CurrentSkill];
                if (m_CurSprite.Animation.LocalTime >= (m_CurSprite.Animation.TimeAnimation - (float)_gameTime.ElapsedGameTime.TotalMilliseconds))
                {
                    if ((m_CurrentSkill == 0) && (m_CurSprite.Animation.CurFrame == 8))
                    {
                        m_ListEffect.Add(m_EffectHeroAttack1_Ball);
                        if (m_DirFace == DirFace.Right)
                        {
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(this.Position.X + 30.0f, this.Position.Y);
                            m_ListEffect[m_ListEffect.Count - 1].CurSprite._Effect = SpriteEffects.FlipHorizontally;
                        }
                        else
                        {
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(this.Position.X - 300.0f, this.Position.Y);
                            m_ListEffect[m_ListEffect.Count - 1].CurSprite._Effect = SpriteEffects.None;
                        }
                    }
                    if ((m_CurrentSkill == 1) && (m_CurSprite.Animation.CurFrame == 7))
                    {
                        m_ListEffect.Add(m_EffectHeroAttack2_Ball);
                        if (m_DirFace == DirFace.Right)
                        {
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(this.Position.X + 80.0f, this.Position.Y+15.0f);
                            m_ListEffect[m_ListEffect.Count - 1].CurSprite._Effect = SpriteEffects.FlipHorizontally;
                        }
                        else
                        {
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(this.Position.X - 300.0f, this.Position.Y+15.0f);
                            m_ListEffect[m_ListEffect.Count - 1].CurSprite._Effect = SpriteEffects.None;
                        }
                    }
                    if ((m_CurrentSkill == 2) && (m_CurSprite.Animation.CurFrame == 12))
                    {
                        m_ListEffect.Add(m_EffectHeroAttack3_Ball);
                        if (m_DirFace == DirFace.Right)
                        {
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(this.Position.X + 100.0f, this.Position.Y - 53.0f);
                            m_ListEffect[m_ListEffect.Count - 1].CurSprite._Effect = SpriteEffects.FlipHorizontally;
                        }
                        else
                        {
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(this.Position.X - 100.0f, this.Position.Y - 53.0f);
                            m_ListEffect[m_ListEffect.Count - 1].CurSprite._Effect = SpriteEffects.None;
                        }
                    }
                    InitEffectSkill4();
                    
                    if ((m_CurrentSkill == 4) && (m_CurSprite.Animation.CurFrame == 0))
                    {
                        InitEffectSkill5();
                    }
                }
            }
            UpdateEffectSkill4(_gameTime);
        }
        public void InitEffectSkill4()
        {
            if ((m_Level >= 1)&&(Mana>=20))
            {
                if ((m_CurrentSkill == 3) && (m_CurSprite.Animation.CurFrame == 0))
                {
                    Mana -= 20;
                    m_ListEffect.Add(m_EffectHeroAttack4_Ball1_Lv1);
                    if (Position.X <= 400.0f)
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(0.0f, 100.0f);
                    else
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X - 400.0f, 100.0f);

                    m_ListEffect.Add(m_EffectHeroAttack4_Ball3_Lv1);
                    if (Position.X <= 400.0f)
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(300.0f, 50.0f);
                    else
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X - 100.0f, 50.0f);


                    m_ListEffect.Add(m_EffectHeroAttack4_Ball4_Lv1);
                    if (Position.X <= 400.0f)
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(103.0f, 150.0f);
                    else
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X - 400.0f + 103.0f, 150.0f);

                    m_ListEffect.Add(m_EffectHeroAttack4_Ball6_Lv1);
                    if (Position.X <= 400.0f)
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(600.0f, 327.0f);
                    else
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X - 400.0f + 600.0f, 327.0f);
                }
            }
            if ((m_Level >= 2)&&(Mana>=20))
            {
                if ((m_CurrentSkill == 3) && (m_CurSprite.Animation.CurFrame == 0))
                {
                    Mana -= 20;
                    m_ListEffect.Add(m_EffectHeroAttack4_Ball2_Lv1);
                    if (Position.X <= 400.0f)
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(100.0f, 150.0f);
                    else
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X - 300.0f, 150.0f);

                    m_ListEffect.Add(m_EffectHeroAttack4_Ball5_Lv1);
                    if (Position.X <= 400.0f)
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(500.0f, 200.0f);
                    else
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X - 400.0f + 500.0f, 200.0f);
                }
            }
            if ((m_Level >= 3) && (Mana >= 50))
            {
                if ((m_CurrentSkill == 3) && (m_CurSprite.Animation.CurFrame == (m_CurSprite.Animation.FrameEnd - 5)))
                {
                    Mana -= 10;
                    m_ListEffect.Add(m_EffectHeroAttack4_Ball_Lv3);
                    if (Position.X <= 400.0f)
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(330.0f, -71.0f);
                    else
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X - 70.0f, -71.0f);
                }
            }
            if ((m_Level >= 4)&&(Mana>=50))
            {
                if ((m_CurrentSkill == 3) && (m_CurSprite.Animation.CurFrame == m_CurSprite.Animation.FrameEnd))
                {
                    Mana -= 50;
                    m_ListEffect.Add(new CEffect(m_EffectHeroAttack4_Ball6_Lv3));
                    if (Position.X <= 400.0f)
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(0.0f, 200.0f);
                    else
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X - 400.0f, 200.0f);

                    m_ListEffect.Add(new CEffect(m_EffectHeroAttack4_Ball5_Lv3));
                    if (Position.X <= 400.0f)
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(100.0f, 215.0f);
                    else
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X - 300.0f, 215.0f);


                    m_ListEffect.Add(new CEffect(m_EffectHeroAttack4_Ball4_Lv3));
                    if (Position.X <= 400.0f)
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(200.0f, 330.0f);
                    else
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X - 200.0f, 330.0f);


                    m_ListEffect.Add(new CEffect(m_EffectHeroAttack4_Ball3_Lv3));
                    if (Position.X <= 400.0f)
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(350.0f, 320.0f);
                    else
                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X - 50.0f, 320.0f);


                       m_ListEffect.Add(new CEffect(m_EffectHeroAttack4_Ball2_Lv3));
                       if (Position.X <= 400.0f)
                           m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(500.0f, 260.0f);
                       else
                           m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X + 100.0f, 260.0f);

                       m_ListEffect.Add(new CEffect(m_EffectHeroAttack4_Ball1_Lv3));
                       if (Position.X <= 400.0f)
                           m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(600.0f, 250.0f);
                       else
                           m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X + 200.0f, 250.0f);
                }
            }
        }
        public void UpdateEffectSkill4(GameTime _gameTime)
        {
            if ((m_Level >= 5) && (Mana >= 50))
            {
                for (int i = 0; i < m_ListEffect.Count; i++)
                {
                    if ( (m_ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball1_Lv3) && (m_ListEffect[i].CurSprite.Animation.CurFrame == m_ListEffect[i].CurSprite.Animation.FrameEnd) && (m_ListEffect[i].CurSprite.Animation.LocalTime >= (m_ListEffect[i].CurSprite.Animation.TimeAnimation - (float)_gameTime.ElapsedGameTime.TotalMilliseconds)) )
                    {
                        Mana -= 50;
                        m_ListEffect.Add(new CEffect(m_EffectHeroAttack4_Ball6_Lv3));
                        if (Position.X <= 400.0f)
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(0.0f, 200.0f);
                        else
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X - 400.0f, 200.0f);

                        m_ListEffect.Add(new CEffect(m_EffectHeroAttack4_Ball5_Lv3));
                        if (Position.X <= 400.0f)
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(100.0f, 215.0f);
                        else
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X - 300.0f, 215.0f);

                        m_ListEffect.Add(new CEffect(m_EffectHeroAttack4_Ball4_Lv3));
                        if (Position.X <= 400.0f)
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(200.0f, 330.0f);
                        else
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X - 200.0f, 330.0f);


                        m_ListEffect.Add(new CEffect(m_EffectHeroAttack4_Ball3_Lv3));
                        if (Position.X <= 400.0f)
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(350.0f, 320.0f);
                        else
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X - 50.0f, 320.0f);


                        m_ListEffect.Add(new CEffect(m_EffectHeroAttack4_Ball2_Lv3));
                        if (Position.X <= 400.0f)
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(500.0f, 260.0f);
                        else
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X + 100.0f, 260.0f);

                        m_ListEffect.Add(new CEffect(m_EffectHeroAttack4_Ball1_Lv3));
                        if (Position.X <= 400.0f)
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(600.0f, 250.0f);
                        else
                            m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(Position.X + 200.0f, 250.0f);
                    }
                }
            }
        }
        public void InitEffectSkill5()
        {
            for (int i = 0; i < m_ListEffect.Count; i++)
            {
                if ((m_ListEffect[i].ID == IDEffect.Effect_Hero_Attack5_Effect1) || (m_ListEffect[i].ID == IDEffect.Effect_Hero_Attack5_Effect2) || (m_ListEffect[i].ID == IDEffect.Effect_Hero_Attack5_Effect3) || (m_ListEffect[i].ID == IDEffect.Effect_Hero_Attack5_Effect4) || (m_ListEffect[i].ID == IDEffect.Effect_Hero_Attack5_Effect5) || (m_ListEffect[i].ID == IDEffect.Effect_Hero_Attack5_Effect6) || (m_ListEffect[i].ID == IDEffect.Effect_Hero_Attack5_Effect7))
                {
                    m_ListEffect[i].CurSprite.Animation.Loop = 0;
                    m_ListEffect[i].CurSprite.Animation.CurFrame = 0;
                    m_ListEffect.Remove(m_ListEffect[i]);
                }
            }
            if (m_Level == 1)
            {
                m_ListEffect.Add(m_EffectHeroAttack5_Effect1);
                m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(this.Position.X-70.0f, this.Position.Y - 75.0f);
            }
            if (m_Level == 2)
            {
                m_ListEffect.Add(m_EffectHeroAttack5_Effect2);
                    m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(this.Position.X - 48.0f, this.Position.Y - 42.0f);
            }
            if (m_Level == 3)
            {
                m_ListEffect.Add(m_EffectHeroAttack5_Effect3);
                m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(this.Position.X - 65.0f, this.Position.Y - 120.0f);
            }
            if (m_Level == 4)
            {
                m_ListEffect.Add(m_EffectHeroAttack5_Effect4);
                m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(this.Position.X - 45.0f, this.Position.Y - 167.5f);
            }
            if (m_Level == 5)
            {
                m_ListEffect.Add(m_EffectHeroAttack5_Effect5);
                m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(this.Position.X - 45.0f, this.Position.Y - 35.0f);
            }
            if (m_Level == 6)
            {
                m_ListEffect.Add(m_EffectHeroAttack5_Effect6);
                m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(this.Position.X - 47.0f, this.Position.Y - 65.0f);
            }
            if (m_Level >= 7)
            {
                m_ListEffect.Add(m_EffectHeroAttack5_Effect7);
                m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(this.Position.X - 79.0f, this.Position.Y - 100.0f);
            }
        }
        public void UpdateEffectSkill5(CEffect _Effect)
        {
            if (_Effect.ID == IDEffect.Effect_Hero_Attack5_Effect1)
            {
                _Effect.Position = new Vector2(this.Position.X - 70.0f, this.Position.Y - 75.0f);
            }
            if (_Effect.ID == IDEffect.Effect_Hero_Attack5_Effect2)
            {
                _Effect.Position = new Vector2(this.Position.X - 48.0f, this.Position.Y - 42.0f);
            }
            if (_Effect.ID == IDEffect.Effect_Hero_Attack5_Effect3)
            {
                _Effect.Position = new Vector2(this.Position.X - 65.0f, this.Position.Y - 120.0f);
            }
            if (_Effect.ID == IDEffect.Effect_Hero_Attack5_Effect4)
            {
                _Effect.Position = new Vector2(this.Position.X - 45.0f, this.Position.Y - 167.5f);
            }
            if (_Effect.ID == IDEffect.Effect_Hero_Attack5_Effect5)
            {
                _Effect.Position = new Vector2(this.Position.X - 45.0f, this.Position.Y - 35.0f);
            }
            if (_Effect.ID == IDEffect.Effect_Hero_Attack5_Effect6)
            {
                _Effect.Position = new Vector2(this.Position.X - 47.0f, this.Position.Y - 65.0f);
            }
            if (_Effect.ID == IDEffect.Effect_Hero_Attack5_Effect7)
            {
                _Effect.Position = new Vector2(this.Position.X - 79.0f, this.Position.Y - 100.0f);
            }

        }
        public override void UpdateMovement(GameTime _gameTime)
        {
            if ((States == Object_States.Before_Die) || (States == Object_States.Die))
                return;

            if (States != Object_States.Attacking)
            {
                Accel = new Vector2(0.0f, 0.004f);
                if (CInput.KeyDown(Keys.Right))
                {
                    if (m_DirFace != DirFace.Right)
                        m_DirFace = DirFace.Right;
                    Velocity = new Vector2(0.2f, Velocity.Y);
                    States = Object_States.Move;
                }
                
                if (CInput.KeyDown(Keys.Left))
                {
                    if (m_DirFace != DirFace.Left)
                        m_DirFace = DirFace.Left;
                    Velocity = new Vector2(- 0.2f, Velocity.Y);
                    States = Object_States.Move;
                }
                
                if ((CInput.KeyDown(Keys.Up) == true) && Velocity.Y == 0.0f)
                {
                    Velocity = new Vector2(Velocity.X, - 1.25f);
                    States = Object_States.Jumping;
                }
                //////////////////////////////////////////////////////////////////////////
                for (int i = 0; i < m_SkillList.Count-1; i++)
                {
                    if (CInput.KeyPressed(m_KeySkillList[i]))
                    {
                        States = Object_States.Attacking;
                        m_CurrentSkill = i;
                        Velocity = new Vector2(0.0f, 0.0f);
                        if ((m_CurrentSkill == 0) || (m_CurrentSkill == 1) || (m_CurrentSkill == 3))
                            Accel = new Vector2(0.0f, 0.0f);
                    }
                }
                //////////////////////////////////////////////////////////////////////////
                if (CInput.KeyDown(m_KeySkillList[m_SkillList.Count - 1]))
                {
                    Mana += 10;
                    if (Mana > MAX_MANA)
                        Mana = MAX_MANA;

                    Console.WriteLine("Mana= " + Mana);
                    States = Object_States.Attacking;
                    m_CurrentSkill = m_SkillList.Count - 1;
                    Velocity = new Vector2(0.0f, 0.0f);
                }
            }
            if ((CInput.KeyUnPressed(Keys.Right)) || (CInput.KeyUnPressed(Keys.Left)) || (CInput.KeyUnPressed(Keys.Up)))
            {
                Velocity = new Vector2(0.0f, Velocity.Y);
            }
                
            if (Velocity.Y > 1.2f)
            {
                Velocity = new Vector2(Velocity.X, 1.2f);
            }

            if ((Velocity.X == 0) && (Velocity.Y == 0.0f) && (States != Object_States.Attacking))
                States = Object_States.Stand;
            base.UpdateMovement(_gameTime);
        }
        public override void UpdateCollision(ref CObject _Object)
        {
            #region Collision Brick and BaseBrick
            if ((_Object.ID == IDObject.Brick) 
                || (_Object.ID == IDObject.BaseBrick) 
                || (_Object.ID == IDObject.Barrel))
            {
                    CollisionDir _Dir = this.getCollisionDir(this, _Object);

                    if (_Dir == CollisionDir.Bottom)
                    {
                        Velocity = new Vector2(Velocity.X, 0.0f);
                        Position = new Vector2(this.Position.X, _Object.Position.Y - this.Bound.Height + 1);
                    }
                    if (_Dir == CollisionDir.Top)
                    {
                        Position = new Vector2(this.Position.X, _Object.Position.Y + _Object.Bound.Height);
                        Velocity = new Vector2(Velocity.X, 0.2f);
                    }
                    if (_Dir == CollisionDir.Left)
                    {
                        Velocity = new Vector2(0.0f, Velocity.Y);
                        if (_Object.ID == IDObject.Barrel)
                            Position = new Vector2(_Object.Position.X + _Object.Bound.Width + 75 - 47, Position.Y);
                        else Position = new Vector2(_Object.Position.X + _Object.Bound.Width, Position.Y);
                    }
                    if (_Dir == CollisionDir.Right)
                    {
                        Velocity = new Vector2(0.0f, Velocity.Y);
                        if(_Object.ID == IDObject.Barrel)
                            Position = new Vector2(_Object.Position.X - this.Bound.Width + 25, Position.Y);
                        else Position = new Vector2(_Object.Position.X - this.Bound.Width, Position.Y);
                    }
                
            }
            #endregion

            #region  Collision Monster with Player effect
            if ((_Object.ID == IDObject.Monster) 
                || (_Object.ID == IDObject.Boss) 
                || (_Object.ID == IDObject.Master))
            {
                if (_Object.States == Object_States.Die 
                    || _Object.States == Object_States.Before_Die
                    || ((_Object.States == Object_States.Stand) && (_Object.ID == IDObject.Master))
                    || _Object.States == Object_States.Transform)
                    return;

                for (int i = 0; i < m_ListEffect.Count; i++)
                {
                    if(_Object.Collision(this.ListEffect[i]) == true)
                    {
                        if((_Object.ID == IDObject.Boss)
                            &&
                            ((States == Object_States.Before_Die) || (States == Object_States.Transform)))
                            return;

                        if ((_Object.ID == IDObject.Master) 
                            && 
                            ((States == Object_States.Before_Die) || (States == Object_States.Stand)))
                            return;

                        if ((ListEffect[i].ID == IDEffect.Effect_Hero_Attack1_Ball) && (_Object.States != Object_States.Hit))
                        {
                            _Object.DeleteIDEffect();
                            _Object.HP -= 50;
                            _Object.States = Object_States.Hit;
                            m_ListEffect.Add(new CEffect(m_EffectHeroAttack1_Hit));
                            if (_Object.ID == IDObject.Boss)
                            {

                                if (m_DirFace == DirFace.Right)
                                    m_ListEffect[m_ListEffect.Count - 1].Position = _Object.Position;
                                else
                                    m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(_Object.Position.X + _Object.Bound.Width / 2, _Object.Position.Y);
                            }
                            else m_ListEffect[m_ListEffect.Count - 1].Position = _Object.Position;
                            _Object.AddIDEffect(ListEffect[i].ID);
                            
                        }

                        if ((ListEffect[i].ID == IDEffect.Effect_Hero_Attack1_Ball) && (_Object.States == Object_States.Hit) && (_Object.CheckIDEffect(ListEffect[i])== false))
                        {
                            _Object.HP -= 50;
                            m_ListEffect.Add(new CEffect(m_EffectHeroAttack1_Hit));
                            if (_Object.ID == IDObject.Boss)
                            {

                                if (m_DirFace == DirFace.Right)
                                    m_ListEffect[m_ListEffect.Count - 1].Position = _Object.Position;
                                else
                                    m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(_Object.Position.X + _Object.Bound.Width / 2, _Object.Position.Y);
                            }
                            else m_ListEffect[m_ListEffect.Count - 1].Position = _Object.Position;
                            _Object.AddIDEffect(ListEffect[i].ID);
                            
                        }
                        if ((ListEffect[i].ID == IDEffect.Effect_Hero_Attack2_Ball) && (_Object.States != Object_States.Hit))
                        {
                            _Object.DeleteIDEffect();
                            _Object.HP -= 70;
                            _Object.States = Object_States.Hit;
                            m_ListEffect.Add(new CEffect(m_EffectHeroAttack2_Hit));
                            if (_Object.ID == IDObject.Boss)
                            {

                                if (m_DirFace == DirFace.Right)
                                    m_ListEffect[m_ListEffect.Count - 1].Position = _Object.Position;
                                else
                                    m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(_Object.Position.X + _Object.Bound.Width / 2 - 50, _Object.Position.Y);
                            }
                            else m_ListEffect[m_ListEffect.Count - 1].Position = _Object.Position;
                            _Object.AddIDEffect(ListEffect[i].ID);

                        }

                        if ((ListEffect[i].ID == IDEffect.Effect_Hero_Attack2_Ball) && (_Object.States == Object_States.Hit) && (_Object.CheckIDEffect(ListEffect[i]) == false))
                        {
                            _Object.HP -= 70;
                            m_ListEffect.Add(new CEffect(m_EffectHeroAttack2_Hit));
                            if (_Object.ID == IDObject.Boss)
                            {

                                if (m_DirFace == DirFace.Right)
                                    m_ListEffect[m_ListEffect.Count - 1].Position = _Object.Position;
                                else
                                    m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(_Object.Position.X + _Object.Bound.Width / 2 - 50, _Object.Position.Y);
                            }
                            else m_ListEffect[m_ListEffect.Count - 1].Position = _Object.Position;
                            _Object.AddIDEffect(ListEffect[i].ID);

                        }
                        if ((ListEffect[i].ID == IDEffect.Effect_Hero_Attack3_Ball) && (_Object.States != Object_States.Hit))
                        {
                            _Object.DeleteIDEffect();
                            _Object.HP -= 90;
                            _Object.States = Object_States.Hit;
                            m_ListEffect.Add(new CEffect(m_EffectHeroAttack3_Hit));
                            if (_Object.ID == IDObject.Boss)
                            {

                                if (m_DirFace == DirFace.Right)
                                    m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(_Object.Position.X, _Object.Position.Y + _Object.Bound.Height / 2);
                                else
                                    m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(_Object.Position.X + _Object.Bound.Width / 2 - 50, _Object.Position.Y + _Object.Bound.Height / 2);
                            }
                            else m_ListEffect[m_ListEffect.Count - 1].Position = _Object.Position;
                            _Object.AddIDEffect(ListEffect[i].ID);
                            
                        }
                        if ((ListEffect[i].ID == IDEffect.Effect_Hero_Attack3_Ball) && (_Object.States == Object_States.Hit) && (_Object.CheckIDEffect(ListEffect[i])== false))
                        {
                            _Object.HP -= 90;
                            m_ListEffect.Add(new CEffect(m_EffectHeroAttack3_Hit));
                            if (_Object.ID == IDObject.Boss)
                            {

                                if (m_DirFace == DirFace.Right)
                                    m_ListEffect[m_ListEffect.Count - 1].Position = _Object.Position;
                                else
                                    if(_Object.States == Object_States.Attacking)
                                        m_ListEffect[m_ListEffect.Count - 1].Position = new Vector2(_Object.Position.X + _Object.Bound.Width / 2 - 200, _Object.Position.Y);
                            }
                            else m_ListEffect[m_ListEffect.Count - 1].Position = _Object.Position;
                            _Object.AddIDEffect(ListEffect[i].ID);
                            
                        }

                        if (((ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball1_Lv3) ||
                            (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball2_Lv3) ||
                            (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball3_Lv3) ||
                            (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball4_Lv3) ||
                            (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball5_Lv3) ||
                            (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball6_Lv3)) && (_Object.States != Object_States.Hit))
                        {
                            if ((m_ListEffect[i].CurSprite.Animation.CurFrame >= 10)&&(m_ListEffect[i].CurSprite.Animation.CurFrame <= 12))
                            {
                                _Object.DeleteIDEffect();
                                _Object.HP -= 100;
                                _Object.States = Object_States.Hit;
                                _Object.AddIDEffect(ListEffect[i].ID);
                            }
                        }

                        if (((ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball1_Lv3) ||
                        (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball2_Lv3) ||
                        (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball3_Lv3) ||
                        (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball4_Lv3) ||
                        (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball5_Lv3) ||
                        (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball6_Lv3)) && (_Object.States == Object_States.Hit) && (_Object.CheckIDEffect(ListEffect[i]) == false))
                        {
                            if ((m_ListEffect[i].CurSprite.Animation.CurFrame >= 10) && (m_ListEffect[i].CurSprite.Animation.CurFrame <= 12))
                            {
                                _Object.HP -= 100;
                                _Object.States = Object_States.Hit;
                                _Object.AddIDEffect(ListEffect[i].ID);
                            }
                        }

                        if (((ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball1_Lv1) ||
                            (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball2_Lv1) ||
                            (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball3_Lv1) ||
                            (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball4_Lv1) ||
                            (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball5_Lv1) ||
                            (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball6_Lv1)) && (_Object.States != Object_States.Hit))
                        {
                            if ((m_ListEffect[i].CurSprite.Animation.CurFrame >= 7) && (m_ListEffect[i].CurSprite.Animation.CurFrame <= 11))
                            {
                                _Object.DeleteIDEffect();
                                _Object.HP -= 100;
                                _Object.States = Object_States.Hit;
                                _Object.AddIDEffect(ListEffect[i].ID);
                            }
                        }

                        if (((ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball1_Lv1) ||
                        (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball2_Lv1) ||
                        (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball3_Lv1) ||
                        (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball4_Lv1) ||
                        (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball5_Lv1) ||
                        (ListEffect[i].ID == IDEffect.Effect_Hero_Attack4_Ball6_Lv1)) && (_Object.States == Object_States.Hit) && (_Object.CheckIDEffect(ListEffect[i]) == false))
                        {
                            if ((m_ListEffect[i].CurSprite.Animation.CurFrame >= 7) && (m_ListEffect[i].CurSprite.Animation.CurFrame <= 11))
                            {
                                _Object.HP -= 100;
                                _Object.States = Object_States.Hit;
                                _Object.AddIDEffect(ListEffect[i].ID);
                            }
                        }
                    }
                }
            }
            #endregion

            #region Collision with item
            if (_Object.ID == IDObject.Item)
            {
                CItem _item = (CItem) _Object;
                switch(_item.ItemName)
                {
                    case EItem_Name.Hp_Potion_1:
                        Console.WriteLine("HPPPPPPPPPPPPPPPPPPPPP");
                        HP += 200;
                        if (HP > MAX_HP)
                        {
                            MAX_HP = HP;
                        }
                        break;

                    case EItem_Name.Hp_Potion_2:
                        HP += 150;
                        if (HP > MAX_HP)
                        {
                            MAX_HP = HP;
                        }
                        break;
                }
                
            }
            #endregion

            base.UpdateCollision(ref _Object);
        }
        public void UpdateEffect(GameTime _gameTime)
        {
            for (int i = 0; i < m_ListEffect.Count; i++)
            {
                m_ListEffect[i].Update(_gameTime);
                
                if (m_ListEffect[i].ID == IDEffect.Effect_Hero_Attack1_Ball)
                {
                    if (m_DirFace == DirFace.Right)
                        m_ListEffect[i].Position += new Vector2(13.0f, 0.0f);
                    if (m_DirFace == DirFace.Left)
                        m_ListEffect[i].Position += new Vector2(-13.0f, 0.0f);

                }
                if (m_ListEffect[i].ID == IDEffect.Effect_Hero_Attack2_Ball)
                {
                    if (m_DirFace == DirFace.Right)
                        m_ListEffect[i].Position += new Vector2(11.0f, 0.0f);
                    if (m_DirFace == DirFace.Left)
                        m_ListEffect[i].Position += new Vector2(-11.0f, 0.0f);
                }
                if (m_ListEffect[i].ID == IDEffect.Effect_Hero_Attack3_Ball)
                {
                    if (m_ListEffect[i].CurSprite.Animation.LocalTime >= (m_ListEffect[i].CurSprite.Animation.TimeAnimation-(float)_gameTime.ElapsedGameTime.TotalMilliseconds))
                    {
                        if (m_DirFace == DirFace.Right)
                            m_ListEffect[i].Position += new Vector2(55.0f, 0.0f);
                        if (m_DirFace == DirFace.Left)
                            m_ListEffect[i].Position += new Vector2(-55.0f, 0.0f);
                    }
                }
                UpdateEffectSkill5(m_ListEffect[i]);
                if (m_ListEffect[i].CurSprite.Animation.Loop >= 1)
                {
                    m_ListEffect[i].CurSprite.Animation.Loop = 0;
                    m_ListEffect[i].CurSprite.Animation.CurFrame = 0;
                    m_ListEffect.Remove(m_ListEffect[i]);
                }
            }
        }
        int _count2Mana = 0;
        public override void Update(GameTime _gameTime)
        {
            _count2Mana++;
            if(_count2Mana > 15)
            {
                _count2Mana = 0;
                Mana++;
                if (Mana > MAX_MANA)
                    Mana = MAX_MANA;
            }
            
            UpdateAttacking(_gameTime);
            UpdateEffect(_gameTime);
            UpdateAnimation(_gameTime);
            UpdateMovement(_gameTime);
        }
        public override Rectangle Bound
        {
            get
            {
                Rectangle _Rect;
                _Rect.X = (int)Position.X;
                _Rect.Y = (int)Position.Y;
                _Rect.Width = (int)((Size.X * m_CurSprite.Scale - 10));
                _Rect.Height = (int)((Size.Y * m_CurSprite.Scale - 10));
                return _Rect;
            }
        }
    }
}
