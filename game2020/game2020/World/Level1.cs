using game2020.Interfaces;
using game2020.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RefactoringCol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game1
{
    class Level1: Levels
    {
        public Level1()
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
