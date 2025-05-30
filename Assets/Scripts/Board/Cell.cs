using UnityEngine;
using Game.Buildings;

namespace Game.GridSystem
{
    public class Cell : MonoBehaviour
    {
        [field: SerializeField] public string Id { get; private set; }
        public bool IsOwned { get; set; }
        public Building OccupiedBuilding { get; private set; }

        public void Initialize(string id)
        {
            Id = id;
            IsOwned = false;
            OccupiedBuilding = null;
        }

        public void PlaceBuilding(Building building)
        {
            OccupiedBuilding = building;
        }

        public bool IsEmpty()
        {
            return IsOwned && OccupiedBuilding == null;
        }

        public override string ToString()
        {
            return $"Cell {Id} - Owned: {IsOwned}";
        }
    }
}