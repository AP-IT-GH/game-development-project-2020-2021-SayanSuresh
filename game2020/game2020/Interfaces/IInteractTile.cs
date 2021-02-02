using game2020.World;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace game2020.Interfaces
{
    public interface IInteractTile
    {
        public bool IsExit { get; set; }
        public string Name { get; set; }
        public Vector2 Pos { get; set; }
    }
}
