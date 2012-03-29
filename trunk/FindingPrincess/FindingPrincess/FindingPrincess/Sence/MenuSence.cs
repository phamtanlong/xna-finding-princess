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
    public enum EMainMenu
    {
        PLAY,
        HELP,
        ABOUT,
        OPTION,
        HIGH_SCORE,
        EXIT
    }

    public class MenuSence : MenuComponent
    {
        public MenuSence(Game game)
            : base(game, new Vector2(0, 0))
        {
            _menuItemsEN = new string[]
            {
                "Play",
                "Help",
                "About",
                "Option",
                "High Score",
                "Exit"
            };

            _menuItemsTV = new string[]
            {
                "Chơi",
                "Trợ giúp",
                "UIT-ER",
                "Cài đặt",
                "Bảng điểm",
                "Thoát"
            };

            MenuItems = _menuItemsEN;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Texture2D _bg = Game.Content.Load<Texture2D>(@"Image\BackGround\MenuBG");
            _spriteBatch.Begin();

            _spriteBatch.Draw(_bg, Vector2.Zero, Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
