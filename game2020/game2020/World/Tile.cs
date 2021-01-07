using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    public abstract class Tile
    {
        public Texture2D texture;

        private  static ContentManager content;
        //private ContentManager getContent;
        private Rectangle rectangle;

        public Rectangle Rectangle
        {
            get { return rectangle; }
            protected set { rectangle = value; }
        }

        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        //public void GetContent(ContentManager Content)
        //{
        //    this.getContent = Content;
        //}

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Rectangle, Color.White);
        }
    }
}
