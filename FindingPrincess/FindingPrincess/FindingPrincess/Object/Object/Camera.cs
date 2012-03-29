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

namespace FindingPrincess.Object
{
    public class Camera
    {
        private Rectangle _bound;
        private Vector2 _mapSize;

#region  Properties..........
        public Vector2 MapBound
        {
            get { return _mapSize; }
        }

        public Rectangle Bound
        {
            get{ return _bound; }
        }
#endregion

        public Camera(Rectangle _cameraRect, Vector2 _mapSize)
        {
            _bound = _cameraRect;
            this._mapSize = _mapSize;
        }

        public void Update(Player _player)
        {
            _bound.X = (int)_player.Position.X - _bound.Width / 2;

            if (_bound.X <= 0)
                _bound.X = 0;

            if (_bound.X >= (_mapSize.X - _bound.Width))
            {
                _bound.X = ((int)_mapSize.X - _bound.Width) - 1;
            }

            _bound.Y = (int)_player.Position.Y - _bound.Height / 2;

            if (_bound.Y <= 0)
                _bound.Y = 0;

            if (_bound.Y >= (_mapSize.Y - _bound.Height))
            {
                _bound.Y = ((int)_mapSize.Y - _bound.Height) - 1;
            }
        }
    }
}
