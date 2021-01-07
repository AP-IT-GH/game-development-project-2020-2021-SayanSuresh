using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.World
{
    public class CollisionTiles : Tile
    {
        public CollisionTiles(int i, Rectangle newRectangle, string path)
        {
            texture = Content.Load<Texture2D>(path + i);
            this.Rectangle = newRectangle;
        }
    }
}
