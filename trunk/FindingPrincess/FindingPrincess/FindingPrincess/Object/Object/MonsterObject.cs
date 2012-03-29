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


namespace FindingPrincess.Object
{
    public class MonsterObject : MovableObject
    {
        protected List<Skill> _skillList;
        protected Skill _activeSkill;

        public MonsterObject(Vector2 _pos)
            : base(_pos, Vector2.Zero, Vector2.Zero)
        {
            _skillList = new List<Skill>();
        }
    }
}
