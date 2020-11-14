using game2020.Animation;
using game2020.Commands;
using game2020.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Players
{
    public class Hero : IGameObject, ITransform
    {
        public Vector2 Position { get ; set; }
        public Rectangle CollisinRectangle { get; set; }


        Texture2D heroTexture;
        AnimationManager animation;
        private Vector2 speed;
        private Vector2 acceleration;

        private IInputReader reader;
        private IGameCommand moveCommand;

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.heroTexture = texture;

            animation = new AnimationManager();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 70, 48, 62)));
            animation.AddFrame(new AnimationFrame(new Rectangle(48, 70, 48, 62)));
            animation.AddFrame(new AnimationFrame(new Rectangle(96, 70, 48, 62)));
            

            //Read input for my hero class
            this.reader = inputReader;

            moveCommand = new MoveCommand();
        }

        private void move(Vector2 _direction)
        {
            moveCommand.Execute(this, _direction);

            //if (position.X > 600 || position.X < 0)
            //{
            //    speed.X *= -1;
            //    acceleration.X *= -1;
            //}
            //if (position.Y > 400 || position.Y < 0)
            //{
            //    speed.Y *= -1;
            //    acceleration.Y *= -1;
            //}
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, Position, animation.currentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 2f, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            var direction = reader.ReadInput();
            if (direction.X != 0 || direction.Y != 0)
            {
                animation.Update(gameTime);
                move(direction);
            }
        }
    }
}
