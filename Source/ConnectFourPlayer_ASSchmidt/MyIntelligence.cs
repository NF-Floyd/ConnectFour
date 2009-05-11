using ConnectFour;

namespace PlayerX
{
    public class MyIntelligence : PlayerIntelligence
    {
        // acts as player 1 only, because player-id is disregarded
        public override int MakeMove(int[,] sockets, int player)
        {
            int slot = 0;
            bool flag = false;
            for (int i = 0; i < sockets.GetLength(1); i++)
            {
                for (int n = 0; n < sockets.GetLength(0); n++)
                {
                    if (sockets[n, i] == 0)
                    {
                        slot = n;
                        flag = true;
                    }
                    if (flag)
                    {
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
            for (int j = 0; j < sockets.GetLength(1); j++)
            {
                for (int num5 = 0; num5 < sockets.GetLength(0); num5++)
                {
                    slot = Horizontal(sockets, slot, j, num5);
                }
            }
            for (int k = 0; k < sockets.GetLength(1); k++)
            {
                for (int num7 = 0; num7 < sockets.GetLength(0); num7++)
                {
                    slot = Diagonal(sockets, slot, k, num7);
                }
            }
            for (int m = 0; m < sockets.GetLength(0); m++)
            {
                for (int num9 = 0; num9 < sockets.GetLength(1); num9++)
                {
                    slot = Vertikal(sockets, slot, m, num9);
                }
            }
            return slot;
        }

        private static int Diagonal(int[,] sockets, int slot, int y, int x)
        {
            if ((((x + 3) < sockets.GetLength(0)) && ((y + 3) < sockets.GetLength(1))) && (sockets[x, y] == 2))
            {
                if (sockets[x + 1, y + 1] == 2)
                {
                    if (sockets[x + 2, y + 2] == 2)
                    {
                        if ((sockets[x + 3, y + 3] == 0) && (sockets[x + 3, y + 2] != 0))
                        {
                            slot = x + 3;
                        }
                    }
                    else if (((sockets[x + 2, y + 2] == 0) && (sockets[x + 3, y + 3] == 2)) && (sockets[x + 2, y + 1] != 0))
                    {
                        slot = x + 2;
                    }
                }
                else if (((sockets[x + 1, y + 1] == 0) && (sockets[x + 2, y + 2] == 2)) && ((sockets[x + 3, y + 3] == 2) && (sockets[x + 1, y] != 0)))
                {
                    slot = x + 1;
                }
            }
            if (((((x + 3) < sockets.GetLength(0)) && ((y + 3) < sockets.GetLength(1))) && ((sockets[x, y] == 0) && (sockets[x + 1, y + 1] == 2))) && ((sockets[x + 2, y + 2] == 2) && (sockets[x + 3, y + 3] == 2)))
            {
                slot = x;
            }
            if ((((x - 3) >= 0) && ((y + 3) < sockets.GetLength(1))) && (sockets[x, y] == 2))
            {
                if (sockets[x - 1, y + 1] == 2)
                {
                    if (sockets[x - 2, y + 2] == 2)
                    {
                        if ((sockets[x - 3, y + 3] == 0) && (sockets[x - 3, y + 2] != 0))
                        {
                            slot = x - 3;
                        }
                    }
                    else if (((sockets[x - 2, y + 2] == 0) && (sockets[x - 3, y + 3] == 2)) && (sockets[x - 2, y + 1] != 0))
                    {
                        slot = x - 2;
                    }
                }
                else if (((sockets[x - 1, y + 1] == 0) && (sockets[x - 2, y + 2] == 2)) && ((sockets[x - 3, y + 3] == 2) && (sockets[x - 1, y] != 0)))
                {
                    slot = x - 1;
                }
            }
            if (((((x - 3) >= 0) && ((y + 3) < sockets.GetLength(1))) && ((sockets[x, y] == 0) && (sockets[x - 1, y + 1] == 2))) && ((sockets[x - 2, y + 2] == 2) && (sockets[x - 3, y + 3] == 2)))
            {
                if ((y == 0) && (sockets[x, y] != 0))
                {
                    slot = x;
                    return slot;
                }
                if ((y > 0) && (sockets[x, y - 1] != 0))
                {
                    slot = x;
                }
            }
            return slot;
        }

        private static int Horizontal(int[,] sockets, int slot, int y, int x)
        {
            if (sockets[x, y] == 2)
            {
                if (((x + 1) < sockets.GetLength(0)) && (sockets[x + 1, y] == 2))
                {
                    if ((((x + 3) < sockets.GetLength(0)) && (sockets[x + 2, y] == 2)) && (sockets[x + 3, y] == 0))
                    {
                        if ((y > 0) && (sockets[x + 3, y - 1] != 0))
                        {
                            slot = x + 3;
                        }
                        else if (y == 0)
                        {
                            slot = x + 3;
                        }
                    }
                    if (((((x + 2) < sockets.GetLength(0)) && (sockets[x + 2, y] == 2)) && (((x - 1) > 0) && (sockets[x - 1, y] != 1))) && (sockets[x - 1, y] == 0))
                    {
                        if (((x > 0) && (y > 0)) && (sockets[x - 1, y - 1] != 0))
                        {
                            slot = x - 1;
                        }
                        else if (y == 0)
                        {
                            slot = x - 1;
                        }
                    }
                }
                if ((((x + 3) < sockets.GetLength(0)) && (sockets[x + 1, y] == 0)) && ((sockets[x + 2, y] == 2) && (sockets[x + 3, y] == 2)))
                {
                    if ((y > 0) && (sockets[x + 1, y - 1] != 0))
                    {
                        slot = x + 1;
                    }
                    else if ((y == 0) && (sockets[x + 1, y] == 0))
                    {
                        slot = x + 1;
                    }
                }
                if ((((x + 3) < sockets.GetLength(0)) && (sockets[x + 1, y] == 2)) && ((sockets[x + 2, y] == 0) && (sockets[x + 3, y] == 2)))
                {
                    if ((y > 0) && (sockets[x + 2, y - 1] != 0))
                    {
                        slot = x + 2;
                    }
                    else if ((y == 0) && (sockets[x + 2, y] == 0))
                    {
                        slot = x + 2;
                    }
                }
            }
            if (((((x + 3) < sockets.GetLength(0)) && ((x - 1) >= 0)) && ((sockets[x, y] == 2) && (sockets[x + 1, y] == 2))) && (((sockets[x + 2, y] == 0) && (sockets[x + 3, y] == 0)) && (sockets[x - 1, y] == 0)))
            {
                slot = x + 2;
            }
            if (((((x + 2) < sockets.GetLength(0)) && ((x - 2) >= 0)) && ((sockets[x, y] == 2) && (sockets[x + 1, y] == 2))) && (((sockets[x + 2, y] == 0) && (sockets[x - 2, y] == 0)) && (sockets[x - 1, y] == 0)))
            {
                slot = x - 1;
            }
            return slot;
        }

        private static int Vertikal(int[,] sockets, int slot, int x, int y)
        {
            if ((((sockets[x, y] == 2) && ((y + 1) < sockets.GetLength(1))) && ((sockets[x, y + 1] == 2) && ((y + 2) < sockets.GetLength(1)))) && (((sockets[x, y + 2] == 2) && ((y + 3) < sockets.GetLength(1))) && ((sockets[x, y + 3] != 1) && (sockets[x, y + 3] == 0))))
            {
                slot = x;
            }
            return slot;
        }
    }
}
