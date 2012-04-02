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
    class CSprite
    {
        Texture2D m_Texture;
        private int m_Col;
        private int m_Row;
        private int m_Width;
        private int m_Height;
        private int m_TotalFrames;
        private Vector2 m_Position;
        private Vector2 m_DeltaPosLeft;
        private Vector2 m_DeltaPosRight;
        private Rectangle m_SrcRect;
        private Color m_Color;
        private float m_Rotation;
        private Vector2 m_Origin;
        private float m_Scale;
        private SpriteEffects m_Effect;
        private float m_Depth;
        private CAnimation m_Animation;
        private IDResource m_IDResource;
        #region Get and Set
        public Vector2 DeltaPosLeft
        {
            get { return m_DeltaPosLeft; }
            set { m_DeltaPosLeft = value; }
        }

        public Vector2 DeltaPosRight
        {
            get { return m_DeltaPosRight; }
            set { m_DeltaPosRight = value; }
        }
        public Texture2D Texture
        {
            get { return m_Texture; }
            set { m_Texture = value; }
        }
        public int Col
        {
            get { return m_Col; }
            set { m_Col = value; }
        }
        public int Row
        {
            get { return m_Row; }
            set { m_Row = value; }
        }
        public int Width
        {
            get { return m_Width; }
            set { m_Width = value; }
        }
        public int Height
        {
            get { return m_Height; }
            set { m_Height = value; }
        }
        public int TotalFrames
        {
            get { return m_TotalFrames; }
            set { m_TotalFrames = value; }
        }
        public Vector2 Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }
        public Rectangle SrcRect
        {
            get { return m_SrcRect; }
            set { m_SrcRect = value; }
        }
        public Color _Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }
        public float Rotation
        {
            get { return m_Rotation; }
            set { m_Rotation = value; }
        }
        public Vector2 Origin
        {
            get { return m_Origin; }
            set { m_Origin = value; }
        }
        public float Scale
        {
            get { return m_Scale; }
            set { m_Scale = value; }
        }
        public SpriteEffects _Effect
        {
            get { return m_Effect; }
            set { m_Effect = value; }
        }
        public float Depth
        {
            get { return m_Depth; }
            set { m_Depth = value; }
        }
        public CAnimation Animation
        {
            get { return m_Animation; }
            set { m_Animation = value; }
        }
        public IDResource _IDResource
        {
            get { return m_IDResource; }
            set { m_IDResource = value; }
        }
        #endregion
        public CSprite(IDResource _IDResource, int _Col, int _Row, int _Width, int _Height, int _TotalFrames, float _Depth)
        {
            m_IDResource = _IDResource;
            m_Texture = null;
            m_Col = _Col;
            m_Row = _Row;
            m_Width = _Width;
            m_Height = _Height;
            m_TotalFrames = _TotalFrames;
            m_Position = Vector2.Zero;
            m_SrcRect = new Rectangle(0, 0, m_Width, m_Height);
            m_Color = Color.White;
            m_Rotation = 0.0f;
            m_Origin = new Vector2(0.0f, 0.0f);
            m_Scale = 1.0f;
            m_Effect = SpriteEffects.FlipHorizontally;
            m_Depth = _Depth;
            m_Animation = new CAnimation();
            m_DeltaPosLeft = Vector2.Zero;
            m_DeltaPosRight = Vector2.Zero;
        }
        public CSprite(CSprite _copy)
        {
            m_IDResource = _copy.m_IDResource;
            m_Texture = _copy.m_Texture;
            m_Col = _copy.m_Col;
            m_Row = _copy.m_Row;
            m_Width = _copy.m_Width;
            m_Height = _copy.m_Height;
            m_TotalFrames = _copy.m_TotalFrames;
            m_Position = _copy.m_Position;
            m_SrcRect = _copy.m_SrcRect;
            m_Color = _copy.m_Color;
            m_Rotation = 0.0f;
            m_Origin = Vector2.Zero;
            m_Scale = _copy.m_Scale;
            m_Effect = _copy.m_Effect;
            m_Depth = _copy.m_Depth;
            m_Animation = new CAnimation(_copy.m_Animation);
            m_DeltaPosLeft = _copy.m_DeltaPosLeft;
            m_DeltaPosRight = _copy.m_DeltaPosRight;
        }
        virtual public void Init(ContentManager _CM, string _FileName, IDResource _ID, int _FrameStart, int _FrameEnd, float _TimeAnimation, Vector2 _deltaPosL, Vector2 _deltaPosR)
        {
            m_Texture = _CM.Load<Texture2D>(_FileName);
            m_Animation.CreateAnimation(_ID, _FrameStart, _FrameEnd, _TimeAnimation);
            m_DeltaPosLeft = _deltaPosL;
            m_DeltaPosRight = _deltaPosR;
        }
        virtual public void Init(ContentManager _CM, string _FileName, IDResource _ID, int _FrameStart, int _FrameEnd, float _TimeAnimation)
        {
            m_Texture = _CM.Load<Texture2D>(_FileName);
            m_Animation.CreateAnimation(_ID,_FrameStart, _FrameEnd, _TimeAnimation);
        }
        virtual public void Update(GameTime _GameTime)
        {
            m_Animation.UpdateAnimation(_GameTime, m_Width, m_Height, m_Col, ref m_SrcRect);
        }
        virtual public void Draw(SpriteBatch _SpriteBatch)
        {
            if (m_Effect == SpriteEffects.None)
                _SpriteBatch.Draw(m_Texture, m_Position + m_DeltaPosLeft, m_SrcRect, m_Color, m_Rotation, m_Origin, m_Scale, m_Effect, m_Depth);
            else
                _SpriteBatch.Draw(m_Texture, m_Position + m_DeltaPosRight, m_SrcRect, m_Color, m_Rotation, m_Origin, m_Scale, m_Effect, m_Depth);
        }
        public Rectangle getSrcRect(int _CurFrame)
        {
            Rectangle _Rect;
            _Rect.X = (_CurFrame % m_Col) * m_Width;
            _Rect.Y = (_CurFrame / m_Col) * m_Height;
            _Rect.Width = m_Width;
            _Rect.Height = m_Height;
            return _Rect;
        }

    }
}
