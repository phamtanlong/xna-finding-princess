using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FindingPrincess.Framework
{
    class CBarrel : CObject
    {
        public CBarrel(IDObject _ID, float _PosX, float _PosY)
            : base(_ID, _PosX, _PosY)
        {

        }
        public override void Init(ContentManager _CM)
        {
            m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Barrel));
            //CResourceManager.getInstance().Init(_CM);
            base.Init(_CM);
        }
        public override void UpdateCollision(CObject _Object)
        {
            base.UpdateCollision(_Object);
        }
        public override void Update(GameTime _GameTime)
        {
            base.Update(_GameTime);
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
        }
        public override Rectangle getBoundingBox()
        {
            Rectangle _Rect;
            _Rect.X = (int)Position.X+25;
            _Rect.Y = (int)Position.Y;
            _Rect.Width = (int)((Size.X * m_CurSprite.Scale-25-25));
            _Rect.Height = (int)((Size.Y * m_CurSprite.Scale));
            return _Rect;
        }
    }
}
