using game2020.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Collision
{
    class CollisionManager 
    {
        public CollisionManager() { }
        public CollisionManager(ICollisionHelper helper)
        {
            this.collisionhelper = helper;
        }

        private ICollisionHelper collisionhelper;

        public void ExecuteCollision(Rectangle playerRec, Rectangle newRectangle, int xOffset, int yOffset, ICollisionEntity transform)
        {
            if (collisionhelper.CollisionTopOf(playerRec, newRectangle))
            {
                playerRec.Y = newRectangle.Y - playerRec.Height;
                transform.Velocity = new Vector2(transform.Velocity.X, 0f);
                transform.HasJumped = false;
            }

            if (collisionhelper.CollisionLeftOf(playerRec, newRectangle))
                transform.Position = new Vector2(newRectangle.X - playerRec.Width - 2, transform.Position.Y);

            if (collisionhelper.CollisionRightOf(playerRec, newRectangle))
                transform.Position = new Vector2(newRectangle.X + playerRec.Width + 2, transform.Position.Y);

            if (collisionhelper.CollisionBottomOf(playerRec, newRectangle))
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

        //public bool CheckCollision(Rectangle rect1, Rectangle rect2)
        //{
        //    if (rect1.Intersects(rect1))
        //    {
        //        return true;
        //    }
        //    else
        //    return false;
        //}
    }
}
