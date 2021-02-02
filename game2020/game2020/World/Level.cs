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
        public int[,] CurrentMap { get; set; }
        public int Size { get; set; }
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public abstract List<Enemy> Enemies { get; set; }
        public abstract List<Background> Layers { get; set; }
        public abstract List<Background> ScrollingLayer { get; set; }
        public List<IInteractTile> InteractWithTiles { get; set; }
        public Level(ContentManager Content) { this.content = Content; }
        public List<CollisionTiles> CollisionTiles { get { return collisionTiles; } }

        protected int width, height;
        protected ContentManager content;
        protected abstract string path { get; set; }
        protected virtual void addLayers() { }
        protected virtual void addScrollingLayers() { }
        protected virtual void addEnemies() { }
        protected virtual void addInteract() { }

        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>();

        //public Level()
        //{
        //    InteractWithTiles = new List<IInteractTile>();
        //}

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
