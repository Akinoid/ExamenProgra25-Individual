using System.Collections.Generic;
using Game.Buildings;
using Game.GridSystem;
using Game.Players;
using UnityEngine;
using Game.Utils;

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
            
            Cell origin = gridManager.GetCell(originCellId);
            if (origin == null) return false;

           
            Vector2Int originPos = BoardIDs.IdToCoords(originCellId);

            
            
            List<string> requiredCellIds = new List<string>();

            
            foreach (Vector2Int offset in building.GetRelativePositions())
            {
                Vector2Int pos = originPos + offset;
                string cellId = BoardIDs.CoordsToId(pos);

                
                if (!gridManager.GetAllCells().ContainsKey(cellId))
                    return false;

                requiredCellIds.Add(cellId);
            }

            
            if (!player.OwnsCells(requiredCellIds))
                return false;

            
            List<Cell> targetCells = new List<Cell>();
            foreach (var id in requiredCellIds)
            {
                Cell cell = gridManager.GetCell(id);
                if (cell != null)
                {
                    targetCells.Add(cell);
                }
                else
                {
                    
                    return false;
                }
            }

            
            player.PlaceBuilding(building, targetCells);

            return true;
        }
    }
}