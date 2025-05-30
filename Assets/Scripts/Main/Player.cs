using System.Collections.Generic;
using Game.GridSystem;

namespace Game.Players
{
    public class Player
    {
        public string Name { get; private set; }
        public int Money { get; set; }
        public List<Cell> OwnedCells { get; private set; }

        public Player(string name, int startingMoney = 20)
        {
            Name = name;
            Money = startingMoney;
            OwnedCells = new List<Cell>();
        }

        public bool BuyCell(CellCard card)
        {
            if (Money >= card.Cost && !card.Cell.IsOwned)
            {
                Money -= card.Cost;
                card.Cell.IsOwned = true;
                OwnedCells.Add(card.Cell);
                return true;
            }

            return false;
        }
    }
}
