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
    public enum EYesNo
    {
        YES,
        NO
    }

    public class YesNoSence : MenuComponent
    {
        protected Texture2D _YesNoBG;
        public YesNoSence(Game game)
            : base(game, new Vector2(0, 0))
        {
            _YesNoBG = Game.Content.Load<Texture2D>(@"Image\BackGround\MenuBG");
            _menuItemsEN = new string[]
            {
                "Yes",
                "No"
            };

            _menuItemsTV = new string[]
            {
                "Có",
                "Không"
            };

            MenuItems = _menuItemsEN;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (CInput.RightPressed)
                EventProcess();
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(_YesNoBG, Vector2.Zero, Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
