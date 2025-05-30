using System.Collections.Generic;
using Game.GridSystem;
using Game.Utils;

namespace Game.Managers
{
    public class GridManager
    {
        private Dictionary<string, Cell> grid;

        public GridManager()
        {
            grid = new Dictionary<string, Cell>();

            foreach (string id in BoardIDs.GenerateCellIds())
            {
                grid.Add(id, new Cell(id));
            }
        }

        public Cell GetCell(string id)
        {
            return grid.ContainsKey(id) ? grid[id] : null;
        }

        public Dictionary<string, Cell> GetAllCells() => grid;
    }
}
