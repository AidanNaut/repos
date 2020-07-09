using System;
using System.Collections.Generic;
using System.Text;

namespace TableOptimization
{
    public class BoardCatalogue
    {
        private Dictionary<Board, int> _boards = new Dictionary<Board, int>();
        public BoardCatalogue(List<int[]> sizes)
        {
            foreach (int[] size in sizes)
            {
                _boards.Add(new Board
                {
                    Thickness = size[0],
                    Length = size[1],
                    Width = size[2]
                }, size[3]);
            }
        }

        public BoardCatalogue()
        {

        }

        public Dictionary<Board, int> GetCatalogue()
        {
            return _boards;
        }
    }
}
