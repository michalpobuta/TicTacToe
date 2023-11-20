namespace TicTacToe.TicTacToeGame
{
    public struct Array2D
    {
        private int[,] array;

        public Array2D(int rows, int cols)
        {
            array = new int[rows, cols];
        }
        public Point LastElement { get; private set; }

        public int this[int row, int col]
        {
            get
            {
                if (row >= 0 && row < array.GetLength(0) && col >= 0 && col < array.GetLength(1))
                    return array[row, col];
                throw new IndexOutOfRangeException("Indeks poza zakresem.");
            }
            set
            {
                if (row >= 0 && row < array.GetLength(0) && col >= 0 && col < array.GetLength(1)) 
                {
                    array[row, col] = value;
                    LastElement = new Point(row, col);
                }
                else
                    throw new IndexOutOfRangeException("Indeks poza zakresem.");
            }
        }
        public int GetLength(int dim) {
            return array.GetLength(dim);
        }
    }
}
