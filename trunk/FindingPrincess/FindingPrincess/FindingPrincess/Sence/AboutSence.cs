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
    public class AboutSence : GameSence
    {
        protected Texture2D _bg;

        public AboutSence(Game game)
            : base(game)
        {
            Show();

            _bg = Game.Content.Load<Texture2D>(@"Image\BackGround\AboutBG");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (CInput.KeyPressed(Keys.Enter) || CInput.RightPressed)
            {
                EventProcess();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            this.Game.GraphicsDevice.Clear(Color.Pink);
            _spriteBatch.Begin();

            _spriteBatch.Draw(_bg, Vector2.Zero, Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        protected override void Dispose(bool disposing)
        {
            _bg.Dispose();
            base.Dispose(disposing);
        }

    }
}
