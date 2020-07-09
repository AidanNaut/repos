using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TableOptimization
{
    class Former
    {
        private static Dictionary<Board, int> mainBoards = new Dictionary<Board, int>();
        private static Dictionary<Board, int> reuseBoards = new Dictionary<Board, int>();
        private static List<Board> scrapBoards;

        private static Board boardInUse;
        private static Point workingPoint;

        private static Table _table;
        public Former(Dictionary<Board, int> boards)
        {
            workingPoint.XCoordinate = 0;
            workingPoint.YCoordinate = 0;
            SetMainBoards(boards);
        }

        public static void FormTable(BoardCatalogue catalogue, double endWidth, double endLength)
        {
            while (true)
            {
                
            }
            
        }
        public static void CutBoard(Board board)
        {
            // check if board is less than 1.5 inch, if so, discard
            if (board.Width < 1.5)
            {
                scrapBoards.Add(board);
            }
            else
            {
                var newBoard = board;
                board.Width -= 1.5;
                newBoard.Width -= board.Width;
                reuseBoards.Add(newBoard);
            }
            
        }

        public static void SelectBoard(double thickness, double length, double width)
        {
            // select a board  and run other methods as needed based on certain paramaters
            if (reuseBoards.Count > 0)
            {
                if (reuseBoards.ContainsKey(new Board { Thickness = thickness, Length = length, Width = width }))
                {
                    boardInUse = reuseBoards.Keys.Where(x => x.Thickness == thickness && x.Width == width && x.Length == length).FirstOrDefault();
                    reuseBoards[boardInUse] -= 1;
                }
                else if (reuseBoards.ContainsKey(new Board { Thickness = thickness }))
                {
                    boardInUse = reuseBoards.Keys.Where(x => x.Thickness == thickness).FirstOrDefault();
                    if (boardInUse.Width > 1.5)
                    {
                        CutBoard(boardInUse);
                    }
                }
                
            }

            boardInUse = mainBoards.Keys.Where(x => x.Thickness == thickness && x.Width == width && x.Length == length).FirstOrDefault();
        }

        public static void PlaceBoard()
        {

        }
        public static void SetMainBoards(Dictionary<Board, int> boards)
        {
            mainBoards = boards;
        }
    }
}
