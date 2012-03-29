using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FindingPrincess.Object.QuadTree
{
    public class CQuadtreeNode2
    {
        public int m_NodeLvl;
        public Vector2 m_Pos;
        public Vector2 m_Size;
        private List<IBound> m_ListObject;
        public CQuadtreeNode2 m_ParentNode;
        public CQuadtreeNode2[] m_ListChild;

        public CQuadtreeNode2(CQuadtreeNode2 _ParentNode, Vector2 _Pos, Vector2 _Size)
        {
            if (m_ParentNode == null)
            {
                m_ParentNode = null;
                m_NodeLvl = 1;
            }
            else
            {
                m_ParentNode = _ParentNode;
                m_NodeLvl = m_ParentNode.m_NodeLvl + 1;
            }

            m_Pos = _Pos;
            m_Size = _Size;

            m_ListChild = null;
            m_ListObject = new List<IBound>();
        }

        public void AddObject(IBound _NewObj)
        {
            m_ListObject.Add(_NewObj);
        }

        // Lấy list object trong 1 node cho vào _ListObject
        public void GetObject(ref List<IBound> _ListObject)
        {
            int size = m_ListObject.Count;

            for (int i = 0; i < size; ++i)
            {
                _ListObject.Add(m_ListObject[i]);
            }
        }

        public bool RemoveObject(IBound _RmvObj)
        {
            return m_ListObject.Remove(_RmvObj);
        }

        public Rectangle GetBoundingBox()
        {
            Rectangle nodeRect = new Rectangle((int)m_Pos.X, (int)m_Pos.Y, (int)m_Size.X, (int)m_Size.Y);

            return nodeRect;
        }


    }
}
