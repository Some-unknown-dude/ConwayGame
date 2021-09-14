using Logic;
using System;
using System.Threading;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            Grid grid = new Grid(GetRandomBool2DArray(random));
            while (true)
            {
                Console.WriteLine(grid);
                grid.Update();
                Thread.Sleep(100);
                Console.SetCursorPosition(0, 0);
            }
        }

        public static bool[,] GetRandomBool2DArray(Random random)
        {
            bool[,] result = new bool[Grid.size, Grid.size];
            for (int i = 0; i < Grid.size; ++i)
            {
                for (int j = 0; j < Grid.size; ++j)
                {
                    result[i, j] = random.Next(0, 2) == 0 ? false : true;
                }
            }

            return result;
        }
    }
}
