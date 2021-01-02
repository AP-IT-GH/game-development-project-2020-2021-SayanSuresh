using game2020.Commands;
using game2020.Interfaces;
using Microsoft.Xna.Framework;
using RefactoringCol;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Collision
{
    class CollisionManager : ICheckCollision
    {
        public bool CollisionWithBot { get; set; }
        public CollisionManager() { }
        public CollisionManager(ICollisionHelper helper)
        {
            this.collisionhelper = helper;
        }

        private ICollisionHelper collisionhelper;

        public void UpdateCollision(Rectangle playerRec, Rectangle tileRectangle, int xOffset, int yOffset, ICollisionEntity transform)
        {
            if (collisionhelper.CollisionTopOf(playerRec, tileRectangle))
            {
                playerRec.Y = tileRectangle.Y - playerRec.Height;
                transform.Velocity = new Vector2(transform.Velocity.X, 0f);
                transform.HasJumped = false;
            }

            if (collisionhelper.CollisionLeftOf(playerRec, tileRectangle))
                transform.Position = new Vector2(tileRectangle.X - playerRec.Width - 2, transform.Position.Y);

            if (collisionhelper.CollisionRightOf(playerRec, tileRectangle))
                transform.Position = new Vector2(tileRectangle.X + playerRec.Width + 2, transform.Position.Y);

            if (collisionhelper.CollisionBottomOf(playerRec, tileRectangle))
                transform.Velocity = new Vector2(transform.Velocity.X, 7f);


            // Trap hero inside window borders 
            if (transform.Position.X < 0)
                transform.Position = new Vector2(0, transform.Position.Y);

            if (transform.Position.X > xOffset - playerRec.Width)
                transform.Position = new Vector2(xOffset - playerRec.Width, transform.Position.Y);

            if (transform.Position.Y < 0)
                transform.Velocity = new Vector2(transform.Velocity.X, 7.5f);

            if (transform.Position.Y > yOffset - playerRec.Height)
                transform.Position = new Vector2(transform.Position.X, yOffset - playerRec.Height);
        }

        public bool CheckCollision(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.Intersects(rect2))
            {
                CollisionWithBot = true;
                return true;
            }

            CollisionWithBot = false;
            return false;
        }
    }
}
