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
    enum IDEffect
    {
        Effect_Boss_Attack1_Hit,
        Effect_Boss_Attack2_Hit,
        Effect_Boss_Attack3_Hit,
        Effect_Boss_Attack4_Hit,

        Effect_Master_Attack1_Hit,
        Effect_Master_Attack2_Hit,
        Effect_Master_Attack4_Hit,

        Effect_Hero_Attack1_Ball,
        Effect_Hero_Attack3_Ball,

        Effect_Hero_Attack4_Ball1_Lv1,
        Effect_Hero_Attack4_Ball2_Lv1,
        Effect_Hero_Attack4_Ball3_Lv1,
        Effect_Hero_Attack4_Ball4_Lv1,
        Effect_Hero_Attack4_Ball5_Lv1,
        Effect_Hero_Attack4_Ball6_Lv1,

        Effect_Hero_Attack4_Ball_Lv3,
        Effect_Hero_Attack4_Ball1_Lv3,
        Effect_Hero_Attack4_Ball2_Lv3,
        Effect_Hero_Attack4_Ball3_Lv3,
        Effect_Hero_Attack4_Ball4_Lv3,
        Effect_Hero_Attack4_Ball5_Lv3,
        Effect_Hero_Attack4_Ball6_Lv3,

        Effect_Hero_Attack1_Hit,
        Effect_Hero_Attack2_Hit,
        Effect_Hero_Attack3_Hit,
        Effect_Hero_Attack5_Effect1,
        Effect_Hero_Attack5_Effect2,
        Effect_Hero_Attack5_Effect3,
        Effect_Hero_Attack5_Effect4,
        Effect_Hero_Attack5_Effect5,
        Effect_Hero_Attack5_Effect6,
        Effect_Hero_Attack5_Effect7,
        Effect_Hero_Attack2_Ball
    }
    class CEffect
    {
        protected IDEffect m_ID;
        protected CSprite m_CurSprite;
        protected Vector2 m_Position;
        #region Get and Set
        public IDEffect ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
        public CSprite CurSprite
        {
            get { return m_CurSprite; }
            set { m_CurSprite = value; }
        }
        public Vector2 Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }
        #endregion
        public CEffect(IDEffect _ID)
        {
            m_ID = _ID;
            m_CurSprite = null;
            m_Position = Vector2.Zero;
        }
        public CEffect(CEffect _Copy)
        {
            m_ID = _Copy.m_ID;
            m_CurSprite = new CSprite(_Copy.m_CurSprite);
            m_Position = _Copy.m_Position;
        }
        public virtual void Init(IDResource _ID)
        {
            m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(_ID));
        }
        public virtual void Init(IDResource _ID, Vector2 _Position)
        {
            m_CurSprite = new CSprite(CResourceManager.getInstance().getSprite(_ID));
            m_Position = _Position;
        }
        public virtual void Update(GameTime _GameTime)
        {
            m_CurSprite.Update(_GameTime);
        }

        public virtual void Draw(SpriteBatch _SpriteBatch)
        {
            m_CurSprite.Position = new Vector2(m_Position.X, m_Position.Y);
            m_CurSprite.Draw(_SpriteBatch);
        }
        public Rectangle Bound
        {
            get
            {
                Rectangle _Rect;
                _Rect.X = (int)m_CurSprite.Position.X;
                _Rect.Y = (int)m_CurSprite.Position.Y;
                _Rect.Width = (int)((m_CurSprite.Width * m_CurSprite.Scale));
                _Rect.Height = (int)((m_CurSprite.Height * m_CurSprite.Scale));
                return _Rect;
            }
        }
    }
}
