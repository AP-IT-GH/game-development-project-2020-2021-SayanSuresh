using game2020.Backgrounds;
using game2020.Interfaces;
using game2020.Players;
using game2020.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RefactoringCol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class Level1 : Level
    {
        public override List<Layer> Layers { get; set; }
        public override List<Scrolling> ScrollingLayer { get; set; }
        public override List<Enemy> Enemies { get; set; }

        public Level1(ContentManager content) : base(content)
        {
            Layers = new List<Layer>();
            ScrollingLayer = new List<Scrolling>();
            Enemies = new List<Enemy>();

            GenerateLevel(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,38,39,0,0,},
                {0,0,0,51,0,0,0,0,0,0,0,0,43,44,39,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,51,51,51,0,0,0,0,0,},
                {0,0,0,1,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,27,0,0,0,27,0,0,43,44,40,0,0,0,0,1,1,1,0,0,0,0,0,},
                {0,0,0,0,0,0,0,55,8,0,0,0,0,0,0,0,0,20,63,0,0,0,0,0,0,27,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,38,39,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,1,1,0,0,27,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,51,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,20,23,23,0,0,0,51,0,0,0,48,56,0,0,0,0,3,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,},
                {1,1,0,0,3,0,0,0,9,0,0,0,0,0,38,39,0,0,0,0,0,0,3,8,8,0,0,0,0,0,0,0,0,24,0,0,0,0,3,0,0,0,24,0,0,0,0,0,0,65,},
                {0,24,0,0,24,0,0,0,0,0,0,0,23,0,0,0,0,0,0,0,0,0,13,48,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,38,39,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,50,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,17,0,0,0,},
                {37,37,262,262,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262},
            }, 64);

            addLayers();
            addScrollingLayers();
            addEnemies();
        }

        protected override void addLayers()
        {
            Layers.Add(new Layer(content.Load<Texture2D>("Backgrounds/Level1/layer_07_2048 x 1546"), new Rectangle(0, 0, 3200, 1200)));
            Layers.Add(new Layer(content.Load<Texture2D>("Backgrounds/Level1/layer_05_1920 x 1080"), new Rectangle(0, 0, 3200, 1200)));
            Layers.Add(new Layer(content.Load<Texture2D>("Backgrounds/Level1/layer_04_1920 x 1080"), new Rectangle(0, 0, 3200, 3200)));
            Layers.Add(new Layer(content.Load<Texture2D>("Backgrounds/Level1/layer_03_1920 x 1080"), new Rectangle(0, 0, 3200, 3200)));
            Layers.Add(new Layer(content.Load<Texture2D>("Backgrounds/Level1/layer_01_1920 x 1080"), new Rectangle(0, 0, 3200, 840)));
        }

        protected override void addScrollingLayers()
        {
            ScrollingLayer.Add(new Scrolling(content.Load<Texture2D>("Backgrounds/Level1/layer_06_1920 x 1080"), new Rectangle(0, 0, 1600, 700)));
        }
        protected override void addEnemies()
        {
            Enemies.Add(new Enemy(content.Load<Texture2D>("Levels/Level1/52"), new Vector2(1200, 95), 150));
            Enemies.Add(new Enemy(content.Load<Texture2D>("Levels/Level1/52"), new Vector2(600, 610), 150));
        }
    }
}
