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

    public class BlackJackData
    {
        public double MoneyBet { get; set; }
        public bool GameActive { get; set; }
        public string Wins { get; set; }
        public int NumberOfHands { get; set; }
        public bool DealerHasBlackJack { get; set; }
        public bool PlayerHasBlackJackHand1 { get; set; }
        public bool PlayerHasBlackJackHand2 { get; set; }
        public bool PlayerHasBlackJackHand3 { get; set; }
        public List<Card> PlayerCards { get; set; }
        public List<Card> DealerCards { get; set; }
        public List<Card> AvailableCards { get; set; }
    }

    public class Card
    {
        public string CardName { get; set; }
        public string CardRank { get; set; }
        public string CardSuit { get; set; }
        public string CardHand { get; set; }
    }
    public enum HandStatus
    {
        NONE,
        WIN,
        DRAW,
        LOSS,
    }

    public class CrashData
    {
        public double MoneyBet { get; set; }
        public bool GameActive { get; set; }
        public bool CashedOut { get; set; }
        public double AutoCashOut { get; set; }
        public CrashData()
        {
            GameActive = false;
            CashedOut = false;
        }
    }
}
