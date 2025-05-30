using UnityEngine;
using Game.Buildings;

namespace Game.GridSystem
{
    public class Cell : MonoBehaviour
    {
        [field: SerializeField] public string Id { get; private set; }
        [SerializeField] private Renderer cellRenderer;
        [SerializeField] private Color defaultColor = Color.gray;
        [SerializeField] private Color player1Color = Color.green;
        [SerializeField] private Color player2Color = Color.red;
        [SerializeField] private Color buildingColor = Color.blue;

        public int OwnerId { get; private set; } = 0;
        public bool IsOwned { get;  set; } = false;
        public Building OccupiedBuilding { get; private set; }

        public void SetOwner(int playerId)
        {
            OwnerId = playerId;
            IsOwned = true;
            UpdateVisual();
        }

        public void Initialize(string id)
        {
            Id = id;
            IsOwned = false;
            OwnerId = 0;
            OccupiedBuilding = null;
            UpdateVisual();
        }

        public void PlaceBuilding(Building building)
        {
            OccupiedBuilding = building;
            UpdateVisual();
        }

        public bool IsEmpty()
        {
            return IsOwned && OccupiedBuilding == null;
        }

        public void UpdateVisual()
        {
            if (OccupiedBuilding != null)
            {
                cellRenderer.material.color = buildingColor;
            }
            else if (IsOwned)
            {
                cellRenderer.material.color = OwnerId switch
                {
                    1 => player1Color,
                    2 => player2Color,
                    _ => defaultColor
                };
            }
            else
            {
                cellRenderer.material.color = defaultColor;
            }
        }

        public void Reset()
        {
            IsOwned = false;
            OwnerId = 0;
            OccupiedBuilding = null;
            UpdateVisual();
        }
    }
}