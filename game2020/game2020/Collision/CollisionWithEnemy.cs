using game2020.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace game2020.Collision
{
    public class CollisionWithEnemy 
    {
        public void HandleHeroSpawn(ICheckCollision collision, ITransform heroTransform)
        {
            if (collision.CollisionWithBot)
                heroTransform.Position = new Vector2(200, 30);
        }
    }
}
