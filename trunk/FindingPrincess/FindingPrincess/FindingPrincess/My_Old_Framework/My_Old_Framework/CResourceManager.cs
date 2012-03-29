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

namespace FindingPrincess.Framework
{
    public enum IDResource
    {
        Player_Move,
        Player_Stand,
        Player_Jump,

        Player_Attack1,
        Player_Attack2,
        Player_Attack3,
        Player_Attack4,
        Player_Attack5,

        Monster_SnowMan_Move,
        Monster_SnowMan_Attack,
        Monster_SnowMan_Hit,
        Monster_SnowMan_Die,
        
        Effect_Hero_Attack1_Ball,
        Effect_Attack2,
        Effect_Hero_Attack3_Ball,
        Effect_Attack4,

        Effect_Hero_Attack4_Ball1_Lv1,
        Effect_Hero_Attack4_Ball2_Lv1,
        Effect_Hero_Attack4_Ball3_Lv1,
        Effect_Hero_Attack4_Ball4_Lv1,
        Effect_Hero_Attack4_Ball5_Lv1,
        Effect_Hero_Attack4_Ball6_Lv1,

        Effect_Hero_Attack4_Ball_Lv3,
        Effect_Hero_Attack4_Ball1_Lv3,
        Effect_Hero_Attack4_Ball2_Lv3,
        Effect_Hero_Attack4_Ball3_Lv3,
        Effect_Hero_Attack4_Ball4_Lv3,
        Effect_Hero_Attack4_Ball5_Lv3,
        Effect_Hero_Attack4_Ball6_Lv3,
        Effect_Hero_Attack4_Ball7_Lv3,
        Effect_Hero_Attack4_Ball8_Lv3,

        Effect_Hero_Attack1_Hit,
        Effect_Hero_Attack3_Hit,

        Effect_Hero_Attack5_Effect1,
        Effect_Hero_Attack5_Effect2,
        Effect_Hero_Attack5_Effect3,
        Effect_Hero_Attack5_Effect4,
        Effect_Hero_Attack5_Effect5,
        Effect_Hero_Attack5_Effect6,
        Effect_Hero_Attack5_Effect7,
        Brick,
        BaseBrick,
        Barrel,
    }
    class CResourceManager
    {
        private CSprite m_PlayerStand;
        private CSprite m_PlayerMove;
        private CSprite m_PlayerJump;

        private CSprite m_Monster_SnowManMove;
        private CSprite m_Monster_SnowManAttack;
        private CSprite m_Monster_SnowManHit;
        private CSprite m_Monster_SnowManDie;
        private CSprite m_PlayerAttack1;
        private CSprite m_PlayerAttack2;
        private CSprite m_PlayerAttack3;
        private CSprite m_PlayerAttack4;
        private CSprite m_PlayerAttack5;

        private CSprite m_EffectHeroAttack1_Ball;
        private CSprite m_EffectHeroAttack3_Ball;

        private CSprite m_EffectHeroAttack4_Ball1_Lv1;
        private CSprite m_EffectHeroAttack4_Ball2_Lv1;
        private CSprite m_EffectHeroAttack4_Ball3_Lv1;
        private CSprite m_EffectHeroAttack4_Ball4_Lv1;
        private CSprite m_EffectHeroAttack4_Ball5_Lv1;
        private CSprite m_EffectHeroAttack4_Ball6_Lv1;

        private CSprite m_EffectHeroAttack4_Ball_Lv3;
        private CSprite m_EffectHeroAttack4_Ball1_Lv3;
        private CSprite m_EffectHeroAttack4_Ball2_Lv3;
        private CSprite m_EffectHeroAttack4_Ball3_Lv3;
        private CSprite m_EffectHeroAttack4_Ball4_Lv3;
        private CSprite m_EffectHeroAttack4_Ball5_Lv3;
        private CSprite m_EffectHeroAttack4_Ball6_Lv3;

        private CSprite m_EffectHeroAttack5_Effect1;
        private CSprite m_EffectHeroAttack5_Effect2;
        private CSprite m_EffectHeroAttack5_Effect3;
        private CSprite m_EffectHeroAttack5_Effect4;
        private CSprite m_EffectHeroAttack5_Effect5;
        private CSprite m_EffectHeroAttack5_Effect6;
        private CSprite m_EffectHeroAttack5_Effect7;

        private CSprite m_EffectHeroAttack1_Hit;
        private CSprite m_EffectHeroAttack3_Hit;

        private CSprite m_Brick;
        private CSprite m_BaseBrick;
        private CSprite m_Barrel;
        private static CResourceManager m_ResourceManager;
        private CResourceManager()
        {
            m_PlayerMove = new CSprite(IDResource.Player_Move, 6, 1, 79, 103, 6, 0.1f);
            m_PlayerStand = new CSprite(IDResource.Player_Stand, 4, 1, 79, 98, 4, 0.1f);
            m_PlayerJump = new CSprite(IDResource.Player_Jump, 6, 1, 79, 103, 6, 0.1f);

            m_BaseBrick = new CSprite(IDResource.BaseBrick, 1, 1, 500, 50, 1, 0.95f);
            m_Brick = new CSprite(IDResource.Brick, 1, 1, 50, 50, 1, 1.0f);
            m_Barrel = new CSprite(IDResource.Barrel, 1, 1, 170, 174, 1, 1.0f);
            
            m_Monster_SnowManMove = new CSprite(IDResource.Monster_SnowMan_Move,4,1,121,111,4,0.9f);
            m_Monster_SnowManAttack = new CSprite(IDResource.Monster_SnowMan_Attack,9,1,224,191,9,0.9f);
            m_Monster_SnowManHit = new CSprite(IDResource.Monster_SnowMan_Hit,1,1,105,117,1,0.9f);
            m_Monster_SnowManDie = new CSprite(IDResource.Monster_SnowMan_Die, 7, 1, 190, 108, 7, 0.9f);

            m_PlayerAttack1 = new CSprite(IDResource.Player_Attack1, 3, 6, (int)2280/4, 255, 16, 0.1f);
            m_PlayerAttack2 = new CSprite(IDResource.Player_Attack2, 5, 3, 1470/5, (int)492 / 3, 15, 0.1f);
            m_PlayerAttack3 = new CSprite(IDResource.Player_Attack3, 5, 4, 274, 231, 20, 0.1f);
            m_PlayerAttack4 = new CSprite(IDResource.Player_Attack4, 5, 4, 212, 251, 19, 0.1f);
            m_PlayerAttack5 = new CSprite(IDResource.Player_Attack5, 6, 1, 140, 133, 6, 0.1f);
            
            m_EffectHeroAttack1_Ball = new CSprite(IDResource.Effect_Hero_Attack1_Ball, 5, 1, 415, 143, 5, 0.1f);
            m_EffectHeroAttack3_Ball = new CSprite(IDResource.Effect_Hero_Attack3_Ball, 7, 1, 97, 150, 7, 0.1f);

            m_EffectHeroAttack4_Ball1_Lv1 = new CSprite(IDResource.Effect_Hero_Attack4_Ball1_Lv1, 6, 3, 136, 389, 18, 0.2f);
            m_EffectHeroAttack4_Ball2_Lv1 = new CSprite(IDResource.Effect_Hero_Attack4_Ball2_Lv1, 6, 3, 237, 414, 18, 0.2f);
            m_EffectHeroAttack4_Ball3_Lv1 = new CSprite(IDResource.Effect_Hero_Attack4_Ball3_Lv1, 6, 3, 256, 417, 18, 0.2f);
            m_EffectHeroAttack4_Ball4_Lv1 = new CSprite(IDResource.Effect_Hero_Attack4_Ball4_Lv1, 4, 4, 136, 298, 16, 0.2f);
            m_EffectHeroAttack4_Ball5_Lv1 = new CSprite(IDResource.Effect_Hero_Attack4_Ball5_Lv1, 4, 4, 256, 324, 16, 0.2f);
            m_EffectHeroAttack4_Ball6_Lv1 = new CSprite(IDResource.Effect_Hero_Attack4_Ball6_Lv1, 3, 5, 256, 239, 15, 0.2f);

            m_EffectHeroAttack4_Ball_Lv3 = new CSprite(IDResource.Effect_Hero_Attack4_Ball_Lv3, 10, 2, 187, 723, 18, 0.01f);
            m_EffectHeroAttack4_Ball1_Lv3 = new CSprite(IDResource.Effect_Hero_Attack4_Ball1_Lv3, 4, 4, 289, 201, 16, 0.96f);
            m_EffectHeroAttack4_Ball2_Lv3 = new CSprite(IDResource.Effect_Hero_Attack4_Ball2_Lv3, 4, 4, 205, 210, 16, 0.96f);
            m_EffectHeroAttack4_Ball3_Lv3 = new CSprite(IDResource.Effect_Hero_Attack4_Ball3_Lv3, 4, 4, 267, 222, 16, 0.96f);
            m_EffectHeroAttack4_Ball4_Lv3 = new CSprite(IDResource.Effect_Hero_Attack4_Ball4_Lv3, 4, 4, 301, 229, 15, 0.96f);
            m_EffectHeroAttack4_Ball5_Lv3 = new CSprite(IDResource.Effect_Hero_Attack4_Ball5_Lv3, 4, 4, 274, 338, 16, 0.96f);
            m_EffectHeroAttack4_Ball6_Lv3 = new CSprite(IDResource.Effect_Hero_Attack4_Ball6_Lv3, 6, 3, 331, 349, 18, 0.96f);



            m_EffectHeroAttack5_Effect1 = new CSprite(IDResource.Effect_Hero_Attack5_Effect1, 6, 4, 216, 240, 24, 0.01f);
            m_EffectHeroAttack5_Effect2 = new CSprite(IDResource.Effect_Hero_Attack5_Effect2, 6, 5, 174, 174, 30, 0.01f);
            m_EffectHeroAttack5_Effect3 = new CSprite(IDResource.Effect_Hero_Attack5_Effect3, 5, 3, 220, 249, 13, 0.01f);
            m_EffectHeroAttack5_Effect4 = new CSprite(IDResource.Effect_Hero_Attack5_Effect4, 7, 3, 180, 294, 21, 0.01f);
            m_EffectHeroAttack5_Effect5 = new CSprite(IDResource.Effect_Hero_Attack5_Effect5, 4, 6, 169, 170, 23, 0.01f);
            m_EffectHeroAttack5_Effect6 = new CSprite(IDResource.Effect_Hero_Attack5_Effect6, 6, 3, 180, 170, 18, 0.01f);
            m_EffectHeroAttack5_Effect7 = new CSprite(IDResource.Effect_Hero_Attack5_Effect7, 6, 3, 241, 276, 18, 0.2f);


            m_EffectHeroAttack1_Hit = new CSprite(IDResource.Effect_Hero_Attack1_Hit, 6, 1, 96 , 113, 6, 0.01f);
            m_EffectHeroAttack3_Hit = new CSprite(IDResource.Effect_Hero_Attack3_Hit, 5, 1, 124 , 109, 5, 0.01f);
        }
        public void Init(ContentManager _CM)
        {
            m_PlayerStand.Init(_CM, "Sprite/Hero/Hero_Stand", IDResource.Player_Stand, 0, 3, 100.0f);
            m_PlayerMove.Init(_CM, "Sprite/Hero/Hero_Move", IDResource.Player_Move, 0, 5, 150.0f);
            m_PlayerJump.Init(_CM, "Sprite/Hero/Hero_Move", IDResource.Player_Jump, 0, 5, 150.0f);

            m_PlayerAttack1.Init(_CM, "Sprite/Hero/Hero_Attack1", IDResource.Player_Attack1, 0, 15, 120.0f, new Vector2(-350, -73), new Vector2(-141, -73));
            m_PlayerAttack2.Init(_CM, "Sprite/Hero/Hero_Attack2", IDResource.Player_Attack2, 0, 14, 150.0f, new Vector2(-164, -16), new Vector2(-51, -16));
            m_PlayerAttack3.Init(_CM, "Sprite/Hero/Hero_Attack3", IDResource.Player_Attack3, 0, 19, 120.0f, new Vector2(-143, -111 + 11), new Vector2(-44, -111 + 11));
            m_PlayerAttack4.Init(_CM, "Sprite/Hero/Hero_Attack4", IDResource.Player_Attack4, 0, 18, 150.0f, new Vector2(-73, -147), new Vector2(-60, -147));
            m_PlayerAttack5.Init(_CM, "Sprite/Hero/Hero_Attack5", IDResource.Player_Attack5, 0, 5, 100.0f, new Vector2(-34, 1), new Vector2(-27, 1));


            m_EffectHeroAttack1_Ball.Init(_CM, "Sprite/Hero/Hero_Attack1_Ball", IDResource.Effect_Hero_Attack1_Ball, 0, 4, 130.0f);
            m_EffectHeroAttack3_Ball.Init(_CM, "Sprite/Hero/Hero_Attack3_Ball", IDResource.Effect_Hero_Attack3_Ball, 0, 6, 150.0f);

            m_EffectHeroAttack5_Effect1.Init(_CM, "Sprite/Hero/Hero_Attack5_Effect1", IDResource.Effect_Hero_Attack5_Effect1, 0, 23, 90.0f);
            m_EffectHeroAttack5_Effect2.Init(_CM, "Sprite/Hero/Hero_Attack5_Effect2", IDResource.Effect_Hero_Attack5_Effect2, 0, 29, 40.0f);
            m_EffectHeroAttack5_Effect3.Init(_CM, "Sprite/Hero/Hero_Attack5_Effect3", IDResource.Effect_Hero_Attack5_Effect3, 0, 12, 190.0f);
            m_EffectHeroAttack5_Effect4.Init(_CM, "Sprite/Hero/Hero_Attack5_Effect4", IDResource.Effect_Hero_Attack5_Effect4, 0, 20, 90.0f);
            m_EffectHeroAttack5_Effect5.Init(_CM, "Sprite/Hero/Hero_Attack5_Effect5", IDResource.Effect_Hero_Attack5_Effect5, 0, 22, 90.0f);
            m_EffectHeroAttack5_Effect6.Init(_CM, "Sprite/Hero/Hero_Attack5_Effect6", IDResource.Effect_Hero_Attack5_Effect6, 0, 17, 90.0f);
            m_EffectHeroAttack5_Effect7.Init(_CM, "Sprite/Hero/Hero_Attack5_Effect7", IDResource.Effect_Hero_Attack5_Effect7, 0, 17, 110.0f);

            m_EffectHeroAttack4_Ball1_Lv1.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball1_Lv1", IDResource.Effect_Hero_Attack4_Ball1_Lv1, 0, 17, 200.0f);
            m_EffectHeroAttack4_Ball2_Lv1.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball2_Lv1", IDResource.Effect_Hero_Attack4_Ball2_Lv1, 0, 17, 150.0f);
            m_EffectHeroAttack4_Ball3_Lv1.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball3_Lv1", IDResource.Effect_Hero_Attack4_Ball3_Lv1, 0, 17, 180.0f);
            m_EffectHeroAttack4_Ball4_Lv1.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball4_Lv1", IDResource.Effect_Hero_Attack4_Ball4_Lv1, 0, 15, 170.0f);
            m_EffectHeroAttack4_Ball5_Lv1.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball5_Lv1", IDResource.Effect_Hero_Attack4_Ball5_Lv1, 0, 15, 150.0f);
            m_EffectHeroAttack4_Ball6_Lv1.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball6_Lv1", IDResource.Effect_Hero_Attack4_Ball6_Lv1, 0, 14, 180.0f);

            m_EffectHeroAttack4_Ball_Lv3.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball_Lv3", IDResource.Effect_Hero_Attack4_Ball_Lv3, 0, 17, 150.0f);
            m_EffectHeroAttack4_Ball1_Lv3.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball1_Lv3", IDResource.Effect_Hero_Attack4_Ball1_Lv3, 0, 15, 150.0f);
            m_EffectHeroAttack4_Ball2_Lv3.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball2_Lv3", IDResource.Effect_Hero_Attack4_Ball2_Lv3, 0, 15, 150.0f);
            m_EffectHeroAttack4_Ball3_Lv3.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball3_Lv3", IDResource.Effect_Hero_Attack4_Ball3_Lv3, 0, 15, 150.0f);
            m_EffectHeroAttack4_Ball4_Lv3.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball4_Lv3", IDResource.Effect_Hero_Attack4_Ball4_Lv3, 0, 15, 150.0f);
            m_EffectHeroAttack4_Ball5_Lv3.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball5_Lv3", IDResource.Effect_Hero_Attack4_Ball5_Lv3, 0, 15, 150.0f);
            m_EffectHeroAttack4_Ball6_Lv3.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball6_Lv3", IDResource.Effect_Hero_Attack4_Ball6_Lv3, 0, 17, 150.0f);
            

            m_EffectHeroAttack1_Hit.Init(_CM, "Sprite/Hero/Hero_Attack1_Hit", IDResource.Effect_Hero_Attack1_Hit, 0, 5, 150.0f);
            m_EffectHeroAttack3_Hit.Init(_CM, "Sprite/Hero/Hero_Attack3_Hit", IDResource.Effect_Hero_Attack1_Hit, 0, 4, 150.0f);

            m_Brick.Init(_CM, "Sprite/Brick", IDResource.Brick, 0, 0, 0.0f);
            m_BaseBrick.Init(_CM, "Sprite/BaseBrick", IDResource.BaseBrick, 0, 0, 0.0f);
            m_Barrel.Init(_CM, "Sprite/Barrel", IDResource.Barrel, 0, 0, 0.0f);
            
            m_Monster_SnowManMove.Init(_CM, "Sprite/Monster/Monster_SnowMan_Move", IDResource.Monster_SnowMan_Move, 0, 3, 200.0f);
            m_Monster_SnowManHit.Init(_CM, "Sprite/Monster/Monster_SnowMan_Hit", IDResource.Monster_SnowMan_Hit, 0, 0, 800.0f, new Vector2(8, -6), new Vector2(8, -6));
            m_Monster_SnowManDie.Init(_CM, "Sprite/Monster/Monster_SnowMan_Die", IDResource.Monster_SnowMan_Die, 0, 6, 0.0f, new Vector2(-80, 4), new Vector2(-11, 4));
            m_Monster_SnowManAttack.Init(_CM, "Sprite/Monster/Monster_SnowMan_Attack", IDResource.Monster_SnowMan_Attack, 0, 8, 120.0f, new Vector2(-115, -75), new Vector2(0, -75));
        }
        public static CResourceManager getInstance()
        {
            if (m_ResourceManager == null)
            {
                m_ResourceManager = new CResourceManager();
                return m_ResourceManager;
            }
            else
                return m_ResourceManager;
        }
        public CSprite getSprite(IDResource _ID)
        {
            switch (_ID)
            {
                case IDResource.Player_Stand:
                    return m_PlayerStand;
                case IDResource.Player_Move:
                    return m_PlayerMove;
                case IDResource.Player_Jump:
                    return m_PlayerJump;

                case IDResource.Brick:
                    return m_Brick;
                case IDResource.BaseBrick:
                    return m_BaseBrick;
                case IDResource.Barrel:
                    return m_Barrel;

                case IDResource.Monster_SnowMan_Move:
                    return m_Monster_SnowManMove;
                case IDResource.Monster_SnowMan_Attack:
                    return m_Monster_SnowManAttack;
                case IDResource.Monster_SnowMan_Hit:
                    return m_Monster_SnowManHit;
                case IDResource.Monster_SnowMan_Die:
                    return m_Monster_SnowManDie;

                case IDResource.Player_Attack1:
                    return m_PlayerAttack1;
                case IDResource.Player_Attack2:
                    return m_PlayerAttack2;
                case IDResource.Player_Attack3:
                    return m_PlayerAttack3;
                case IDResource.Player_Attack4:
                    return m_PlayerAttack4;
                case IDResource.Player_Attack5:
                    return m_PlayerAttack5;
                
                case IDResource.Effect_Hero_Attack1_Ball:
                    return m_EffectHeroAttack1_Ball;
                case IDResource.Effect_Hero_Attack3_Ball:
                    return m_EffectHeroAttack3_Ball;
                case IDResource.Effect_Hero_Attack1_Hit:
                    return m_EffectHeroAttack1_Hit;
                case IDResource.Effect_Hero_Attack3_Hit:
                    return m_EffectHeroAttack3_Hit;

                case IDResource.Effect_Hero_Attack4_Ball1_Lv1:
                    return m_EffectHeroAttack4_Ball1_Lv1;
                case IDResource.Effect_Hero_Attack4_Ball2_Lv1:
                    return m_EffectHeroAttack4_Ball2_Lv1;
                case IDResource.Effect_Hero_Attack4_Ball3_Lv1:
                    return m_EffectHeroAttack4_Ball3_Lv1;
                case IDResource.Effect_Hero_Attack4_Ball4_Lv1:
                    return m_EffectHeroAttack4_Ball4_Lv1;
                case IDResource.Effect_Hero_Attack4_Ball5_Lv1:
                    return m_EffectHeroAttack4_Ball5_Lv1;
                case IDResource.Effect_Hero_Attack4_Ball6_Lv1:
                    return m_EffectHeroAttack4_Ball6_Lv1;

                case IDResource.Effect_Hero_Attack4_Ball_Lv3:
                    return m_EffectHeroAttack4_Ball_Lv3;
                case IDResource.Effect_Hero_Attack4_Ball1_Lv3:
                    return m_EffectHeroAttack4_Ball1_Lv3;
                case IDResource.Effect_Hero_Attack4_Ball2_Lv3:
                    return m_EffectHeroAttack4_Ball2_Lv3;
                case IDResource.Effect_Hero_Attack4_Ball3_Lv3:
                    return m_EffectHeroAttack4_Ball3_Lv3;
                case IDResource.Effect_Hero_Attack4_Ball4_Lv3:
                    return m_EffectHeroAttack4_Ball4_Lv3;
                case IDResource.Effect_Hero_Attack4_Ball5_Lv3:
                    return m_EffectHeroAttack4_Ball5_Lv3;
                case IDResource.Effect_Hero_Attack4_Ball6_Lv3:
                    return m_EffectHeroAttack4_Ball6_Lv3;

                case IDResource.Effect_Hero_Attack5_Effect1:
                    return m_EffectHeroAttack5_Effect1;
                case IDResource.Effect_Hero_Attack5_Effect2:
                    return m_EffectHeroAttack5_Effect2;
                case IDResource.Effect_Hero_Attack5_Effect3:
                    return m_EffectHeroAttack5_Effect3;
                case IDResource.Effect_Hero_Attack5_Effect4:
                    return m_EffectHeroAttack5_Effect4;
                case IDResource.Effect_Hero_Attack5_Effect5:
                    return m_EffectHeroAttack5_Effect5;
                case IDResource.Effect_Hero_Attack5_Effect6:
                    return m_EffectHeroAttack5_Effect6;
                case IDResource.Effect_Hero_Attack5_Effect7:
                    return m_EffectHeroAttack5_Effect7;
            }
            return null;
        }

        public void UnLoad()
        {
            Console.WriteLine("UnLoad content of CResourceManager......");
        }
    }
}
