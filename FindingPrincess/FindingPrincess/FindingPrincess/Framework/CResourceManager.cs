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
        Player_Die,
        Player_Attack1,
        Player_Attack2,
        Player_Attack3,
        Player_Attack4,
        Player_Attack5,

        Boss_Move,
        Boss_Stand,
        Boss_Hit,
        Boss_Die1,
        Boss_Die2,
        Boss_Die3,
        Boss_Transform1,
        Boss_Transform2,
        Boss_Stand2,
        Boss_Attack1_1,
        Boss_Attack1_2,
        Boss_Attack2_1,
        Boss_Attack2_2,
        Boss_Attack3,
        Boss_Attack4_1,
        Boss_Attack4_2,
        Boss_Attack4_3,
        Boss_Attack4_4,

        Effect_Boss_Attack1_Hit,
        Effect_Boss_Attack2_Hit,
        Effect_Boss_Attack3_Hit,
        Effect_Boss_Attack4_Hit,

        Master_Move,
        Master_Stand,
        Master_Hit,
        Master_Die,
        Master_Attack1_1,
        Master_Attack1_2,
        Master_Attack1_3,
        Master_Attack1_4,
        Master_Attack2_1,
        Master_Attack2_2,
        Master_Attack3_1,
        Master_Attack3_2,
        Master_Attack4,
        Master_Attack5,

        Dark_Player_Stand,
        Dark_Player_Move,
        Dark_Player_Hit,
        Dark_Player_Attack1,
        Dark_Player_Attack2,
        Dark_Player_Attack3,
        Dark_Player_Heal,
        Effect_Master_Attack1_Hit,
        Effect_Master_Attack2_Hit,
        Effect_Master_Attack4_Hit,

        Effect_Hero_Attack1_Ball,
        Effect_Hero_Attack2_Ball,
        Effect_Hero_Attack3_Ball,

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
        Effect_Hero_Attack2_Hit,
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


        Monster_SnowMan_Move,
        Monster_SnowMan_Attack,
        Monster_SnowMan_Hit,
        Monster_SnowMan_Die,
        Monster_SnowMan_Blue_Move,
        Monster_SnowMan_Blue_Attack,
        Monster_SnowMan_Blue_Hit,
        Monster_SnowMan_Blue_Die,

        Monster_SnowMan_Red_Move,
        Monster_SnowMan_Red_Attack,
        Monster_SnowMan_Red_Hit,
        Monster_SnowMan_Red_Die,

        Monster_SnowMan_Lady_Move,
        Monster_SnowMan_Lady_Attack,
        Monster_SnowMan_Lady_Hit,
        Monster_SnowMan_Lady_Die,

        Monster_SnowMan_Purple_Move,
        Monster_SnowMan_Purple_Attack,
        Monster_SnowMan_Purple_Hit,
        Monster_SnowMan_Purple_Die,

        Monster_BigClown_Move,
        Monster_BigClown_Attack,
        Monster_BigClown_Hit,
        Monster_BigClown_Die,

        Monster_MiniClown_Move,
        Monster_MiniClown_Attack,
        Monster_MiniClown_Hit,
        Monster_MiniClown_Die,

        Monster_YellowBean_Move,
        Monster_YellowBean_Attack1,
        Monster_YellowBean_Attack2,
        Monster_YellowBean_Hit,
        Monster_YellowBean_Die,

        Monster_Shark_Move,
        Monster_Shark_Attack,
        Monster_Shark_Hit,
        Monster_Shark_Die,

        Monster_WolfMan_Move,
        Monster_WolfMan_Attack,
        Monster_WolfMan_Hit,
        Monster_WolfMan_Die,

        Monster_WolfOrc_Move,
        Monster_WolfOrc_Attack1,
        Monster_WolfOrc_Attack2,
        Monster_WolfOrc_Hit,
        Monster_WolfOrc_Die,

        Monster_WolfOwl_Move,
        Monster_WolfOwl_Attack1,
        Monster_WolfOwl_Attack2,
        Monster_WolfOwl_Hit,
        Monster_WolfOwl_Die,

        Monster_OldPanda_Move,
        Monster_OldPanda_Attack,
        Monster_OldPanda_Hit,
        Monster_OldPanda_Die,
        
        Item_Clover,
        Item_Cuddly_Penguin,
        Item_Diamond,
        Item_Fire_Box,
        Item_Ice_Box,
        Item_Key,
        Item_Lemon_Juice,
        Item_Water,
        Item_Gold_1,
        Item_Gold_2,
        Item_Gold_3,
        Item_Gold_4,
        Item_Hp_Potion_1,
        Item_Hp_Potion_2,
        Item_Hp_Potion_3,
        Item_Mana_Potion_1,
        Item_Mana_Potion_2,
        Item_Mana_Potion_3,
        LOSE,
    }
    class CResourceManager
    {
        #region Without Monster
        private CSprite m_PlayerStand;
        private CSprite m_PlayerMove;
        private CSprite m_PlayerJump;
        private CSprite m_PlayerDie;
        private CSprite m_PlayerAttack1;
        private CSprite m_PlayerAttack2;
        private CSprite m_PlayerAttack3;
        private CSprite m_PlayerAttack4;
        private CSprite m_PlayerAttack5;

        private CSprite m_BossMove;
        private CSprite m_BossStand;
        private CSprite m_BossHit;
        private CSprite m_BossDie1;
        private CSprite m_BossDie2;
        private CSprite m_BossDie3;
        private CSprite m_BossStand2;
        private CSprite m_BossTransform1;
        private CSprite m_BossTransform2;
        private CSprite m_BossAttack1_1;
        private CSprite m_BossAttack1_2;
        private CSprite m_BossAttack2_1;
        private CSprite m_BossAttack2_2;
        private CSprite m_BossAttack3;
        private CSprite m_BossAttack4_1;
        private CSprite m_BossAttack4_2;
        private CSprite m_BossAttack4_3;
        private CSprite m_BossAttack4_4;


        private CSprite m_MasterMove;
        private CSprite m_MasterStand;
        private CSprite m_MasterHit;
        private CSprite m_MasterDie;
        private CSprite m_MasterAttack1_1;
        private CSprite m_MasterAttack1_2;
        private CSprite m_MasterAttack1_3;
        private CSprite m_MasterAttack1_4;
        private CSprite m_MasterAttack2_1;
        private CSprite m_MasterAttack2_2;
        private CSprite m_MasterAttack3_1;
        private CSprite m_MasterAttack3_2;
        private CSprite m_MasterAttack4;
        private CSprite m_MasterAttack5;
        private CSprite m_EffectMasterAttack1_Hit;
        private CSprite m_EffectMasterAttack2_Hit;
        private CSprite m_EffectMasterAttack4_Hit;

        private CSprite m_EffectBossAttack1_Hit;
        private CSprite m_EffectBossAttack2_Hit;
        private CSprite m_EffectBossAttack3_Hit;
        private CSprite m_EffectBossAttack4_Hit;

        private CSprite m_EffectHeroAttack1_Ball;
        private CSprite m_EffectHeroAttack2_Ball;
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
        private CSprite m_EffectHeroAttack2_Hit;
        private CSprite m_EffectHeroAttack3_Hit;

        private CSprite m_Brick;
        private CSprite m_BaseBrick;
        private CSprite m_Barrel;
        #endregion
        #region Monster
        private CSprite m_Monster_SnowManMove;
        private CSprite m_Monster_SnowManAttack;
        private CSprite m_Monster_SnowManHit;
        private CSprite m_Monster_SnowManDie;


        private CSprite m_Monster_SnowManBlueMove;
        private CSprite m_Monster_SnowManBlueAttack;
        private CSprite m_Monster_SnowManBlueHit;
        private CSprite m_Monster_SnowManBlueDie;

        private CSprite m_Monster_SnowManRedMove;
        private CSprite m_Monster_SnowManRedAttack;
        private CSprite m_Monster_SnowManRedHit;
        private CSprite m_Monster_SnowManRedDie;

        private CSprite m_Monster_SnowManLadyMove;
        private CSprite m_Monster_SnowManLadyAttack;
        private CSprite m_Monster_SnowManLadyHit;
        private CSprite m_Monster_SnowManLadyDie;

        private CSprite m_Monster_SnowManPurpleMove;
        private CSprite m_Monster_SnowManPurpleAttack;
        private CSprite m_Monster_SnowManPurpleHit;
        private CSprite m_Monster_SnowManPurpleDie;

        private CSprite m_Monster_BigClown_Move;
        private CSprite m_Monster_BigClown_Attack;
        private CSprite m_Monster_BigClown_Hit;
        private CSprite m_Monster_BigClown_Die;

        private CSprite m_Monster_MiniClown_Move;
        private CSprite m_Monster_MiniClown_Attack;
        private CSprite m_Monster_MiniClown_Hit;
        private CSprite m_Monster_MiniClown_Die;

        private CSprite m_Monster_YellowBean_Move;
        private CSprite m_Monster_YellowBean_Attack1;
        private CSprite m_Monster_YellowBean_Attack2;
        private CSprite m_Monster_YellowBean_Hit;
        private CSprite m_Monster_YellowBean_Die;

        private CSprite m_Monster_Shark_Move;
        private CSprite m_Monster_Shark_Attack;
        private CSprite m_Monster_Shark_Hit;
        private CSprite m_Monster_Shark_Die;

        private CSprite m_Monster_WolfMan_Move;
        private CSprite m_Monster_WolfMan_Attack;
        private CSprite m_Monster_WolfMan_Hit;
        private CSprite m_Monster_WolfMan_Die;

        private CSprite m_Monster_WolfOrc_Move;
        private CSprite m_Monster_WolfOrc_Attack1;
        private CSprite m_Monster_WolfOrc_Attack2;        
        private CSprite m_Monster_WolfOrc_Hit;
        private CSprite m_Monster_WolfOrc_Die;

        private CSprite m_Monster_WolfOwl_Move;
        private CSprite m_Monster_WolfOwl_Attack1;
        private CSprite m_Monster_WolfOwl_Attack2;
        private CSprite m_Monster_WolfOwl_Hit;
        private CSprite m_Monster_WolfOwl_Die;

        private CSprite m_Monster_OldPanda_Move;
        private CSprite m_Monster_OldPanda_Attack;
        private CSprite m_Monster_OldPanda_Hit;
        private CSprite m_Monster_OldPanda_Die;
        #endregion
        #region Item
        private CSprite m_Item_Clover;
        private CSprite m_Item_Cuddly_Penguin;
        private CSprite m_Item_Diamond;
        private CSprite m_Item_Fire_Box;
        private CSprite m_Item_Ice_Box;
        private CSprite m_Item_Key;
        private CSprite m_Item_Lemon_Juice;
        private CSprite m_Item_Water;
        private CSprite m_Item_Gold_1;
        private CSprite m_Item_Gold_2;
        private CSprite m_Item_Gold_3;
        private CSprite m_Item_Gold_4;
        private CSprite m_Item_Hp_Potion_1;
        private CSprite m_Item_Hp_Potion_2;
        private CSprite m_Item_Hp_Potion_3;
        private CSprite m_Item_Mana_Potion_1;
        private CSprite m_Item_Mana_Potion_2;
        private CSprite m_Item_Mana_Potion_3;
        #endregion
#region otherss......
        private CSprite m_LOSE;
#endregion

        private static CResourceManager m_ResourceManager;
        private CResourceManager()
        {
            #region Without Monster
            m_PlayerMove = new CSprite(IDResource.Player_Move, 6, 1, 79, 103, 6, 0.1f);
            m_PlayerStand = new CSprite(IDResource.Player_Stand, 4, 1, 79, 98, 4, 0.1f);
            m_PlayerJump = new CSprite(IDResource.Player_Jump, 6, 1, 79, 103, 6, 0.1f);
            m_PlayerDie = new CSprite(IDResource.Player_Die, 5, 4, 212, 202, 20, 0.1f);

            m_BaseBrick = new CSprite(IDResource.BaseBrick, 1, 1, 500*4, 50, 1, 0.95f);
            m_Brick = new CSprite(IDResource.Brick, 1, 1, 50, 50, 1, 1.0f);
            m_Barrel = new CSprite(IDResource.Barrel, 1, 1, 170, 174, 1, 1.0f);
            


            m_PlayerAttack1 = new CSprite(IDResource.Player_Attack1, 3, 6, (int)2280/4, 255, 16, 0.1f);
            m_PlayerAttack2 = new CSprite(IDResource.Player_Attack2, 5, 3, 1470/5, (int)492 / 3, 15, 0.1f);
            m_PlayerAttack3 = new CSprite(IDResource.Player_Attack3, 5, 4, 274, 231, 20, 0.1f);
            m_PlayerAttack4 = new CSprite(IDResource.Player_Attack4, 5, 4, 212, 251, 19, 0.1f);
            m_PlayerAttack5 = new CSprite(IDResource.Player_Attack5, 6, 1, 140, 133, 6, 0.1f);
            
            m_BossMove = new CSprite(IDResource.Boss_Move, 6, 3, 323, 299, 18, 0.97f);
            m_BossStand = new CSprite(IDResource.Boss_Stand, 6, 1, 316, 290, 6, 0.97f);
            m_BossHit = new CSprite(IDResource.Boss_Hit, 1, 1, 388, 287, 1, 0.97f);
            m_BossDie1 = new CSprite(IDResource.Boss_Die1, 4, 5, 417, 399, 20, 0.97f);
            m_BossDie2 = new CSprite(IDResource.Boss_Die2, 4, 5, 417, 399, 20, 0.97f);
            m_BossDie3 = new CSprite(IDResource.Boss_Die3, 3, 5, 417, 399, 13, 0.97f);
            m_BossTransform1 = new CSprite(IDResource.Boss_Transform1, 4, 5, 397, 330, 20, 0.97f);
            m_BossTransform2 = new CSprite(IDResource.Boss_Transform2, 4, 5, 397, 330, 20, 0.97f);
            m_BossStand2 = new CSprite(IDResource.Boss_Stand2, 1, 1, 397, 43, 62, 0.97f);
            m_BossAttack1_1 = new CSprite(IDResource.Boss_Attack1_1, 4, 4, 457, 369, 16, 0.97f);
            m_BossAttack1_2 = new CSprite(IDResource.Boss_Attack1_2, 3, 1, 457, 369, 3, 0.97f);
            m_BossAttack2_1 = new CSprite(IDResource.Boss_Attack2_1, 3, 4, 563, 417, 12, 0.97f);
            m_BossAttack2_2 = new CSprite(IDResource.Boss_Attack2_2, 3, 4, 563, 417, 12, 0.97f);
            m_BossAttack3   = new CSprite(IDResource.Boss_Attack3, 5, 5, 409, 344, 24, 0.97f);
            m_BossAttack4_1 = new CSprite(IDResource.Boss_Attack4_1, 2, 5, 767, 364, 10, 0.97f);
            m_BossAttack4_2 = new CSprite(IDResource.Boss_Attack4_2, 2, 5, 767, 364, 10, 0.97f);
            m_BossAttack4_3 = new CSprite(IDResource.Boss_Attack4_3, 2, 5, 767, 364, 10, 0.97f);
            m_BossAttack4_4 = new CSprite(IDResource.Boss_Attack4_4, 2, 5, 767, 364, 10, 0.97f);
            m_EffectBossAttack1_Hit = new CSprite(IDResource.Effect_Boss_Attack1_Hit, 5, 1, 165, 158, 5, 0.01f);
            m_EffectBossAttack2_Hit = new CSprite(IDResource.Effect_Boss_Attack2_Hit, 6, 1, 194, 177, 6, 0.01f);
            m_EffectBossAttack3_Hit = new CSprite(IDResource.Effect_Boss_Attack3_Hit, 4, 1, 151, 151, 4, 0.01f);
            m_EffectBossAttack4_Hit = new CSprite(IDResource.Effect_Boss_Attack4_Hit, 7, 1, 103, 106, 7, 0.01f);

            m_MasterMove = new CSprite(IDResource.Master_Move, 4, 1, 155, 83, 4, 0.97f);
            m_MasterStand = new CSprite(IDResource.Master_Stand, 6, 1, 175, 92, 6, 0.97f);
            m_MasterHit = new CSprite(IDResource.Master_Hit, 1, 1, 175, 109, 1, 0.97f);
            m_MasterDie = new CSprite(IDResource.Master_Die, 9, 3, 209, 186, 27, 0.97f);
            
            m_MasterAttack1_1 = new CSprite(IDResource.Master_Attack1_1, 2, 4, 887, 451, 8, 0.97f);
            m_MasterAttack1_2 = new CSprite(IDResource.Master_Attack1_2, 2, 4, 887, 451, 8, 0.97f);
            m_MasterAttack1_3 = new CSprite(IDResource.Master_Attack1_3, 2, 4, 887, 451, 8, 0.97f);
            m_MasterAttack1_4 = new CSprite(IDResource.Master_Attack1_4, 2, 3, 887, 451, 5, 0.97f);
            m_MasterAttack2_1 = new CSprite(IDResource.Master_Attack2_1, 3, 6, 520, 334, 18, 0.97f);
            m_MasterAttack2_2 = new CSprite(IDResource.Master_Attack2_2, 3, 5, 520, 334, 14, 0.97f);
            m_MasterAttack3_1 = new CSprite(IDResource.Master_Attack3_1, 2, 5, 824, 224, 10, 0.97f);
            m_MasterAttack3_2 = new CSprite(IDResource.Master_Attack3_2, 2, 5, 824, 224, 10, 0.97f);
            m_MasterAttack4 = new CSprite(IDResource.Master_Attack4, 3, 7, 550, 182, 20, 0.97f);
            m_MasterAttack5 = new CSprite(IDResource.Master_Attack5, 5, 4, 409, 339, 20, 0.97f);

            m_EffectMasterAttack1_Hit = new CSprite(IDResource.Effect_Master_Attack1_Hit, 6, 1, 177, 182, 6, 0.01f);
            m_EffectMasterAttack2_Hit = new CSprite(IDResource.Effect_Master_Attack2_Hit, 7, 1, 168, 116, 7, 0.01f);
            m_EffectMasterAttack4_Hit = new CSprite(IDResource.Effect_Master_Attack4_Hit, 7, 1, 113, 139, 7, 0.01f);

            m_EffectHeroAttack1_Ball = new CSprite(IDResource.Effect_Hero_Attack1_Ball, 5, 1, 415, 143, 5, 0.1f);
            m_EffectHeroAttack2_Ball = new CSprite(IDResource.Effect_Hero_Attack2_Ball, 4, 1, 310, 100, 4, 0.1f);
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
            m_EffectHeroAttack2_Hit = new CSprite(IDResource.Effect_Hero_Attack2_Hit, 4, 1, 249, 118, 4, 0.01f);
            m_EffectHeroAttack3_Hit = new CSprite(IDResource.Effect_Hero_Attack3_Hit, 5, 1, 124 , 109, 5, 0.01f);
            #endregion
            #region Monster
            m_Monster_SnowManMove = new CSprite(IDResource.Monster_SnowMan_Move, 4, 1, 121, 111, 4, 0.97f);
            m_Monster_SnowManAttack = new CSprite(IDResource.Monster_SnowMan_Attack, 9, 1, 224, 191, 9, 0.97f);
            m_Monster_SnowManHit = new CSprite(IDResource.Monster_SnowMan_Hit, 1, 1, 105, 117, 1, 0.97f);
            m_Monster_SnowManDie = new CSprite(IDResource.Monster_SnowMan_Die, 7, 1, 190, 108, 7, 0.97f);

            m_Monster_SnowManBlueMove = new CSprite(IDResource.Monster_SnowMan_Blue_Move, 8, 1, 127, 171, 8, 0.97f);
            m_Monster_SnowManBlueAttack = new CSprite(IDResource.Monster_SnowMan_Blue_Attack, 7, 3, 280, 283, 21, 0.97f);
            m_Monster_SnowManBlueHit = new CSprite(IDResource.Monster_SnowMan_Blue_Hit, 1, 1, 135, 200, 1, 0.97f);
            m_Monster_SnowManBlueDie = new CSprite(IDResource.Monster_SnowMan_Blue_Die, 3, 6, 515, 213, 23, 0.97f);

            m_Monster_SnowManPurpleMove = new CSprite(IDResource.Monster_SnowMan_Purple_Move, 8, 1, 127, 171, 8, 0.97f);
            m_Monster_SnowManPurpleAttack = new CSprite(IDResource.Monster_SnowMan_Purple_Attack, 7, 3, 309, 273, 21, 0.97f);
            m_Monster_SnowManPurpleHit = new CSprite(IDResource.Monster_SnowMan_Purple_Hit, 1, 1, 135, 200, 1, 0.97f);
            m_Monster_SnowManPurpleDie = new CSprite(IDResource.Monster_SnowMan_Purple_Die, 3, 8, 515, 213, 23, 0.97f);

            m_Monster_SnowManRedMove = new CSprite(IDResource.Monster_SnowMan_Red_Move, 4, 1, 121, 152, 4, 0.97f);
            m_Monster_SnowManRedAttack = new CSprite(IDResource.Monster_SnowMan_Red_Attack, 3, 3, 219, 215, 9, 0.97f);
            m_Monster_SnowManRedHit = new CSprite(IDResource.Monster_SnowMan_Red_Hit, 1, 1, 135, 200, 1, 0.97f);
            m_Monster_SnowManRedDie = new CSprite(IDResource.Monster_SnowMan_Red_Die, 7, 1, 232, 172, 7, 0.97f);

            m_Monster_SnowManLadyMove = new CSprite(IDResource.Monster_SnowMan_Lady_Move, 8, 1, 90, 93, 8, 0.94f);
            m_Monster_SnowManLadyAttack = new CSprite(IDResource.Monster_SnowMan_Lady_Attack, 4, 2, 178, 94, 8, 0.94f);
            m_Monster_SnowManLadyHit = new CSprite(IDResource.Monster_SnowMan_Lady_Hit, 1, 1, 133, 108, 1, 0.94f);
            m_Monster_SnowManLadyDie = new CSprite(IDResource.Monster_SnowMan_Lady_Die, 4, 3, 162, 108, 11, 0.94f);

            m_Monster_MiniClown_Move = new CSprite(IDResource.Monster_MiniClown_Move, 6, 1, 88, 99, 6, 0.97f);
            m_Monster_MiniClown_Attack = new CSprite(IDResource.Monster_MiniClown_Attack, 4, 3, 102, 102, 12, 0.97f);
            m_Monster_MiniClown_Hit = new CSprite(IDResource.Monster_MiniClown_Hit, 1, 1, 91, 96, 1, 0.97f);
            m_Monster_MiniClown_Die = new CSprite(IDResource.Monster_MiniClown_Die, 6, 1, 105, 113, 6, 0.97f);

            m_Monster_BigClown_Move = new CSprite(IDResource.Monster_BigClown_Move, 6, 1, 160, 129, 6, 0.97f);
            m_Monster_BigClown_Attack = new CSprite(IDResource.Monster_BigClown_Attack, 5, 3, 180, 220, 15, 0.97f);
            m_Monster_BigClown_Hit = new CSprite(IDResource.Monster_BigClown_Hit, 1, 1, 161, 125, 1, 0.97f);
            m_Monster_BigClown_Die = new CSprite(IDResource.Monster_BigClown_Die, 7, 1, 164, 139, 7, 0.97f);

            m_Monster_YellowBean_Move = new CSprite(IDResource.Monster_YellowBean_Move, 6, 1, 67, 61, 6, 0.97f);
            m_Monster_YellowBean_Attack1 = new CSprite(IDResource.Monster_YellowBean_Attack1, 11, 2, 96, 82, 22, 0.97f);
            m_Monster_YellowBean_Attack2 = new CSprite(IDResource.Monster_YellowBean_Attack2, 5, 3, 135, 87, 15, 0.97f);
            m_Monster_YellowBean_Hit = new CSprite(IDResource.Monster_YellowBean_Hit, 1, 1, 75, 62, 1, 0.97f);
            m_Monster_YellowBean_Die = new CSprite(IDResource.Monster_YellowBean_Die, 8, 1, 76, 60, 8, 0.97f);

            m_Monster_Shark_Move = new CSprite(IDResource.Monster_Shark_Move, 8, 1, 124, 100, 8, 0.97f);
            m_Monster_Shark_Attack = new CSprite(IDResource.Monster_Shark_Attack, 3, 3, 215, 131, 9, 0.97f);
            m_Monster_Shark_Hit = new CSprite(IDResource.Monster_Shark_Hit, 1, 1, 127, 101, 1, 0.97f);
            m_Monster_Shark_Die = new CSprite(IDResource.Monster_Shark_Die, 6, 1, 156, 110, 6, 0.97f);

            m_Monster_WolfMan_Move = new CSprite(IDResource.Monster_WolfMan_Move, 3, 3, 165, 158, 9, 0.97f);
            m_Monster_WolfMan_Attack = new CSprite(IDResource.Monster_WolfMan_Attack, 5, 3, 315, 235, 15, 0.97f);
            m_Monster_WolfMan_Hit = new CSprite(IDResource.Monster_WolfMan_Hit, 1, 1, 173, 169, 1, 0.97f);
            m_Monster_WolfMan_Die = new CSprite(IDResource.Monster_WolfMan_Die, 7, 1, 249, 178, 7, 0.97f);

            m_Monster_OldPanda_Move = new CSprite(IDResource.Monster_OldPanda_Move, 8, 1, 87, 77, 8, 0.97f);
            m_Monster_OldPanda_Attack = new CSprite(IDResource.Monster_OldPanda_Attack, 3, 9, 285, 218, 27, 0.97f);
            m_Monster_OldPanda_Hit = new CSprite(IDResource.Monster_OldPanda_Hit, 1, 1, 84, 80, 1, 0.97f);
            m_Monster_OldPanda_Die = new CSprite(IDResource.Monster_OldPanda_Die, 6, 4, 239, 413, 24, 0.97f);

            m_Monster_WolfOwl_Move = new CSprite(IDResource.Monster_WolfOwl_Move, 6, 1, 122, 124, 6, 0.97f);
            m_Monster_WolfOwl_Attack1 = new CSprite(IDResource.Monster_WolfOwl_Attack1, 3, 3, 201, 116, 9, 0.97f);
            m_Monster_WolfOwl_Attack2 = new CSprite(IDResource.Monster_WolfOwl_Attack2, 7, 2, 231, 145, 14, 0.97f);
            m_Monster_WolfOwl_Hit = new CSprite(IDResource.Monster_WolfOwl_Hit, 1, 1, 149, 128, 1, 0.97f);
            m_Monster_WolfOwl_Die = new CSprite(IDResource.Monster_WolfOwl_Die, 3, 3, 169, 128, 9, 0.97f);

            m_Monster_WolfOrc_Move = new CSprite(IDResource.Monster_WolfOrc_Move, 6, 1, 116, 168, 6, 0.97f);
            m_Monster_WolfOrc_Attack1 = new CSprite(IDResource.Monster_WolfOrc_Attack1, 5, 5, 230, 312, 25, 0.97f);
            m_Monster_WolfOrc_Attack2 = new CSprite(IDResource.Monster_WolfOrc_Attack2, 5, 5, 243, 245, 25, 0.97f);
            m_Monster_WolfOrc_Hit = new CSprite(IDResource.Monster_WolfOrc_Hit, 1, 1, 126, 158, 1, 0.97f);
            m_Monster_WolfOrc_Die = new CSprite(IDResource.Monster_WolfOrc_Die, 6, 3, 330, 172, 18, 0.97f);
            #endregion
            m_Item_Clover = new CSprite(IDResource.Item_Clover, 2, 1, 32, 33, 2, 0.97f);
            m_Item_Cuddly_Penguin = new CSprite(IDResource.Item_Cuddly_Penguin, 1, 1, 29, 29, 1, 0.97f);
            m_Item_Diamond = new CSprite(IDResource.Item_Diamond, 1, 1, 26, 28, 1, 0.97f);
            m_Item_Fire_Box = new CSprite(IDResource.Item_Fire_Box, 1, 1, 27, 30, 1, 0.97f);
            m_Item_Ice_Box = new CSprite(IDResource.Item_Ice_Box, 1, 1, 27, 30, 1, 0.97f);
            m_Item_Key = new CSprite(IDResource.Item_Key, 1, 1, 30, 31, 1, 0.97f);
            m_Item_Lemon_Juice = new CSprite(IDResource.Item_Lemon_Juice, 1, 1, 31, 33, 1, 0.97f);
            m_Item_Water = new CSprite(IDResource.Item_Water, 1, 1, 31, 31, 1, 0.97f);
            m_Item_Gold_1 = new CSprite(IDResource.Item_Gold_1, 1, 1, 32, 32, 1, 0.97f);
            m_Item_Gold_2 = new CSprite(IDResource.Item_Gold_2, 1, 1, 32, 32, 1, 0.97f);
            m_Item_Gold_3 = new CSprite(IDResource.Item_Gold_3, 1, 1, 32, 32, 1, 0.97f);
            m_Item_Gold_4 = new CSprite(IDResource.Item_Gold_4, 1, 1, 32, 32, 1, 0.97f);
            m_Item_Hp_Potion_1 = new CSprite(IDResource.Item_Hp_Potion_1, 1, 1, 25, 33, 1, 0.97f);
            m_Item_Hp_Potion_2 = new CSprite(IDResource.Item_Hp_Potion_2, 1, 1, 26, 33, 1, 0.97f);
            m_Item_Hp_Potion_3 = new CSprite(IDResource.Item_Hp_Potion_3, 1, 1, 36, 36, 1, 0.97f);
            m_Item_Mana_Potion_1 = new CSprite(IDResource.Item_Mana_Potion_1, 1, 1, 25, 33, 1, 0.97f);
            m_Item_Mana_Potion_2 = new CSprite(IDResource.Item_Mana_Potion_2, 1, 1, 26, 32, 1, 0.97f);
            m_Item_Mana_Potion_3 = new CSprite(IDResource.Item_Mana_Potion_3, 2, 1, 31, 40, 2, 0.97f);
            m_LOSE = new CSprite(IDResource.LOSE, 4, 5, 194, 130, 20, 0.97f);
        }

        public void Init(ContentManager _CM)
        {
            #region Without Monster
            m_PlayerStand.Init(_CM, "Sprite/Hero/Hero_Stand", IDResource.Player_Stand, 0, 3, 100.0f);
            m_PlayerMove.Init(_CM, "Sprite/Hero/Hero_Move", IDResource.Player_Move, 0, 5, 150.0f);
            m_PlayerJump.Init(_CM, "Sprite/Hero/Hero_Move", IDResource.Player_Jump, 0, 5, 150.0f);
            m_PlayerDie.Init(_CM, "Sprite/Hero/Hero_Die", IDResource.Player_Jump, 0, 19, 150.0f, new Vector2(-9, -49), new Vector2(-124, -49));

            m_PlayerAttack1.Init(_CM, "Sprite/Hero/Hero_Attack1", IDResource.Player_Attack1, 0, 15, 85.0f, new Vector2(-350, -73), new Vector2(-141, -73));
            m_PlayerAttack2.Init(_CM, "Sprite/Hero/Hero_Attack2", IDResource.Player_Attack2, 0, 14, 90.0f, new Vector2(-164, -16), new Vector2(-51, -16));
            m_PlayerAttack3.Init(_CM, "Sprite/Hero/Hero_Attack3", IDResource.Player_Attack3, 0, 19, 65.0f, new Vector2(-143, -111 + 11), new Vector2(-44, -111 + 11));
            m_PlayerAttack4.Init(_CM, "Sprite/Hero/Hero_Attack4", IDResource.Player_Attack4, 0, 18, 70.0f, new Vector2(-73, -147), new Vector2(-60, -147));
            m_PlayerAttack5.Init(_CM, "Sprite/Hero/Hero_Attack5", IDResource.Player_Attack5, 0, 5, 100.0f, new Vector2(-34, 1), new Vector2(-27, 1));


            m_BossMove.Init(_CM, "Sprite/Boss/Boss_Move", IDResource.Boss_Move, 0, 17, 60.0f, new Vector2(-5, -10), new Vector2(-2, -10));
            m_BossStand.Init(_CM, "Sprite/Boss/Boss_Stand", IDResource.Boss_Stand, 0, 5, 80.0f);
            m_BossHit.Init(_CM, "Sprite/Boss/Boss_Hit", IDResource.Boss_Hit, 0, 0, 500.0f, new Vector2(-31, 2), new Vector2(-41, 2));
            m_BossDie1.Init(_CM, "Sprite/Boss/Boss_Die1", IDResource.Boss_Die1, 0, 19, 70.0f, new Vector2(-46, -62), new Vector2(-55, -62));
            m_BossDie2.Init(_CM, "Sprite/Boss/Boss_Die2", IDResource.Boss_Die2, 0, 19, 100.0f, new Vector2(-46, -62), new Vector2(-55, -62));
            m_BossDie3.Init(_CM, "Sprite/Boss/Boss_Die3", IDResource.Boss_Die3, 0, 12, 100.0f, new Vector2(-46, -62), new Vector2(-55, -62));
            m_BossTransform1.Init(_CM, "Sprite/Boss/Boss_Transform1", IDResource.Boss_Transform1, 0, 19, 150.0f);
            m_BossTransform2.Init(_CM, "Sprite/Boss/Boss_Transform2", IDResource.Boss_Transform2, 0, 19, 150.0f);
            m_BossStand2.Init(_CM, "Sprite/Boss/Boss_Stand2", IDResource.Boss_Stand2, 0, 0, 100.0f);
            m_BossAttack1_1.Init(_CM, "Sprite/Boss/Boss_Attack1_1", IDResource.Boss_Attack1_1, 0, 15, 95.0f, new Vector2(-90, -30), new Vector2(-51, -30));
            m_BossAttack1_2.Init(_CM, "Sprite/Boss/Boss_Attack1_2", IDResource.Boss_Attack1_2, 0, 2, 80.0f, new Vector2(-94, -42), new Vector2(-47, -42));
            m_BossAttack2_1.Init(_CM, "Sprite/Boss/Boss_Attack2_1", IDResource.Boss_Attack2_1, 0, 11, 80.0f, new Vector2(-120, -63), new Vector2(-127, -63));
            m_BossAttack2_2.Init(_CM, "Sprite/Boss/Boss_Attack2_2", IDResource.Boss_Attack2_2, 0, 11, 80.0f, new Vector2(-120, -60), new Vector2(-127, -60));
            m_BossAttack3.Init(_CM, "Sprite/Boss/Boss_Attack3", IDResource.Boss_Attack3, 0, 23, 80.0f, new Vector2(-47, -5), new Vector2(-46, -5));
            m_BossAttack4_1.Init(_CM, "Sprite/Boss/Boss_Attack4_1", IDResource.Boss_Attack4_1, 0, 9, 80.0f, new Vector2(-255, -15), new Vector2(-196, -15));
            m_BossAttack4_2.Init(_CM, "Sprite/Boss/Boss_Attack4_2", IDResource.Boss_Attack4_2, 0, 9, 80.0f, new Vector2(-255, 4), new Vector2(-196, 4));
            m_BossAttack4_3.Init(_CM, "Sprite/Boss/Boss_Attack4_3", IDResource.Boss_Attack4_3, 0, 9, 100.0f, new Vector2(-255, -15), new Vector2(-196, -15));
            m_BossAttack4_4.Init(_CM, "Sprite/Boss/Boss_Attack4_4", IDResource.Boss_Attack4_4, 0, 9, 100.0f, new Vector2(-255, -13), new Vector2(-196, -13));
            
            
            m_EffectBossAttack1_Hit.Init(_CM, "Sprite/Boss/Boss_Attack1_Hit", IDResource.Effect_Boss_Attack1_Hit, 0, 4, 100.0f);
            m_EffectBossAttack2_Hit.Init(_CM, "Sprite/Boss/Boss_Attack2_Hit", IDResource.Effect_Boss_Attack2_Hit, 0, 5, 100.0f);
            m_EffectBossAttack3_Hit.Init(_CM, "Sprite/Boss/Boss_Attack3_Hit", IDResource.Effect_Boss_Attack3_Hit, 0, 3, 100.0f);
            m_EffectBossAttack4_Hit.Init(_CM, "Sprite/Boss/Boss_Attack4_Hit", IDResource.Effect_Boss_Attack4_Hit, 0, 6, 100.0f);



            m_MasterMove.Init(_CM, "Sprite/Master/Master_Move", IDResource.Master_Move, 0, 3, 120.0f, new Vector2(48, +10), new Vector2(10, +10));
            m_MasterStand.Init(_CM, "Sprite/Master/Master_Stand", IDResource.Master_Stand, 0, 5, 80.0f, new Vector2(0, +5), new Vector2(0, +5));
            m_MasterHit.Init(_CM, "Sprite/Master/Master_Hit", IDResource.Master_Hit, 0, 0, 500.0f);
            m_MasterDie.Init(_CM, "Sprite/Master/Master_Die", IDResource.Master_Die, 0, 26, 200.0f, new Vector2(-51, -89), new Vector2(13, -89));
            m_MasterAttack1_1.Init(_CM, "Sprite/Master/Master_Attack1_1", IDResource.Master_Attack1_1, 0, 7, 80.0f, new Vector2(-357, -357), new Vector2(-320, -357));
            m_MasterAttack1_2.Init(_CM, "Sprite/Master/Master_Attack1_2", IDResource.Master_Attack1_2, 0, 7, 80.0f, new Vector2(-357, -357), new Vector2(-320, -357));
            m_MasterAttack1_3.Init(_CM, "Sprite/Master/Master_Attack1_3", IDResource.Master_Attack1_3, 0, 7, 80.0f, new Vector2(-357, -357), new Vector2(-320, -357));
            m_MasterAttack1_4.Init(_CM, "Sprite/Master/Master_Attack1_4", IDResource.Master_Attack1_4, 0, 4, 80.0f, new Vector2(-357, -357), new Vector2(-320, -357));
            m_MasterAttack2_1.Init(_CM, "Sprite/Master/Master_Attack2_1", IDResource.Master_Attack2_1, 0, 17, 80.0f, new Vector2(-194, -221), new Vector2(-116, -221));
            m_MasterAttack2_2.Init(_CM, "Sprite/Master/Master_Attack2_2", IDResource.Master_Attack2_2, 0, 13, 80.0f, new Vector2(-194, -221), new Vector2(-116, -221));
            m_MasterAttack3_1.Init(_CM, "Sprite/Master/Master_Attack3_1", IDResource.Master_Attack3_1, 0, 9, 80.0f, new Vector2(-588, -82), new Vector2(-26, -82));
            m_MasterAttack3_2.Init(_CM, "Sprite/Master/Master_Attack3_2", IDResource.Master_Attack3_2, 0, 9, 80.0f, new Vector2(-588, -82), new Vector2(-26, -82));
            m_MasterAttack4.Init(_CM, "Sprite/Master/Master_Attack4", IDResource.Master_Attack4, 0, 19, 80.0f, new Vector2(-221, -89), new Vector2(-119, -89));
            m_MasterAttack5.Init(_CM, "Sprite/Master/Master_Attack5", IDResource.Master_Attack5, 0, 19, 80.0f, new Vector2(-101, -215), new Vector2(-98, -215));

            m_EffectMasterAttack1_Hit.Init(_CM, "Sprite/Master/Master_Attack1_Hit", IDResource.Effect_Master_Attack1_Hit, 0, 5, 100.0f);
            m_EffectMasterAttack2_Hit.Init(_CM, "Sprite/Master/Master_Attack2_Hit", IDResource.Effect_Master_Attack2_Hit, 0, 6, 100.0f);
            m_EffectMasterAttack4_Hit.Init(_CM, "Sprite/Master/Master_Attack4_Hit", IDResource.Effect_Master_Attack4_Hit, 0, 6, 100.0f);

            m_EffectHeroAttack1_Ball.Init(_CM, "Sprite/Hero/Hero_Attack1_Ball", IDResource.Effect_Hero_Attack1_Ball, 0, 4, 75.0f);
            m_EffectHeroAttack2_Ball.Init(_CM, "Sprite/Hero/Hero_Attack2_Ball", IDResource.Effect_Hero_Attack2_Ball, 0, 2, 130.0f);
            m_EffectHeroAttack3_Ball.Init(_CM, "Sprite/Hero/Hero_Attack3_Ball", IDResource.Effect_Hero_Attack3_Ball, 0, 6, 130.0f);

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

            m_EffectHeroAttack4_Ball_Lv3.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball_Lv3", IDResource.Effect_Hero_Attack4_Ball_Lv3, 0, 17, 100.0f);
            m_EffectHeroAttack4_Ball1_Lv3.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball1_Lv3", IDResource.Effect_Hero_Attack4_Ball1_Lv3, 0, 15, 100.0f);
            m_EffectHeroAttack4_Ball2_Lv3.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball2_Lv3", IDResource.Effect_Hero_Attack4_Ball2_Lv3, 0, 15, 100.0f);
            m_EffectHeroAttack4_Ball3_Lv3.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball3_Lv3", IDResource.Effect_Hero_Attack4_Ball3_Lv3, 0, 15, 100.0f);
            m_EffectHeroAttack4_Ball4_Lv3.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball4_Lv3", IDResource.Effect_Hero_Attack4_Ball4_Lv3, 0, 15, 100.0f);
            m_EffectHeroAttack4_Ball5_Lv3.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball5_Lv3", IDResource.Effect_Hero_Attack4_Ball5_Lv3, 0, 15, 100.0f);
            m_EffectHeroAttack4_Ball6_Lv3.Init(_CM, "Sprite/Hero/Hero_Attack4_Ball6_Lv3", IDResource.Effect_Hero_Attack4_Ball6_Lv3, 0, 17, 100.0f);

            m_EffectHeroAttack1_Hit.Init(_CM, "Sprite/Hero/Hero_Attack1_Hit", IDResource.Effect_Hero_Attack1_Hit, 0, 5, 150.0f);
            m_EffectHeroAttack2_Hit.Init(_CM, "Sprite/Hero/Hero_Attack2_Hit", IDResource.Effect_Hero_Attack2_Hit, 0, 3, 150.0f);
            m_EffectHeroAttack3_Hit.Init(_CM, "Sprite/Hero/Hero_Attack3_Hit", IDResource.Effect_Hero_Attack3_Hit, 0, 4, 150.0f);

            m_Brick.Init(_CM, "Sprite/Brick", IDResource.Brick, 0, 0, 0.0f);
            m_BaseBrick.Init(_CM, "Sprite/BaseBrick", IDResource.BaseBrick, 0, 0, 0.0f);
            m_Barrel.Init(_CM, "Sprite/Barrel", IDResource.Barrel, 0, 0, 0.0f);
            #endregion
            #region Monster
            m_Monster_SnowManMove.Init(_CM, "Sprite/Monster/Monster_SnowMan_Move", IDResource.Monster_SnowMan_Move, 0, 3, 200.0f);
            m_Monster_SnowManHit.Init(_CM, "Sprite/Monster/Monster_SnowMan_Hit", IDResource.Monster_SnowMan_Hit, 0, 0, 800.0f, new Vector2(8, -6), new Vector2(8, -6));
            m_Monster_SnowManDie.Init(_CM, "Sprite/Monster/Monster_SnowMan_Die", IDResource.Monster_SnowMan_Die, 0, 6, 200.0f, new Vector2(-80, 4), new Vector2(-11, 4));
            m_Monster_SnowManAttack.Init(_CM, "Sprite/Monster/Monster_SnowMan_Attack", IDResource.Monster_SnowMan_Attack, 0, 8, 120.0f, new Vector2(-115, -75), new Vector2(0, -75));

            m_Monster_SnowManBlueMove.Init(_CM, "Sprite/Monster/Monster_SnowMan_Blue_Move", IDResource.Monster_SnowMan_Blue_Move, 0, 7, 200.0f);
            m_Monster_SnowManBlueHit.Init(_CM, "Sprite/Monster/Monster_SnowMan_Blue_Hit", IDResource.Monster_SnowMan_Blue_Hit, 0, 0, 800.0f, new Vector2(0, -29), new Vector2(0, -29));
            m_Monster_SnowManBlueDie.Init(_CM, "Sprite/Monster/Monster_SnowMan_Blue_Die", IDResource.Monster_SnowMan_Blue_Die, 0, 22, 200.0f, new Vector2(-81, -34), new Vector2(-107, -34));
            m_Monster_SnowManBlueAttack.Init(_CM, "Sprite/Monster/Monster_SnowMan_Blue_Attack", IDResource.Monster_SnowMan_Blue_Attack, 0, 20, 120.0f, new Vector2(-134, -71), new Vector2(42, -71));

            m_Monster_SnowManPurpleMove.Init(_CM, "Sprite/Monster/Monster_SnowMan_Purple_Move", IDResource.Monster_SnowMan_Purple_Move, 0, 7, 200.0f);
            m_Monster_SnowManPurpleHit.Init(_CM, "Sprite/Monster/Monster_SnowMan_Purple_Hit", IDResource.Monster_SnowMan_Purple_Hit, 0, 0, 800.0f, new Vector2(0, -29), new Vector2(0, -29));
            m_Monster_SnowManPurpleDie.Init(_CM, "Sprite/Monster/Monster_SnowMan_Purple_Die", IDResource.Monster_SnowMan_Purple_Die, 0, 22, 200.0f, new Vector2(-82, -34), new Vector2(-302, -34));
            m_Monster_SnowManPurpleAttack.Init(_CM, "Sprite/Monster/Monster_SnowMan_Purple_Attack", IDResource.Monster_SnowMan_Purple_Attack, 0, 20, 120.0f, new Vector2(-163, -61), new Vector2(2, -61));

            m_Monster_SnowManRedMove.Init(_CM, "Sprite/Monster/Monster_SnowMan_Red_Move", IDResource.Monster_SnowMan_Red_Move, 0, 3, 200.0f);
            m_Monster_SnowManRedHit.Init(_CM, "Sprite/Monster/Monster_SnowMan_Red_Hit", IDResource.Monster_SnowMan_Red_Hit, 0, 0, 800.0f, new Vector2(7, -39), new Vector2(-7, -39));
            m_Monster_SnowManRedDie.Init(_CM, "Sprite/Monster/Monster_SnowMan_Red_Die", IDResource.Monster_SnowMan_Red_Die, 0, 6, 200.0f, new Vector2(-79, -17), new Vector2(-32, -17));
            m_Monster_SnowManRedAttack.Init(_CM, "Sprite/Monster/Monster_SnowMan_Red_Attack", IDResource.Monster_SnowMan_Red_Attack, 0, 8, 120.0f, new Vector2(-99, -59), new Vector2(1, -59));

            m_Monster_SnowManLadyMove.Init(_CM, "Sprite/Monster/Monster_SnowMan_Lady_Move", IDResource.Monster_SnowMan_Lady_Move, 0, 7, 100.0f, new Vector2(0, 5), new Vector2(0, 5));
            m_Monster_SnowManLadyHit.Init(_CM, "Sprite/Monster/Monster_SnowMan_Lady_Hit", IDResource.Monster_SnowMan_Lady_Hit, 0, 0, 800.0f, new Vector2(-27, -4), new Vector2(-16, -4));
            m_Monster_SnowManLadyDie.Init(_CM, "Sprite/Monster/Monster_SnowMan_Lady_Die", IDResource.Monster_SnowMan_Lady_Die, 0, 10, 200.0f, new Vector2(-45, -11), new Vector2(-27, -11));
            m_Monster_SnowManLadyAttack.Init(_CM, "Sprite/Monster/Monster_SnowMan_Lady_Attack", IDResource.Monster_SnowMan_Lady_Attack, 0, 7, 120.0f, new Vector2(-61, 6), new Vector2(-27, 6));

            m_Monster_MiniClown_Move.Init(_CM, "Sprite/Monster/Monster_MiniClown_Move", IDResource.Monster_MiniClown_Move, 0, 5, 200.0f, new Vector2(0, 7), new Vector2(0, 7));
            m_Monster_MiniClown_Hit.Init(_CM, "Sprite/Monster/Monster_MiniClown_Hit", IDResource.Monster_MiniClown_Hit, 0, 0, 800.0f, new Vector2(0, 7), new Vector2(0, 7));
            m_Monster_MiniClown_Die.Init(_CM, "Sprite/Monster/Monster_MiniClown_Die", IDResource.Monster_MiniClown_Die, 0, 5, 200.0f, new Vector2(-12, -12), new Vector2(-5, -12));
            m_Monster_MiniClown_Attack.Init(_CM, "Sprite/Monster/Monster_MiniClown_Attack", IDResource.Monster_MiniClown_Attack, 0, 11, 120.0f, new Vector2(-7, 7), new Vector2(-7, 7));

            m_Monster_BigClown_Move.Init(_CM, "Sprite/Monster/Monster_BigClown_Move", IDResource.Monster_BigClown_Move, 0, 5, 200.0f);
            m_Monster_BigClown_Hit.Init(_CM, "Sprite/Monster/Monster_BigClown_Hit", IDResource.Monster_BigClown_Hit, 0, 0, 800.0f, new Vector2(0, 0), new Vector2(0, 0));
            m_Monster_BigClown_Die.Init(_CM, "Sprite/Monster/Monster_BigClown_Die", IDResource.Monster_BigClown_Die, 0, 6, 200.0f, new Vector2(2, -7), new Vector2(2, -7));
            m_Monster_BigClown_Attack.Init(_CM, "Sprite/Monster/Monster_BigClown_Attack", IDResource.Monster_BigClown_Attack, 0, 14, 120.0f, new Vector2(-17, -80), new Vector2(-3, -80));

            m_Monster_YellowBean_Move.Init(_CM, "Sprite/Monster/Monster_YellowBean_Move", IDResource.Monster_YellowBean_Move, 0, 5, 200.0f);
            m_Monster_YellowBean_Hit.Init(_CM, "Sprite/Monster/Monster_YellowBean_Hit", IDResource.Monster_YellowBean_Hit, 0, 0, 800.0f, new Vector2(0, 0), new Vector2(0, 0));
            m_Monster_YellowBean_Die.Init(_CM, "Sprite/Monster/Monster_YellowBean_Die", IDResource.Monster_YellowBean_Die, 0, 7, 200.0f, new Vector2(-8, 7), new Vector2(-1, 7));
            m_Monster_YellowBean_Attack1.Init(_CM, "Sprite/Monster/Monster_YellowBean_Attack1", IDResource.Monster_YellowBean_Attack1, 0, 21, 120.0f, new Vector2(-11, -25), new Vector2(-2, -25));
            m_Monster_YellowBean_Attack2.Init(_CM, "Sprite/Monster/Monster_YellowBean_Attack2", IDResource.Monster_YellowBean_Attack2, 0, 14, 120.0f, new Vector2(-25, -19), new Vector2(-43, -19));

            m_Monster_Shark_Move.Init(_CM, "Sprite/Monster/Monster_Shark_Move", IDResource.Monster_Shark_Move, 0, 7, 200.0f);
            m_Monster_Shark_Hit.Init(_CM, "Sprite/Monster/Monster_Shark_Hit", IDResource.Monster_Shark_Hit, 0, 0, 800.0f, new Vector2(-17, 0), new Vector2(-14, 0));
            m_Monster_Shark_Die.Init(_CM, "Sprite/Monster/Monster_Shark_Die", IDResource.Monster_Shark_Die, 0, 5, 200.0f, new Vector2(-27, -5), new Vector2(-5, -5));
            m_Monster_Shark_Attack.Init(_CM, "Sprite/Monster/Monster_Shark_Attack", IDResource.Monster_Shark_Attack, 0, 8, 120.0f, new Vector2(-95, -24), new Vector2(-4, -24));

            m_Monster_WolfMan_Move.Init(_CM, "Sprite/Monster/Monster_WolfMan_Move", IDResource.Monster_WolfMan_Move, 0, 8, 200.0f);
            m_Monster_WolfMan_Hit.Init(_CM, "Sprite/Monster/Monster_WolfMan_Hit", IDResource.Monster_WolfMan_Hit, 0, 0, 800.0f, new Vector2(5, -11), new Vector2(3, -11));
            m_Monster_WolfMan_Die.Init(_CM, "Sprite/Monster/Monster_WolfMan_Die", IDResource.Monster_WolfMan_Die, 0, 6, 200.0f, new Vector2(7, -18), new Vector2(77, -18));
            m_Monster_WolfMan_Attack.Init(_CM, "Sprite/Monster/Monster_WolfMan_Attack", IDResource.Monster_WolfMan_Attack, 0, 14, 120.0f, new Vector2(-79, -35), new Vector2(-71, -35));

            m_Monster_OldPanda_Move.Init(_CM, "Sprite/Monster/Monster_OldPanda_Move", IDResource.Monster_OldPanda_Move, 0, 7, 200.0f);
            m_Monster_OldPanda_Hit.Init(_CM, "Sprite/Monster/Monster_OldPanda_Hit", IDResource.Monster_OldPanda_Hit, 0, 0, 800.0f, new Vector2(22, -3), new Vector2(-19, -3));
            m_Monster_OldPanda_Die.Init(_CM, "Sprite/Monster/Monster_OldPanda_Die", IDResource.Monster_OldPanda_Die, 0, 23, 200.0f, new Vector2(0, -290), new Vector2(-152, -290));
            m_Monster_OldPanda_Attack.Init(_CM, "Sprite/Monster/Monster_OldPanda_Attack", IDResource.Monster_OldPanda_Attack, 0, 26, 120.0f, new Vector2(-100, -127), new Vector2(-98, -127));

            m_Monster_WolfOwl_Move.Init(_CM, "Sprite/Monster/Monster_WolfOwl_Move", IDResource.Monster_WolfOwl_Move, 0, 5, 80.0f, new Vector2(0, +5), new Vector2(0, +5));
            m_Monster_WolfOwl_Hit.Init(_CM, "Sprite/Monster/Monster_WolfOwl_Hit", IDResource.Monster_WolfOwl_Hit, 0, 0, 800.0f, new Vector2(1, 0), new Vector2(26, 0));
            m_Monster_WolfOwl_Die.Init(_CM, "Sprite/Monster/Monster_WolfOwl_Die", IDResource.Monster_WolfOwl_Die, 0, 8, 200.0f, new Vector2(-7, 0), new Vector2(-40, 0));
            m_Monster_WolfOwl_Attack1.Init(_CM, "Sprite/Monster/Monster_WolfOwl_Attack1", IDResource.Monster_WolfOwl_Attack1, 0, 8, 90.0f, new Vector2(-34, 12), new Vector2(-45, 12));
            m_Monster_WolfOwl_Attack2.Init(_CM, "Sprite/Monster/Monster_WolfOwl_Attack2", IDResource.Monster_WolfOwl_Attack2, 0, 13, 90.0f, new Vector2(-45, -17), new Vector2(-64, -17));

            m_Monster_WolfOrc_Move.Init(_CM, "Sprite/Monster/Monster_WolfOrc_Move", IDResource.Monster_WolfOrc_Move, 0, 5, 200.0f);
            m_Monster_WolfOrc_Hit.Init(_CM, "Sprite/Monster/Monster_WolfOrc_Hit", IDResource.Monster_WolfOrc_Hit, 0, 0, 800.0f, new Vector2(12, 10), new Vector2(-2, 10));
            m_Monster_WolfOrc_Die.Init(_CM, "Sprite/Monster/Monster_WolfOrc_Die", IDResource.Monster_WolfOrc_Die, 0, 17, 200.0f, new Vector2(-151, -4), new Vector2(-63, -4));
            m_Monster_WolfOrc_Attack1.Init(_CM, "Sprite/Monster/Monster_WolfOrc_Attack1", IDResource.Monster_WolfOrc_Attack1, 0, 24, 120.0f, new Vector2(-88, -137), new Vector2(-26, -137));
            m_Monster_WolfOrc_Attack2.Init(_CM, "Sprite/Monster/Monster_WolfOrc_Attack2", IDResource.Monster_WolfOrc_Attack2, 0, 24, 120.0f, new Vector2(-94, 0), new Vector2(-33, 0));

            #endregion
            m_Item_Clover.Init(_CM, "Sprite/Item/Item_Clover", IDResource.Item_Clover, 0, 1, 200.0f);
            m_Item_Cuddly_Penguin.Init(_CM, "Sprite/Item/Item_Cuddly_Penguin", IDResource.Item_Cuddly_Penguin, 0, 0, 200.0f);
            m_Item_Diamond.Init(_CM, "Sprite/Item/Item_Diamond", IDResource.Item_Diamond, 0, 0, 200.0f);
            m_Item_Fire_Box.Init(_CM, "Sprite/Item/Item_Fire_Box", IDResource.Item_Fire_Box, 0, 0, 200.0f);
            m_Item_Ice_Box.Init(_CM, "Sprite/Item/Item_Ice_Box", IDResource.Item_Ice_Box, 0, 0, 200.0f);
            m_Item_Key.Init(_CM, "Sprite/Item/Item_Key", IDResource.Item_Key, 0, 0, 200.0f);
            m_Item_Lemon_Juice.Init(_CM, "Sprite/Item/Item_Lemon_Juice", IDResource.Item_Lemon_Juice, 0, 0, 200.0f);
            m_Item_Water.Init(_CM, "Sprite/Item/Item_Water", IDResource.Item_Water, 0, 0, 200.0f);
            m_Item_Gold_1.Init(_CM, "Sprite/Item/Item_Gold_1", IDResource.Item_Gold_1, 0, 0, 200.0f);
            m_Item_Gold_2.Init(_CM, "Sprite/Item/Item_Gold_2", IDResource.Item_Gold_2, 0, 0, 200.0f);
            m_Item_Gold_3.Init(_CM, "Sprite/Item/Item_Gold_3", IDResource.Item_Gold_3, 0, 0, 200.0f);
            m_Item_Gold_4.Init(_CM, "Sprite/Item/Item_Gold_4", IDResource.Item_Gold_4, 0, 0, 200.0f);
            m_Item_Hp_Potion_1.Init(_CM, "Sprite/Item/Item_Hp_Potion_1", IDResource.Item_Hp_Potion_1, 0, 0, 200.0f);
            m_Item_Hp_Potion_2.Init(_CM, "Sprite/Item/Item_Hp_Potion_2", IDResource.Item_Hp_Potion_2, 0, 0, 200.0f);
            m_Item_Hp_Potion_3.Init(_CM, "Sprite/Item/Item_Hp_Potion_3", IDResource.Item_Hp_Potion_3, 0, 0, 200.0f);
            m_Item_Mana_Potion_1.Init(_CM, "Sprite/Item/Item_Mana_Potion_1", IDResource.Item_Mana_Potion_1, 0, 0, 200.0f);
            m_Item_Mana_Potion_2.Init(_CM, "Sprite/Item/Item_Mana_Potion_2", IDResource.Item_Mana_Potion_2, 0, 0, 200.0f);
            m_Item_Mana_Potion_3.Init(_CM, "Sprite/Item/Item_Mana_Potion_3", IDResource.Item_Mana_Potion_3, 0, 0, 200.0f);
            m_LOSE.Init(_CM, @"Image\LOSE", IDResource.LOSE, 0, 19, 200.0f);
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
                #region Without Monster
                case IDResource.Player_Stand:
                    return m_PlayerStand;
                case IDResource.Player_Move:
                    return m_PlayerMove;
                case IDResource.Player_Jump:
                    return m_PlayerJump;
                case IDResource.Player_Die:
                    return m_PlayerDie;
                case IDResource.Master_Move:
                    return m_MasterMove;
                case IDResource.Master_Stand:
                    return m_MasterStand;
                case IDResource.Master_Hit:
                    return m_MasterHit;
                case IDResource.Master_Die:
                    return m_MasterDie;
                case IDResource.Master_Attack1_1:
                    return m_MasterAttack1_1;
                case IDResource.Master_Attack1_2:
                    return m_MasterAttack1_2;
                case IDResource.Master_Attack1_3:
                    return m_MasterAttack1_3;
                case IDResource.Master_Attack1_4:
                    return m_MasterAttack1_4;
                case IDResource.Master_Attack2_1:
                    return m_MasterAttack2_1;
                case IDResource.Master_Attack2_2:
                    return m_MasterAttack2_2;
                case IDResource.Master_Attack3_1:
                    return m_MasterAttack3_1;
                case IDResource.Master_Attack3_2:
                    return m_MasterAttack3_2;
                case IDResource.Master_Attack4:
                    return m_MasterAttack4;
                case IDResource.Master_Attack5:
                    return m_MasterAttack5;
                case IDResource.Effect_Master_Attack1_Hit:
                    return m_EffectMasterAttack1_Hit;
                case IDResource.Effect_Master_Attack2_Hit:
                    return m_EffectMasterAttack2_Hit;
                case IDResource.Effect_Master_Attack4_Hit:
                    return m_EffectMasterAttack4_Hit;

                case IDResource.Boss_Move:
                    return m_BossMove;
                case IDResource.Boss_Stand:
                    return m_BossStand;
                case IDResource.Boss_Stand2:
                    return m_BossStand2;
                case IDResource.Boss_Transform1:
                    return m_BossTransform1;
                case IDResource.Boss_Transform2:
                    return m_BossTransform2;
                case IDResource.Boss_Hit:
                    return m_BossHit;
                case IDResource.Boss_Die1:
                    return m_BossDie1;
                case IDResource.Boss_Die2:
                    return m_BossDie2;
                case IDResource.Boss_Die3:
                    return m_BossDie3;
                case IDResource.Boss_Attack1_1:
                    return m_BossAttack1_1;
                case IDResource.Boss_Attack1_2:
                    return m_BossAttack1_2;
                case IDResource.Boss_Attack2_1:
                    return m_BossAttack2_1;
                case IDResource.Boss_Attack2_2:
                    return m_BossAttack2_2;
                case IDResource.Boss_Attack3:
                    return m_BossAttack3;
                case IDResource.Boss_Attack4_1:
                    return m_BossAttack4_1;
                case IDResource.Boss_Attack4_2:
                    return m_BossAttack4_2;
                case IDResource.Boss_Attack4_3:
                    return m_BossAttack4_3;
                case IDResource.Boss_Attack4_4:
                    return m_BossAttack4_4;

                case IDResource.Effect_Boss_Attack1_Hit:
                    return m_EffectBossAttack1_Hit;
                case IDResource.Effect_Boss_Attack2_Hit:
                    return m_EffectBossAttack2_Hit;
                case IDResource.Effect_Boss_Attack3_Hit:
                    return m_EffectBossAttack3_Hit;
                case IDResource.Effect_Boss_Attack4_Hit:
                    return m_EffectBossAttack4_Hit;

                case IDResource.Brick:
                    return m_Brick;
                case IDResource.BaseBrick:
                    return m_BaseBrick;
                case IDResource.Barrel:
                    return m_Barrel;

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
                case IDResource.Effect_Hero_Attack2_Ball:
                    return m_EffectHeroAttack2_Ball;
                case IDResource.Effect_Hero_Attack3_Ball:
                    return m_EffectHeroAttack3_Ball;
                case IDResource.Effect_Hero_Attack1_Hit:
                    return m_EffectHeroAttack1_Hit;
                case IDResource.Effect_Hero_Attack2_Hit:
                    return m_EffectHeroAttack2_Hit;
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
                #endregion
                #region Monster
                case IDResource.Monster_SnowMan_Move:
                    return m_Monster_SnowManMove;
                case IDResource.Monster_SnowMan_Attack:
                    return m_Monster_SnowManAttack;
                case IDResource.Monster_SnowMan_Hit:
                    return m_Monster_SnowManHit;
                case IDResource.Monster_SnowMan_Die:
                    return m_Monster_SnowManDie;

                case IDResource.Monster_SnowMan_Blue_Move:
                    return m_Monster_SnowManBlueMove;
                case IDResource.Monster_SnowMan_Blue_Attack:
                    return m_Monster_SnowManBlueAttack;
                case IDResource.Monster_SnowMan_Blue_Hit:
                    return m_Monster_SnowManBlueHit;
                case IDResource.Monster_SnowMan_Blue_Die:
                    return m_Monster_SnowManBlueDie;
                case IDResource.Monster_SnowMan_Purple_Move:
                    return m_Monster_SnowManPurpleMove;
                case IDResource.Monster_SnowMan_Purple_Attack:
                    return m_Monster_SnowManPurpleAttack;
                case IDResource.Monster_SnowMan_Purple_Hit:
                    return m_Monster_SnowManPurpleHit;
                case IDResource.Monster_SnowMan_Purple_Die:
                    return m_Monster_SnowManPurpleDie;
                case IDResource.Monster_SnowMan_Red_Move:
                    return m_Monster_SnowManRedMove;
                case IDResource.Monster_SnowMan_Red_Attack:
                    return m_Monster_SnowManRedAttack;
                case IDResource.Monster_SnowMan_Red_Hit:
                    return m_Monster_SnowManRedHit;
                case IDResource.Monster_SnowMan_Red_Die:
                    return m_Monster_SnowManRedDie;
                case IDResource.Monster_SnowMan_Lady_Move:
                    return m_Monster_SnowManLadyMove;
                case IDResource.Monster_SnowMan_Lady_Attack:
                    return m_Monster_SnowManLadyAttack;
                case IDResource.Monster_SnowMan_Lady_Hit:
                    return m_Monster_SnowManLadyHit;
                case IDResource.Monster_SnowMan_Lady_Die:
                    return m_Monster_SnowManLadyDie;

                case IDResource.Monster_BigClown_Move:
                    return m_Monster_BigClown_Move;
                case IDResource.Monster_BigClown_Attack:
                    return m_Monster_BigClown_Attack;
                case IDResource.Monster_BigClown_Hit:
                    return m_Monster_BigClown_Hit;
                case IDResource.Monster_BigClown_Die:
                    return m_Monster_BigClown_Die;

                case IDResource.Monster_MiniClown_Move:
                    return m_Monster_MiniClown_Move;
                case IDResource.Monster_MiniClown_Attack:
                    return m_Monster_MiniClown_Attack;
                case IDResource.Monster_MiniClown_Hit:
                    return m_Monster_MiniClown_Hit;
                case IDResource.Monster_MiniClown_Die:
                    return m_Monster_MiniClown_Die;

                case IDResource.Monster_YellowBean_Move:
                    return m_Monster_YellowBean_Move;
                case IDResource.Monster_YellowBean_Attack1:
                    return m_Monster_YellowBean_Attack1;
                case IDResource.Monster_YellowBean_Attack2:
                    return m_Monster_YellowBean_Attack2;
                case IDResource.Monster_YellowBean_Hit:
                    return m_Monster_YellowBean_Hit;
                case IDResource.Monster_YellowBean_Die:
                    return m_Monster_YellowBean_Die;

                case IDResource.Monster_Shark_Move:
                    return m_Monster_Shark_Move;
                case IDResource.Monster_Shark_Attack:
                    return m_Monster_Shark_Attack;
                case IDResource.Monster_Shark_Hit:
                    return m_Monster_Shark_Hit;
                case IDResource.Monster_Shark_Die:
                    return m_Monster_Shark_Die;

                case IDResource.Monster_WolfMan_Move:
                    return m_Monster_WolfMan_Move;
                case IDResource.Monster_WolfMan_Attack:
                    return m_Monster_WolfMan_Attack;
                case IDResource.Monster_WolfMan_Hit:
                    return m_Monster_WolfMan_Hit;
                case IDResource.Monster_WolfMan_Die:
                    return m_Monster_WolfMan_Die;

                case IDResource.Monster_WolfOrc_Move:
                    return m_Monster_WolfOrc_Move;
                case IDResource.Monster_WolfOrc_Attack1:
                    return m_Monster_WolfOrc_Attack1;
                case IDResource.Monster_WolfOrc_Attack2:
                    return m_Monster_WolfOrc_Attack2;
                case IDResource.Monster_WolfOrc_Hit:
                    return m_Monster_WolfOrc_Hit;
                case IDResource.Monster_WolfOrc_Die:
                    return m_Monster_WolfOrc_Die;

                case IDResource.Monster_WolfOwl_Move:
                    return m_Monster_WolfOwl_Move;
                case IDResource.Monster_WolfOwl_Attack1:
                    return m_Monster_WolfOwl_Attack1;
                case IDResource.Monster_WolfOwl_Attack2:
                    return m_Monster_WolfOwl_Attack2;
                case IDResource.Monster_WolfOwl_Hit:
                    return m_Monster_WolfOwl_Hit;
                case IDResource.Monster_WolfOwl_Die:
                    return m_Monster_WolfOwl_Die;

                case IDResource.Monster_OldPanda_Move:
                    return m_Monster_OldPanda_Move;
                case IDResource.Monster_OldPanda_Attack:
                    return m_Monster_OldPanda_Attack;
                case IDResource.Monster_OldPanda_Hit:
                    return m_Monster_OldPanda_Hit;
                case IDResource.Monster_OldPanda_Die:
                    return m_Monster_OldPanda_Die;
                #endregion
                case IDResource.Item_Clover:
                    return m_Item_Clover;
                case IDResource.Item_Cuddly_Penguin:
                    return m_Item_Cuddly_Penguin;
                case IDResource.Item_Diamond:
                    return m_Item_Diamond;
                case IDResource.Item_Fire_Box:
                    return m_Item_Fire_Box;
                case IDResource.Item_Ice_Box:
                    return m_Item_Ice_Box;
                case IDResource.Item_Key:
                    return m_Item_Key;
                case IDResource.Item_Lemon_Juice:
                    return m_Item_Lemon_Juice;
                case IDResource.Item_Water:
                    return m_Item_Water;
                case IDResource.Item_Gold_1:
                    return m_Item_Gold_1;
                case IDResource.Item_Gold_2:
                    return m_Item_Gold_2;
                case IDResource.Item_Gold_3:
                    return m_Item_Gold_3;
                case IDResource.Item_Gold_4:
                    return m_Item_Gold_4;
                case IDResource.Item_Hp_Potion_1:
                    return m_Item_Hp_Potion_1;
                case IDResource.Item_Hp_Potion_2:
                    return m_Item_Hp_Potion_2;
                case IDResource.Item_Hp_Potion_3:
                    return m_Item_Hp_Potion_3;
                case IDResource.Item_Mana_Potion_1:
                    return m_Item_Mana_Potion_1;
                case IDResource.Item_Mana_Potion_2:
                    return m_Item_Mana_Potion_2;
                case IDResource.Item_Mana_Potion_3:
                    return m_Item_Mana_Potion_3;
                case IDResource.LOSE:
                    return m_LOSE;
            }
            return null;
        }
    }
}
