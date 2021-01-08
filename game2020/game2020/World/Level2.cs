﻿using game2020.Backgrounds;
using game2020.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.World
{
    public class Level2 : Level
    {
        protected override string path { get; set; }
        public override List<Layer> Layers { get; set; }
        public override List<Scrolling> ScrollingLayer { get; set; }
        public override List<Enemy> Enemies { get; set; }

        public Level2(ContentManager content) : base(content)
        {
            path = "Levels/Level1/";
            Layers = new List<Layer>();
            ScrollingLayer = new List<Scrolling>();
            Enemies = new List<Enemy>();

            GenerateLevel(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,45,45,45,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,45,45,0,0,0,0,0,0,45,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,45,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,45,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,45,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,45,0,0,0,0,0,0,0,0,0,0,0,7,7,7,7,7,7,7,7,7,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,45,0,0,0,45,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,45,45,0,0,0,45,45,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,7,0,0,0,0,0,0,0,0,0,0,0,45,45,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,45,45,0,0,0,0,45,45,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,0,7,7,0,0,0,0,0,45,45,0,0,0,0,0,0,0,0,45,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,0,0,7,0,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,0,0,0,7,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,46,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,7,7,0,0,0,7,7,0,0,0,0,0,0,0,0,0,0,7,0,0,0,0,7,7,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,7,7,7,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,0,0,0,0,7,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,46,0,0,0,},
{0,0,0,0,0,0,0,7,7,7,7,7,7,7,0,0,7,0,0,0,0,0,0,0,7,7,7,7,7,7,0,0,7,0,0,0,0,0,0,7,7,7,7,7,7,7,7,7,7,7,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,45,0,},
{0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,45,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,7,0,0,0,7,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,0,0,0,0,0,0,0,45,45,45,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,7,0,0,0,0,0,0,0,0,7,7,7,0,0,0,0,0,0,0,0,45,},
{7,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,0,0,0,0,0,0,7,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,},
{7,0,0,0,0,0,0,0,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,0,0,264,0,0,0,0,0,0,0,0,7,7,7,0,0,0,0,0,0,7,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0,},
{12,0,0,0,0,12,12,12,12,0,0,0,12,12,12,0,0,0,12,0,0,0,0,0,12,12,12,12,12,0,0,0,0,0,12,12,12,12,0,0,0,0,0,0,12,0,0,0,0,0,12,0,0,0,0,0,0,0,0,0,},
{262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262,262},
            }, 64);

            addLayers();
            addScrollingLayers();
            addEnemies();
        }

        protected override void addLayers()
        {
            Layers.Add(new Layer(content.Load<Texture2D>("Backgrounds/Level2/Background"), new Rectangle(0, 0, 5120, 2230)));
            Layers.Add(new Layer(content.Load<Texture2D>("Backgrounds/Level1/layer_05_1920 x 1080"), new Rectangle(0, 0, 5120, 2230)));
            Layers.Add(new Layer(content.Load<Texture2D>("Backgrounds/Level1/layer_04_1920 x 1080"), new Rectangle(0, 0, 5120, 2230)));
            Layers.Add(new Layer(content.Load<Texture2D>("Backgrounds/Level1/layer_03_1920 x 1080"), new Rectangle(0, 0, 5120, 2290)));
            Layers.Add(new Layer(content.Load<Texture2D>("Backgrounds/Level1/layer_01_1920 x 1080"), new Rectangle(0, 0, 5120, 1730)));
        }
        protected override void addScrollingLayers()
        {
            ScrollingLayer.Add(new Scrolling(content.Load<Texture2D>("Backgrounds/Level1/layer_06_1920 x 1080"), new Rectangle(0, 0, 5120, 1800)));
        }
        protected override void addEnemies()
        {
            Enemies.Add(new Enemy(content.Load<Texture2D>("Levels/Level1/52"), new Vector2(1200, 95), 150));
            Enemies.Add(new Enemy(content.Load<Texture2D>("Levels/Level1/52"), new Vector2(600, 610), 150));
        }
    }
}
