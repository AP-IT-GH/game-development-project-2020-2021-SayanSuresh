using game2020.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.World
{
    public class InteractTile : IInteractTile
    {
        public bool IsExit { get; set; }
        public string Name { get; set; }
        public Vector2 Pos { get; set; }
      
        public InteractTile(Vector2 position, string textureName, bool exit = false)
        {
            this.Pos = position;
            this.Name = textureName;
            this.IsExit = exit;
        }
    }
}
