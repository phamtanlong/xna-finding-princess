using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FindingPrincess.Object;

namespace FindingPrincess.Object
{
    public enum IDResource
    {
        HERO_MOVE,
        HERO_STAND,
        HERO_ATTACK1,
        HERO_ATTACK2,
        HERO_ATTACK3,
        HERO_ATTACK4,
        HERO_DIE,
        TER,
        TER_LEFT,
        TER_RIGHT
    }

    // Class can be called any where after Init it
    public class ResourceManager
    {
        static private bool _isCreated = false;

        static private Sprite _HeroMove;
        static private Sprite _HeroStand;
        static private Sprite _HeroAttack1;
        static private Sprite _HeroAttack2;
        static private Sprite _HeroAttack3;
        static private Sprite _HeroAttack4;
        static private Sprite _HeroDie;
        static private Sprite _Ter;
        static private Sprite _TerLeft;
        static private Sprite _TerRight;

        private ResourceManager()
        {

        }

        // Call Init() 1 time in Game 1 in LoadContent
        public static void Init(ContentManager _content)
        {
            if (_isCreated) 
                return;
            else 
                _isCreated = true;

            Texture2D tt = _content.Load<Texture2D>(@"Image\Hero\Hero_Move");
            _HeroMove = new Sprite(tt, 6, 1);

            tt = _content.Load<Texture2D>(@"Image\Hero\Hero_Stand");
            _HeroStand = new Sprite(tt, 4, 1);

            tt = _content.Load<Texture2D>(@"Image\Hero\Hero_Attack1");
            _HeroAttack1 = new Sprite(tt, 3, 4);

            tt = _content.Load<Texture2D>(@"Image\Hero\Hero_Attack222");
            _HeroAttack2 = new Sprite(tt, 5, 6);

            tt = _content.Load<Texture2D>(@"Image\Hero\Hero_Attack3");
            _HeroAttack3 = new Sprite(tt, 5, 4);

            tt = _content.Load<Texture2D>(@"Image\Hero\Hero_Attack4");
            _HeroAttack4 = new Sprite(tt, 5, 4);

            tt = _content.Load<Texture2D>(@"Image\Hero\Hero_Die");
            _HeroDie = new Sprite(tt, 5, 4);

            tt = _content.Load<Texture2D>(@"Image\Tile\Ter");
            _Ter = new Sprite(tt, 1, 1);

            tt = _content.Load<Texture2D>(@"Image\Tile\TerLeft");
            _TerLeft = new Sprite(tt, 1, 1);

            tt = _content.Load<Texture2D>(@"Image\Tile\TerRight");
            _TerRight = _TerRight = new Sprite(tt, 1, 1);
        }

        public static Sprite GetSprite(IDResource _ID)
        {
            switch (_ID)
            {
                case IDResource.HERO_MOVE:
                    return _HeroMove;
                case IDResource.HERO_STAND:
                    return _HeroStand;
                case IDResource.HERO_ATTACK1:
                    return _HeroAttack1;
                case IDResource.HERO_ATTACK2:
                    return _HeroAttack2;
                case IDResource.HERO_ATTACK3:
                    return _HeroAttack3;
                case IDResource.HERO_ATTACK4:
                    return _HeroAttack4;
                case IDResource.HERO_DIE:
                    return _HeroDie;
                case IDResource.TER:
                    return _Ter;
                case IDResource.TER_LEFT:
                    return _TerLeft;
                case IDResource.TER_RIGHT:
                    return _TerRight;
            }
            return null;
        }
    }
}
