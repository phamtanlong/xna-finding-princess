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
using System.IO;
using FindingPrincess.Sence;

namespace FindingPrincess.Object
{
    public enum ECollision
    {
        TOP,
        BOTTOM,
        LEFT,
        RIGHT,
        NONE
    }

    ///////////////////////////////////////////////////////////////////////////
    public class ObjectManager
    {
        #region  Const.........

        const int _MAP_WIDTH = 40;
        const int _MAP_HEIGH = 15;
        const int _DELTA = 0;

        const int _DELTA_COLLISION = 10; // Khoảng cách giữa nhân vật và thảm cỏ khi có va chạm
        const float _MINIMUM = 0.1f;

        #endregion

        protected List<MovableObject> _movableObjects;
        protected List<UnMovableObject> _unMovableObjects;
        protected int[,] _map;
        public static Rectangle CAMERA;
        protected ResourceManager _RM;

        #region Properties.....................

        public List<MovableObject> MovableObjects
        {
            get { return _movableObjects; }
        }

        public List<UnMovableObject> UnMovableObjects
        {
            get { return _unMovableObjects; }
        }

        #endregion

        public ObjectManager(ResourceManager _rm)
        {
            _movableObjects = new List<MovableObject>();
            _unMovableObjects = new List<UnMovableObject>();
            _map = new int[_MAP_HEIGH, _MAP_WIDTH];
            _RM = _rm;
            CAMERA = new Rectangle(0, 0, 800, 600);
        }

        public virtual void Update(GameTime gametime, Player _player)
        {
            UpdateCollision(gametime, _player);
        }

        public virtual void Draw(SpriteBatch _sb)
        {
            foreach(UnMovableObject _animation in _unMovableObjects)
            {
                if(_animation != null)
                    _animation.Draw(_sb);
            }
        }

        public virtual void LoadMap(string _fileName)
        {
            RemoveObject();

            ReadFileMap(_fileName);

            CreateObject();
        }

        public void RemoveObject()
        {
            if (_movableObjects.Count > 0)
                _movableObjects.RemoveAll(item => item != null);

            if (_unMovableObjects.Count > 0)
                _unMovableObjects.RemoveAll(item => item != null);
        }

        public void CreateObject()
        {
            // Chiều đọc Map có ý nghĩa lớn vì nó liên quan đến thứ tự xét va chạm của các object trong List
            for (int i = _MAP_HEIGH - 1; i >= 0; --i )
            {
                for(int j = 0; j < _MAP_WIDTH; ++j)
                {
                    Vector2 _pos = new Vector2(j * 40, i * 40);
                    IDObject _ID = (IDObject)_map[i, j];
                    switch(_ID)
                    {
                        case IDObject.TER:
                            UnMovableObject _ter = new UnMovableObject(IDObject.TER, _pos);
                            _unMovableObjects.Add(_ter);
                            break;

                        case IDObject.TER_LEFT:
                            _ter = new UnMovableObject(IDObject.TER, _pos);
                            _unMovableObjects.Add(_ter);
                            break;

                        case IDObject.TER_RIGHT:
                            _ter = new UnMovableObject(IDObject.TER, _pos);
                            _unMovableObjects.Add(_ter);
                            break;
                    }
                }
            }
        }
        
        protected void ReadFileMap(string _fileName)
        {
            try
            {
                System.IO.StreamReader _streamReader = System.IO.File.OpenText(_fileName);
                string _line = "";
                int i = 0;

                while ((_line = _streamReader.ReadLine()) != null)
                {
                    string[] _ss = _line.Split(' ');
                    int n = _ss.Length;
                    for (int k = 0; k < n; k++)
                    {
                        _map[i, k] = int.Parse(_ss[k]);
                    }
                    i++;
                }
            }
            catch
            {
                Engine.ShowMessage("Can not read Map");
            }

            for (int i = 0; i < _MAP_HEIGH; ++i)
            {
                for (int j = 0; j < _MAP_WIDTH; ++j)
                {
                    Console.Write(_map[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void UpdateCollision(GameTime gametime, Player _player)
        {
            for (int i = 0; i < _unMovableObjects.Count; ++i )
            {
                ECollision _dir = CheckCollision(_player, _unMovableObjects[i]);
                if(_dir != ECollision.NONE)
                    _player.UpdateCollision(_unMovableObjects[i], _dir);
            }
        }

        public ECollision CheckCollision(GameObject _Obj1, GameObject _Obj2)
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
                    return ECollision.TOP;
                }
                if (rs == botom)
                {
                    return ECollision.BOTTOM;
                }
                if (rs == left)
                {
                    return ECollision.LEFT;
                }
                if (rs == right)
                {
                    return ECollision.RIGHT;
                }
            }
            return ECollision.NONE;
        }
    }
}
