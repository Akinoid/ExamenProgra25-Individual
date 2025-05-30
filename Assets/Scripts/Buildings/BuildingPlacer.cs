sing System.Collections.Generic;
using Game.Buildings;
using Game.GridSystem;
using Game.Players;
using UnityEngine;

namespace Game.Managers
{
    public class BuildingPlacer
    {
        private GridManager gridManager;

        public BuildingPlacer(GridManager gridManager)
        {
            this.gridManager = gridManager;
        }

        public bool TryPlaceBuilding(Player player, string originCellId, Building building)
        {
            List<string> requiredCells = new List<string>();
            Cell? origin = gridManager.GetCell(originCellId);
            if (origin == null) return false;

            Vector2Int originPos = GridUtils.IdToCoords(originCellId);

            foreach (Vector2Int offset in building.GetRelativePositions())
            {
                Vector2Int pos = originPos + offset;
                string cellId = GridUtils.CoordsToId(pos);
                if (!gridManager.GetAllCells().ContainsKey(cellId)) return false;
                requiredCells.Add(cellId);
            }

            if (!player.OwnsCells(requiredCells)) return false;

            player.ApplyBuildingEffects(building);
            return true;
        }
    }
}
