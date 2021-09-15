using System;
using System.Text;

namespace Logic
{
    public class ConwayGameGrid
    {
        private bool[,] grid;
        private readonly int size;
        private const int MaxProbability = 100;

        public ConwayGameGrid(int size, int lifeSpawnProbability)
        {
            this.size = size;
            this.grid = new bool[this.size, this.size];
            this.CreateInitialState(lifeSpawnProbability);
        }

        public void Update()
        {
            bool[,] newGrid = new bool[this.size, this.size];
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    newGrid[i, j] = this.UpdateToANewState(i, j);
                }
            }

            this.grid = newGrid;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    result.Append(this.grid[i, j] ? '█' : ' ');
                }

                result.Append('\n');
            }

            return result.ToString();
        }

        private bool UpdateToANewState(int row, int column)
        {
            int aliveCelsCount = 0;
            aliveCelsCount += this.IsInRange(row - 1, column - 1) && this.grid[row - 1, column - 1] ? 1 : 0;
            aliveCelsCount += this.IsInRange(row - 1, column) && this.grid[row - 1, column] ? 1 : 0;
            aliveCelsCount += this.IsInRange(row - 1, column + 1) && this.grid[row - 1, column + 1] ? 1 : 0;
            aliveCelsCount += this.IsInRange(row, column - 1) && this.grid[row, column - 1] ? 1 : 0;
            aliveCelsCount += this.IsInRange(row, column + 1) && this.grid[row, column + 1] ? 1 : 0;
            aliveCelsCount += this.IsInRange(row + 1, column - 1) && this.grid[row + 1, column - 1] ? 1 : 0;   
            aliveCelsCount += this.IsInRange(row + 1, column) && this.grid[row + 1, column] ? 1 : 0;
            aliveCelsCount += this.IsInRange(row + 1, column + 1) && this.grid[row + 1, column + 1] ? 1 : 0;

            if (this.grid[row, column])
            {
                return aliveCelsCount == 2 || aliveCelsCount == 3;
            }

            return aliveCelsCount == 3;
        }

        private void CreateInitialState(double lifeSpawnProbability)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < this.size; ++i)
            {
                for (int j = 0; j < this.size; ++j)
                {
                    this.grid[i, j] = random.NextDouble() * MaxProbability <= lifeSpawnProbability;
                }
            }
        }

        private bool IsInRange(int row, int column)
            => row >= 0 && row < this.size && column >= 0 && column < this.size;
    }
}
