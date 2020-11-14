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
        public Vector2 Position { get ; set; }

        Texture2D heroTexture;

        private IInputReader reader;
        private IGameCommand moveCommand;
        IEntityAnimation walkRight, walkLeft, walkDown, walkUp, currentAnimation;

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.heroTexture = texture;
            walkRight = new WalkRightAnimation(texture, this);
            walkLeft = new WalkLeftAnimation(texture, this);
            walkDown = new WalkDownAnimation(texture, this);
            walkUp = new WalkUpAnimation(texture, this);
            currentAnimation = walkRight;

            //Read input for hero class
            this.reader = inputReader;
            moveCommand = new MoveCommand();

            Position = new Vector2(0, 0);

            _collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, 48, 62);

        }

        private void move(Vector2 _direction)
        {
            if (_direction.X == -1)
                currentAnimation = walkLeft;
            else if (_direction.X == 1)
                currentAnimation = walkRight;
            moveCommand.Execute(this, _direction);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentAnimation.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            var direction = reader.ReadInput();

            if (direction.X != 0 || direction.Y != 0)
            {
                //animatie.Update(gameTime);
                currentAnimation.Update(gameTime);
                move(direction);
            }

            _collisionRectangle.X = (int)Position.X;
            CollisionRectangle = _collisionRectangle;
        }
    }
}
