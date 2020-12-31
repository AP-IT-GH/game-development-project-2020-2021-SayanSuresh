using game2020.Commands;
using game2020.Interfaces;
using Microsoft.Xna.Framework;
using RefactoringCol;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Collision
{
    class CollisionManager 
    {
        private ICollisionHelper collisionhelper;

        //public bool HasJumped { get ; set ; }
        //public Vector2 Velocity { get ; set ; }
        //public Vector2 Position { get ; set ; }

        public CollisionManager() { }
        public CollisionManager(ICollisionHelper helper)
        {
            this.collisionhelper = helper;
        }

        //Rectangle playerRec;
        //Rectangle newRectangle;
        //int xOffset;
        //int yOffset;


        //public bool IsJumping(Rectangle playerRec, Rectangle newRectangle)
        //{
        //    if (collisionhelper.CollisionTopOf(playerRec, newRectangle))
        //         return false;
        //    return true;
        //}

        //public void CheckUpdate(bool jump, Vector2 velocity, Vector2 position)
        //{
        //    this.HasJumped = jump;
        //    this.Velocity = velocity;
        //    this.Position = position;
        //}

        public void ExecuteCollision(Rectangle playerRec, Rectangle newRectangle, int xOffset, int yOffset, IMove bla)
        {
            if (collisionhelper.CollisionTopOf(playerRec, newRectangle))
            {
                playerRec.Y = newRectangle.Y - playerRec.Height;
                bla.Velocity = new Vector2(bla.Velocity.X, 0f);
                bla.HasJumped = false;
            }

            if (collisionhelper.CollisionLeftOf(playerRec, newRectangle))
                bla.Position = new Vector2(newRectangle.X - playerRec.Width - 2, bla.Position.Y);

            if (collisionhelper.CollisionRightOf(playerRec, newRectangle))
                bla.Position = new Vector2(newRectangle.X + playerRec.Width + 2, bla.Position.Y);

            if (collisionhelper.CollisionBottomOf(playerRec, newRectangle))
                bla.Velocity = new Vector2(bla.Velocity.X, 7f);


            // Trap hero inside window borders 
            if (bla.Position.X < 0)
                bla.Position = new Vector2(0, bla.Position.Y);

            if (bla.Position.X > xOffset - playerRec.Width)
                bla.Position = new Vector2(xOffset - playerRec.Width, bla.Position.Y);

            if (bla.Position.Y < 0)
                bla.Velocity = new Vector2(bla.Velocity.X, 7.5f);

            if (bla.Position.Y > yOffset - playerRec.Height)
                bla.Position = new Vector2(bla.Position.X, yOffset - playerRec.Height);
        }



        //public void CheckCollision(Rectangle playerRec, Rectangle newRectangle, int xOffset, int yOffset)
        //{
        //    this.playerRec = playerRec;
        //    this.newRectangle = newRectangle;
        //    this.xOffset = xOffset;
        //    this.yOffset = yOffset;
        //}

        //public void ExecuteCollision(ITransform transform, IMove bla)
        //{
        //    if (collisionhelper.CollisionTopOf(playerRec, newRectangle))
        //    {
        //        playerRec.Y = newRectangle.Y - playerRec.Height;
        //        bla.Velocity = new Vector2(bla.Velocity.X, 0f);
        //        bla.HasJumped = false;
        //    }

        //    if (collisionhelper.CollisionLeftOf(playerRec, newRectangle))
        //        transform.Position = new Vector2(newRectangle.X - playerRec.Width - 2, transform.Position.Y);

        //    if (collisionhelper.CollisionRightOf(playerRec, newRectangle))
        //        transform.Position = new Vector2(newRectangle.X + playerRec.Width + 2, transform.Position.Y);

        //    if (collisionhelper.CollisionBottomOf(playerRec, newRectangle))
        //        bla.Velocity = new Vector2(bla.Velocity.X, 7f);


        //    // Trap hero inside window borders 
        //    if (transform.Position.X < 0)
        //        transform.Position = new Vector2(0, transform.Position.Y);

        //    if (transform.Position.X > xOffset - playerRec.Width)
        //        transform.Position = new Vector2(xOffset - playerRec.Width, transform.Position.Y);

        //    if (transform.Position.Y < 0)
        //        bla.Velocity = new Vector2(bla.Velocity.X, 7.5f);

        //    if (transform.Position.Y > yOffset - playerRec.Height)
        //        transform.Position = new Vector2(transform.Position.X, yOffset - playerRec.Height);
        //}
    }
}
