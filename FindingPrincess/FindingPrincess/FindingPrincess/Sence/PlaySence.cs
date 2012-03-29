using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;
using FindingPrincess.Framework;

namespace FindingPrincess.Sence
{
    public class PlaySence : GameSence
    {

    #region Attribute........
        FindingPrincess.Framework.CResourceManager _RM;
        FindingPrincess.Framework.CPlayer _Player;
        FindingPrincess.Framework.CMap _Map;
        FindingPrincess.Framework.CQuadtree _Quadtree;
        FindingPrincess.Framework.LGCamera _Camera;

        /************************************************************************/
        protected SpriteFont _font;
        protected const int MAX_MEM = 550000000;
        protected LoadingBar _loadingBar;
        public bool IsGameOver = false;
        /************************************************************************/
    #endregion

        public PlaySence(Game game)
            : base(game)
        {
            Show();
            IsGameOver = false;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _font = Game.Content.Load<SpriteFont>(@"Font\Motorwerk48");
            _oldMem = Environment.WorkingSet;
            _loadingBar = new LoadingBar((int)_oldMem, (int)MAX_MEM, (int)_oldMem, new Vector2(175, 175), Game.Content);

            Thread _loadingThread = new Thread(()
            =>
            {
                _RM = FindingPrincess.Framework.CResourceManager.getInstance();
                FindingPrincess.Framework.CResourceManager.getInstance().Init(Game.Content);
                _Map = new FindingPrincess.Framework.CMap("MAP9.png");
                _Quadtree = new CQuadtree(50, new Vector2(_Map.Width, _Map.Heigh));
                _Camera = new FindingPrincess.Framework.LGCamera(new Rectangle(0, 0, 800, 600));
                _Player = new FindingPrincess.Framework.CPlayer(IDObject.Player, 350, 200, 0.0f, 0.0f, 0.0f, 0.004f);
                _Player.Init(Game.Content);
                _Quadtree.AddObject(_Player);
                _Map.Init(Game.Content, ref _Quadtree);
            });
            _loadingThread.Start();
        }

        public override void Update(GameTime gameTime)
        {
            ////////////////////////////// LoadingBar ////////////////////////////////
            if (_Quadtree == null || ! _Quadtree.IsHavingPlayer)
            {
                _nowMem = Environment.WorkingSet;
                _loadingBar.Value = (int)_nowMem;
                return;
            }
            else
            {
                if(_Player != null && _Player.HP <= 0)
                {
                    if (_Player.States == Object_States.Die)
                    {
                        IsGameOver = true;
                        EventProcess();
                    }
                }
                ///////////////////////////////////Exit//////////////////////////////////
                if (CInput.KeyDown(Keys.Escape) || CInput.RightPressed)
                {
                    EventProcess();
                }

                //////////////////////////////////////////////////////////////////////////
                FindingPrincess.Framework.CInput.Update();

                _Camera.Update(_Player, new Vector2(800, 600), new Vector2(_Map.Width, _Map.Heigh));
                Global.Player_Positon.X = _Player.Position.X;
                _Quadtree.Update(_Camera.RectCamera, new Vector2(100, 100), gameTime);

                base.Update(gameTime);
            }
        }

        long _oldMem = Environment.WorkingSet;
        long _nowMem = Environment.WorkingSet;
        public override void Draw(GameTime gameTime)
        {
            /////////////////////////////Draw LoadingBar//////////////////////////////
            if (_Quadtree == null || ! _Quadtree.IsHavingPlayer)
            {
                GraphicsDevice.Clear(new Color(70, 70, 70));
                _spriteBatch.Begin();
                _loadingBar.Draw(_spriteBatch);

                if (_nowMem <= MAX_MEM)
                    _spriteBatch.DrawString(_font, (100 * (_nowMem - _oldMem) / (MAX_MEM - _oldMem)) + "%", new Vector2(350, 380), Color.Red);
                else
                    _spriteBatch.DrawString(_font, 100 + "%", new Vector2(350, 380), Color.Red);

                _spriteBatch.End();
                base.Draw(gameTime);
                return;
            }
            //////////////////////////////////////////////////////////////////////////
            if( ! IsGameOver)
            {
                GraphicsDevice.Clear(Color.SkyBlue);
                _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, _Camera.getTransformation(GraphicsDevice));

                _Quadtree.Draw(_spriteBatch, _Camera.RectCamera, new Vector2(100, 100));

                _spriteBatch.End();
            }
        }
    }
}
