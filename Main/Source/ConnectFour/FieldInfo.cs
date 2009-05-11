using System;

namespace ConnectFour
{
    internal struct FieldInfo
    {
        public void SetWon()
        {
            if (_player == 1)
                _player = 3;
            if (_player == 2)
                _player = 4;
        }

        int _player;
        public int Player
        {
            get { return _player; }
            set { _player = value; }
        }

        int _xValue;
        public int X
        {
            get { return _xValue; }
            set { _xValue = value; }
        }

        int _yValue;
        public int Y
        {
            get { return _yValue; }
            set { _yValue = value; }
        }

        public override string ToString()
        {
            return string.Format("[{0},{1}] Player {2}", _xValue, _yValue, _player);
        }
    }
}
