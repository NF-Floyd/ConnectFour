using System;
using System.Collections.Generic;
using System.Threading;
using ConnectFour;

namespace PlayerX
{
    public class MyIntelligence : PlayerIntelligence
    {
        private const int THE_NEED = 4;

        public override int MakeMove(int[,] felder, int me)
        {
            MyField f = new MyField(felder, me);

            List<FieldInfo> bestFields = new List<FieldInfo>();
            foreach (FieldInfo fi in f.FieldInfos)
            {
                if (bestFields.Count == 0)
                {
                    bestFields.Add(fi);
                    continue;
                }

                if (bestFields.Count > 0 && fi.Weight >= bestFields[0].Weight)
                {
                    if (fi.Weight > bestFields[0].Weight)
                        bestFields.Clear();

                    bestFields.Add(fi);
                }
            }

            int oneBest = 0;
            if (bestFields.Count > 1)
            {
                Thread.Sleep(3);
                Random r = new Random();
                oneBest = r.Next(0, bestFields.Count);
            }

            return bestFields[oneBest].X;
        }
    }
}
