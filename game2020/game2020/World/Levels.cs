using game2020.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RefactoringCol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class Levels
    {
        public Levels() { }
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public List<CollisionTiles> CollisionTiles { get { return collisionTiles; } }

        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>();
        private int width, height;

        public void Generate(int[,] Map, int size)
        {
            for (int x = 0; x < Map.GetLength(1); x++)
            {
                for (int y = 0; y < Map.GetLength(0); y++)
                {
                    int number = Map[y, x];

                    if (number > 0)
                        CollisionTiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size)));

                    width = (x + 1) * size;
                    height = (y + 1) * size; 
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionTiles tile in collisionTiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
