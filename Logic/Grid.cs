using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Grid
    {
        public const int size = 100;
        private bool[,] grid = new bool[size, size];

        public Grid(bool[,] array)
        {
            this.grid = array;
        }

        public void Update()
        {
            bool[,] newGrid = (bool[,])grid.Clone();
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    newGrid[i, j] = this.UpdateToANewState(this.grid[i, j], GetAllNeighboutCells(i, j));
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

        private void ValidateCoordinates((int row, int column)[] startCoordinates)
        {
            foreach (var (row, column) in startCoordinates)
            {
                if (row < 0 || row >= size)
                {
                    throw new ArgumentOutOfRangeException(nameof(row), $"{nameof(row)} must be between 0 and ({nameof(size)} - 1) inclusive.");
                }

                if (column < 0 || column >= size)
                {
                    throw new ArgumentOutOfRangeException(nameof(row), $"{nameof(row)} must be between 0 and ({nameof(size)} - 1) inclusive.");
                }
            }
        }

        private bool UpdateToANewState(bool initialState, IEnumerable<bool> neighbours)
        {
            int aliveNeighboursCount = neighbours.Count(c => c);
            if (initialState)
            {
                return (aliveNeighboursCount == 2 || aliveNeighboursCount == 3);
            }

            return aliveNeighboursCount == 3;
        }

        private IEnumerable<bool> GetAllNeighboutCells(int row, int column)
        {
            for (int i = -1; i <= 1; ++i)
            {
                if (IsInRange(row + i, column - 1))
                {
                    yield return this.grid[row + i, column - 1];
                }

                if (IsInRange(row + i, column + 1))
                {
                    yield return this.grid[row + i, column + 1];
                }
            }

            if (IsInRange(row - 1, column))
            {
                yield return this.grid[row - 1, column];
            }

            if (IsInRange(row + 1, column))
            {
                yield return this.grid[row + 1, column];
            }
        }

        private bool IsInRange(int row, int column) => row >= 0 && row < size && column >= 0 && column < size;
    }
}
