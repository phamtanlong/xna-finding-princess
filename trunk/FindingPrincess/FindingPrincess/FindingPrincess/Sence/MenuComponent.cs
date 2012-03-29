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

namespace FindingPrincess.Sence
{
    public class MenuComponent : GameSence
    {
        protected string[]      _menuItems;
        protected string[]      _menuItemsEN;
        protected string[]      _menuItemsTV;

        protected int           _selectIndex;

        protected SpriteFont    _fontSelect;
        protected Texture2D _ttselect;
        protected Vector2[]     _menuPosition;
        protected Vector2[]     _menuSize;
        protected Vector2 _deltaPos;
        protected bool _canClick;

        #region Thêm vào các Properties ở đây...

        public bool CanClick
        {
            get { return _canClick; }
        }

        public int SelectedMenu
        {
            get { return _selectIndex; }
        }

        public string[] MenuItems
        {
            get { return _menuItems; }
            set 
            {
                AddItems(value);
            }
        }
        
        public SpriteFont SelectedFont
        {
            get { return _fontSelect; }
            set { _fontSelect = value; }
        }

        #endregion

        public MenuComponent(Game game, Vector2 _deltaPos)
            : base(game)
        {
            this._deltaPos = _deltaPos;
            _selectIndex = 0;
            _canClick = false;
            Show();

            _fontSelect = Game.Content.Load<SpriteFont>(@"Font\TNR48");
            _ttselect = Game.Content.Load<Texture2D>(@"Image\BackGround\Select");
        }

        public MenuComponent(Game game)
            : base(game)
        {
            _deltaPos = Vector2.Zero;
            _selectIndex = 0;
            _canClick = false;
            Show();

            _fontSelect = Game.Content.Load<SpriteFont>(@"Font\TNR48");
        }


        protected void AddItems(string[] items)
        {
            _menuItems = items;
            int _no = _menuItems.Length;
            _menuPosition = new Vector2[_no];
            _menuSize = new Vector2[_no];

            int _menuHeigh = _fontSelect.LineSpacing * _no;
            int _y = 300 - _menuHeigh / 2 + (int)_deltaPos.Y;

            for (int i = 0; i < _no; ++i)
            {
                float _x = 400 - _fontSelect.MeasureString(_menuItems[i]).Length() / 2 + _deltaPos.X; // i => 0
                _menuPosition[i] = new Vector2(_x, _y + i * _fontSelect.LineSpacing);
                _menuSize[i].X = (int)_fontSelect.MeasureString(_menuItems[i]).Length();
                _menuSize[i].Y = _fontSelect.LineSpacing;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (OptionSence.OptionCheck[(int)EOption.LANGUAGE])
            {
                MenuItems = _menuItemsTV;
            }
            else
            {
                MenuItems = _menuItemsEN;
            }

            UpdateColor();
            CheckKeyboardInput();
            CheckMouseInput();
            base.Update(gameTime);
        }

        protected int r = 255;
        protected int g = 0;
        protected int b = 0;
        protected int a = 255;
        protected bool _inc = true;
        protected void UpdateColor()
        {
            if(_inc)
            {
                r += 10;
                if (r >= 255) _inc = false;
            }
            else
            {
                r -= 10;
                if (r <= 0) _inc = true;
            }
        }

        int _oldPress = Environment.TickCount;
        protected bool CheckKeyboardInput()
        {
            int _nowPress = Environment.TickCount;
            if (CInput.KeyDown(Keys.Up) && _nowPress - _oldPress >= _MENU_SELECT)
            {
                _selectIndex += _menuItems.Length - 1;
                _selectIndex %= _menuItems.Length;
                _oldPress = _nowPress;
                return true;
            }
            else
                if (CInput.KeyDown(Keys.Down) && _nowPress - _oldPress >= _MENU_SELECT)
                {
                    _selectIndex += 1;
                    _selectIndex %= _menuItems.Length;
                    _oldPress = _nowPress;
                    return true;
                }

            if(CInput.KeyPressed(Keys.Enter))
            {
                EventProcess();
            }
            return false;
        }

        int _oldX = CInput.MousePoint.X;
        int _oldY = CInput.MousePoint.Y;
        protected void CheckMouseInput()
        {
            if (CInput.LeftPressed && _canClick)
            {
                EventProcess();
            }

            int x = CInput.MousePoint.X;
            int y = CInput.MousePoint.Y;
            if (_oldX == x && _oldY == y)
                return;
            Rectangle rect;
            _canClick = false;

            for (int i = 0; i < _menuItems.Length; ++i)
            {
                rect.X = (int)_menuPosition[i].X;
                rect.Y = (int)_menuPosition[i].Y;
                rect.Width = (int)_menuSize[i].X;
                rect.Height = (int)_menuSize[i].Y;
                if (rect.Contains(new Point(x, y)))
                {
                    _selectIndex = i;
                    _canClick = true;
                    break;
                }
            }

            _oldX = x;
            _oldY = y;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            for (int i = 0; i < _menuItems.Length; ++i)
            {
                if (i != _selectIndex)
                {
                    _spriteBatch.DrawString(_fontSelect, _menuItems[i], _menuPosition[i] - new Vector2(3, 3), Color.Yellow);
                    _spriteBatch.DrawString(_fontSelect, _menuItems[i], _menuPosition[i] - new Vector2(2, 2), new Color(85, 0, 0));
                }
                else
                {
                    _spriteBatch.Draw(_ttselect,
                        new Vector2(_menuPosition[i].X + _fontSelect.MeasureString(_menuItems[i]).Length()/2 - 210, 
                        _menuPosition[i].Y - 32), 
                        Color.White);

                    _spriteBatch.DrawString(_fontSelect, _menuItems[i], _menuPosition[i] - new Vector2(2, 2), Color.Black);
                    _spriteBatch.DrawString(_fontSelect, _menuItems[i], _menuPosition[i], Color.Red);
                }
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        #region Constants...
        int _MENU_SELECT = 150;
        #endregion
    }
}
