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


namespace FindingPrincess.Framework
{
    public static class CInput
    {
        public static KeyboardState m_CurrentState = Keyboard.GetState();
        public static KeyboardState m_LastState;
        public static void Update()
        {
            m_LastState = m_CurrentState;
            m_CurrentState = Keyboard.GetState();
        }
        // Kiem tra key co vua dc nhan ( hien k nhan ) k
        public static bool KeyUnPressed(Keys _Key)
        {
            return (m_CurrentState.IsKeyUp(_Key) && m_LastState.IsKeyDown(_Key));
        }
        // Kiem tra key chi nhan 1 lan k ( dung cho skill..,neu giu nut nhan thi false )
        public static bool KeyPressed(Keys _Key)
        {
            return ( m_CurrentState.IsKeyDown(_Key) && m_LastState.IsKeyUp(_Key) );
        }
        // Kiem tra key nhan lien tuc ( dung cho di chuyen )
        public static bool KeyDown(Keys _Key)
        {
            return (m_CurrentState.IsKeyDown(_Key));
        }
    }
}
