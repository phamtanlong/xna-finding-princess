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
using System.Threading;

namespace FindingPrincess.Sence
{
    public class IntroSence : GameSence
    {
        protected Texture2D _introBG;
        protected Texture2D _light;
        protected string _FindingPrincess = "Finding Princess";
        protected SpriteFont _fontBig;
        protected SpriteFont _fontSmall;
        protected Vector2 _textPosition;
        protected int _millionSecondPerFrame = 100;

        public IntroSence(Game game)
            : base(game)
        {
            Show();
            _fontBig = Game.Content.Load<SpriteFont>(@"Font\UVNHoaKy100");
            _fontSmall = Game.Content.Load<SpriteFont>(@"Font\TNR14");
            int x = Game.Window.ClientBounds.Width / 2 - (int)_fontBig.MeasureString(_FindingPrincess).Length() / 2;
            int y = -_fontBig.LineSpacing;
            _middleY = Game.Window.ClientBounds.Height / 2 - _fontBig.LineSpacing / 2;
            _textPosition = new Vector2(x, y);
            _introBG = game.Content.Load<Texture2D>(@"Image\BackGround\IntroBG");
            _light = game.Content.Load<Texture2D>(@"Image\BackGround\Light");
            _lightPos = new Vector2(- 2 * Game.Window.ClientBounds.Width, _middleY + _fontBig.LineSpacing - 2 * _light.Height / 3);
        }

        int _start = Environment.TickCount;
        int _middleY;
        bool _part2 = false;
        Vector2 _lightPos;
        bool _increase = true;
        public override void Update(GameTime gameTime)
        {
            if (Environment.TickCount - _start < 1500)
                return;

            if(! _part2)
            {
                _textPosition.Y += 25;
                if (_textPosition.Y >= _middleY)
                {
                    _textPosition.Y = _middleY;
                    _part2 = true;
                }
            }
            else
            {
                if (_increase)
                {
                    _lightPos.X+=20;
                    if (_lightPos.X > 2*Game.Window.ClientBounds.Width)
                    {
                        _increase = false;
                    }
                }
                else
                {
                    _lightPos.X-=20;
                    if (_lightPos.X < -_light.Width - Game.Window.ClientBounds.Width)
                    {
                        _increase = true;
                    }
                }
            }

            if (_part2 && (CInput.RightPressed || CInput.PressedKeys().Length > 0))
                EventProcess();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_introBG, Vector2.Zero, Color.White);
            if (_part2)
            {
                _spriteBatch.Draw(_light, _lightPos, Color.White);
                float x = Game.Window.ClientBounds.Width - _lightPos.X - _light.Width;
                float y = _middleY;
                _spriteBatch.Draw(_light, new Vector2(x, y), Color.White);
            }

            _spriteBatch.DrawString(_fontBig, _FindingPrincess, _textPosition - new Vector2(5,5), Color.Black);
            _spriteBatch.DrawString(_fontBig, _FindingPrincess, _textPosition, Color.Red);
            _spriteBatch.DrawString(_fontBig, _FindingPrincess, _textPosition + new Vector2(5, 5), new Color(0, 0, 0, 50));

            if(_part2)
                _spriteBatch.DrawString(_fontSmall, "...press any key...", _textPosition + new Vector2(0, 200), new Color(100, 90, 90));

            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
