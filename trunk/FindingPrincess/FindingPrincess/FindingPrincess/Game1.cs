using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using FindingPrincess.Sence;
using FindingPrincess.Framework;

namespace FindingPrincess
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Attribute....
        protected GraphicsDeviceManager _graphics;
        protected SpriteBatch _spriteBatch;

        protected IntroSence _introSence;
        protected MenuSence _menuSence;
        protected HelpSence _helpSence;
        protected PlaySence _playSence;
        protected PauseSence _pauseSence;
        protected AboutSence _aboutSence;
        protected OptionSence _optionSence;
        protected HighScoreSence _highScoreSence;
        protected YesNoSence _yesnoSence;
        protected GameOverSence _gameOverSence;

        protected GameSence _activeSence;
        protected GameSence _lastSence;

        protected Texture2D _cursor;
        protected Texture2D _cursorSelect;
        protected Texture2D _activeCursor;
        protected SpriteFont _font;
        #endregion

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _introSence = new IntroSence(this);
            _menuSence = new MenuSence(this);
            _playSence = new PlaySence(this);
            _helpSence = new HelpSence(this);
            _pauseSence = new PauseSence(this);
            _aboutSence = new AboutSence(this);
            _optionSence = new OptionSence(this);
            _highScoreSence = new HighScoreSence(this);
            _yesnoSence = new YesNoSence(this);
            _gameOverSence = new GameOverSence(this);

            _introSence.AddHandler(IntroSenceHandler);
            _menuSence.AddHandler(MenuSenceHandler);
            _playSence.AddHandler(PlaySenceHandler);
            _helpSence.AddHandler(HelpSenceHandler);
            _pauseSence.AddHandler(PauseSenceHandler);
            _aboutSence.AddHandler(AboutSenceHandler);
            _optionSence.AddHandler(OptionSenceHandler);
            _highScoreSence.AddHandler(HighScoreSenceHandler);
            _yesnoSence.AddHandler(YesNoSenceHandler);
            _gameOverSence.AddHandler(GameOverSenceHandler);

            ////////////////////////////// Use to debug /////////////////////////////
            ChangeSence(_introSence);
            _cursor = Content.Load<Texture2D>(@"Image\Cursor");
            _cursorSelect = Content.Load<Texture2D>(@"Image\CursorSelect");
            _activeCursor = _cursor;
            _font = Content.Load<SpriteFont>(@"Font\UVNHoaKy100");
        }

        bool _isUpdate = true;
        protected override void OnActivated(object sender, EventArgs args)
        {
            _isUpdate = true;
            base.OnActivated(sender, args);
        }

        protected override void OnDeactivated(object sender, EventArgs args)
        {
            _isUpdate = false;
            base.OnDeactivated(sender, args);
        }

        protected override void Update(GameTime gameTime)
        {
            if (!_isUpdate) return;
            CInput.Update();

            if (CInput._nowMouseState.LeftButton != Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                _activeCursor = _cursor;
            else
                _activeCursor = _cursorSelect;
            base.Update(gameTime);
        }

        public void ChangeSence(GameSence _newSence)
        {
            if (Components.Contains(_activeSence))
                Components.Remove(_activeSence);
            _activeSence = _newSence;
            this.Components.Add(_activeSence);
        }

        #region Handlerss...

        protected void IntroSenceHandler()
        {
            _menuSence = new MenuSence(this);
            _menuSence.AddHandler(MenuSenceHandler);
            ChangeSence(_menuSence);
        }

        protected void MenuSenceHandler()
        {
            MenuSence _MnSence = (MenuSence)_activeSence;

            switch ((EMainMenu)_MnSence.SelectedMenu)
            {
                case EMainMenu.PLAY:
                    _playSence = new PlaySence(this);
                    _playSence.AddHandler(PlaySenceHandler);
                    ChangeSence(_playSence);
                    break;

                case EMainMenu.HELP:
                    ChangeSence(_helpSence);
                    break;

                case EMainMenu.ABOUT:
                    ChangeSence(_aboutSence);
                    break;

                case EMainMenu.OPTION:
                    _lastSence = _activeSence;
                    ChangeSence(_optionSence);
                    break;

                case EMainMenu.HIGH_SCORE:
                    ChangeSence(_highScoreSence);
                    break;

                case EMainMenu.EXIT:
                    _lastSence = _activeSence;
                    ChangeSence(_yesnoSence);
                    break;

                default: break;
            }
        }

        protected void PlaySenceHandler()
        {
            _lastSence = _activeSence;
            if (!_playSence.IsGameOver)
                ChangeSence(_pauseSence);
            else
                ChangeSence(_gameOverSence);
        }

        protected void PauseSenceHandler()
        {
            PauseSence _PSence = (PauseSence)_activeSence;

            switch ((EMenuPause)_PSence.SelectedMenu)
            {
                case EMenuPause.CONTINUE:
                    ChangeSence(_playSence);
                    break;

                case EMenuPause.BACK2MENU:
                    ChangeSence(_menuSence);
                    break;

                case EMenuPause.OPTION:
                    _lastSence = _activeSence;
                    ChangeSence(_optionSence);
                    break;
                case EMenuPause.EXIT:
                    _lastSence = _activeSence;
                    ChangeSence(_yesnoSence);
                    break;;
            }
        }

        protected void HelpSenceHandler()
        {
            ChangeSence(_menuSence);
        }

        protected void AboutSenceHandler()
        {
            ChangeSence(_menuSence);
        }

        protected void OptionSenceHandler()
        {
            bool[] check = OptionSence.OptionCheck;
            if(check[(int)EOption.FULL_SCREEN] != _graphics.IsFullScreen)
            {
                _graphics.IsFullScreen = check[(int)EOption.FULL_SCREEN];
                _graphics.ApplyChanges();
            }
            ChangeSence(_lastSence);
        }

        protected void HighScoreSenceHandler()
        {
            ChangeSence(_menuSence);
        }

        protected void YesNoSenceHandler()
        {
            YesNoSence _sence = (YesNoSence)_activeSence;
            switch ((EYesNo)_sence.SelectedMenu)
            {
                case EYesNo.YES:
                    Exit();
                    break;
                case EYesNo.NO:
                    ChangeSence(_lastSence);
                    break;
            }
        }

        protected void GameOverSenceHandler()
        {
            ChangeSence(_menuSence);
        }

        #endregion

        protected override void Draw(GameTime gameTime)
        {
            if (!_isUpdate)
            {
                _spriteBatch.Begin();
                _spriteBatch.DrawString(_font, "Pause!!!", new Vector2(250, 200), Color.CornflowerBlue);
                _spriteBatch.DrawString(_font, System.DateTime.Now.Hour 
                    + ":" + System.DateTime.Now.Minute 
                    + ":" + System.DateTime.Now.Second, new Vector2(280, 350), Color.DarkGray);
                _spriteBatch.End();
                return;
            }
            _spriteBatch.Begin();
            base.Draw(gameTime);
            _spriteBatch.Draw(_activeCursor, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
            _spriteBatch.End();
        }
    }
}
