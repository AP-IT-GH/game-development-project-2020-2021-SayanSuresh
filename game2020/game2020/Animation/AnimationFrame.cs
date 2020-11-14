using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace game2020.Animation
{
    public class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }

        public AnimationFrame(Rectangle rectangle)
        {
            SourceRectangle = rectangle;
        }
    }
}
