﻿using game2020.Interfaces;
using game2020.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RefactoringCol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class Level1 : Levels
    {
        public Level1()
        {
            //GenerateLevel(new int[,]
            //{
            //    { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            //    { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,},
            //    { 2,1,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,1,1,2,2,},
            //    { 2,2,1,1,1,0,0,0,0,1,1,1,2,2,2,1,0,0,0,0,2,2,},
            //    { 2,2,0,0,0,0,0,0,1,2,2,2,2,2,2,2,1,0,0,0,2,2,},
            //    { 2,0,0,0,0,0,1,1,2,2,2,2,2,2,2,2,2,1,1,1,2,2,},
            //    { 2,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
            //    { 2,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,}
            //}, 64);

            GenerateLevel(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,43,44,39,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,51,0,0,0,0,38,39,0,0,0,0,0,0,0,0,20,63,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0,22,3,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,38,39,0,0,0,0,0,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,1,1,0,0,27,0,0,0,0,0,0,0,0,0,0,0,0,51,0,0,0,0,},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,51,0,0,0,0,0,0,0,0,3,2,0,0,0,},
                {0,0,0,0,0,0,0,1,2,0,0,0,0,0,0,0,0,20,23,23,0,0,0,51,0,0,0,48,56,0,0,0,},
                {1,1,0,0,3,0,0,13,9,0,0,0,0,0,38,39,0,24,0,0,0,0,3,8,8,0,0,0,0,0,0,65,},
                {0,24,0,0,24,0,0,0,0,0,0,0,23,0,0,0,0,0,0,0,0,0,13,48,5,0,0,0,0,0,0,7,},
                {0,0,38,39,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,43,44,40,0,49,5,0,0,0,0,0,7,7,},
                {0,0,0,0,0,0,0,0,0,0,50,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,7,},
                {37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37,37},
            }, 64);
        }
    }
}
