using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DLabyrinth
{
    class Program
    {
        static void Main()
        {
            Solve();
        }

        static void Solve()
        {
            //bool[level, row, column];
            var startPositionAsString = Console.ReadLine();
            var startPositionParts = startPositionAsString.Split(' ');

            var startCell = new Cell<int>(
                int.Parse(startPositionParts[0]),
                int.Parse(startPositionParts[1]),
                int.Parse(startPositionParts[2]),
                0);

            var dimensionsAsString = Console.ReadLine();
            var dimensionsParts = dimensionsAsString.Split(' ');
            var levels = int.Parse(dimensionsParts[0]);
            var rows = int.Parse(dimensionsParts[1]);
            var columns = int.Parse(dimensionsParts[2]);

            var labyrinth = new char[levels, rows, columns];
            for (int l = 0; l < levels; l++)
            {
                for (int r = 0; r < rows; r++)
                {
                    string line = Console.ReadLine();
                    for (int c = 0; c < columns; c++)
                    {
                        labyrinth[l, r, c] = line[c];
                    }
                }
            }

            var used = new HashSet<Cell<int>>();
            var queue = new Queue<Cell<int>>();
            queue.Enqueue(startCell);
            used.Add(startCell);

            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();

                if (cell.Column > 0) // left
                {
                    var nextCell = new Cell<int>(cell.Level, cell.Row, cell.Column - 1, cell.QueueLevel + 1);

                    if (!used.Contains(nextCell) && labyrinth[cell.Level, cell.Row, cell.Column] != '#')
                    {
                        queue.Enqueue(nextCell);
                        used.Add(nextCell);
                    }
                }

                if (cell.Column < columns - 1) // right
                {
                    var nextCell = new Cell<int>(cell.Level, cell.Row, cell.Column + 1, cell.QueueLevel + 1);

                    if (!used.Contains(nextCell) && labyrinth[cell.Level, cell.Row, cell.Column] != '#')
                    {
                        queue.Enqueue(nextCell);
                        used.Add(nextCell);
                    }
                }

                if (cell.Row > 0) // back 
                {
                    var nextCell = new Cell<int>(cell.Level, cell.Row - 1, cell.Column, cell.QueueLevel + 1);

                    if (!used.Contains(nextCell) && labyrinth[cell.Level, cell.Row, cell.Column] != '#')
                    {
                        queue.Enqueue(nextCell);
                        used.Add(nextCell);
                    }
                }

                if (cell.Row < rows - 1) // forward 
                {
                    var nextCell = new Cell<int>(cell.Level, cell.Row + 1, cell.Column, cell.QueueLevel + 1);

                    if (!used.Contains(nextCell) && labyrinth[cell.Level, cell.Row, cell.Column] != '#')
                    {
                        queue.Enqueue(nextCell);
                        used.Add(nextCell);
                    }
                }

                if (labyrinth[cell.Level, cell.Row, cell.Column] == 'U') // up
                {
                    if (cell.Level + 1 == levels)
                    {
                        Console.WriteLine(cell.QueueLevel + 1);
                        Environment.Exit(0);
                    }

                    else
                    {
                        var nextCell = new Cell<int>(cell.Level + 1, cell.Row, cell.Column, cell.QueueLevel + 1);

                        if (!used.Contains(nextCell) && labyrinth[cell.Level, cell.Row, cell.Column] != '#')
                        {
                            queue.Enqueue(nextCell);
                            used.Add(nextCell);
                        }
                    }
                }

                if (labyrinth[cell.Level, cell.Row, cell.Column] == 'D') // down
                {
                    if (cell.Level == 0)
                    {
                        Console.WriteLine(cell.QueueLevel + 1);
                        Environment.Exit(0);
                    }

                    else
                    {
                        var nextCell = new Cell<int>(cell.Level - 1, cell.Row, cell.Column, cell.QueueLevel + 1);

                        if (!used.Contains(nextCell) && labyrinth[cell.Level, cell.Row, cell.Column] != '#')
                        {
                            queue.Enqueue(nextCell);
                            used.Add(nextCell);
                        }
                    }
                }
            }
        }
    }

    class Cell<T>
    {
        public Cell(T level, T row, T column, int queueLevel)
        {
            this.Level = level;
            this.Row = row;
            this.Column = column;
            this.QueueLevel = queueLevel;
        }

        public T Level { get; set; }

        public T Row { get; set; }

        public T Column { get; set; }

        public int QueueLevel { get; set; }

        public override bool Equals(object obj)
        {
            var otherCell = obj as Cell<T>;
            if (otherCell == null)
            {
                return false;
            }

            return this.Level.Equals(otherCell.Level) 
                && this.Row.Equals(otherCell.Row)
                && this.Column.Equals(otherCell.Column);
        }

        public override int GetHashCode()
        {
            return this.Level.GetHashCode() ^
                this.Row.GetHashCode() ^
                this.Column.GetHashCode();
        }
    }
}
