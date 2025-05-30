using System.Collections.Generic;
using Game.GridSystem;
using Game.Players;
using UnityEngine;
using Game.Managers;
using Game.Utils;

namespace Game.Managers
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private Cell cellPrefab;
        [SerializeField] public GameObject buildingVisualPrefab;

        private Dictionary<string, Cell> grid;

        public Player Player1;
        public PurchaseRow purchaseRow;
        public PurchaseRowUI purchaseRowUI;

        private void Awake()
        {
            grid = new Dictionary<string, Cell>();

            foreach (string id in BoardIDs.GenerateCellIds())
            {
                Cell newCell = Instantiate(cellPrefab, transform);
                newCell.Initialize(id);

                Vector2Int coords = BoardIDs.IdToCoords(id);
                newCell.transform.localPosition = new Vector3(coords.x, 0f, coords.y);

                grid.Add(id, newCell);
            }
        }

        private void Start()
        {
            purchaseRow = new PurchaseRow(this);
            purchaseRowUI.Initialize(purchaseRow);
        }

        public Cell GetCell(string id)
        {
            return grid.ContainsKey(id) ? grid[id] : null;
        }

        public Dictionary<string, Cell> GetAllCells() => grid;
    }
}