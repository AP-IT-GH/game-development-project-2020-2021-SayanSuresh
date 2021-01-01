using game2020.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Players
{
    public class Enemy : ICollision, ITransform, ICollisionEntity
    {
        public bool HasJumped { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        private Rectangle _collisionRectangle;
        private Texture2D texture;
        private Rectangle rectangle;
        private Vector2 position;
        private Vector2 origin;
        private Vector2 velocity;

        private bool right;
        private float rotation = 0f;
        private float distance;
        private float oldDistance;
        private float playerDistance;

        private IGameCommand moveCommand;

        public Enemy(Texture2D newTexture, Vector2 newPosition, float newDistance)
        {
            texture = newTexture;
            position = newPosition;
            distance = newDistance;

            oldDistance = distance;

            _collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
        }

        public void Update(ITransform player)
        {
            position += velocity;
            origin = new Vector2(texture.Width / 2, texture.Height / 2);

            if (distance <= 0)
            {
                right = true;
                velocity.X = 1;
            }
            else if (distance >= oldDistance)
            {
                right = false;
                velocity.X = -1f;
            }

            if (right) distance += 1; else distance -= 1;

            playerDistance = player.Position.X - position.X;

            if (playerDistance >= -200 && playerDistance <= 200)
            {
                if (playerDistance < -1)
                    velocity.X = -1f;
                else if (playerDistance > 1)
                    velocity.X = 1f;
                else if (playerDistance == 0)
                    velocity.X = 0f;
            }

            _collisionRectangle.X = (int)Position.X;
            _collisionRectangle.Y = (int)Position.Y;
            CollisionRectangle = _collisionRectangle;
        }

        //public void Update()
        //{
        //    position += velocity;
        //    origin = new Vector2(texture.Width / 2, texture.Height / 2);

        //    if (distance <= 0)
        //    {
        //        right = true;
        //        velocity.X = 1;
        //    }
        //    else if (distance >= oldDistance)
        //    {
        //        right = false;
        //        velocity.X = -1f;
        //    }

        //    if (right) distance += 1; else distance -= 1;

        //    MouseState mouse = Mouse.GetState();
        //    mouseDistance = mouse.X - position.X;

        //    if (mouseDistance >= -200 && mouseDistance <= 200)
        //    {
        //        if (mouseDistance < -1)
        //            velocity.X = -1f;
        //        else if (mouseDistance > 1)
        //            velocity.X = 1f;
        //        else if (mouseDistance == 0)
        //            velocity.X = 0f;
        //    }
        //}

        public void Draw(SpriteBatch spriteBatch)
        {
            if (velocity.X > 0)
                spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, 1f, SpriteEffects.FlipHorizontally, 0f);
            else
                spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
