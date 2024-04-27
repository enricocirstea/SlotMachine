using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinningsCalculator
{
    public class WinType
    {
        public String WinLine { get; set; }
        public double WinAmount { get; set; }
        public int IconAmount { get; set; }
        public WinType(String winLine, double winAmount, int iconAmount)
        {
            WinLine = winLine;
            WinAmount = winAmount;
            IconAmount = iconAmount;
        }
    }
}
