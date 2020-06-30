using System;
using System.Collections.Generic;
using System.Text;

namespace TableOptimization
{
    public class BoardCatalogue
    {
        private List<Board> _boards = new List<Board>();
        public BoardCatalogue(double[] thicknesses, double[] lengths, double[] widths)
        {
            foreach (var thickness in thicknesses)
            {
                foreach(var length in lengths)
                {
                    foreach (var width in widths)
                    {
                        _boards.Add(new Board
                        {
                            Thickness = thickness,
                            Length = length,
                            Width = width
                        });
                    }
                }
            }
        }

        public List<Board> GetCatalogue()
        {
            return _boards;
        }
    }
}
