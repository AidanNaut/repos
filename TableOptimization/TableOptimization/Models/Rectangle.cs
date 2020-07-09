using System;
using System.Collections.Generic;
using System.Text;

namespace TableOptimization.Models
{
    public struct Rectangle
    {
        public Point X0Y0 { get; set; }
        public Point X1Y0 { get; set; }
        public Point X0Y1 { get; set; }
        public Point X1Y1 { get; set; }
    }
}
