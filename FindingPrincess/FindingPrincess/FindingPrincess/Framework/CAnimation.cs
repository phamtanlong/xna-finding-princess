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
    class CAnimation
    {
        private IDResource m_ID;
        protected int m_FrameStart; // number of frame start
        protected int m_FrameEnd; // number of frame end
        protected int m_CurFrame;
        protected float m_LocalTime; // Total time from start,when m_LocalTime = m_TimeAnimation, next frames
        protected float m_TimeAnimation; // time to change the frame
        protected float m_Loop;
        #region Get and Set
        public int FrameStart
        {
            get { return m_FrameStart; }
            set { m_FrameStart = value; }
        }

        public int FrameEnd
        {
            get { return m_FrameEnd; }
            set { m_FrameEnd = value; }
        }

        public int CurFrame
        {
            get { return m_CurFrame; }
            set { m_CurFrame = value; }
        }

        public float TimeAnimation
        {
            get { return m_TimeAnimation; }
            set { m_TimeAnimation = value; }
        }
        public float LocalTime
        {
            get { return m_LocalTime; }
            set { m_LocalTime = value; }
        }
        public float Loop
        {
            get { return m_Loop; }
            set { m_Loop = value; }
        }
        #endregion
        public CAnimation()
        {
        }
        public CAnimation(CAnimation _copy)
        {
            m_ID = _copy.m_ID;
            m_FrameStart = _copy.m_FrameStart;
            m_FrameEnd = _copy.m_FrameEnd;
            m_TimeAnimation = _copy.m_TimeAnimation;
            m_CurFrame = 0;
            m_LocalTime = 0;
            m_Loop = 0;
        }
        public void CreateAnimation(IDResource _ID,int _FrameStart, int _FrameEnd, float _TimeAnimation)
        {
            m_ID = _ID;
            m_FrameStart = _FrameStart;
            m_FrameEnd = _FrameEnd;
            m_CurFrame = _FrameStart;
            m_LocalTime = 0.0f;
            m_TimeAnimation = _TimeAnimation;
        }
        public void NextFrame()
        {
            m_CurFrame++;
            if (m_CurFrame > m_FrameEnd)
            {
                m_CurFrame = m_FrameStart;
                m_Loop++;
            }
        }
        public void UpdateAnimation(GameTime _GameTime,int _Width,int _Height,int _Col,ref Rectangle _Rect)
        {
            Rectangle rect;
            m_LocalTime += (float)_GameTime.ElapsedGameTime.TotalMilliseconds;
            if (m_LocalTime > m_TimeAnimation)
            {
                NextFrame();
                m_LocalTime -= m_TimeAnimation;
                rect.X = (m_CurFrame % _Col) * _Width;
                rect.Y = (m_CurFrame / _Col) * _Height;
                rect.Width = _Width;
                rect.Height = _Height;
                _Rect = rect;
            }
        }
    }
}
