using game2020.Animation;
using game2020.Animation.HeroAnimations;
using game2020.Collision;
using game2020.Commands;
using game2020.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RefactoringCol;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Players
{
    public class Hero : ITransform, ICollision, IMove
    {
        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public bool HasJumped { get; set; }
        public Vector2 Velocity { get; set; }

        private Rectangle _collisionRectangle;
        private Texture2D heroTexture;
        private GameTime gameTime;

        private IInputReader reader;
        private IGameCommand moveCommand;
        private IEntityAnimation walkRight, walkLeft, walkUp, walkDown, currentAnimation;


        public void HeroWalkAnimation(IEntityAnimation walkRight, IEntityAnimation walkLeft, IEntityAnimation walkUp, IEntityAnimation walkDown)
        {
            this.walkRight = walkRight;
            this.walkLeft = walkLeft;
            this.walkUp = walkUp;
            this.walkDown = walkDown;
            currentAnimation = walkDown;
        }

        public Hero(Texture2D texture, IInputReader inputReader, ICollisionHelper helper, IGameCommand mvCommand)
        {
            this.heroTexture = texture;
            //walkRight = new WalkRightAnimation(texture, this);
            //walkLeft = new WalkLeftAnimation(texture, this);
            //walkUp = new WalkUpAnimation(texture, this);
            //walkDown = new WalkDownAnimation(texture, this);
            currentAnimation = walkDown;

            //Read input for hero class
            this.reader = inputReader;
            this.moveCommand = mvCommand;

            // Testing ColManager
            _collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 62, 110);
            Position = new Vector2(65, 340);
        }

        private void move(Vector2 _direction)
        {
            if (_direction.X == -1)
                currentAnimation = walkLeft;
            else if (_direction.X == 1)
                currentAnimation = walkRight;
            else if (_direction.Y == -1)
                currentAnimation = walkUp;
            if (_direction.X == 0 && _direction.Y == 0)
                currentAnimation = walkDown;

            //jumping movement
            if (_direction.Y == -1 && HasJumped == false)
            {
                //velocity.Y = -9f;
                //hasJumped = true;

                Velocity = new Vector2(Velocity.X, -9f);
                HasJumped = true;
            }

            //hasJumped = collisionEntity.CheckCollision().HasJumped;
            //Position += velocity;
            //if (velocity.Y < 20)
                //velocity += new Vector2(Velocity.X, 0.9f);
            Position += Velocity;
            if (Velocity.Y < 20)
                Velocity += new Vector2(Velocity.X, 0.9f);

            //moveCommand.GetInfo(this);
            moveCommand.Execute(this, _direction);
            //collisionEntity.ExecuteCollision(this);
        }

        //public void Collision(Rectangle playerRec, Rectangle newRectangle, int xOffset, int yOffset)
        //{

        //    if (collisionhelper.CollisionTopOf(playerRec, newRectangle))
        //    {
        //        _collisionRectangle.Y = newRectangle.Y - _collisionRectangle.Height;
        //        velocity.Y = 0f;
        //        hasJumped = false;
        //    }

        //    if (collisionhelper.CollisionLeftOf(playerRec, newRectangle))
        //        Position = new Vector2(newRectangle.X - _collisionRectangle.Width - 2, Position.Y);

        //    if (collisionhelper.CollisionRightOf(playerRec, newRectangle))
        //        Position = new Vector2(newRectangle.X + _collisionRectangle.Width + 2, Position.Y);

        //    if (collisionhelper.CollisionBottomOf(playerRec, newRectangle))
        //        velocity.Y = 7f;


        //    // Trap hero inside window borders 
        //    if (Position.X < 0)
        //        Position = new Vector2(0, Position.Y);

        //    if (Position.X > xOffset - _collisionRectangle.Width)
        //        Position = new Vector2(xOffset - _collisionRectangle.Width, Position.Y);

        //    if (Position.Y < 0)
        //        velocity.Y = 7.5f;

        //    if (Position.Y > yOffset - _collisionRectangle.Height)
        //        Position = new Vector2(Position.X, yOffset - _collisionRectangle.Height);
        //}

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
