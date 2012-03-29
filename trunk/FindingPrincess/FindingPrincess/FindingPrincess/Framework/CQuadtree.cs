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

    #region My code............
    class CQuadtree
    {
        public static int MAX_LEVEL;
        protected Vector2 _size;
        protected Node _rootNode;
        public bool IsHavingPlayer = false;

        public CQuadtree(int _maxlevel, Vector2 _size)
        {
            MAX_LEVEL = _maxlevel;
            this._size = _size;
            _rootNode = new Node(new Rectangle(0, 0, (int)_size.X, (int)_size.Y), 1);
        }

        public bool AddObject(CObject _obj)
        {
            if (_rootNode.AddObject(_obj))
            {
                if (_obj is CPlayer)
                    IsHavingPlayer = true;
                return true;
            }
            return false;
        }

        public bool RemoveObject(CObject _obj)
        {
            if (_rootNode.RemoveObject(_obj))
            {
                return true;
            }
            return false;
        }

        public List<CObject> GetObjects(Rectangle _camera)
        {
            return _rootNode.GetObjects(_camera);
        }

        /// <summary>
        /// Update all the object in the QuadTree, event Player
        /// </summary>
        /// <param name="_cam"> Rectangle of view camera</param>
        /// <param name="_expandCameraSize"> The expand size of rectangle _camra, used to GetObject to check Colliion # GetOjbect to Update</param>
        /// <param name="_gametime"> The GameTime to update object</param>
        public void Update(Rectangle _cam, Vector2 _expandCameraSize, GameTime _gametime)
        {
            Rectangle _updateRect = new Rectangle(
                _cam.X - (int)_expandCameraSize.X,
                _cam.Y - (int)_expandCameraSize.Y,
                _cam.Width + 2 * (int)_expandCameraSize.X,
                _cam.Height + 2 * (int)_expandCameraSize.Y);

            Rectangle _collisionRect = new Rectangle(
                _updateRect.X - (int)_expandCameraSize.X,
                _updateRect.Y - (int)_expandCameraSize.Y,
                _updateRect.Width + 2 * (int)_expandCameraSize.X,
                _updateRect.Height + 2 * (int)_expandCameraSize.Y); // The expanded Rect to get Collision list

            List<CObject> _listUpdate = new List<CObject>();    // Object to Update
            List<CObject> _listCollision = new List<CObject>(); // Object _listUpdate check Collision with

            _listUpdate = GetObjects(_updateRect);
            _listCollision = GetObjects(_collisionRect);

            int _countUpdate = _listUpdate.Count;
            int _countCollision = _listCollision.Count;

            ////////////////////////// Update từng Object //////////////////////////
            for (int i = 0; i < _countUpdate; ++i)
            {
                RemoveObject(_listUpdate[i]);      // Xóa ra trước khi Update
                _listUpdate[i].Update(_gametime);  // Có thể thay đổi IsAlive của nhân vật
            }

            //////////////////////// Sau đó mới xét va chạm ////////////////////////
            bool _hasAnyCollision = false;
            for (int i = 0; i < _countUpdate; ++i)
            {
                if (_listUpdate[i].States != Object_States.Die)
                {
                    for (int j = 0; j < _countCollision; ++j)
                    {
                        if (_listUpdate[i] != _listCollision[j])
                        {
                            CObject _obj = _listCollision[j];
                                _listUpdate[i].UpdateCollision(ref _obj);
                        }
                    }
                }
            }

            //////////////////////// Add lại vào QuadTree ///////////////////////////
            for (int i = 0; i < _countUpdate; ++i)
            {
                if (_listUpdate[i].States != Object_States.Die)
                {
                    AddObject(_listUpdate[i]);
                }
            }
        }

        public bool Collision(Rectangle _rect1, Rectangle _rect2)
        {
            return _rect1.Intersects(_rect2);
        }

        public void Draw(SpriteBatch _SpriteBatch, Rectangle _cam, Vector2 _expandCameraSize)
        {
            List<CObject> _listRender = new List<CObject>();

            Rectangle _drawRect = new Rectangle(
                _cam.X - (int)_expandCameraSize.X,
                _cam.Y - (int)_expandCameraSize.Y,
                _cam.Width + 2 * (int)_expandCameraSize.X,
                _cam.Height + 2 * (int)_expandCameraSize.Y);

            _listRender = GetObjects(_drawRect);

            for (int i = 0; i < _listRender.Count; ++i)
            {
                _listRender[i].Draw(_SpriteBatch);
            }
        }
    }
    #endregion
}
