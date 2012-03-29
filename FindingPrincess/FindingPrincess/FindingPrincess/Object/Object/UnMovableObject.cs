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
    public class UnMovableObject : GameObject
    {
        const int _DELAY = 1000000;
        
        public UnMovableObject(IDObject _id, Vector2 _pos)
        {
            _IDObject = _id;
            switch(_IDObject)
            {
                case IDObject.TER:
                    _curAnimation = new Animation(IDResource.TER, _DELAY, IDirect.LEFT);
                    break;
                case IDObject.TER_LEFT:
                    _curAnimation = new Animation(IDResource.TER_LEFT, _DELAY, IDirect.LEFT);
                    break;
                case IDObject.TER_RIGHT:
                    _curAnimation = new Animation(IDResource.TER_RIGHT, _DELAY, IDirect.LEFT);
                    break;
            }
            _position = _pos;
        }
    }
}
