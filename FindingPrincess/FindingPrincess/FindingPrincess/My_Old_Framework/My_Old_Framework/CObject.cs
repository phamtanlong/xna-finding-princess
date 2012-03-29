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
    Player,
    Monster,
    Brick,
    BaseBrick,
    Barrel
}
public enum CollisionDir
{
    Left,
    Right,
    Top,
    Bottom,
    None
}
namespace FindingPrincess.Framework
{
    class CObject
    {
        private IDObject m_ID;
        public CSprite m_CurSprite;

        private Vector2 m_Position;
        private Vector2 m_Size;
        //private int m_CurFrame;

        private bool m_isLife;
        private bool m_isVisible;

        //Rectangle m_LastRect;

        protected List<CEffect> m_ListEffect;
        private Object_States m_States;
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
        public bool isLife
        {
            get { return m_isLife; }
            set { m_isLife = value; }
        }
        public bool isVisible
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
            //m_CurFrame = 0;
            m_isLife = true;
            m_isVisible = true;
        }
        virtual public void Init(ContentManager _CM)
        {
            m_Size = new Vector2(m_CurSprite.Width, m_CurSprite.Height);
         //   m_LastRect = this.getBoundingBox();
        }
        virtual public void UpdateAnimation(GameTime _GameTime)
        {

        }
        virtual public void Update(GameTime _GameTime)
        {

        }
        virtual public void UpdateCollision(CObject _Object)
        {

        }
        virtual public void Draw(SpriteBatch _SpriteBatch)
        {
            m_CurSprite.Position = m_Position;
            m_CurSprite.Draw(_SpriteBatch);
        }
        virtual public Rectangle getBoundingBox()
        {
            Rectangle _Rect;
            _Rect.X = (int)Position.X;
            _Rect.Y = (int)Position.Y;
            _Rect.Width = (int)((m_Size.X * m_CurSprite.Scale));
            _Rect.Height = (int)((m_Size.Y * m_CurSprite.Scale));
            return _Rect;
        }
        // kiem tra 2 object va cham bt
        public bool Collision(CObject _Object)
        {
            return this.getBoundingBox().Intersects(_Object.getBoundingBox());
        }
        public bool Collision(CEffect _Effect)
        {
            return this.getBoundingBox().Intersects(_Effect.getBoundingBox());
        }
        //kiem tra va cham, neu va cham tra ve huong, k va cham tra ve None
        /*
        public CollisionDir getCollisionDir(CObject _Object)
        {
            if(Collision(_Object) == false)
            {
                m_LastRect = this.getBoundingBox();
                return CollisionDir.None;
            }
            else
            {
                Rectangle tempRect;
                tempRect = new Rectangle((int)m_LastRect.X, (int)this.Position.Y, (int)(Size.X * m_CurSprite.Scale), (int)(Size.Y * m_CurSprite.Scale));
                if (tempRect.Intersects(_Object.getBoundingBox()))
                {
                    if(tempRect.Y>this.m_LastRect.Y)
                        return CollisionDir.Bottom; //this bi va cham ben duoi,_Object bi va cham ben tren
                    return CollisionDir.Top;
                }
                else
                {
                    tempRect = new Rectangle((int)this.Position.X, (int)m_LastRect.Y, (int)(Size.X * m_CurSprite.Scale), (int)(Size.Y * m_CurSprite.Scale));
                    if (tempRect.X > this.m_LastRect.X)
                        return CollisionDir.Right;
                    else return CollisionDir.Left;
                }
            }
        }
        */
        public CollisionDir getCollisionDir(CObject _Obj1, CObject _Obj2)
        {
            if (_Obj1.getBoundingBox().Intersects(_Obj2.getBoundingBox()))
            {
                float top = Math.Abs(_Obj1.getBoundingBox().Top - _Obj2.getBoundingBox().Bottom);
                float botom = Math.Abs(_Obj1.getBoundingBox().Bottom - _Obj2.getBoundingBox().Top);
                float left = Math.Abs(_Obj1.getBoundingBox().Left - _Obj2.getBoundingBox().Right);
                float right = Math.Abs(_Obj1.getBoundingBox().Right - _Obj2.getBoundingBox().Left);
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

        public virtual void UnLoad()
        {
            Console.WriteLine("UnLoad content of CObject.......");
        }
    }
}
