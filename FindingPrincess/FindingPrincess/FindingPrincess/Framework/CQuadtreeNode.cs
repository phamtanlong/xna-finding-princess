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
    class Node
    {
        protected int _level;
        protected Rectangle _bound;
        protected List<CObject> _listObject;
        protected Node[] _listChildNode;

        #region  Properties..............
        public Node[] ChildNodes
        {
            get { return _listChildNode; }
        }

        public List<CObject> Objects
        {
            get { return _listObject; }
        }

        public int Level
        {
            get { return _level; }
        }

        public Rectangle Bound
        {
            get { return _bound; }
        }
        #endregion

        public Node(Rectangle _bound, int _level)
        {
            this._level = _level;
            this._bound = _bound;
            _listChildNode = null;
            _listObject = new List<CObject>();
        }

        public bool AddObject(CObject _obj)
        {
            ////////////////////////// Hoàn toàn không va chạm ///////////////////////
            if (!this._bound.Intersects(_obj.Bound))
            {
                _Engine.ShowMessage("Bound no intersect!" + "\nBound: " + this.Bound.ToString() + "\nObject: " + _obj.Bound.ToString());
                return false;
            }

            ///////////////////// Không được phép chia Node con nữa /////////////////
            if (this._level >= CQuadtree.MAX_LEVEL)
            {
                _listObject.Add(_obj);
                return true;
            }
            else
            {//////////////////////Có thể chia ra Node con nữa ///////////////////////
                if (_listChildNode == null)
                    Devide4Nodes();

                int countCollision = 0;
                for (int i = 0; i < 4; ++i)
                {
                    if (_listChildNode[i].Bound.Intersects(_obj.Bound))
                        countCollision++;
                }

                if (countCollision >= 2)
                {////////////////////////// Thuộc Node hiện tại /////////////////////////////
                    _listObject.Add(_obj);
                    return true;
                }
                else
                {////////////////////// Thuộc 1 trong các Node con //////////////////////////
                    for (int i = 0; i < 4; ++i)
                    {
                        if (_listChildNode[i].Bound.Intersects(_obj.Bound))
                        {
                            return _listChildNode[i].AddObject(_obj);
                        }
                    }
                }
            }
            return false;
        }

        protected void Devide4Nodes()
        {
            _listChildNode = new Node[4];
            Rectangle[] childRect = new Rectangle[4];
            int midX = _bound.Width / 2 + _bound.X;
            int midY = _bound.Height / 2 + _bound.Y;
            childRect[0] = new Rectangle(_bound.X, _bound.Y, _bound.Width / 2, _bound.Height / 2);
            childRect[1] = new Rectangle(midX, _bound.Y, _bound.Width / 2, _bound.Height / 2);
            childRect[2] = new Rectangle(midX, midY, _bound.Width / 2, _bound.Height / 2);
            childRect[3] = new Rectangle(_bound.X, midY, _bound.Width / 2, _bound.Height / 2);

            for (int i = 0; i < 4; ++i)
            {
                Node node = new Node(childRect[i], this.Level + 1);
                _listChildNode[i] = node;
            }
        }

        public bool RemoveObject(CObject _obj)
        {
            if (_listObject.Contains(_obj))
            {
                _listObject.Remove(_obj);
                return true;
            }
            else
            {
                if (_listChildNode == null)
                    return false;
                else
                    for (int i = 0; i < 4; ++i)
                    {
                        if (_listChildNode[i].Bound.Intersects(_obj.Bound))
                        {
                            return _listChildNode[i].RemoveObject(_obj);
                        }
                    }
            }
            return false;
        }

        public List<CObject> GetObjects(Rectangle _camera)
        {
            List<CObject> _list = new List<CObject>();
            if (!this.Bound.Intersects(_camera))
            {//////////////////////////Không va chạm với camera/////////////////////////
                return _list;
            }
            else
            {///////////////////////////// Có va chạm camera ///////////////////////////
                if (_listChildNode == null)
                {///////////////////////// không có Node con ///////////////////////////
                    for (int i = 0; i < _listObject.Count; ++i)
                    {
                        if (_listObject[i].Bound.Intersects(_camera))
                            _list.Add(_listObject[i]);
                    }
                }
                else
                {//////////////////////////// Có Node con ///////////////////////////////
                    int countCollision = 0;
                    for (int i = 0; i < 4; ++i)
                    {
                        if (_listChildNode[i].Bound.Intersects(_camera))
                            countCollision++;
                    }
                    /////////////////////////////////////////////////////////////////////////
                    if (countCollision >= 2)
                    {// Nếu va chạm với 2 con, nghĩa là có thể va chạm với các Obj của Node hiện tại
                        for (int i = 0; i < _listObject.Count; ++i)
                        {
                            if (_listObject[i].Bound.Intersects(_camera))
                                _list.Add(_listObject[i]);
                        }
                    }
                    //////////////////////////////////////////////////////////////////////////
                    for (int i = 0; i < 4; ++i)
                    {
                        _list.AddRange(_listChildNode[i].GetObjects(_camera));
                    }
                }
            }
            return _list;
        }
    }
}
