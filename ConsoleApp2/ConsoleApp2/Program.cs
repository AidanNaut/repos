using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleExtender;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(Console.LargestWindowWidth - 3, Console.LargestWindowHeight - 1);

            int hWnd = Process.GetCurrentProcess().MainWindowHandle.ToInt32();

            Console.SetBufferSize(Console.LargestWindowWidth - 3, Console.LargestWindowHeight - 1);

            var fonts = ConsoleHelper.ConsoleFonts;

            Console.ReadKey();

            for (int f = 0; f < fonts.Length; f++)

                Console.WriteLine("{0}: X={1}, Y={2}",

                   fonts[f].Index, fonts[f].SizeX, fonts[f].SizeY);

            ConsoleHelper.SetConsoleFont(5);


            Console.WriteLine("Test one two three . . .");

            Console.ReadKey();

            ConsoleHelper.SetConsoleFont(12);


            Console.WriteLine("Test one two three . . .");

            Console.ReadKey();

            // ConsoleHelper.SetConsoleIcon(SystemIcons.Information);

            

            //Move();
            //ShowWindow(hWnd, SW_MAXIMIZE);
        }

       
        
    }
}
