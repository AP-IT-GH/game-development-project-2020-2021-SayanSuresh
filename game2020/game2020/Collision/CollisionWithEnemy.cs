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
        public int i { get; set; } = 0;
        public void HandleHeroSpawn(ICheckCollision collision, ITransform heroTransform)
        {
            if (collision.CollisionWithBot)
                heroTransform.Position = new Vector2(200, 30);
            //Debug.WriteLine($"testi{i++}");
            //else
            //heroTransform.Position = new Vector2(30, 30);
        }
    }
}
