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

enum EMonster_Name
{
    SnowMan,
    SnowMan_Blue,
    SnowMan_Red,
    SnowMan_Purple,
    SnowMan_Lady,
    Big_Clown,
    Mini_Clown,
    Yellow_Bean,
    Shark,
    Wolf_Man,
    Wolf_Orc,
    Wolf_Owl,
    Old_Panda
}


namespace FindingPrincess.Framework
{
    class CMonster : CAnimatedObject
    {
        private DirFace m_DirFace;
        private EMonster_Name m_Name;
        protected Vector2 Monster_Velocity;
        protected CSprite Monster_Attack;
        protected CSprite Monster_Attack2;
        protected CSprite Monster_Move;
        protected CSprite Monster_Hit;
        protected CSprite Monster_Die;
        protected CEffect m_EffectMonsterAttack_Hit;
        protected CEffect m_EffectMonsterAttack2_Hit;
        protected List<CSprite> m_SkillList;
        protected int m_CurrentSkill;
        protected List<CEffect> m_ListHitEffect;
        protected CItem m_Item;
        int Level;
        protected int Dam;
        public CMonster(IDObject _ID, float _PosX, float _PosY, float _VelocX, float _VelocY, float _AccelX, float _AccelY, DirFace _DirFace,EMonster_Name _Name)
            : base(_ID, _PosX, _PosY, _VelocX, _VelocY, _AccelX, _AccelY)
        {
            m_DirFace = _DirFace;
            States = Object_States.Move;
            m_Name = _Name;
            Monster_Velocity = new Vector2(_VelocX, _VelocY);
            m_SkillList = new List<CSprite>();
            m_ListHitEffect = new List<CEffect>();
        }
        public override void Init(ContentManager _CM)
        {
//            m_Item = new CItem(IDObject.Item, 0.0f, 0.0f, EItem_Name.Hp_Potion_1);
            if (m_Name == EMonster_Name.SnowMan)
            {
                m_Item = new CItem(IDObject.Item, 0.0f, 0.0f, EItem_Name.Hp_Potion_1);
                Level = 3;
                Dam = 20;
                HP = 400;
                Monster_Move = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Move));
                Monster_Attack = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Attack));
                Monster_Hit = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Hit));
                Monster_Die = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Die));
                m_EffectMonsterAttack_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
                m_EffectMonsterAttack_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);
                m_SkillList.Add(Monster_Attack);
                m_ListHitEffect.Add(m_EffectMonsterAttack_Hit);
                Random _random = new Random();
                m_CurrentSkill = _random.Next(0, m_SkillList.Count);
            }
            if (m_Name == EMonster_Name.SnowMan_Blue)
            {
                m_Item = new CItem(IDObject.Item, 0.0f, 0.0f, EItem_Name.Hp_Potion_2);
                Level = 1;
                Dam = 20;
                HP = 400;
                Monster_Move = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Blue_Move));
                Monster_Attack = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Blue_Attack));
                Monster_Hit = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Blue_Hit));
                Monster_Die = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Blue_Die));
                m_EffectMonsterAttack_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
                m_EffectMonsterAttack_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);
                m_SkillList.Add(Monster_Attack);
                m_ListHitEffect.Add(m_EffectMonsterAttack_Hit);
                Random _random = new Random();
                m_CurrentSkill = _random.Next(0, m_SkillList.Count);
            }
            if (m_Name == EMonster_Name.SnowMan_Purple)
            {
                m_Item = new CItem(IDObject.Item, 0.0f, 0.0f, EItem_Name.Hp_Potion_3);
                Level = 1;
                Dam = 20;
                HP = 500;
                Monster_Move = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Purple_Move));
                Monster_Attack = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Purple_Attack));
                Monster_Hit = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Purple_Hit));
                Monster_Die = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Purple_Die));
                m_EffectMonsterAttack_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
                m_EffectMonsterAttack_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);
                m_SkillList.Add(Monster_Attack);
                m_ListHitEffect.Add(m_EffectMonsterAttack_Hit);
                Random _random = new Random();
                m_CurrentSkill = _random.Next(0, m_SkillList.Count);
            }
            if (m_Name == EMonster_Name.SnowMan_Red)
            {
                m_Item = new CItem(IDObject.Item, 0.0f, 0.0f, EItem_Name.Clover);
                Level = 1;
                Dam = 20;
                HP = 450;
                Monster_Move = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Red_Move));
                Monster_Attack = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Red_Attack));
                Monster_Hit = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Red_Hit));
                Monster_Die = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Red_Die));
                m_EffectMonsterAttack_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
                m_EffectMonsterAttack_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);
                m_SkillList.Add(Monster_Attack);
                m_ListHitEffect.Add(m_EffectMonsterAttack_Hit);
                Random _random = new Random();
                m_CurrentSkill = _random.Next(0, m_SkillList.Count);
            }
            if (m_Name == EMonster_Name.SnowMan_Lady)
            {
                m_Item = new CItem(IDObject.Item, 0.0f, 0.0f, EItem_Name.Cuddly_Penguin);
                Level = 1;
                Dam = 20;
                HP = 300;
                Monster_Move = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Lady_Move));
                Monster_Attack = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Lady_Attack));
                Monster_Hit = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Lady_Hit));
                Monster_Die = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_SnowMan_Lady_Die));
                m_EffectMonsterAttack_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
                m_EffectMonsterAttack_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);
                m_SkillList.Add(Monster_Attack);
                m_ListHitEffect.Add(m_EffectMonsterAttack_Hit);
                Random _random = new Random();
                m_CurrentSkill = _random.Next(0, m_SkillList.Count);
            }
            if (m_Name == EMonster_Name.Mini_Clown)
            {
                m_Item = new CItem(IDObject.Item, 0.0f, 0.0f, EItem_Name.Diamond);
                Level = 1;
                Dam = 20;
                HP = 350;
                Monster_Move = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_MiniClown_Move));
                Monster_Attack = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_MiniClown_Attack));
                Monster_Hit = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_MiniClown_Hit));
                Monster_Die = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_MiniClown_Die));
                m_EffectMonsterAttack_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
                m_EffectMonsterAttack_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);
                m_SkillList.Add(Monster_Attack);
                m_ListHitEffect.Add(m_EffectMonsterAttack_Hit);
                Random _random = new Random();
                m_CurrentSkill = _random.Next(0, m_SkillList.Count);
            }

            if (m_Name == EMonster_Name.Big_Clown)
            {
                m_Item = new CItem(IDObject.Item, 0.0f, 0.0f, EItem_Name.Fire_Box);
                Level = 1;
                Dam = 20;
                HP = 500;
                Monster_Move = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_BigClown_Move));
                Monster_Attack = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_BigClown_Attack));
                Monster_Hit = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_BigClown_Hit));
                Monster_Die = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_BigClown_Die));
                m_EffectMonsterAttack_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
                m_EffectMonsterAttack_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);
                m_SkillList.Add(Monster_Attack);
                m_ListHitEffect.Add(m_EffectMonsterAttack_Hit);
                Random _random = new Random();
                m_CurrentSkill = _random.Next(0, m_SkillList.Count);
            }
            if (m_Name == EMonster_Name.Yellow_Bean)
            {
                m_Item = new CItem(IDObject.Item, 0.0f, 0.0f, EItem_Name.Gold_1);
                Level = 1;
                Dam = 20;
                HP = 300;
                Monster_Move = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_YellowBean_Move));
                Monster_Attack = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_YellowBean_Attack1));
                Monster_Attack2 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_YellowBean_Attack2));
                Monster_Hit = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_YellowBean_Hit));
                Monster_Die = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_YellowBean_Die));
                m_SkillList.Add(Monster_Attack);
                m_SkillList.Add(Monster_Attack2);
                m_EffectMonsterAttack_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
                m_EffectMonsterAttack_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);
                
                m_EffectMonsterAttack2_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
                m_EffectMonsterAttack2_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);
                m_ListHitEffect.Add(m_EffectMonsterAttack_Hit);
                m_ListHitEffect.Add(m_EffectMonsterAttack2_Hit);
                Random _random = new Random();
                m_CurrentSkill = _random.Next(0, m_SkillList.Count);
            }
            if (m_Name == EMonster_Name.Shark)
            {
                m_Item = new CItem(IDObject.Item, 0.0f, 0.0f, EItem_Name.Gold_2);
                Level = 1;
                Dam = 20;
                HP = 400;
                Monster_Move = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_Shark_Move));
                Monster_Attack = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_Shark_Attack));
                Monster_Hit = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_Shark_Hit));
                Monster_Die = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_Shark_Die));
                m_EffectMonsterAttack_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
                m_EffectMonsterAttack_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);
                m_SkillList.Add(Monster_Attack);
                m_ListHitEffect.Add(m_EffectMonsterAttack_Hit);
                Random _random = new Random();
                m_CurrentSkill = _random.Next(0, m_SkillList.Count);
            }
            if (m_Name == EMonster_Name.Wolf_Man)
            {
                m_Item = new CItem(IDObject.Item, 0.0f, 0.0f, EItem_Name.Gold_3);
                Level = 1;
                Dam = 20;
                HP = 600;
                Monster_Move = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_WolfMan_Move));
                Monster_Attack = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_WolfMan_Attack));
                Monster_Hit = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_WolfMan_Hit));
                Monster_Die = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_WolfMan_Die));
                m_EffectMonsterAttack_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
                m_EffectMonsterAttack_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);
                m_SkillList.Add(Monster_Attack);
                m_ListHitEffect.Add(m_EffectMonsterAttack_Hit);
                Random _random = new Random();
                m_CurrentSkill = _random.Next(0, m_SkillList.Count);
            }
            if (m_Name == EMonster_Name.Old_Panda)
            {
                m_Item = new CItem(IDObject.Item, 0.0f, 0.0f, EItem_Name.Gold_4);
                Level = 1;
                Dam = 20;
                HP = 700;
                Monster_Move = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_OldPanda_Move));
                Monster_Attack = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_OldPanda_Attack));
                Monster_Hit = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_OldPanda_Hit));
                Monster_Die = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_OldPanda_Die));
                m_EffectMonsterAttack_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
                m_EffectMonsterAttack_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);
                m_SkillList.Add(Monster_Attack);
                m_ListHitEffect.Add(m_EffectMonsterAttack_Hit);
                Random _random = new Random();
                m_CurrentSkill = _random.Next(0, m_SkillList.Count);
            }

            if (m_Name == EMonster_Name.Wolf_Owl)
            {
                m_Item = new CItem(IDObject.Item, 0.0f, 0.0f, EItem_Name.Lemon_Juice);
                Level = 2;
                Dam = 20;
                HP = 700;
                Monster_Move = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_WolfOwl_Move));
                Monster_Attack = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_WolfOwl_Attack1));
                Monster_Attack2 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_WolfOwl_Attack2));
                Monster_Hit = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_WolfOwl_Hit));
                Monster_Die = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_WolfOwl_Die));
                m_SkillList.Add(Monster_Attack);
                m_SkillList.Add(Monster_Attack2);
                m_EffectMonsterAttack_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
                m_EffectMonsterAttack_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);

                m_EffectMonsterAttack2_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
                m_EffectMonsterAttack2_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);
                m_ListHitEffect.Add(m_EffectMonsterAttack_Hit);
                m_ListHitEffect.Add(m_EffectMonsterAttack2_Hit);
                Random _random = new Random();
                m_CurrentSkill = _random.Next(0, m_SkillList.Count);
            }
            if (m_Name == EMonster_Name.Wolf_Orc)
            {
                m_Item = new CItem(IDObject.Item, 0.0f, 0.0f, EItem_Name.Mana_Potion_1);
                Level = 1;
                Dam = 20;
                HP = 600;
                Monster_Move = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_WolfOrc_Move));
                Monster_Attack = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_WolfOrc_Attack1));
                Monster_Attack2 = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_WolfOrc_Attack2));
                Monster_Hit = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_WolfOrc_Hit));
                Monster_Die = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Monster_WolfOrc_Die));
                m_SkillList.Add(Monster_Attack);
                m_SkillList.Add(Monster_Attack2);
                m_EffectMonsterAttack_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
                m_EffectMonsterAttack_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);

                m_EffectMonsterAttack2_Hit = new CEffect(IDEffect.Effect_Hero_Attack3_Hit);
                m_EffectMonsterAttack2_Hit.Init(IDResource.Effect_Hero_Attack3_Hit);
                m_ListHitEffect.Add(m_EffectMonsterAttack_Hit);
                m_ListHitEffect.Add(m_EffectMonsterAttack2_Hit);
                Random _random = new Random();
                m_CurrentSkill = _random.Next(0, m_SkillList.Count);
            }
            
            m_Item.Init(_CM);
            m_Item.m_CurSprite.Scale = 1.5f;

            m_CurSprite = Monster_Move;

            MAX_HP = HP;
            MAX_MANA = Mana;

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
            if ((States != Object_States.Die)&&(IsVisible = true))
            {
                m_CurSprite.Update(_gameTime);
            }
            if ((HP <= 0) && (States != Object_States.Die))
            {
                States = Object_States.Before_Die;
            }
            if (States == Object_States.Before_Die)
            {
                m_CurSprite = Monster_Die;
                if (m_CurSprite.Animation.Loop >= 1)
                {
                    IsVisible = false;
                    m_Item.Position = new Vector2(Position.X + Bound.Width / 3, Position.Y);
                    //States = Object_States.Die;
                }
            }
            if (States == Object_States.Attacking)
            {
                m_CurSprite = m_SkillList[m_CurrentSkill];
                if (m_CurSprite.Animation.Loop == 1)
                {
                    Random _random = new Random();
                    m_CurrentSkill = _random.Next(0, m_SkillList.Count);
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                    States = Object_States.Move;
                }
            }
            if (States == Object_States.Move)
            {
                m_CurSprite = Monster_Move;
            }
            if (States == Object_States.Hit)
            {
                if (m_CurSprite != Monster_Hit)
                {
                    m_CurSprite.Animation.Loop = 0;
                    m_CurSprite.Animation.CurFrame = 0;
                }
                m_CurSprite = Monster_Hit;
                if (m_CurSprite.Animation.Loop == 1)
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
        public override void UpdateCollision(ref CObject _Object)
        {
            #region Collision Brick and Base Brick
            if ((_Object.ID == IDObject.Brick) 
                || (_Object.ID == IDObject.BaseBrick) 
                || (_Object.ID == IDObject.Monster) 
                || (_Object.ID == IDObject.Barrel))
            {
                if (CheckCollision(_Object))
                {
                    CollisionDir _Dir = this.getCollisionDir(this, _Object);
                    if (_Dir == CollisionDir.Bottom)
                    {
                        Velocity = new Vector2(-Velocity.X, 0.0f);
                        Position = new Vector2(this.Position.X, _Object.Position.Y - this.Bound.Height + 1);
                    }
                    if (_Dir == CollisionDir.Left)
                    {
                        Velocity = new Vector2(Monster_Velocity.X, Velocity.Y);
                        if (_Object.ID == IDObject.Barrel)
                            Position = new Vector2(_Object.Position.X + _Object.Bound.Width + 75 - 47, Position.Y);
                        else Position = new Vector2(_Object.Position.X + _Object.Bound.Width, Position.Y);
                        if (m_DirFace != DirFace.Right)
                            m_DirFace = DirFace.Right;
                    }
                    if (_Dir == CollisionDir.Right)
                    {
                        Velocity = new Vector2(-Monster_Velocity.X, Velocity.Y);
                        if (_Object.ID == IDObject.Barrel)
                            Position = new Vector2(_Object.Position.X - this.Bound.Width + 25, Position.Y);
                        else Position = new Vector2(_Object.Position.X - this.Bound.Width, Position.Y);
                        if (m_DirFace != DirFace.Left)
                            m_DirFace = DirFace.Left;
                    }
                    if (_Dir == CollisionDir.Top)
                    {
                        Position = new Vector2(this.Position.X, _Object.Position.Y + _Object.Bound.Height);
                        Velocity = new Vector2(Monster_Velocity.X, 0);
                    }
                    //////////////////////////////////////////////////////////////////////////
                }
                else
                {
                    if (Level == 1)
                        return;
                    int Max_Range = 0;
                    if (Level == 2)
                    {
                        Max_Range = 150;
                    }
                    if (Level == 3)
                    {
                        Max_Range = 600;
                    }
                    if (((Global.Player_Positon.X - Position.X) <= (Max_Range + m_CurSprite.Width)) && ((Global.Player_Positon.X - Position.X) > 0) && (m_CurSprite == Monster_Move))
                    {
                        if (m_CurSprite.Animation.CurFrame == m_CurSprite.Animation.FrameEnd)
                        {
                            m_DirFace = DirFace.Right;
                            return;
                        }
                    }
                    else
                    {
                        if (((Position.X - Global.Player_Positon.X) <= (Max_Range + 80)) && ((Position.X - Global.Player_Positon.X) > 0) && (m_CurSprite == Monster_Move))
                        {
                            if (m_CurSprite.Animation.CurFrame == m_CurSprite.Animation.FrameEnd)
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

            #region Collison Player
            if (_Object.ID == IDObject.Player)
            {
                if (CheckCollision(_Object))
                {
                    /////////////////////////// Start to attack ///////////////////////
                    if ((States != Object_States.Hit) &&
                        (States != Object_States.Die)
                        && ((States != Object_States.Before_Die)))
                    {
                        States = Object_States.Attacking;
                        CollisionDir _Dir = this.getCollisionDir(this, _Object);
                        if ((m_CurSprite == Monster_Move))
                        {
                            if (_Dir == CollisionDir.Left)
                            {
                                m_DirFace = DirFace.Left;
                            }
                            if (_Dir == CollisionDir.Right)
                            {
                                m_DirFace = DirFace.Right;
                            }
                        }
                        if (m_CurSprite == m_SkillList[m_CurrentSkill])
                        {
                            if (m_CurSprite.Animation.Loop == 1)
                            {
                                m_CurSprite.Animation.Loop = 0;
                                m_CurSprite.Animation.CurFrame = 0;
                                States = Object_States.Move;
                                if (_Dir == CollisionDir.Left)
                                {
                                    m_DirFace = DirFace.Left;
                                }
                                if (_Dir == CollisionDir.Right)
                                {
                                    m_DirFace = DirFace.Right;
                                }
                            }
                        }
                    }
                    //////////////////////////////////////////////////////////////////////////
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
                    //////////////////////////////////////////////////////////////////////////
                    if (GetDam == true)
                    {
                        int max = 0;
                        int min = 0;
                        if (m_Name == EMonster_Name.Big_Clown)
                        {
                            min = 4;
                            max = 7;
                        }
                        if (m_Name == EMonster_Name.Mini_Clown)
                        {
                            min = 2;
                            max = 4;
                        }
                        if (m_Name == EMonster_Name.Old_Panda)
                        {
                            min = 11;
                            max = 12;
                        }
                        if (m_Name == EMonster_Name.Shark)
                        {
                            min = 2;
                            max = 6;
                        }
                        if (m_Name == EMonster_Name.SnowMan)
                        {
                            min = 4;
                            max = 5;
                        }
                        if (m_Name == EMonster_Name.SnowMan_Blue)
                        {
                            min = 10;
                            max = 13;
                        }
                        if (m_Name == EMonster_Name.SnowMan_Lady)
                        {
                            min = 3;
                            max = 5;
                        }
                        if (m_Name == EMonster_Name.SnowMan_Purple)
                        {
                            min = 10;
                            max = 13;
                        }
                        if (m_Name == EMonster_Name.SnowMan_Red)
                        {
                            min = 4;
                            max = 6;
                        }
                        if (m_Name == EMonster_Name.Wolf_Man)
                        {
                            min = 7;
                            max = 9;
                        }
                        if ((m_Name == EMonster_Name.Wolf_Orc) && (m_CurSprite == Monster_Attack))
                        {
                            min = 9;
                            max = 11;
                        }
                        if ((m_Name == EMonster_Name.Wolf_Owl) && (m_CurSprite == Monster_Attack))
                        {
                            min = 4;
                            max = 6;
                        }
                        if ((m_Name == EMonster_Name.Wolf_Owl) && (m_CurSprite == Monster_Attack2))
                        {
                            min = 9;
                            max = 10;
                        }
                        if ((m_Name == EMonster_Name.Yellow_Bean) && (m_CurSprite == Monster_Attack))
                        {
                            min = 3;
                            max = 7;
                        }
                        if ((m_Name == EMonster_Name.Yellow_Bean) && (m_CurSprite == Monster_Attack2))
                        {
                            min = 3;
                            max = 7;
                        }
                        //////////////////////////////////////////////////////////////////////////
                        if ((States == Object_States.Attacking)
                            && (m_CurSprite.Animation.CurFrame >= min)
                            && (m_CurSprite.Animation.CurFrame <= max))
                        {
                            ListEffect.Add(new CEffect(m_ListHitEffect[m_CurrentSkill]));
                            m_ListEffect[m_ListEffect.Count - 1].Position = _Object.Position;
                            _Object.HP -= Dam;
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
            base.UpdateMovement(_gameTime);
        }
        public override void Update(GameTime _GameTime)
        {
            if ((IsVisible == false) && (m_Item.States != Object_States.Die))
            {
                m_Item.Update(_GameTime);
                return;
            }
            for (int i = 0; i < m_ListEffect.Count; i++)
            {
                m_ListEffect[i].Update(_GameTime);
                if (m_ListEffect[i].CurSprite.Animation.Loop >= 1)
                {
                    m_ListEffect[i].CurSprite.Animation.Loop = 0;
                    m_ListEffect[i].CurSprite.Animation.CurFrame = 0;
                    m_ListEffect.Remove(m_ListEffect[i]);
                }
            }
            UpdateAnimation(_GameTime);
            UpdateMovement(_GameTime);
            base.Update(_GameTime);
        }
    }
    
}
