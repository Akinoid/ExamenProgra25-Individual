using UnityEngine;

namespace Game.GridSystem
{
    public class Cell: MonoBehaviour
    {
        public string Id { get; private set; }
        public bool IsOwned { get; set; }

        public Cell(string id)
        {
            Id = id;
            IsOwned = false;
        }

        public override string ToString()
        {
            return $"Cell {Id} - Owned: {IsOwned}";
        }
    }
}