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
        public bool IsInteracting { get; set; }

        public void Handle(ICollisionWith collision, ITransform transform)
        {
            if (collision.IsCollision)
            {
                IsInteracting = true;
                transform.Position = new Vector2(0, 30);
            }
        }
    }
}
