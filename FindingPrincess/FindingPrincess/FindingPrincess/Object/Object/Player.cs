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
using FindingPrincess.Sence;

namespace FindingPrincess.Object
{
    public class Player : MovableObject
    {
        #region  Const............
        static Vector2 _PLAYER_ACCEL = new Vector2(0.2f, 0.005f);
        
        const int _PLAYER_MIL = 150;
        const int _DELTA = 10;
        const float _MINIMUM = 0.05f;
        #endregion

        protected List<Skill> _skillList;

        protected Animation _skinMove;
        protected Animation _skinStand;

        //////////////////// Thêm

        protected SpriteFont _font;

        ////////////////////

        protected Skill _activeSkill;
        protected bool _isAttacking;
        protected bool _isJumping;

#region Properties.............
        public bool IsAttacking
        {
            get { return _isAttacking; }
            set { _isAttacking = value; }
        }

        const int _delta = 20;
        public override Rectangle Bound
        {
            get
            {
                Rectangle r;
                r.X = base.Bound.X + _delta;
                r.Y = base.Bound.Y;
                r.Width = base.Bound.Width - 2 * _delta;
                r.Height = base.Bound.Height;

                return r;
            }
        }
#endregion
        

        public Player(Vector2 _pos, Game game) ////////////////////////////////////////////////////////////////////////// Thêm cái Game
            : base(_pos, Vector2.Zero, _PLAYER_ACCEL)
        {
            _skillList = new List<Skill>();
            _isAttacking = false;
            _isJumping = false;

            _skinMove = new Animation(IDResource.HERO_MOVE, _PLAYER_MIL, IDirect.RIGHT);
            _skinStand = new Animation(IDResource.HERO_STAND, _PLAYER_MIL, IDirect.RIGHT);

            _curAnimation = _skinStand;
            _font = game.Content.Load<SpriteFont>(@"Font\Cambria16");
        }

        public override void Update(GameTime gametime)
        {
            UpdateSkill(gametime);

            if (!_isAttacking)
            {
                if (CInput.KeyPressed(Keys.Up) && ! _isJumping)
                {
                    JumpUp();
                    _isJumping = true;
                }

                if (CInput.KeyDown(Keys.Left))
                {
                    MoveLeft();
                }
                else if (CInput.KeyDown(Keys.Right))
                {
                    MoveRight();
                }
            }
            
            UpdateSkin();

            base.Update(gametime);
        }

        public void UpdateSkin()
        {
            IDirect _curDir = _curAnimation.DirectFace;

            // Check when Hero drop
            if (Math.Abs(_velocity.Y) > _MINIMUM)
                _isJumping = true;

            if (_isJumping)
            {
                _curAnimation = new Animation(IDResource.HERO_MOVE, _PLAYER_MIL, _curDir);
            }
            
            if(Math.Abs(Velocity.X) >= _MINIMUM)
            {
                _skinMove.DirectFace = _curDir;
                _curAnimation = _skinMove;
            }
            else
            {
                _skinStand.DirectFace = _curDir;
                _curAnimation = _skinStand;
            }
        }

        public override void UpdateMovement(GameTime gametime)
        {
            _oldPosition = _position;

            _position.X += _velocity.X * gametime.ElapsedGameTime.Milliseconds;
            _position.Y += _velocity.Y * gametime.ElapsedGameTime.Milliseconds;

            ////////////////////////Tính toán vận tốc theo thời gian//////////////////////////

            if(! _isJumping)
                _velocity.X *= (1 - _accel.X);
            _velocity.Y += _accel.Y * gametime.ElapsedGameTime.Milliseconds;

            ///////////////////////// Đoạn này để giới hạn trong màn hình thôi///////////
            if (_position.X < 0) _position.X = 0;
            if (_position.X > 800) _position.X = 800;
            if (_position.Y > 600-80) _position.Y = 600-80;
        }

        public override void UpdateCollision(GameObject _Object, ECollision _Dir)
        {
            if (_Dir == ECollision.BOTTOM)
            {
                Console.WriteLine("BOTTOM");
                _isJumping = false;
                _velocity = new Vector2(_velocity.X, 0.0f);
                _position = new Vector2(Position.X, _Object.Position.Y - this.Bound.Height + 1);
            }
            if (_Dir == ECollision.TOP)
            {
                Console.WriteLine("TOP");
                Position = new Vector2(this.Position.X, _Object.Position.Y + _Object.Bound.Height);
                Velocity = new Vector2(Velocity.X, 0.2f);
            }
            if (_Dir == ECollision.LEFT)
            {
                Console.WriteLine("LEFT");
                Velocity = new Vector2(0.0f, Velocity.Y);
                Position = new Vector2(_Object.Position.X + _Object.Bound.Width + 1 - _delta, Position.Y);
            }
            if (_Dir == ECollision.RIGHT)
            {
                Console.WriteLine("RIGHT");
                Velocity = new Vector2(0.0f, Velocity.Y);
                Position = new Vector2(_Object.Position.X - this.Bound.Width - 1 - _delta, Position.Y);
            }
            //base.UpdateCollision(_otherObject);
        }

        public override void Draw(SpriteBatch sB)
        {
            
            if (_activeSkill != null && _activeSkill.EnableUpdate)
            {
                _activeSkill.Draw(sB, _position);
            }
            else
                base.Draw(sB);

            sB.DrawString(_font, OptionSence._player.ToLower(), this.Position - new Vector2(20, 20), Color.Red);
        }

        private void UpdateSkill(GameTime gametime)
        {
            if (_activeSkill == null || _activeSkill.EnableUpdate == false)
                for (int i = 0; i < _skillList.Count; ++i )
                {
                    if (_skillList[i].CheckKey())
                    {
                        _activeSkill = _skillList[i];
                        _activeSkill.EnableUpdate = true;
                        return;
                    }
                }

            if (_activeSkill != null && _activeSkill.EnableUpdate)
            {
                _activeSkill.DirectFace = _curAnimation.DirectFace;
                _activeSkill.Update(gametime);
                _isAttacking = true;
            }
            else 
                _isAttacking = false;
        }

        public void AddSkill(Skill _skill)
        {
            _skillList.Add(_skill);
        }
    }
}
