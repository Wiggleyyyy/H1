using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gambling
{
    public class MinesData
    {
        public int NumberOfMines { get; set; }
        public double MoneyBet { get; set; }
        List<Field> Fields { get; set; }
        //Maybe add multiplier method here?
    }

    public class Field
    {
        public int MineID { get; set; }
        public bool IsMine { get; set; }
    }
}
