using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
enum EItem_Name
{
        Clover,
        Cuddly_Penguin,
        Diamond,
        Fire_Box,
        Ice_Box,
        Key,
        Lemon_Juice,
        Water,
        Gold_1,
        Gold_2,
        Gold_3,
        Gold_4,
        Hp_Potion_1,
        Hp_Potion_2,
        Hp_Potion_3,
        Mana_Potion_1,
        Mana_Potion_2,
        Mana_Potion_3,
}

namespace FindingPrincess.Framework
{
    class CItem : CAnimatedObject
    {
        protected EItem_Name _itemName;

        public EItem_Name ItemName
        {
            get { return _itemName; }
        }

        public CItem(IDObject _ID, float _PosX, float _PosY, EItem_Name _Name)
            : base(_ID, _PosX, _PosY)
        {
            _itemName = _Name;
            States = Object_States.Stand;
        }

        public override void Init(ContentManager _CM)
        {
            if (_itemName == EItem_Name.Clover)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Clover));
            if (_itemName == EItem_Name.Cuddly_Penguin)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Cuddly_Penguin));
            if (_itemName == EItem_Name.Diamond)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Diamond));
            if (_itemName == EItem_Name.Fire_Box)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Fire_Box));
            if (_itemName == EItem_Name.Ice_Box)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Ice_Box));
            if (_itemName == EItem_Name.Key)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Key));
            if (_itemName == EItem_Name.Lemon_Juice)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Lemon_Juice));
            if (_itemName == EItem_Name.Water)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Water));
            if (_itemName == EItem_Name.Gold_1)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Gold_1));
            if (_itemName == EItem_Name.Gold_2)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Gold_2));
            if (_itemName == EItem_Name.Gold_3)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Gold_3));
            if (_itemName == EItem_Name.Gold_4)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Gold_4));
            if (_itemName == EItem_Name.Hp_Potion_1)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Hp_Potion_1));
            if (_itemName == EItem_Name.Hp_Potion_2)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Hp_Potion_2));
            if (_itemName == EItem_Name.Hp_Potion_3)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Hp_Potion_3));
            if (_itemName == EItem_Name.Mana_Potion_1)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Mana_Potion_1));
            if (_itemName == EItem_Name.Mana_Potion_2)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Mana_Potion_2));
            if (_itemName == EItem_Name.Mana_Potion_3)
                m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Item_Mana_Potion_3));
            base.Init(_CM);
        }
        public override void UpdateCollision(ref CObject _Object)
        {
        #region Collision with unMonster - unPlayer
            if ((_Object.ID == IDObject.Brick)
                || (_Object.ID == IDObject.BaseBrick)
                || (_Object.ID == IDObject.Barrel))
            {
                if(CheckCollision(_Object))
                {
                    CollisionDir _Dir = this.getCollisionDir(this, _Object);
                    if (_Dir == CollisionDir.Bottom)
                    {
                        Velocity = new Vector2(0.0f, 0.0f);
                        Position = new Vector2(this.Position.X, _Object.Position.Y - this.Bound.Height + 1);
                    }
                }
            }
        #endregion

        #region Collision with Monster - Master - Boss do nothing...
            if (_Object.ID == IDObject.Monster 
                || _Object.ID == IDObject.Master 
                || _Object.ID == IDObject.Boss)
            {
                //States = Object_States.Die;
            }
        #endregion
            
        #region  Collision with Player...Disappeare... Player earn health
            if (_Object.ID == IDObject.Player)
            {
                if (CheckCollision(_Object))
                {
                    States = Object_States.Die;
                    _Object.HP += 50;
                    if (_Object.MAX_HP < _Object.HP)
                        _Object.MAX_HP = _Object.HP;
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Clover)
                    {
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Cuddly_Penguin)
                    {
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Diamond)
                    {
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Fire_Box)
                    {
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Ice_Box)
                    {
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Key)
                    {
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Lemon_Juice)
                    {
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Water)
                    {
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Gold_1)
                    {
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Gold_2)
                    {
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Gold_3)
                    {
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Gold_4)
                    {
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Hp_Potion_1)
                    {
                        _Object.HP += 50;
                        if (_Object.MAX_HP < _Object.HP)
                        {
                            _Object.MAX_HP = _Object.HP;
                        }
                        Console.WriteLine("MAX_HP= " + _Object.MAX_HP + " : HP= " + _Object.HP);
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Hp_Potion_2)
                    {
                        _Object.HP += 80;
                        if (_Object.MAX_HP < _Object.HP)
                        {
                            _Object.MAX_HP = _Object.HP;
                        }
                        Console.WriteLine("MAX_HP= " + _Object.MAX_HP + " : HP= " + _Object.HP);
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Hp_Potion_3)
                    {
                        _Object.HP += 100;
                        if (_Object.MAX_HP < _Object.HP)
                        {
                            _Object.MAX_HP = _Object.HP;
                        }
                        Console.WriteLine("MAX_HP= " + _Object.MAX_HP + " : HP= " + _Object.HP);
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Mana_Potion_1)
                    {
                        _Object.Mana += 40;
                        if (_Object.MAX_MANA < _Object.Mana)
                        {
                            _Object.Mana = _Object.MAX_MANA;
                        }
                        Console.WriteLine("MAX_MANA= " + _Object.MAX_MANA + " : Mana= " + _Object.Mana);
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Mana_Potion_2)
                    {
                        _Object.Mana += 60;
                        if (_Object.MAX_MANA < _Object.Mana)
                        {
                            _Object.Mana = _Object.MAX_MANA;
                        }
                        Console.WriteLine("MAX_MANA= " + _Object.MAX_MANA + " : Mana= " + _Object.Mana);
                    }
                    //--------------------------------------------------------------------------
                    if (_itemName == EItem_Name.Mana_Potion_3)
                    {
                        _Object.Mana += 80;
                        if (_Object.MAX_MANA < _Object.Mana)
                        {
                            _Object.Mana = _Object.MAX_MANA;
                        }
                        Console.WriteLine("MAX_MANA= " + _Object.MAX_MANA + " : Mana= " + _Object.Mana);
                    }
                }
            }
        #endregion
        }

        public override void Update(GameTime _GameTime)
        {
            if ((_itemName == EItem_Name.Clover)
                || (_itemName == EItem_Name.Mana_Potion_3))
                m_CurSprite.Update(_GameTime);
            else 
                base.Update(_GameTime);

            UpdateMovement(_GameTime);
        }
        public override void UpdateMovement(GameTime _gameTime)
        {
            base.UpdateMovement(_gameTime);
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
        }
    }
}