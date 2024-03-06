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
        public int CleardFields { get; set; }
        public double MoneyBet { get; set; }
        public List<Field> Fields { get; set; }
        public bool GameActive { get; set; }
        //Maybe add multiplier method here?
        public MinesData()
        {
            GameActive = false;
        }
    }

    public class Field
    {
        public int MineID { get; set; }
        public string MineName { get; set; }
        public bool IsMine { get; set; }
        public bool IsRevealed { get; set; }
    }
}
