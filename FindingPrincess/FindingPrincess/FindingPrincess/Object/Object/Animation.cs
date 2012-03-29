using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FindingPrincess.Sence;

namespace FindingPrincess.Object
{
    // Enum to manage the direct of Animation, it is used to Draw Sprite with SpriteEffects...
    public enum IDirect
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    // Manage a Sprite and Position, used to make Skin of GameObjecct...
    public class Animation
    {
        protected IDResource _IDResource;
        protected Sprite    _sprite;
        protected int       _indexFrame     = 0;
        protected int       _millisecondPerFrame;
        protected IDirect   _directFace = IDirect.LEFT;

        // No important...
        protected float     _rotation = 0f;
        protected Vector2   _origin = Vector2.Zero;
        protected float     _scale = 1.0f;

    #region Propertiess....
        
        public Sprite Sprite
        {
            get { return _sprite; }
        }
        
        public Vector2 Size
        {
            get { return new Vector2(_sprite.Width, _sprite.Heigh); }
        }

        public int MillisecondPerFrame
        {
            get { return _millisecondPerFrame; }
            set { _millisecondPerFrame = value; }
        }

        public IDirect DirectFace
        {
            get { return _directFace; }
            set { _directFace = value; }
        }

        public int IndexFrame
        {
            get { return _indexFrame; }
            set { _indexFrame = value; }
        }

        public float Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public Vector2 Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

    #endregion

        public Animation(IDResource _ID, int _mil, IDirect _direct)
        {
            _IDResource = _ID;
            _sprite = ResourceManager.GetSprite(_IDResource);
            _indexFrame = 0;
            _millisecondPerFrame = _mil;
            _directFace = _direct;
        }

        private int _counter;
        public virtual void Update(GameTime gametime)
        {
            _counter += gametime.ElapsedGameTime.Milliseconds;

            if (_counter < _millisecondPerFrame) return;
            else
            {
                _counter -= _millisecondPerFrame;
                _indexFrame++;
                _indexFrame %= _sprite.Frames.Length;
            }

        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 _position)
        {
            if (_directFace == IDirect.LEFT)
                _sprite.Draw(_indexFrame, spriteBatch, _position, SpriteEffects.None);
            else
                _sprite.Draw(_indexFrame, spriteBatch, _position, SpriteEffects.FlipHorizontally);
        }

        public virtual void Dispose()
        {
            _sprite.Dispose();
        }
    }
}
