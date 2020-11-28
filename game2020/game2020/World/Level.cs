using game2020.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.World
{
    class Level
    {
        public Texture2D texture1;
        public Texture2D texture2;
        //public Rectangle CollisionRectangle { get; set; }

        private int[,] width;

        public int[,] Width
        {
            get { return width; }
        }
        private int[,] height;

        public int[,] Height
        {
            get { return height; }
        }


        public int[,] tileArray = new int[,]
        {
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,},
            { 2,1,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,1,1,2,2,},
            { 2,2,1,1,1,0,0,0,0,1,1,1,2,2,2,1,0,0,0,0,2,2,},
            { 2,2,0,0,0,0,0,0,1,2,2,2,2,2,2,2,1,0,0,0,2,2,},
            { 2,0,0,0,0,0,1,1,2,2,2,2,2,2,2,2,2,1,1,1,2,2,},
            { 2,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
            { 2,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,}
        };

        public Block[,] blokArray = new Block[8, 22];

        private ContentManager content;


        public Level(ContentManager content)
        {
            this.content = content;
            InitializeContent();
        }

        private void InitializeContent()
        {
            texture1 = content.Load<Texture2D>("Level1Content/Tiles/tile1");
            texture2 = content.Load<Texture2D>("Level1Content/Tiles/tile2");

            //CollisionRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, texture.Width, texture.Height);

            //for (int x = 0; x < 8; x++)
            //{
            //    for (int y = 0; y < 22; y++)
            //    {
            //        if (blokArray[x, y].CollisionRectangle != null)
            //        {
            //            blokArray[x, y].CollisionRectangle;
            //        }
            //    }
            //}

            //foreach (var item in blokArray)
            //{
            //    if (item != null)
            //    {
            //        this.CollisionRectangle = item.CollisionRectangle;
            //    }
            //}
        }


        public void CreateWorld()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 22; y++)
                {
                    if (tileArray[x, y] == 1)
                    {
                        blokArray[x, y] = new Block(texture1, new Vector2(y * 64, x * 64));
                    }
                    if (tileArray[x, y] == 2)
                    {
                        blokArray[x, y] = new Block(texture2, new Vector2(y * 64, x * 64));
                    }

                    //this.width[x, y] = blokArray[x, y]._texture.Width;
                    //this.height[x, y] = blokArray[x, y]._texture.Height;
                }
            }
        }

        public void DrawWorld(SpriteBatch spritebatch)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 22; y++)
                {
                    if (blokArray[x, y] != null)
                    {
                        blokArray[x, y].Draw(spritebatch);
                    }
                }
            }

        }
    }
}
