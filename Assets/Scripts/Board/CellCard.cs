using Game.GridSystem;

namespace Game.Cards
{
    public class CellCard
    {
        public Cell Cell { get; private set; }
        public int Cost { get; private set; }

        public CellCard(Cell cell, int cost)
        {
            Cell = cell;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"{Cell.Id} (${Cost})";
        }
    }
}
