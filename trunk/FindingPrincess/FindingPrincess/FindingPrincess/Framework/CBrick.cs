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
    class CBrick:CObject
    {
        public CBrick(IDObject _ID, float _PosX, float _PosY): base(_ID, _PosX, _PosY)
        {

        }
        public override void Init(ContentManager _CM)
        {
            m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(IDResource.Brick));
            base.Init(_CM);
        }
        public override void UpdateCollision(ref CObject _Object)
        {
            base.UpdateCollision(ref _Object);
        }
        public override void Update(GameTime _GameTime)
        {
            base.Update(_GameTime);
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            base.Draw(_spriteBatch);
        }
    }
}
