using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace FindingPrincess
{
    public class LoadingBar
    {
        protected int _minimum;
        protected int _maximum;
        protected int _curValue;
        protected Vector2 _position;
        protected Texture2D _loadingBar;
        protected Texture2D _loading;

        public int Value
        {
            get { return _curValue; }
            set 
            {
                if(value >= _curValue)
                {
                    if(value >= _maximum)
                        _curValue = _maximum;
                    else
                        _curValue = value;
                }
            }
        }

        public LoadingBar(int _min, int _max, int _cur, Vector2 _pos, ContentManager _ct)
        {
            _minimum = _min;
            _maximum = _max;
            _curValue = _cur;
            _position = _pos;
            _loadingBar = _ct.Load<Texture2D>(@"Image\LoadingBar");
            _loading = _ct.Load<Texture2D>(@"Image\Loading");
        }

        public void Draw(SpriteBatch _sb)
        {
            _sb.Draw(_loadingBar, _position, Color.White);
            _sb.Draw(_loading,
                new Vector2(_position.X + 14 + 25, _position.Y + 11+140),
                new Rectangle(0, 0, (int)((float)_loading.Width * ((float)(_curValue - _minimum) / (float)(_maximum - _minimum))), _loading.Height),
                Color.White);
        }
        
    }
}
