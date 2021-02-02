using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class Camera
    {
        // Voor deze classe heb ik gebruikt gemaakt van youtuber (Oyyou: MonoGame Tutorial 014 - Camera Following Sprite) zijn   uitleg
        // zodat mijn hero gevolgd wordt

        private Matrix transform;
        public Matrix Transform
        {
            get { return transform; }
        }

        private Vector2 center;
        private Viewport viewport;

        public Camera(Viewport newViewport)
        {
            viewport = newViewport;
        }

        public void Update(Vector2 position, int xOffcet, int yOffcet)
        {
            if (position.X < viewport.Width / 2)
                center.X = viewport.Width / 2;
            else if (position.X > xOffcet - (viewport.Width / 2))
                center.X = xOffcet - (viewport.Width / 2);
            else center.X = position.X;

            if (position.Y < viewport.Height / 2)
                center.Y = viewport.Height / 2;
            else if (position.Y > yOffcet - (viewport.Height / 2))
                center.Y = yOffcet - (viewport.Height / 2);
            else center.Y = position.Y;

            transform = Matrix.CreateTranslation(new Vector3(-center.X + (viewport.Width / 2), 
                                                             -center.Y + (viewport.Height / 2), 0));
        }
    }
}
