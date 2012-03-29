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
    class CMap
    {
        private string m_MapName;
        private int m_Rows = 0;
        private int m_Cols = 0;
        private int[,] m_MapMatrix;
        public CMap(string _MapName)
        {
            try
            {
                m_MapName = _MapName;
                System.IO.StreamReader _FileMap = System.IO.File.OpenText(m_MapName); // doc file
                string _Line = string.Empty;
                string[] _StrTemp;
                while ((_Line = _FileMap.ReadLine()) != null) // doc 1 luot nguyen 1 line luu trong _Line
                {
                    _StrTemp = _Line.Split(' '); // thao tac split de cat nho nhung j da doc
                    m_Cols = _StrTemp.Length; ;
                    m_Rows++;
                }
                m_MapMatrix = new int[m_Rows, m_Cols];
                _FileMap.Close();
                _FileMap = new System.IO.StreamReader(m_MapName);
                //_FileMap.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                int k = 0;
                while ((_Line = _FileMap.ReadLine()) != null)
                {
                    _StrTemp = _Line.Split(' '); // thao tac split de cat nho nhung j da doc

                    for (int j = 0; j < m_Cols; j++)
                    {
                        m_MapMatrix[k, j] = int.Parse(_StrTemp[j]);
                    }
                    k++;
                }
                _FileMap.Close();
            }
            catch
            {
                Console.WriteLine("Can't not read Map");
            }
        }
        public void WriteMap()
        {
            for (int i = 0; i < m_Rows; i++)
                for (int j = 0; j < m_Cols; j++)
                    Console.WriteLine(m_MapMatrix[i, j]);
        }
        public void Init(ContentManager Content, ref CQuadtree _Quadtree)
        {
            for (int i = 0; i < m_Cols; i++)
                for (int j = 0; j < m_Rows; j++)
                {
                    switch (m_MapMatrix[j, i])
                    {
                        case 1:
                            CBrick newObj1 = new CBrick(IDObject.Brick, i * 50, j * 50);
                            newObj1.Init(Content);
                            _Quadtree.AddObject(newObj1);
                            break;
                        case 2:
                            CBaseBrick newObj2 = new CBaseBrick(IDObject.BaseBrick, i * 50, j * 50);
                            newObj2.Init(Content);
                            _Quadtree.AddObject(newObj2);
                            break;
                        case 3:
                            CMonster newObj3 = new CMonster(IDObject.Monster, i * 50, j * 50,-0.05f, 0, 0, 0.004f, DirFace.Left,Monster_Name.SnowMan);
                            newObj3.Init(Content);
                            _Quadtree.AddObject(newObj3);
                            break;
                        case 4:
                            CBarrel newObj4 = new CBarrel(IDObject.Barrel, i * 50, j * 50);
                            newObj4.Init(Content);
                            _Quadtree.AddObject(newObj4);
                            break;
                    }
                }
        }
        public void UnLoad()
        {
            Console.WriteLine("UnLoad content of Map......");
        }

    }
}