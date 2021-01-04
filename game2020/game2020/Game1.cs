using Game1;
using game2020.Animation.HeroAnimations;
using game2020.Backgrounds;
using game2020.Collision;
using game2020.Commands;
using game2020.Controls;
using game2020.GameScreen;
using game2020.Input;
using game2020.Interfaces;
using game2020.Players;
using game2020.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RefactoringCol;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace game2020
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Menu
        bool pauzed = false;
        bool oneTimeStart = true;
        Button btnPlay, btnQuit;

        private List<Scrolling> scrollings;

        private IScreenUpdater screenUpdater;
        private IGameCommand gameCommand;

        private Camera camera;
        private CollisionManager collisionManager;
        private CollisionWithEnemy collisionWithEnemy;

        private Level1 lv1;

        private Texture2D textureHero;
        private Hero hero;
        private List<Enemy> enemies;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screenUpdater = new ScreenUpdate();
            //screenUpdater.UpdateScreen(_graphics, 1280, 720);
            //screenUpdater.UpdateScreen(_graphics, 1480, 620);

            // Menu buttons
            btnPlay = new Button();
            btnQuit = new Button();

            scrollings = new List<Scrolling>();

            gameCommand = new MoveCommand();

            collisionManager = new CollisionManager(new CollisionHelper());
            collisionWithEnemy = new CollisionWithEnemy();

            enemies = new List<Enemy>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // Load menu content
            btnPlay.Load(Content.Load<Texture2D>("Menu/start_normal"), new Vector2(280, 100));
            btnQuit.Load(Content.Load<Texture2D>("Menu/quit_normal"), new Vector2(300, 250));

            camera = new Camera(GraphicsDevice.Viewport);

            scrollings.Add(new Scrolling(Content.Load<Texture2D>("Backgrounds/Level1/layer_07_2048 x 1546"), new Rectangle(0, 0, 2048, 1000)));
            scrollings.Add(new Scrolling(Content.Load<Texture2D>("Backgrounds/Level1/layer_06_1920 x 1080"), new Rectangle(0, 0, 1600, 700)));
            scrollings.Add(new Scrolling(Content.Load<Texture2D>("Backgrounds/Level1/layer_05_1920 x 1080"), new Rectangle(0, 0, 1600, 600)));
            scrollings.Add(new Scrolling(Content.Load<Texture2D>("Backgrounds/Level1/layer_04_1920 x 1080"), new Rectangle(0, 0, 1600, 700)));
            scrollings.Add(new Scrolling(Content.Load<Texture2D>("Backgrounds/Level1/layer_03_1920 x 1080"), new Rectangle(0, 0, 1600, 700)));
            //scrollings.Add(new Scrolling(Content.Load<Texture2D>("Backgrounds/Level1/layer_02_1920 x 1080"), new Rectangle(0, 0, 1600, 700)));
            scrollings.Add(new Scrolling(Content.Load<Texture2D>("Backgrounds/Level1/layer_01_1920 x 1080"), new Rectangle(0, 0, 1600, 610)));

            Tiles.Content = Content;
            lv1 = new Level1();

            // Load players conten
            textureHero = Content.Load<Texture2D>("Players/thief");
            enemies.Add(new Enemy(Content.Load<Texture2D>("Levels/Level1/52"), new Vector2(1200, 95), 150));
            //enemies.Add(new Enemy(Content.Load<Texture2D>("Levels/Level1/52"), new Vector2(800, 200), 150));
            enemies.Add(new Enemy(Content.Load<Texture2D>("Levels/Level1/52"), new Vector2(600, 610), 150));
            //enemies.Add(new Enemy(Content.Load<Texture2D>("Levels/Level1/52"), new Vector2(400, 400), 150));

            InitialzeGameObjects();
        }

        private void InitialzeGameObjects()
        {
            hero = new Hero(textureHero, new KeyBoardReader(), gameCommand);
            hero.HeroWalkAnimation(new WalkRightAnimation(textureHero, hero), new WalkLeftAnimation(textureHero, hero),
                                   new WalkUpAnimation(textureHero, hero), new WalkDownAnimation(textureHero, hero));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // Intro
            MouseState mouse = Mouse.GetState();
            if (!pauzed)
            {
                if (oneTimeStart)
                {
                    btnPlay.isClicked = false;
                    pauzed = true;
                    oneTimeStart = false;
                }

                // player and background update
                scrollings[1].Update();
                hero.Update(gameTime);
            }
            else if (pauzed)
            {
                if (btnPlay.isClicked)
                    pauzed = false;
                if (btnQuit.isClicked)
                    Exit();

                btnPlay.Update(mouse);
                btnQuit.Update(mouse);
            }

            // Scrolling backgrounds
            if (scrollings[1].rectangle.X + scrollings[1].texture.Width <= 0)
                scrollings[1].rectangle.X = scrollings[2].rectangle.X + scrollings[2].texture.Width;

            foreach (Enemy enemy in enemies)
            {
                enemy.Update(hero);
                collisionWithEnemy.HandleHeroSpawn(collisionManager, hero);
                collisionManager.CheckCollision(hero.CollisionRectangle, enemy.CollisionRectangle);
            }

            foreach (CollisionTiles tile in lv1.CollisionTiles)
            {
                collisionManager.UpdateCollision(hero.CollisionRectangle, tile.Rectangle, lv1.Width, lv1.Height, hero);
                camera.Update(hero.Position, lv1.Width, lv1.Height);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            if (pauzed)
            {
                //_spriteBatch.Draw(pausedTexture, pauzedRectangle, Color.AliceBlue);
                btnPlay.Draw(_spriteBatch);
                btnQuit.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            _spriteBatch.Begin(SpriteSortMode.Deferred,
                               BlendState.AlphaBlend,
                               null, null, null, null,
                               camera.Transform);

            if (!pauzed)
            {
                foreach (Scrolling scrolling in scrollings)
                    scrolling.Draw(_spriteBatch);

                lv1.Draw(_spriteBatch);

                hero.Draw(_spriteBatch);

                foreach (Enemy enemy in enemies)
                    enemy.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
