using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FindingPrincess.Object
{
    // Class to manage a Texture and Frame
    public class Sprite
    {
        protected Texture2D _texture;
        protected int       _cols;
        protected int       _rows;
        protected Rectangle[]   _frames;

        /// No important, but if you want, you can change it from out side
        protected float     _scale      = 1.0f;
        protected float     _rotation   = 0.0f;
        protected Vector2   _origin     = Vector2.Zero;

    #region Properties...
        public Texture2D Texture 
        { get { return _texture; } }

        public int Cols 
        { get { return _cols; } }

        public int Rows 
        { get { return _rows; } }

        public Rectangle[] Frames 
        { get { return _frames; } }

        public int Width 
        { get { return _texture.Width / _cols; } }

        public int Heigh 
        { get { return _texture.Height / _rows; } }

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
        
        public Sprite(Texture2D textture, int cols, int rows)
        {
            _texture = textture;
            _cols = cols;
            _rows = rows;

            int frameWidth = _texture.Width / _cols;
            int frameHeigh = _texture.Height / _rows;
            int index = 0;

            _frames = new Rectangle[_cols * _rows];

            for (int y = 0; y < _rows; y++)
                for (int x = 0; x < _cols; x++)
                {
                    _frames[index++] = new Rectangle(x * frameWidth, y * frameHeigh, frameWidth, frameHeigh);
                }
        }

        //...
        public void Draw(
            int indexFrame, 
            SpriteBatch spriteBatch, 
            Vector2 position, 
            Color color, 
            SpriteEffects _eff,
            float layerDepth)
        {
            spriteBatch.Draw(_texture, position, _frames[indexFrame %= _frames.Length], color, _rotation, _origin, _scale, _eff, layerDepth);
        }

        //...
        public void Draw(int index, SpriteBatch spriteBatch, Vector2 position, SpriteEffects _eff)
        {
            Draw(index, spriteBatch, position, Color.White, _eff, 0.0f);
        }

        //...
        public void Dispose()
        {
            _texture.Dispose();
        }
    }
}
