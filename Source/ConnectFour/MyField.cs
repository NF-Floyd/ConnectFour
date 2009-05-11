using System;

namespace ConnectFour
{
    internal class MyField
    {
        FieldInfo[,] _fields;
        int _width;
        int _height;
        int _winner;

        public MyField(int[,] fields)
        {
            _width = fields.GetLength(0);
            _height = fields.GetLength(1);
            _fields = new FieldInfo[_width, _height];

            InitializeFields(fields);

            _winner = FindVerticalWinner();

            if (_winner != 0) return;
            _winner = FindHorizontalWinner();

            if (_winner != 0) return;
            _winner = FindDiagonalWinner();
        }

        private void InitializeFields(int[,] fields)
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _fields[x, y].X = x;
                    _fields[x, y].Y = y;
                    _fields[x, y].Player = fields[x, y];
                }
            }
        }

        internal FieldInfo[,] FieldInfos
        {
            get { return _fields; }
        }

        internal int Winner
        {
            get { return _winner; }
        }

        private int FindVerticalWinner()
        {
            int winner = 0;
            ConnectFinder cf = new ConnectFinder(_height);

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                    cf.Add(_fields[x, y]);

                winner = cf.FindWinner(ref _fields);
                if (winner != 0)
                    return winner;
            }

            return winner;
        }

        private int FindHorizontalWinner()
        {
            int winner = 0;
            ConnectFinder cf = new ConnectFinder(_width);

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                    cf.Add(_fields[x, y]);

                winner = cf.FindWinner(ref _fields);
                if (winner != 0)
                    return winner;
            }

            return winner;
        }

        private int FindDiagonalWinner()
        {
            int winner = 0;
            ConnectFinder cfUp = new ConnectFinder(Math.Max(_width, _height));
            ConnectFinder cfDown = new ConnectFinder(Math.Max(_width, _height));

            // iterate through the rows
            for (int y = 0; y < _height; y++)
            {
                // shifting through positions
                for (int z = 0; z < _width; z++)
                {
                    if (y + z < _height)
                        cfUp.Add(_fields[z, y + z]); // we are 'z' units right and up from home
                    if (y - z >= 0)
                        cfDown.Add(_fields[z, y - z]); // we are 'z' units right and down from home
                }

                winner = cfUp.FindWinner(ref _fields);
                if (winner != 0) return winner;
                winner = cfDown.FindWinner(ref _fields);
                if (winner != 0) return winner;
            }

            // iterate through the columns (the first [0,0], we had already)
            for (int x = 1; x < _width; x++)
            {
                // shifting through positions
                for (int z = 0; z < _height; z++)
                {
                    if (x + z < _width)
                        cfUp.Add(_fields[x + z, z]); // we are 'z' units right and up from home
                    if (x - z >= 0)
                        cfDown.Add(_fields[x - z, z]); // we are 'z' units right and down from home
                }

                winner = cfUp.FindWinner(ref _fields);
                if (winner != 0) return winner;
                winner = cfDown.FindWinner(ref _fields);
                if (winner != 0) return winner;
            }

            return winner;
        }
    }
}
