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
    public class HelpSence : GameSence
    {
        const int SPACE = 20;
        protected SpriteFont _font;
        protected Texture2D _bg;
        protected Vector2 _textPosition;
        protected string[] _split;
        protected int line;
        protected string _helpStr;
        protected string _helpStrEN =
            "Use arrow keys to move the Hero.\n"
            + "Use keys Z, X, C to attack.\n"
            + "Try to kill all the monsters and get more skills.\n"
            + "You will have 1 more skill after 1 Map.\n"
            + "You must to pass all 4 Maps and get 4 skills which are needed to fight vs Bolobala.\n"
            + "At the beginning, you have 1 skill to fight.\n"
            + "Try to use your intelligent and fast.\n"
            + "Protect yourself, kill monsters, fight vs Bolobala and rescue your beautiful princess.\n";

        protected string _helpStrTV =
            "Dùng các phím mũi tên để di chuyển nhân vật\n"
            + "Dùng các phím Z, X, C để tấn công.\n"
            + "Cố gắng tiêu diệt thật nhiều quái thú và học các tuyệt chiêu.\n"
            + "Bạn sẽ nhận được 1 tuyệt chiêu sau mỗi 1 màn chơi.\n"
            + "Bạn phải trải qua 4 màn để có đủ khả năng đánh với Bolobala.\n"
            + "Mở đầu cuộc chơi, bạn có 1 tuyệt chiêu để đánh.\n"
            + "Hãy dùng trí thông minh và sự nhanh nhẹn để chinế thắng."
            + "Hãy tiêu diệt yêu quái, sống sót và cứu nàng công chúa xinh đẹp.\n";
        int ll = 60;
        public HelpSence(Game game)
            : base(game)
        {
            Show();
            _helpStr = _helpStrEN;
            _font = this.Game.Content.Load<SpriteFont>(@"Font\TNR14");
            Split(_helpStr, ll, ref _split);
            _bg = Game.Content.Load<Texture2D>(@"Image\BackGround\Help");

            _textPosition = new Vector2(SPACE, 6 * SPACE);
        }

        public override void Update(GameTime gameTime)
        {
            if (OptionSence.OptionCheck[(int)EOption.LANGUAGE])
            {
                Split(_helpStrTV, ll, ref _split);
            }
            else
            {
                Split(_helpStrEN, ll, ref _split);
            }

            if (CInput.KeyPressed(Keys.Enter) || (CInput.RightPressed))
                EventProcess();
        }

        public override void Draw(GameTime gameTime)
        {
            this.Game.GraphicsDevice.Clear(Color.Pink);
            _spriteBatch.Begin();


            _spriteBatch.Draw(_bg, Vector2.Zero, Color.White);
            for (int i = 0; i < _split.Length; ++i )
            {
                if (_split[i] == null)
                    continue;

                int x = (Game.Window.ClientBounds.Width - (int)_font.MeasureString(_split[i]).Length()) / 2;
                //_spriteBatch.DrawString(_font, _split[i], new Vector2(x-1, _textPosition.Y + i * _font.LineSpacing - 1), Color.Yellow);
                _spriteBatch.DrawString(_font, _split[i], new Vector2(x, _textPosition.Y + i * _font.LineSpacing), Color.Black);
                _spriteBatch.DrawString(_font, _split[i], new Vector2(x - 1, _textPosition.Y + i * _font.LineSpacing - 1), Color.White);
            }
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void Split(string srcString, int lineLenght, ref string[] split)
        {
            const int MAX = 10;
            split = new string[srcString.Length / lineLenght + MAX];
            int start = 0;
            int end = 0;
            int i = 0;

            while (true)
            {
                end = start + lineLenght;
                if (end > srcString.Length - 1)
                    end = srcString.Length - 1;

                if (end < srcString.Length - 1)
                    while (srcString.ElementAt(end) != ' ' && srcString.ElementAt(end) != '\n')
                    {
                        end--;
                        if (end < start) break;
                    }
                if (end < start) break;

                split[i] = srcString.Substring(start, end - start);

                if (split[i].Contains('\n'))
                {
                    string s = split[i];
                    int _pos = s.IndexOf('\n');
                    split[i] = s.Substring(0, _pos);
                    end = start + _pos;
                }

                start = end + 1;
                i++;
                if (i >= split.Length) break;
            }
        }

        protected override void Dispose(bool disposing)
        {
            _bg.Dispose();
            base.Dispose(disposing);
        }

    }
}
