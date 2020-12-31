using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Interfaces
{
    public interface ICollisionEntity
    {
        Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public bool HasJumped { get; set; }
    }
}
