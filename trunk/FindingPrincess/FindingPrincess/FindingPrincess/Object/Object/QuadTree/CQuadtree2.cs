using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FindingPrincess.Object.QuadTree
{
    public class CQuadtree2
    {
        private CQuadtreeNode2 m_RootNode;

        public float m_QuadWidth;
        public float m_QuadHeight;
        public int m_MaxLvl;

        public CQuadtree2(int _MaxLv, float _Width, float _Height)
        {
            m_MaxLvl = _MaxLv;
            m_QuadWidth = _Width;
            m_QuadHeight = _Height;

            m_RootNode = new CQuadtreeNode2(null, new Vector2(0, 0), new Vector2(m_QuadWidth, m_QuadHeight));
        }

        // Thêm 1 object vào Quadtree ngay tại Node _QNode, hàm đệ quy nên phải có _QNode
        public void AddObject(IBound _newObj, CQuadtreeNode2 _QNode)
        {
            if (_QNode == null)
                _QNode = m_RootNode;

            int i = 0;
            int collisionIndex = 0;
            int[] index = { -1, -1 };

            // Chia thử thành 4 Node
            int left = (int)_QNode.m_Pos.X;
            int top = (int)_QNode.m_Pos.Y;
            int width = (int)_QNode.m_Size.X / 2;
            int height = (int)_QNode.m_Size.Y / 2;

            Rectangle[] nodeRect = new Rectangle[4];
            nodeRect[0] = new Rectangle(left, top, width, height);//LT
            nodeRect[1] = new Rectangle(left + width, top, width, height);//RT
            nodeRect[2] = new Rectangle(left, top + height, width, height);//RB
            nodeRect[3] = new Rectangle(left + width, top + height, width, height);//LB
            //////////////////////////////////////////////////////////////////////////

            for (i = 0; i < 4; ++i)
            {
                if (_newObj.Bound.Intersects(nodeRect[i]))
                {
                    index[collisionIndex++] = i;
                    if (collisionIndex > 1)
                        break;
                }
            }

            if (collisionIndex > 1)
            {
                _QNode.AddObject(_newObj);
            }
            else if (collisionIndex == 1)
            {
                //////////////////////////////////////////////////////////////////////////
                if (DevideNode(_QNode))
                {
                    AddObject(_newObj, _QNode.m_ListChild[index[0]]);
                }
                else
                {
                    _QNode.AddObject(_newObj);
                }
            }

        }

        private bool DevideNode(CQuadtreeNode2 _QNode)
        {
            if (_QNode.m_NodeLvl < m_MaxLvl)
            {
                if (_QNode.m_ListChild == null)
                {
                    int left = (int)_QNode.m_Pos.X;
                    int top = (int)_QNode.m_Pos.Y;
                    int width = (int)_QNode.m_Size.X / 2;
                    int height = (int)_QNode.m_Size.Y / 2;

                    _QNode.m_ListChild = new CQuadtreeNode2[4];

                    _QNode.m_ListChild[0] = new CQuadtreeNode2(_QNode, new Vector2(left, top), new Vector2(width, height));
                    _QNode.m_ListChild[1] = new CQuadtreeNode2(_QNode, new Vector2(left + width, top), new Vector2(width, height));
                    _QNode.m_ListChild[2] = new CQuadtreeNode2(_QNode, new Vector2(left, top + height), new Vector2(width, height));
                    _QNode.m_ListChild[3] = new CQuadtreeNode2(_QNode, new Vector2(left + width, top + height), new Vector2(width, height));

                    return true;
                }
                else
                    return true;
            }

            return false;
        }

        // Đệ quy lấy các Objeect va chạm vơi cái Camera, đưa ra List, và QNode dùng cho đệ quy
        // Khi gọi hàm này thì truyền _QNode = null, nghĩa là bắt đầu ở Node gốc
        private void GetObject(Rectangle _Camera, /*in-out*/ref List<IBound> _ListObject, CQuadtreeNode2 _QNode)
        {
            if (_QNode == null)
                _QNode = m_RootNode;

            if (_QNode.m_ListChild == null)
            {
                _QNode.GetObject(ref _ListObject);
            }
            else
            {
                // Lấy Object trong Node cha trước
                _QNode.GetObject(ref _ListObject);

                // Sau đó lấy Object trong các Node con của nó
                int collisionIndex = 0;
                int i;

                int[] index = { -1, -1, -1, -1 };

                for (i = 0; i < 4; i++)
                {
                    if (_Camera.Intersects(_QNode.m_ListChild[i].GetBoundingBox()))
                    {
                        index[collisionIndex++] = i;
                    }
                }

                for (i = 0; i < collisionIndex; ++i)
                {
                    GetObject(_Camera, ref _ListObject, _QNode.m_ListChild[index[i]]);
                }

            }
        }

        // Để tránh 1 object xét va chạm với chính nó
        // Lấy nó ra để xét, rồi add vào khi xét xong cho thằng object khác xét tiếp
        private void RemoveObject(IBound _RmvObj, CQuadtreeNode2 _QNode)
        {
            if (_QNode == null)
                _QNode = m_RootNode;

            // Tìm Object nếu có trong Node này thì xóa, có thì return xong!, ko thì tìm trong Node con để xóa
            if (_QNode.RemoveObject(_RmvObj))
                return;

            // Ko có Node con
            if (_QNode.m_ListChild == null)
            {
                return;
            }
            // Và có Node con
            else
            {
                int collisionIndex = 0, i;
                int[] index = { -1, -1, -1, -1 };

                for (i = 0; i < 4; i++)
                {
                    if (_RmvObj.Bound.Intersects(_QNode.m_ListChild[i].GetBoundingBox()))
                    {
                        index[collisionIndex++] = i;
                    }
                }

                // Sửa lại nha ku!!!! Vì chỉ có 1 Node con chứa Object cần xóa này, nên ko cần lặp 4 lần
                for (i = 0; i < collisionIndex; ++i)
                {
                    RemoveObject(_RmvObj, _QNode.m_ListChild[index[i]]);
                }
            }
        }

        public void RemoveObject(CObject _RmvObj)
        {
            RemoveObject(_RmvObj, null);
        }

        // Gọi hàm Update của tất cả các Object chứa trong cái Rect này(camera mini)
        public void Update(Rectangle _RectCam, GameTime _GameTime, CInput _Input)
        {
            List<CObject> pListUpdate = new List<CObject>();
            List<CObject> pListCollision = new List<CObject>();
            // dùng để chứa các Object có thể va chạm với từng cái object trong cái listUpdate trên
            // trong quá trình duyệt listupdate trên
            int updateCount = 0;
            int collisionCount = 0;
            int i, j;

            // Lấy obj ra pListUpdate
            GetObject(_RectCam, ref pListUpdate, null);

            updateCount = pListUpdate.Count;
            Console.WriteLine("asd" + updateCount);
            for (i = 0; i < updateCount; ++i)
            {
                // Xóa nó trước khi update vị trí mới cho nó
                // Vì sau khi update vị trí mới thì nó thuộc Node mới
                RemoveObject(pListUpdate[i]);

                if (pListUpdate[i].Alive == true)
                {
                    pListUpdate[i].Update(_GameTime, _Input);
                }

                pListCollision.Clear();
                // Sửa lại đi bố, chỉ cần lấy ListUpdate.Remove(pListUpdate[i] ) là xong........
                GetObject(_RectCam, ref pListCollision, null);

                collisionCount = pListCollision.Count;

                // Số lần Update sẽ là n^2
                // Vì A.checkWidth(B)
                // Và B.checkWidth(A), dư 1 lần
                for (j = 0; j < collisionCount; ++j)
                {
                    CObject pObj = pListCollision[j];
                    pListUpdate[i].UpdateCollision(ref pObj);
                    if (pObj.Alive == false)
                    {
                        RemoveObject(pObj, null);
                    }
                }

                // Hiệu ứng cho obj sau khi có va chạm 
                if (pListUpdate[i].Alive == false && pListUpdate[i].ID == IDObject.ZOMBIE)
                {
                    CEffectManager.getInstance().AddEffect(IDEffect.TEST, IDResource.EFFECT, pListUpdate[i].Pos);
                }

                if (pListUpdate[i].Alive == false && (pListUpdate[i].ID == IDObject.MUSHROOM_BIG || pListUpdate[i].ID == IDObject.FLOWER ||
                        pListUpdate[i].ID == IDObject.ITEM_UPLIFE || pListUpdate[i].ID == IDObject.ITEM_UPHEALTH || pListUpdate[i].ID == IDObject.COIN))
                {
                    CEffectManager.getInstance().AddEffect(IDEffect.EFFECT_GETITEM, IDResource.EFFECT_GETITEM, pListUpdate[i].Pos);
                }

                if (pListUpdate[i].Alive)
                    AddObject(pListUpdate[i], null);
                else
                    pListUpdate[i] = null;
            }
        }

        public void Draw(SpriteBatch _SpriteBatch, Rectangle _CamRect)
        {
            List<CObject> pListRender = new List<CObject>();
            int renderCount = 0;

            GetObject(_CamRect, ref pListRender, null);

            renderCount = pListRender.Count;
            for (int i = 0; i < renderCount; ++i)
            {
                if (pListRender[i].Visible)
                    pListRender[i].Draw(_SpriteBatch);
            }
        }
    }
}
