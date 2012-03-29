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
    class LGCamera
    {
        Rectangle _rectCamera;
        int DELTA = 100;
        /************************************************************************/
        /*************___________DELTA_______|_______DELTA__________*************/
        /************************************************************************/

        public Rectangle RectCamera
        {
            get { return _rectCamera; }
            set { _rectCamera = value; }
        }

        public LGCamera()
        {
            _rectCamera = new Rectangle();
        }

        public LGCamera(Rectangle _rect)
        {
            _rectCamera = _rect;
        }

        public void Update(CObject _player, Vector2 _appWindowSize, Vector2 _mapSize)
        {
            /////////////////////////// RIGHT ////////////////////////////////////////
            if (_player.Position.X > _rectCamera.X + _appWindowSize.X / 2 + DELTA
                && _player.Position.X < _mapSize.X - _appWindowSize.X / 2 + DELTA)
            {
                _rectCamera.X = (int)(_player.Position.X - _appWindowSize.X / 2 - DELTA);
            }

            //////////////////////////// LEFT ////////////////////////////////////////
            if (_player.Position.X < _rectCamera.X + _appWindowSize.X / 2 - DELTA
                && _player.Position.X > _appWindowSize.X / 2 - DELTA)
            {
                _rectCamera.X = (int)(_player.Position.X - _appWindowSize.X / 2 + DELTA);
            }

            //////////////////////////// BOTTOM //////////////////////////////////////
            if (_player.Position.Y > _rectCamera.Y + _appWindowSize.Y / 2 + DELTA
                && _player.Position.Y < _mapSize.Y - _appWindowSize.Y / 2 + DELTA)
            {
                _rectCamera.Y = (int)(_player.Position.Y - _appWindowSize.Y / 2 - DELTA);
            }

            //////////////////////////// TOP //////////////////////////////////////
            if (_player.Position.Y < _rectCamera.Y + DELTA)
            {
                _rectCamera.Y = (int)(_player.Position.Y - DELTA);
            }
            //////////////////////////////////////////////////////////////////////////
            if (_rectCamera.Y < 0)
            {
                _rectCamera.Y = 0;
            }
        }

        public Matrix getTransformation(GraphicsDevice _gd)
        {
            Matrix m_Transform;
            m_Transform = Matrix.Identity
                * Matrix.CreateTranslation(new Vector3(-_rectCamera.X - 400, -_rectCamera.Y - 300, 0))
                * Matrix.CreateTranslation(new Vector3(_gd.Viewport.Width / 2, _gd.Viewport.Height / 2, 0));

            return m_Transform;
        }
    }
}
