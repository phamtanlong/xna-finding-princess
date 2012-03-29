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
    public enum EMenuPause
    {
        CONTINUE,
        BACK2MENU,
        OPTION,
        EXIT
    }

    public class PauseSence : MenuSence
    {
        public PauseSence(Game game)
            : base(game)
        {
            _menuItemsEN = new string[]
            {
                "Continue",
                "Back2Menu",
                "Option",
                "Exit"
            };
            _menuItemsTV = new string[]
            {
                "Tiếp tục",
                "Ra menu",
                "Tùy chọn",
                "Thoát"
            };
            MenuItems = _menuItemsEN;
        }
    }

    
}
