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

public enum IDObject
{
    Player = 0,
    Monster = 1,
    Boss = 2,
    Brick = 3,
    BaseBrick = 4,
    Barrel = 5,
    Master = 6,
    Item = 7,
}
public enum CollisionDir
{
    Left,
    Right,
    Top,
    Bottom,
    None
}
enum Object_States
{
    Stand,
    Move,
    Attacking,
    Jumping,
    Hit,
    Die,
    Before_Die,
    Transform,
}
namespace FindingPrincess.Framework
{
    /************************************************************************/
    /* Them cai bien Texture _helth, _helthBar, MAX_HP, MAX_MANA
     * 
    /************************************************************************/
    class CObject
    {
        public int MAX_HP;
        public int MAX_MANA;
        public int HP;
        public int Mana;
        protected IDObject m_ID;
        public CSprite m_CurSprite;
        protected List<IDEffect> m_Collided_IDEffect;
        protected Vector2 m_Position;
        protected Vector2 m_Size;
        protected static Texture2D _helth;
        protected static Texture2D _helth25;
        protected static Texture2D _helth50;
        protected static Texture2D _helthBar;
        protected static Texture2D _mana;
        protected bool m_isVisible;

        protected List<CEffect> m_ListEffect;
        protected Object_States m_States;

        #region Get and Set
        public Object_States States
        {
            get { return m_States; }
            set { m_States = value; }
        }
        public List<CEffect> ListEffect
        {
            get { return m_ListEffect; }
            set { m_ListEffect = value; }
        }
        public IDObject ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
        public CSprite CurSprite
        {
            get { return CurSprite; }
            set { CurSprite = value; }
        }
        public Vector2 Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }
        public Vector2 Size
        {
            get { return m_Size; }
            set { m_Size = value; }
        }
      /*  public int CurFrame
        {
            get { return m_CurFrame; }
            set { m_CurFrame = value; }
        } */
       /* public bool isLife
        {
            get { return m_isLife; }
            set { m_isLife = value; }
        }*/
        public bool IsVisible
        {
            get { return m_isVisible; }
            set { m_isVisible = value; }
        }
       /* public Rectangle LastRect
        {
            get { return m_LastRect; }
            set { m_LastRect = value; }
        } */
        #endregion

        public CObject(IDObject _ID, float _PosX,float _PosY)
        {
            m_ID = _ID;
            m_CurSprite = null;
            m_Position = new Vector2(_PosX,_PosY);
            m_Size = Vector2.Zero;
            m_isVisible = true;
        }
        virtual public void Init(ContentManager _CM)
        {
            m_ListEffect = new List<CEffect>();
            m_Collided_IDEffect = new List<IDEffect>();
            m_Size = new Vector2(m_CurSprite.Width, m_CurSprite.Height);
            _helth = _CM.Load<Texture2D>(@"Sprite\Health");
            _helth25 = _CM.Load<Texture2D>(@"Sprite\Health25");
            _helth50 = _CM.Load<Texture2D>(@"Sprite\Health50");
            _helthBar = _CM.Load<Texture2D>(@"Sprite\HealthBar");
            _mana = _CM.Load<Texture2D>(@"Sprite\Mana");
        }
        virtual public void UpdateAnimation(GameTime _GameTime)
        {

        }
        virtual public void Update(GameTime _GameTime)
        {

        }
        virtual public void UpdateCollision(ref CObject _Object)
        {

        }
        virtual public void Draw(SpriteBatch _SpriteBatch)
        {
            m_CurSprite.Position = m_Position;
            m_CurSprite.Draw(_SpriteBatch);

            if (ID == IDObject.Barrel 
                || ID == IDObject.BaseBrick 
                || ID == IDObject.Brick 
                || ID == IDObject.Item)
                return;
            else
            {
                Vector2 _vec = m_Position - new Vector2(10, 20);
                float _percent1 = (float)MAX_HP / 500.0f; // cứ 500HP thì = 1 thanh _health
                _SpriteBatch.Draw(_helthBar, new Rectangle((int)_vec.X, (int)_vec.Y, (int)(_helthBar.Width * _percent1), _helthBar.Height), Color.White);
                
                _vec = m_Position - new Vector2(10, 20) + new Vector2(1, 1);
                float _percent2 = (float)HP / (float)MAX_HP;

                if(_percent2 > 0.5f)
                    _SpriteBatch.Draw(_helth, new Rectangle((int)_vec.X, (int)_vec.Y, (int)(_helth.Width * _percent2 * _percent1), _helth.Height), Color.White);
                else if(_percent2 > 0.25f)
                    _SpriteBatch.Draw(_helth50, new Rectangle((int)_vec.X, (int)_vec.Y, (int)(_helth50.Width * _percent2 * _percent1), _helth50.Height), Color.White);
                else
                    _SpriteBatch.Draw(_helth25, new Rectangle((int)_vec.X, (int)_vec.Y, (int)(_helth25.Width * _percent2 * _percent1), _helth25.Height), Color.White);
            }
        }
        virtual public Rectangle Bound
        {
            get
            {
                Rectangle _Rect;
                _Rect.X = (int)Position.X;
                _Rect.Y = (int)Position.Y;
                _Rect.Width = (int)((m_Size.X * m_CurSprite.Scale));
                _Rect.Height = (int)((m_Size.Y * m_CurSprite.Scale));
                return _Rect;
            }
        }

        public bool Collision(CEffect _Effect)
        {
            return this.Bound.Intersects(_Effect.Bound);
        }

        public bool CheckCollision(CObject _obj)
        {
            return this.Bound.Intersects(_obj.Bound);
        }

        public CollisionDir getCollisionDir(CObject _Obj1, CObject _Obj2)
        {
            if (_Obj1.Bound.Intersects(_Obj2.Bound))
            {
                float top = Math.Abs(_Obj1.Bound.Top - _Obj2.Bound.Bottom);
                float botom = Math.Abs(_Obj1.Bound.Bottom - _Obj2.Bound.Top);
                float left = Math.Abs(_Obj1.Bound.Left - _Obj2.Bound.Right);
                float right = Math.Abs(_Obj1.Bound.Right - _Obj2.Bound.Left);
                float rs = Math.Min(Math.Min(right, left), Math.Min(top, botom));

                if (rs == top)
                {
                    return CollisionDir.Top;
                }
                if (rs == botom)
                {
                    return CollisionDir.Bottom;
                }
                if (rs == left)
                {
                    return CollisionDir.Left;
                }
                if (rs == right)
                {
                    return CollisionDir.Right;
                }
            }
            return CollisionDir.None;
        }
        public bool CheckIDEffect(CEffect _Effect)
        {
            for (int i = 0; i < m_Collided_IDEffect.Count; i++)
            {
                if (m_Collided_IDEffect[i] == _Effect.ID)
                    return true;
            }
            return false;
        }
        public void AddIDEffect(IDEffect _ID)
        {
            m_Collided_IDEffect.Add(_ID);
        }
        public void DeleteIDEffect()
        {
            m_Collided_IDEffect.Clear();
        }
    }
}
