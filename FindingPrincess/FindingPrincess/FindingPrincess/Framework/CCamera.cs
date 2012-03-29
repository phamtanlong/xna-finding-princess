using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FindingPrincess.Framework
{
    class CCamera
    {
        public Matrix m_Transform; // Matrix transform

        private float m_StartPosY;
        private Vector2 m_Pos; // Pos camera;
        private Vector2 m_Distance; // distance between pos cam and pos rect to get obj
        Rectangle m_RectCam;

        public  Vector2 Pos
        {
            get{return m_Pos;}
        }

        public Rectangle CamRect
        {
            get{return m_RectCam;}
        }

        public CCamera()
        {
            m_Pos = Vector2.Zero;
            m_RectCam = new Rectangle();
        }

        public CCamera(Rectangle _Rect)
        {
            m_RectCam = _Rect;
            m_Pos = new Vector2(800/2, 600/2);
            
            m_Distance = new Vector2(m_Pos.X - m_RectCam.X, m_Pos.Y - m_RectCam.Y);
            m_StartPosY = m_Pos.Y;
        }

        public void Update(CObject _Obj, Vector2 _appWindowSize, Vector2 _mapSize)
        {
            Console.WriteLine("X= " + m_Pos.X + "\nY= " + m_Pos.Y);
            Console.WriteLine("StartY= " + m_StartPosY);

            if (_Obj.Position.X > _appWindowSize.X / 2)
            {
                m_Pos = new Vector2(_Obj.Position.X, m_Pos.Y);
            }

            //////////////////////////////////////////////////////////////////////////
            if (m_Pos.X - m_Distance.X > _mapSize.X - _appWindowSize.X)
            {
                m_Pos.X = _mapSize.X - _appWindowSize.X + m_Distance.X;
            }
            //////////////////////////////////////////////////////////////////////////
            
            if (_Obj.Position.Y <= 0)
            {
                m_Pos = new Vector2(m_Pos.X, m_StartPosY - Math.Abs(_Obj.Position.Y)); //m_Pos = new Vector2(m_Pos.X, m_StartPosY - Math.Abs(_Obj.Position.Y));
            }
            else
                m_Pos = new Vector2(m_Pos.X, m_StartPosY);

            m_RectCam = new Rectangle((int)(m_Pos.X - m_Distance.X), (int)(m_Pos.Y - m_Distance.Y), m_RectCam.Width, m_RectCam.Height);
        }

        public Matrix getTransformation(GraphicsDevice _GD)
        {
            m_Transform = Matrix.Identity 
                * Matrix.CreateTranslation(new Vector3(- m_Pos.X, - m_Pos.Y, 0))
                * Matrix.CreateTranslation(new Vector3(400, 300, 0));
            return m_Transform;
        }
    }
}
