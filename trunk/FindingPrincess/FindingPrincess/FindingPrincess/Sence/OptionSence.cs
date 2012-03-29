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
    public enum EOption
    {
        MUSIC,
        LANGUAGE,
        FULL_SCREEN,
        PLAYER_NAME
    }

    public class OptionSence : GameSence
    {
#region Const........
        const int NAME_LENGHT = 10;
#endregion

        protected Texture2D _bg;
        protected SpriteFont _font;
        protected SpriteFont _fontType;
        protected Texture2D _check;
        protected Texture2D _unCheck;
        protected Texture2D _select;
        protected Texture2D _typeBar;
        protected Texture2D _typeBarSelect;
        protected int _curOption;
        public static string _player = "PLAYER";
        protected string[] _options;
        protected string[] _optionsEN = new string[]
            {
                "Music",
                "Tieng Viet",
                "Full Screen",
                "Name"
            };

        protected string[] _optionsTV = new string[]
        {
            "Âm thanh",
            "Tiếng Việt",
            "Tràn màn hình",
            "Tên "
        };
        protected static bool[] _optionCheck;

        protected Vector2[] _positions;
        protected Vector2[] _optionSize;

#region Properties..........
        public static bool[] OptionCheck
        {
            get
            {
                return _optionCheck;
            }
        }
#endregion

        public OptionSence(Game game)
            : base(game)
        {
            Show();
            _curOption = 0;
            _font = Game.Content.Load<SpriteFont>(@"Font\TNR48");
            _fontType = Game.Content.Load<SpriteFont>(@"Font\Motorwerk48");
            _bg = Game.Content.Load<Texture2D>(@"Image\BackGround\Help");
            _check = Game.Content.Load<Texture2D>(@"Image\BackGround\Check");
            _unCheck = Game.Content.Load<Texture2D>(@"Image\BackGround\UnCheck");
            _select = Game.Content.Load<Texture2D>(@"Image\BackGround\Select");
            _typeBar = Game.Content.Load<Texture2D>(@"Image\BackGround\TypeBar");
            _typeBarSelect = Game.Content.Load<Texture2D>(@"Image\BackGround\TypeBarSelect");
            _options = _optionsEN;
            _positions = new Vector2[_options.Length];
            
            float x = 5 * _check.Width;
            float y = Game.Window.ClientBounds.Height / (_options.Length + 1);
            _optionCheck = new bool[_options.Length];
            _optionSize = new Vector2[_options.Length];
            for (int i = 0; i < _options.Length; ++i )
            {
                _optionCheck[i] = false;
                _positions[i] = new Vector2(x, i * y + y - _font.LineSpacing/2);
                _optionSize[i].X = _font.MeasureString(_options[i]).Length();
                _optionSize[i].Y = _font.LineSpacing;
            }
            //_optionCheck[(int)EOption.FULL_SCREEN] = true;
        }

        public override void Update(GameTime gameTime)
        {
            if(_optionCheck[(int)EOption.LANGUAGE] == true)
            {
                _options = _optionsTV;
            }
            else
            {
                _options = _optionsEN;
            }
            base.Update(gameTime);
            CheckMouseInput();
            if(CInput.KeyPressed(Keys.Up))
            {
                _curOption += _options.Length - 1;
                _curOption %= _options.Length;
            }
            else if(CInput.KeyPressed(Keys.Down))
            {
                _curOption++;
                _curOption %= _options.Length;
            }
            //////////////////////////////////////////////////////////////////////////
            if(CInput.KeyPressed(Keys.Space))
            {
                _optionCheck[_curOption] = !_optionCheck[_curOption];
            }

            if(_curOption == (int)EOption.PLAYER_NAME)
            {
                Keys[] _keys = CInput.PressedKeys();

                foreach (Keys _k in _keys)
                {
                    if (_k == Keys.Back && _player.Length >= 1)
                    {
                        _player = _player.Remove(_player.Length - 1);
                    }
                    if (_player.Length >= NAME_LENGHT)
                        continue;
                    if (_k == Keys.Space)
                    {
                        _player += ' ';
                    }

                    if (_k.ToString().Length == 1)
                    {
                        _player += _k.ToString();
                    }
                }
            }

            if (CInput.KeyPressed(Keys.Enter) || CInput.RightPressed)
                EventProcess();
        }

        public override void Draw(GameTime gameTime)
        {
            this.Game.GraphicsDevice.Clear(Color.Pink);
            _spriteBatch.Begin();

            _spriteBatch.Draw(_bg, Vector2.Zero, Color.White);

            _spriteBatch.Draw(_select, _positions[_curOption] - new Vector2(248, 28), Color.White);
            
            if (_curOption != (int)EOption.PLAYER_NAME)
                _spriteBatch.Draw(_typeBar, new Vector2(400, 450), Color.White);
            else
                _spriteBatch.Draw(_typeBarSelect, new Vector2(400, 450), Color.White);

            _spriteBatch.DrawString(_fontType, _player, new Vector2(410, 443), Color.Black);
            
            for (int i = 0; i < _options.Length; ++i)
            {
                _spriteBatch.DrawString(_font, _options[i], _positions[i] - new Vector2(2, 2), Color.Yellow);
                if(i != _curOption)
                    _spriteBatch.DrawString(_font, _options[i], _positions[i], new Color(85, 0, 0));
                else
                    _spriteBatch.DrawString(_font, _options[i], _positions[i], Color.Red);

                if (i != (int)EOption.PLAYER_NAME)
                {
                    if (_optionCheck[i])
                        _spriteBatch.Draw(_check, _positions[i] - new Vector2(96, -4), Color.White);
                    else
                        _spriteBatch.Draw(_unCheck, _positions[i] - new Vector2(96, -4), Color.White);
                }
            }
                        
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        int _oldX = CInput.MousePoint.X;
        int _oldY = CInput.MousePoint.Y;
        bool _canClick = false;
        protected void CheckMouseInput()
        {
            if (CInput.RightPressed)
            {
                EventProcess();
            }

            if(CInput.LeftPressed && _canClick)
            {
                _optionCheck[_curOption] = !_optionCheck[_curOption];
            }

            int x = CInput.MousePoint.X;
            int y = CInput.MousePoint.Y;
            if (_oldX == x && _oldY == y)
                return;
            Rectangle rect;

            _canClick = false;

            for (int i = 0; i < _options.Length; ++i)
            {
                if(i != (int)EOption.PLAYER_NAME)
                {
                    rect.X = (int)_positions[i].X - (int)_optionSize[i].X;
                    rect.Y = (int)_positions[i].Y;
                    rect.Width = 2 * (int)_optionSize[i].X;
                    rect.Height = (int)_optionSize[i].Y;
                    if (rect.Contains(new Point(x, y)))
                    {
                        _curOption = i;
                        _canClick = true;
                        break;
                    }
                }
                else
                {
                    rect.X = (int)_positions[i].X - (int)_optionSize[i].X;
                    rect.Y = (int)_positions[i].Y;
                    rect.Width = 2 * (int)_optionSize[i].X + _typeBar.Width;
                    rect.Height = (int)_optionSize[i].Y;
                    if (rect.Contains(new Point(x, y)))
                    {
                        _curOption = i;
                        break;
                    }
                }
                
                
            }

            _oldX = x;
            _oldY = y;
        }

    }
}
