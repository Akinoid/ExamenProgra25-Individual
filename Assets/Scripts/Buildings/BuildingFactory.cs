using System.Collections.Generic;
using UnityEngine;

namespace Game.Buildings
{
    public static class BuildingFactory
    {
        public static Building CreateSingleCellBuilding(string name, int income, int population)
        {
            return new Building(name, income, population, new List<Vector2Int> { new Vector2Int(0, 0) });
        }

        public static Building CreateTwoByTwoBuilding(string name, int income, int population)
        {
            return new Building(name, income, population, new List<Vector2Int>
            {
                new Vector2Int(0, 0),
                new Vector2Int(1, 0),
                new Vector2Int(0, 1),
                new Vector2Int(1, 1)
            });
        }

        public static Building CreateLShapedBuilding(string name, int income, int population)
        {
            return new Building(name, income, population, new List<Vector2Int>
            {
                new Vector2Int(0,0),
                new Vector2Int(1,0),
                new Vector2Int(0,1)
            });
        }
    }
}