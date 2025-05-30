using UnityEngine;
using Game.Buildings;

namespace Game.GridSystem
{
    public class Cell : MonoBehaviour
    {
        [field: SerializeField] public string Id { get; private set; }
        [SerializeField] private Renderer cellRenderer;

        [SerializeField] private Color defaultColor = Color.gray;
        [SerializeField] private Color ownedColor = Color.green;
        [SerializeField] private Color buildingColor = Color.blue;

        public bool IsOwned { get; set; }
        public Building OccupiedBuilding { get; private set; }

        public void Initialize(string id)
        {
            Id = id;
            IsOwned = false;
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
                cellRenderer.material.color = buildingColor;
            else if (IsOwned)
                cellRenderer.material.color = ownedColor;
            else
                cellRenderer.material.color = defaultColor;
        }
    }
}