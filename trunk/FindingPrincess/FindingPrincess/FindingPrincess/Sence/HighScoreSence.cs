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
using System.Collections;


namespace FindingPrincess.Sence
{
    public class HighScoreSence : GameSence
    {
        const int MAX_PLAYER = 5;
        protected Texture2D _bg;
        protected SpriteFont _font;
        public static List<KeyValuePair<string, int>> _highScore;

        public HighScoreSence(Game game)
            : base(game)
        {
            Show();
            _highScore = new List<KeyValuePair<string, int>>();
            
            for (int i = 0; i < MAX_PLAYER; ++i)
            {
                _highScore.Add(new KeyValuePair<string, int>("Player " + i, Environment.TickCount));
            }

            _bg = Game.Content.Load<Texture2D>(@"Image\BackGround\Help");
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
            _spriteBatch.Draw(_bg, Vector2.Zero, Color.White);

            _spriteBatch.DrawString(_font, "HIGH SCORE", new Vector2(250, 50), Color.White);

            for (int i = 0; i < MAX_PLAYER; ++i )
            {
                _spriteBatch.DrawString(_font, _highScore[i].Key.PadRight(20, '.'), new Vector2(X, Y + i * _font.LineSpacing), Color.Black);
                _spriteBatch.DrawString(_font, "" + _highScore[i].Value, new Vector2(XX, Y + i * _font.LineSpacing), Color.White);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        protected override void Dispose(bool disposing)
        {
            _bg.Dispose();
            base.Dispose(disposing);
        }

        const int X = 80;
        const int Y = 200;
        const int XX = 550;
    }
}
