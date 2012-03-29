/*
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
    public class StartSence : GameSence
    {
        protected IntroSence _introSence;
        protected MenuSence _menuSence;


        #region Properties
        public MenuSence MenuSence
        {
            get { return _menuSence; }
        }
        #endregion

        public StartSence(Game game)
            : base(game)
        {
            _introSence = new IntroSence(this.Game);
            _menuSence = new MenuSence(this.Game);

            _introSence.Show();
            _menuSence.Hide();

            this._components.Add(_introSence);
            this._components.Add(_menuSence);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!_introSence.Visible)
                _menuSence.Show();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

    }
}
*/
