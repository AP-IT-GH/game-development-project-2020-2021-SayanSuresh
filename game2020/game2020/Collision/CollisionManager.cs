using game2020.Commands;
using game2020.Interfaces;
using game2020.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RefactoringCol;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace game2020.Collision
{
    class CollisionManager : CollisionHelper, ICollisionWith
    {
        public bool IsCollision { get; set; }
        public bool IsCollisionWithExit { get; set; }

        public void UpdateCollision(Rectangle playerRec, Rectangle tileRectangle, int xOffset, int yOffset, ICollisionEntity transform)
        {
            if (CollisionBottom(playerRec, tileRectangle))
            {
                playerRec.Y = tileRectangle.Y - playerRec.Height;
                transform.Velocity = new Vector2(transform.Velocity.X, 0f);
                transform.HasJumped = false;
            }

            if (CollisionRight(playerRec, tileRectangle))
                transform.Position = new Vector2(tileRectangle.X - playerRec.Width - 2, transform.Position.Y);

            if (CollisionLeft(playerRec, tileRectangle))
                transform.Position = new Vector2(tileRectangle.X + playerRec.Width + 2, transform.Position.Y);

            if (CollisionTop(playerRec, tileRectangle))
                transform.Velocity = new Vector2(transform.Velocity.X, 7f);


            // Trap hero inside window borders 
            if (transform.Position.X < 0)
                transform.Position = new Vector2(0, transform.Position.Y);

            if (transform.Position.X > xOffset - playerRec.Width)
                transform.Position = new Vector2(xOffset - playerRec.Width, transform.Position.Y);

            if (transform.Position.Y < 0)
                transform.Velocity = new Vector2(transform.Velocity.X, 7.5f);

            if (transform.Position.Y > yOffset - playerRec.Height)
                transform.Position = new Vector2(transform.Position.X, yOffset - playerRec.Height);
        }

        public void CheckCollision(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.Intersects(rect2))
                IsCollision = true;
            else
                IsCollision = false;
        }

        public void LevelCollision(Rectangle playerRec, Rectangle tileRectangle, Texture2D texture, ITransform heroTransform, List<IInteractTile> interactTiles)
        {
            if (interactTiles != null)
            {
                foreach (var interactTile in interactTiles)
                {
                    if (texture.Name == interactTile.Name)
                        if (playerRec.Intersects(tileRectangle))
                        {
                            if (interactTile.IsExit)
                                IsCollisionWithExit = true;
                            heroTransform.Position = interactTile.Pos;
                        }
                }
            }
        }
    }
}

