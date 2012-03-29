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
        /// <param name="_camera"> Rectangle of view camera</param>
        /// <param name="_expandCameraSize"> The expand size of rectangle _camra, used to GetObject to check Colliion # GetOjbect to Update</param>
        /// <param name="_gametime"> The GameTime to update object</param>
        public void Update(Rectangle _camera, Vector2 _expandCameraSize, GameTime _gametime)
        {
            int _wCollsion = (int)_expandCameraSize.X;  // expand size
            int _hCollision = (int)_expandCameraSize.Y;
            Rectangle _collisionRect = new Rectangle(_camera.X - _wCollsion, _camera.Y - _hCollision, _camera.Width + 2 * _wCollsion, _camera.Height + 2 * _hCollision); // The expanded Rect to get Collision list
            
            List<CObject> _listUpdate = new List<CObject>();    // Object to Update
            List<CObject> _listCollision = new List<CObject>(); // Object _listUpdate check Collision with
            
            _listUpdate = GetObjects(_camera);
            _listCollision = GetObjects(_collisionRect);

            Console.WriteLine("Update= " + _listUpdate.Count);
            Console.WriteLine("Collision= " + _listCollision.Count);

            int _countUpdate = _listUpdate.Count;
            int _countCollision = _listCollision.Count;

            ////////////////////////// Update từng Object //////////////////////////
            for (int i = 0; i < _countUpdate; ++i)
            {
                RemoveObject(_listUpdate[i]);      // Xóa ra trước khi Update
                _listUpdate[i].Update(_gametime);  // Có thể thay đổi IsAlive của nhân vật
            }

            //////////////////////// Sau đó mới xét va chạm ////////////////////////
            for (int i = 0; i < _countUpdate; ++i)
            {
                if (_listUpdate[i].isLife)
                {
                    for (int j = 0; j < _countCollision; ++j)
                    {
                        if (_listUpdate[i] != _listCollision[j])
                            _listUpdate[i].UpdateCollision(_listCollision[j]);
                    }
                }
            }

            //////////////////////// Add lại vào QuadTree ///////////////////////////
            for (int i = 0; i < _countUpdate; ++i)
            {
                if (_listUpdate[i].isLife)
                {
                    AddObject(_listUpdate[i]);
                }
            }
        }

        public void Draw(SpriteBatch _SpriteBatch, Rectangle _CamRect)
        {
            List<CObject> _listRender = new List<CObject>();

            _listRender = GetObjects(_CamRect);

            for (int i = 0; i < _listRender.Count; ++i)
            {
                if (_listRender[i].isVisible)
                    _listRender[i].Draw(_SpriteBatch);
            }
        }
    }
#endregion
}
