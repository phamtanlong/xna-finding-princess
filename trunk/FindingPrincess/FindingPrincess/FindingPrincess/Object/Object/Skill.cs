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

namespace FindingPrincess.Object
{
    public class Skill : Animation
    {
        // Đây là độ lệch của Sprite vẽ Skill so với Sprite vẽ Move và Stand, khi tất cả cùng nhìn hướng sang trái
        protected Vector2   _deltaPositionLeft;
        protected Vector2   _deltaPositionRight;
        protected bool      _enableUpdate = true;
        protected Keys      _actionKey;

#region  Propertiess..........
        public bool EnableUpdate
        {
            get { return _enableUpdate; }
            set { _enableUpdate = value; }
        }

        public Vector2 DeltaPostionLeft
        {
            get { return _deltaPositionLeft; }
            set { _deltaPositionLeft = value; }
        }

        public Vector2 DeltaPostionRight
        {
            get { return _deltaPositionRight; }
            set { _deltaPositionRight = value; }
        }

        public Keys ActionKey
        {
            get { return _actionKey; }
            set { _actionKey = value; }
        }


#endregion

        public Skill(IDResource _id, int _mil, Vector2 _dPosL, Vector2 _dPosR, Keys _acKey)
            : base(_id, _mil, IDirect.RIGHT)
        {
            _deltaPositionLeft = _dPosL;
            _deltaPositionRight = _dPosR;
            _actionKey = _acKey;
        }

        public override void  Update(GameTime gametime)
        {
            if (!_enableUpdate) return;

            if (_indexFrame == _sprite.Frames.Length - 1)
            {
                _enableUpdate = false;
                _indexFrame = 0; /////// Defficult to understand ///////
            }

            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 _position)
        {
            if(DirectFace == IDirect.LEFT)
                base.Draw(spriteBatch, _position - _deltaPositionLeft);
            else
                base.Draw(spriteBatch, _position - _deltaPositionRight);
        }

        public bool CheckKey()
        {
            if (CInput.KeyPressed(_actionKey))
            {
                _enableUpdate = true;
                return true;
            }
            return false;
        }


    }
}
