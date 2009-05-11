using System;
using System.Threading;
using ConnectFour;

namespace PlayerX
{
    public class MyIntelligence : PlayerIntelligence
    {
        public override int MakeMove(int[,] sockets, int player)
        {
            Thread.Sleep(1);
            Random random = new Random();
            return random.Next(0, sockets.GetLength(0));
        }
    }
}
