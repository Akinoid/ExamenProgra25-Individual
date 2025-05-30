using System.Collections.Generic;
using Game.Cards;
using Game.GridSystem;
using Game.Utils;

namespace Game.Managers
{
    public class PurchaseRow
    {
        private Queue<string> deck;
        private List<CellCard> row;
        private GridManager gridManager;

        public IReadOnlyList<CellCard> Row => row;

        public PurchaseRow(GridManager gridManager)
        {
            this.gridManager = gridManager;
            deck = new Queue<string>(BoardIDs.GenerateCellIds());
            row = new List<CellCard>();

            for (int i = 0; i < 10; i++)
                DrawNextCard();
        }

        private void DrawNextCard()
        {
            if (deck.Count == 0) return;

            string nextId = deck.Dequeue();
            Cell cell = gridManager.GetCell(nextId);
            if (cell != null)
            {
                int cost = row.Count + 1;
                row.Add(new CellCard(cell, cost));
            }
        }

        public CellCard BuyCardAt(int index)
        {
            if (index < 0 || index >= row.Count)
                return null;

            CellCard bought = row[index];
            row.RemoveAt(index);
            ShiftLeftAndAddNew();
            return bought;
        }

        private void ShiftLeftAndAddNew()
        {
            
            for (int i = 0; i < row.Count; i++)
            {
                row[i] = new CellCard(row[i].Cell, i + 1);
            }

            DrawNextCard();
        }
    }
}
