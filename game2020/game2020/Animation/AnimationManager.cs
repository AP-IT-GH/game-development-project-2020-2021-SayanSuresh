﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Animation
{
    public class AnimationManager
    {
        public AnimationFrame currentFrame { get; set; }
        private List<AnimationFrame> frames;
        private int counter;
        private double frameMovement = 0;

        public AnimationManager()
        {
            frames = new List<AnimationFrame>();
        }

        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            currentFrame = frames[0];
        }

        public void RemoveFrames()
        {
            frames.Clear();
        }

        public void Update(GameTime gameTime)
        {
            currentFrame = frames[counter];

            frameMovement += currentFrame.SourceRectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;

            if (frameMovement >= currentFrame.SourceRectangle.Width / 12)
            {
                counter++;
                frameMovement = 0;
            }

            if (counter >= frames.Count)
                counter = 0;
        }
    }
}
