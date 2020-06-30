using System;
using System.Collections.Generic;

namespace TableOptimization
{
    class Program
    {
        static void Main(string[] args)
        {

            var thicknessesDeckBoards = new double[] { .375, .5, .625, .75 };

            var widthsDeckBoards = new double[] { 5.25, 3 };

            var lengthsDeckBoards = new double[] { 6, 12, 18, 24, 30, 36, 42, 48 };

            var thicknessesStringers = new double[] { 1, 1.25 };

            var widthsStringers = new double[] { 3, 3.25 };

            var lengthsStringers = new double[] { 6, 12, 18, 24, 30, 36, 42, 48 };

            var catalogueDeckBoards = new BoardCatalogue(thicknessesDeckBoards, lengthsDeckBoards, widthsDeckBoards);

            var catalogueDeckBoardsList = catalogueDeckBoards.GetCatalogue();

            var catalogueStringers = new BoardCatalogue(thicknessesStringers, lengthsStringers, widthsStringers);

            var catalogueStringersList = catalogueStringers.GetCatalogue();

            int countDeckBoards = 0;

            int countStringers = 0;

            foreach (var board in catalogueDeckBoardsList)
            {
                Console.WriteLine("Length : " + board.Length);
                Console.WriteLine("Width : " + board.Width);
                Console.WriteLine("Thickness : " + board.Thickness);
                Console.WriteLine();
                countDeckBoards++;
            }

            foreach (var board in catalogueStringersList)
            {
                Console.WriteLine("Length : " + board.Length);
                Console.WriteLine("Width : " + board.Width);
                Console.WriteLine("Thickness : " + board.Thickness);
                Console.WriteLine();
                countStringers++;
            }

            Console.WriteLine("Number of boards : " + countDeckBoards);
            Console.WriteLine("Number of boards : " + countStringers);
        }
    }
}
