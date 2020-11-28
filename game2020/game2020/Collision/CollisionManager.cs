using game2020.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Collision
{
    class CollisionManager 
    {
        public bool CheckCollision(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.Intersects(rect1))
            {
                return true;
            }
            else
            return false;
        }

        //public bool CollisionTopOf()
        //{
        //    return (R1.Bottom >= R2.Top - 1 &&
        //            R1.Bottom <= R2.Top + (R2.Height / 2) &&
        //            R1.Right >= R2.Left + (R2.Width / 5) &&
        //            R1.Left <= R2.Right - (R2.Width / 5));
        //}

        //public bool CollisionBottomOf()
        //{
        //    return (R1.Top <= R2.Bottom + (R2.Height / 5) &&
        //            R1.Top >= R2.Bottom - 1 &&
        //            R1.Right >= R2.Left + (R2.Width / 5) &&
        //            R1.Left <= R2.Right - (R2.Width / 5));
        //}

        //public bool CollisionLeftOf()
        //{
        //    return (R1.Right <= R2.Right &&
        //            R1.Right >= R2.Left - 5 &&
        //            R1.Top <= R2.Bottom - (R2.Width / 4) &&
        //            R1.Bottom >= R2.Top + (R2.Width / 4));
        //}

        //public bool CollisionRightOf()
        //{
        //    return (R1.Left >= R2.Left &&
        //            R1.Left <= R2.Right + 5 &&
        //            R1.Top <= R2.Bottom - (R2.Width / 4) &&
        //            R1.Bottom >= R2.Top + (R2.Width / 4));
        //}
    }
}
