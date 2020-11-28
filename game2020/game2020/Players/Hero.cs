using game2020.Animation;
using game2020.Animation.HeroAnimations;
using game2020.Commands;
using game2020.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Players
{
    public class Hero : ITransform, ICollision
    {
        private Rectangle _collisionRectangle;
        public Rectangle CollisionRectangle { get; set; }
        public Vector2 Position { get; set; }

        Texture2D heroTexture;
        GameTime gameTime;
        Vector2 velocity;
        private bool jump = false;
        const float gravity = 100f;
        float jumpspeed = 1000;

        private IInputReader reader;
        private IGameCommand moveCommand;
        IEntityAnimation walkRight, walkLeft, currentAnimation;


        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.heroTexture = texture;
            walkRight = new WalkRightAnimation(texture, this);
            walkLeft = new WalkLeftAnimation(texture, this);
            currentAnimation = walkRight;

            //Read input for hero class
            this.reader = inputReader;
            moveCommand = new MoveCommand();


            _collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 48, 62);
        }



        //public void Collision(int xoffSet, int yOffSet)
        //{
            //if (rectangle.CollisionTopOf())
            //{
            //    _collisionRectangle.Y = CollisionRectangle.Height;
            //    velocity.Y = 0f;
            //    jump = false;
            //}

            //if (rectangle.CollisionLeftOf())
            //    Position = new Vector2(CollisionRectangle.Width - 2, Position.Y);
            //if (rectangle.CollisionRightOf())
            //    Position = new Vector2(CollisionRectangle.Width + 2, Position.Y);
            //if (rectangle.CollisionBottomOf())
            //    velocity.Y = 1f;


            //if (Position.X > xoffSet)
            //    Position = new Vector2(xoffSet - _collisionRectangle.Height, Position.Y);

            //if (Position.Y > yOffSet )
            //    Position = new Vector2(Position.X, yOffSet - _collisionRectangle.Height);
        //}

        private void move(Vector2 _direction)
        {
            if (_direction.X == -1)
                currentAnimation = walkLeft;
            else if (_direction.X == 1)
                currentAnimation = walkRight;

            // jumping movement
            if (_direction.Y == -1 && jump)
            {
                velocity.Y = -jumpspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                jump = false;
            }

            if (!jump)
                velocity.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else
                velocity.Y = 0;

            Position += velocity;

            jump = Position.Y >= 300;

            moveCommand.Execute(this, _direction);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentAnimation.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            var direction = reader.ReadInput();
            this.gameTime = gameTime;
            if (direction.X != 0 || direction.Y != 0)
                //animatie.Update(gameTime);
                currentAnimation.Update(this.gameTime);
            move(direction);

            _collisionRectangle.X = (int)Position.X;
            _collisionRectangle.Y = (int)Position.Y;
            CollisionRectangle = _collisionRectangle;
        }
    }
}
