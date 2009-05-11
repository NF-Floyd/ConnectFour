using System.Collections.Generic;

namespace ConnectFour
{
    class ConnectFinder
    {
        List<FieldInfo> _fili;

        public ConnectFinder(int maxLen)
        {
            _fili = new List<FieldInfo>(maxLen);
        }

        public void Add(FieldInfo fi)
        {
            _fili.Add(fi);
        }

        internal int FindWinner(ref FieldInfo[,] fields)
        {
            int winner = FindWinner();

            foreach (FieldInfo fi in _fili)
                fields[fi.X, fi.Y].Player = fi.Player;

            _fili.Clear();

            return winner;
        }

        private int FindWinner()
        {
            if (_fili.Count < 4) return 0;

            for (int i = 0; i <= _fili.Count - 4; i++)
            {
                for (int p = 0; p < 2; p++)
                    if (FindConnect(i, p + 1)) return p + 1;
            }

            return 0;
        }

        private bool FindConnect(int index, int player)
        {
            if (_fili[index].Player == player &&
                _fili[index + 1].Player == player &&
                _fili[index + 2].Player == player &&
                _fili[index + 3].Player == player)
            {
                for (int i = 0; i < 4; i++)
                    SetWon(index + i);

                return true;
            }

            return false;
        }

        private void SetWon(int index)
        {
            FieldInfo fi = _fili[index];
            fi.SetWon();
            _fili[index] = fi;
        }
    }
}
