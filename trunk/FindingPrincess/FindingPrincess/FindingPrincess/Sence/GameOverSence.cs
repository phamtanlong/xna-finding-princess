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

namespace FindingPrincess.Sence
{
    public class GameOverSence : GameSence
    {
        const int MAX_PLAYER = 5;
        protected SpriteFont _font;

        public GameOverSence(Game game)
            : base(game)
        {
            _font = Game.Content.Load<SpriteFont>(@"Font\TNR48");
        }

        public override void Update(GameTime gameTime)
        {
            if (CInput.RightPressed || CInput.KeyPressed(Keys.Enter))
                EventProcess();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.DrawString(_font, "GAME OVER", new Vector2(250, 300), Color.White);

            _spriteBatch.End();
        }
    }
}
