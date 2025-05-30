using System.Collections.Generic;
using UnityEngine;

namespace Game.Buildings
{
    public class Building
    {
        public string Name { get; private set; }
        public int Income { get; private set; }
        public int Population { get; private set; }
        public List<Vector2Int> Shape { get; private set; }

        public Building(string name, int income, int population, List<Vector2Int> shape)
        {
            Name = name;
            Income = income;
            Population = population;
            Shape = shape;
        }

        public List<Vector2Int> GetRelativePositions()
        {
            return new List<Vector2Int>(Shape);
        }

        public override string ToString()
        {
            return $"{Name} (Income: {Income}, Pop: {Population}, Size: {Shape.Count} cells)";
        }
    }
}