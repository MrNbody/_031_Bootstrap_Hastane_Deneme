using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _031_Bootstrap_Hastane_Deneme.classes
{
    public class TCHesap
    {
        int[] TC = new int[11];
        int i;
        public TCHesap(string tc)
        {
            i = 0;
            foreach (char item in tc)
            {
                (TC[i]) = (int)Char.GetNumericValue(item);
                i++;
            }
        }

        public bool Kontrol()
        {
            int a10 = ((((TC[0]) + (TC[2]) + (TC[4]) + (TC[6]) + (TC[8])) * 7) - ((TC[1]) + (TC[3]) + (TC[5]) + (TC[7]))) % 10;
            if ((TC[9]) == a10)
            {
                int a11 = 0;
                foreach (int item in TC)
                {
                    a11 += item;
                }
                a11 = a11 % 10;
                if ((TC[10]) == a11)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}