using System;
using System.Collections.Generic;
using System.Text;
using TableOptimization.Models;

namespace TableOptimization
{
    public class Board
    {
        public int BoardID { get; set; }
        public double Thickness { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public Rectangle Rectangle { get; set; }
    }
}
