using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _031_Bootstrap_Hastane_Deneme.classes
{
    public class VeriKontrol
    {
        public bool Kontrol(string tx)
        {
            if (tx != string.Empty || tx != "")
                return true;
            else
                return false;
        }
    }
}