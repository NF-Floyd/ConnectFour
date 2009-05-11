using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    public abstract class PlayerIntelligence
    {
        /// <summary>
        /// Will be called for each player's turn.
        /// </summary>
        /// <param name="sockets">Sockets of the playing field (0: not assigned, 1/2: assigned by according player).</param>
        /// <param name="player">Number of own player's id.</param>
        /// <returns>Column (beginning with 0), which should be occupied.</returns>
        public abstract int MakeMove(int[,] sockets, int player);
    }
}
