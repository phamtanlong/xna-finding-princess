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
        private int _Rows = 0;
        private int _Colums = 0;
        private int[,] _MapMatrix;

        protected int _mapWidth;
        protected int _mapHeigh;
        protected int _tileWidth;
        protected int _tileHeigh;

        public int Width
        {
            get { return _mapWidth; }
        }
        public int Heigh
        {
            get { return _mapHeigh; }
        }
        public int TileWidth
        {
            get { return _tileWidth; }
        }
        public int TileHeigh
        {
            get { return _tileHeigh; }
        }

        public CMap(string _fileName)
        {
            try
            {
                System.Drawing.Bitmap bitmapFile = new System.Drawing.Bitmap(_fileName);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(bitmapFile);
                System.Drawing.Rectangle bitmapRect = new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height);
                System.Drawing.Imaging.BitmapData bitmapData = bitmap.LockBits(bitmapRect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bitmap.PixelFormat);
                IntPtr ptrBitmapDataOnMemory = bitmapData.Scan0;
                Int32 numberBytesOfBitMap = bitmapData.Stride * bitmap.Height;
                Byte[] rgbValuesArrayOfBitmap = new Byte[numberBytesOfBitMap];
                System.Runtime.InteropServices.Marshal.Copy(ptrBitmapDataOnMemory, rgbValuesArrayOfBitmap, 0, numberBytesOfBitMap);

                ////////////////////// Lấy kích thước từng Object tại byte 1 và 2 của pixel thứ 1  //////////////////////
                _tileWidth = rgbValuesArrayOfBitmap[1] == 0 ? 50 : rgbValuesArrayOfBitmap[1];
                _tileHeigh = rgbValuesArrayOfBitmap[2] == 0 ? 50 : rgbValuesArrayOfBitmap[2];
                _Colums = bitmapFile.Width;
                _Rows = bitmapFile.Height;
                _mapWidth = _Colums * _tileWidth;
                _mapHeigh = _Rows * _tileHeigh;
            
                /************************************************************************/
                _MapMatrix = new int[_Rows, _Colums];

                for (int i = 0; i < _Rows; ++i)
                {
                    for (int j = 0; j < _Colums; ++j)
                    {
                        _MapMatrix[i, j] = 0;
                    }
                }
                /************************************************************************/
                int _cols, _rows;
                Byte byteBlue;
                for (int i = 0; i < rgbValuesArrayOfBitmap.Length - 1; i += 4)
                {
                    byteBlue = rgbValuesArrayOfBitmap[i];
                    if(byteBlue != 0)
                    {
                        _cols = (i / 4) % _Colums;
                        _rows = (i / 4) / _Colums;
                        _MapMatrix[_rows, _cols] = byteBlue;
                    }
                }

                System.Runtime.InteropServices.Marshal.Copy(rgbValuesArrayOfBitmap, 0, ptrBitmapDataOnMemory, numberBytesOfBitMap);
                bitmap.UnlockBits(bitmapData); 
                /************************************************************************/
            }
            catch (System.Exception ex)
            {
                //_Engine.ShowMessage("Cannot read map!\n" + ex.Message);
            }
            //_Engine.ShowMessage("Read map ok\n" + this.Width + " : " + this.Heigh);
        }

        public void Init(ContentManager Content, ref CQuadtree _Quadtree)
        {
            CMonster _monster;
            for (int j = 0; j < _Rows; j++)
                for (int i = 0; i < _Colums; i++)
                {
                    /************************************************************************/
                    /* 1-50: background Collision
                     * 51-100: boss, master, ...
                     * 101-150: monster
                     * 151-200: background NonCollision
                     */
                    /************************************************************************/
                    switch (_MapMatrix[j , i])
                    {
                            /////////////////////////////// Background //////////////////////////
                        case 1:
                            CBrick _brick = new CBrick(IDObject.Brick, i * _tileWidth, j * _tileHeigh);
                            _brick.Init(Content);
                            _Quadtree.AddObject(_brick);
                            break;
                        case 2:
                            CBaseBrick _basebrick2 = new CBaseBrick(IDObject.BaseBrick, i * _tileWidth, j * _tileHeigh);
                            _basebrick2.Init(Content);
                            _Quadtree.AddObject(_basebrick2);
                            break;

                            /////////////////////////////// Boss, master ///////////////////////////
                        case 51:
                            CBoss _boss = new CBoss(IDObject.Boss, i * _tileWidth, j * _tileHeigh, 0.12f, 0, 0, 0.004f, DirFace.Left);
                            _boss.Init(Content);
                            _Quadtree.AddObject(_boss);
                            break;
                        case 52:
                            CMaster _master = new CMaster(IDObject.Master, i * _tileWidth, j * _tileHeigh, 0.14f, 0, 0, 0.004f, DirFace.Left);
                            _master.Init(Content);
                            _Quadtree.AddObject(_master);
                            break;

                            //////////////////////////////// Monster ////////////////////////////////////

                        case 101:
                            _monster = new CMonster(IDObject.Monster, i * _tileWidth, j * _tileHeigh, 0.05f, 0, 0, 0.004f, DirFace.Left, 
                                EMonster_Name.Big_Clown);
                            _monster.Init(Content);
                            _Quadtree.AddObject(_monster);
                            break;
                        case 102:
                            _monster = new CMonster(IDObject.Monster, i * _tileWidth, j * _tileHeigh, 0.05f, 0, 0, 0.004f, DirFace.Left, 
                                EMonster_Name.Mini_Clown);
                            _monster.Init(Content);
                            _Quadtree.AddObject(_monster);
                            break;
                        case 103:
                            _monster = new CMonster(IDObject.Monster, i * _tileWidth, j * _tileHeigh, 0.05f, 0, 0, 0.004f, DirFace.Left, 
                                EMonster_Name.Old_Panda);
                            _monster.Init(Content);
                            _Quadtree.AddObject(_monster);
                            break;
                        case 104:
                            _monster = new CMonster(IDObject.Monster, i * _tileWidth, j * _tileHeigh, 0.05f, 0, 0, 0.004f, DirFace.Left, 
                                EMonster_Name.Shark);
                            _monster.Init(Content);
                            _Quadtree.AddObject(_monster);
                            break;
                        case 105:
                            _monster = new CMonster(IDObject.Monster, i * _tileWidth, j * _tileHeigh, 0.05f, 0, 0, 0.004f, DirFace.Left, 
                                EMonster_Name.SnowMan);
                            _monster.Init(Content);
                            _Quadtree.AddObject(_monster);
                            break;
                        case 106:
                            _monster = new CMonster(IDObject.Monster, i * _tileWidth, j * _tileHeigh, 0.05f, 0, 0, 0.004f, DirFace.Left, 
                                EMonster_Name.SnowMan_Blue);
                            _monster.Init(Content);
                            _Quadtree.AddObject(_monster);
                            break;
                        case 107:
                            _monster = new CMonster(IDObject.Monster, i * _tileWidth, j * _tileHeigh, 0.05f, 0, 0, 0.004f, DirFace.Left, 
                                EMonster_Name.SnowMan_Lady);
                            _monster.Init(Content);
                            _Quadtree.AddObject(_monster);
                            break;
                        case 108:
                            _monster = new CMonster(IDObject.Monster, i * _tileWidth, j * _tileHeigh, 0.05f, 0, 0, 0.004f, DirFace.Left, 
                                EMonster_Name.SnowMan_Purple);
                            _monster.Init(Content);
                            _Quadtree.AddObject(_monster);
                            break;
                        case 109:
                            _monster = new CMonster(IDObject.Monster, i * _tileWidth, j * _tileHeigh, 0.05f, 0, 0, 0.004f, DirFace.Left, 
                                EMonster_Name.SnowMan_Red);
                            _monster.Init(Content);
                            _Quadtree.AddObject(_monster);
                            break;
                        case 110:
                            _monster = new CMonster(IDObject.Monster, i * _tileWidth, j * _tileHeigh, 0.05f, 0, 0, 0.004f, DirFace.Left, 
                                EMonster_Name.Wolf_Man);
                            _monster.Init(Content);
                            _Quadtree.AddObject(_monster);
                            break;
                        case 111:
                            _monster = new CMonster(IDObject.Monster, i * _tileWidth, j * _tileHeigh, 0.05f, 0, 0, 0.004f, DirFace.Left, 
                                EMonster_Name.Wolf_Orc);
                            _monster.Init(Content);
                            _Quadtree.AddObject(_monster);
                            break;
                        case 112:
                            _monster = new CMonster(IDObject.Monster, i * _tileWidth, j * _tileHeigh, 0.05f, 0, 0, 0.004f, DirFace.Left, 
                                EMonster_Name.Wolf_Owl);
                            _monster.Init(Content);
                            _Quadtree.AddObject(_monster);
                            break;
                        case 113:
                            _monster = new CMonster(IDObject.Monster, i * _tileWidth, j * _tileHeigh, 0.05f, 0, 0, 0.004f, DirFace.Left, 
                                EMonster_Name.Yellow_Bean);
                            _monster.Init(Content);
                            _Quadtree.AddObject(_monster);
                            break;
                    }
                }
        }
    }
}