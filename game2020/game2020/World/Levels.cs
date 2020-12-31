using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.World
{
    public abstract class Levels
    {
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public List<CollisionTiles> CollisionTiles { get { return collisionTiles; } }

        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>();
        protected int width, height;

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionTiles tile in collisionTiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
