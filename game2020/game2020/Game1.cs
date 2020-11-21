using game2020.Collision;
using game2020.GameScreen;
using game2020.Input;
using game2020.Interfaces;
using game2020.Players;
using game2020.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace game2020
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        IScreenUpdater screenUpdater;
        Level level;
        CollisionManager collisionManager;


        private Texture2D textureHero;
        private Hero hero;

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
            screenUpdater.UpdateScreen(_graphics, 1480, 720);

            level = new Level(Content);
            level.CreateWorld();

            collisionManager = new CollisionManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            textureHero = Content.Load<Texture2D>("Players/thief");


            InitialzeGameObjects();
        }

        private void InitialzeGameObjects()
        {
            hero = new Hero(textureHero, new KeyBoardReader());
        }

        public int i { get; set; } = 0;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            hero.Update(gameTime);

            foreach (var item in level.blokArray)
            {
                if (item != null)
                {
                    if (collisionManager.CheckCollision(hero.CollisionRectangle, item.CollisionRectangle))
                        Debug.WriteLine(i++);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            level.DrawWorld(_spriteBatch);
            hero.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
