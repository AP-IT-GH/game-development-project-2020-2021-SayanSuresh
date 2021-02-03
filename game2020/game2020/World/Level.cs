using Game1;
using game2020.Backgrounds;
using game2020.Interfaces;
using game2020.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game2020.World
{
    public abstract class Level
    {
        private List<Tile> collisionTiles;

        public int[,] CurrentMap { get; set; }
        public int Size { get; set; }
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public List<ICollisionRectangle> Enemies { get; set; }
        public List<Background> Layers { get; set; }
        public List<Background> ScrollingLayer { get; set; }
        public List<IInteractTile> InteractWithTiles { get; set; }
        public List<Tile> CollisionTiles { get { return collisionTiles; } }

        protected int width, height;
        protected ContentManager content;
        protected string path { get; set; }
        protected void addLayers() { }
        protected void addScrollingLayers() { }
        protected void addEnemies() { }
        protected void addInteract() { }

        public Level(ContentManager Content)
        {
            this.content = Content;
            collisionTiles = new List<Tile>();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionTiles tile in collisionTiles)
                tile.Draw(spriteBatch);
        }

        protected void GenerateLevel(int[,] map, int size)
        {
            //this.CurrentMap = map;
            //this.Size = size;

            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];

                    if (number > 0)
                    {
                        CollisionTiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size), path, this.content));
                    }

                    width = (x + 1) * size;
                    height = (y + 1) * size;
                }
            }
        }
    }
}
