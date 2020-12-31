﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.World
{
    public class Level2 : Levels
    {
        public Level2()
        {
            GenerateLevel(new int[,]
            {
                { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,},
                { 2,1,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,1,1,2,2,},
                { 2,2,1,1,1,0,0,0,0,1,1,1,2,2,2,1,0,0,0,0,2,2,},
                { 2,2,0,0,0,0,0,0,1,2,2,2,2,2,2,2,1,0,0,0,2,2,},
                { 2,0,0,0,0,0,1,1,2,2,2,2,2,2,2,2,2,1,1,1,2,2,},
                { 2,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
                { 2,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,}
            }, 64);
        }
    }
}