using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Interfaces
{
    public interface ICollisionEntity
    {
        //public IMove CheckCollision();
        //public bool IsJumping(Rectangle playerRec, Rectangle newRectangle);

        public void ExecuteCollision(ITransform transform);
    }
}
