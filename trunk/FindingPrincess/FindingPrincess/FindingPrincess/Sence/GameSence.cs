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
    public abstract class GameSence : DrawableGameComponent
    {
        #region const......
        public const int MAX_HANDLER = 10;
        #endregion

        protected SpriteBatch _spriteBatch;
        protected List<GameComponent> _components;
        
        public GameSence(Game game)
            : base(game)
        {
            Show();
            _spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
            _components = new List<GameComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < _components.Count; ++i )
            {
                if (_components[i].Enabled)
                {
                    _components[i].Update(gameTime);
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            for (int i = 0; i < _components.Count; ++i )
            {
                if(_components[i] is DrawableGameComponent)
                if (((DrawableGameComponent)_components[i]).Visible == true)
                    ((DrawableGameComponent)_components[i]).Draw(gameTime);
            }
        }

        public delegate void Handler();
        private List<Handler> ArrayHandler = new List<Handler>(MAX_HANDLER);
        
        //Called when have an event
        protected virtual void EventProcess()
        {
            foreach (Handler _handler in ArrayHandler)
            {
                _handler();
            }
        }

        public virtual void AddHandler(Handler _handler)
        {
            if(ArrayHandler.Count < MAX_HANDLER)
                ArrayHandler.Add(_handler);
        }

        public virtual void Hide()
        {
            Visible = false;
            Enabled = false;
        }

        public virtual void Show()
        {
            Enabled = true;
            Visible = true;
        }

        protected override void Dispose(bool disposing)
        {
            _spriteBatch.Dispose();
            foreach (GameComponent _gc in _components)
            {
                _gc.Dispose();
            }
            
            base.Dispose(disposing);
        }
    }
}
