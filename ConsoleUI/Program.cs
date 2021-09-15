using Logic;
using System;
using System.Threading;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.CursorVisible = false;
            Console.WriteLine("Press any key...");
            Console.Read();
            Console.Clear();
            ConwayGameGrid grid = new ConwayGameGrid(100, 50);
            while (true)
            {
                Console.WriteLine(grid);
                grid.Update();
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(1);
            }
        }
    }
}
