using Game.Buildings;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerBuildingSetup
{
    public static List<Building> GetDefaultBuildings()
    {
        var buildings = new List<Building>();
        buildings.Add(BuildingFactory.CreateSingleCellBuilding("Basic 1x1 #1", 7, 10));
        buildings.Add(BuildingFactory.CreateSingleCellBuilding("Basic 1x1 #2", 7, 10));
        buildings.Add(BuildingFactory.CreateSingleCellBuilding("Basic 1x1 #3", 7, 10));
        buildings.Add(BuildingFactory.CreateSingleCellBuilding("Basic 1x1 #4", 7, 10));
        buildings.Add(BuildingFactory.CreateSingleCellBuilding("Basic 1x1 #5", 7, 10));
        buildings.Add(BuildingFactory.CreateSingleCellBuilding("Basic 1x1 #6", 7, 10));
        buildings.Add(BuildingFactory.CreateSingleCellBuilding("Basic 1x1 #7", 7, 10));
        buildings.Add(BuildingFactory.CreateSingleCellBuilding("Basic 1x1 #8", 7, 10));
        buildings.Add(BuildingFactory.CreateSingleCellBuilding("Basic 1x1 #9", 7, 10));
        buildings.Add(BuildingFactory.CreateSingleCellBuilding("Basic 1x1 #10", 7, 10));
        buildings.Add(BuildingFactory.CreateSingleCellBuilding("Basic 1x1 #11", 7, 10));
        buildings.Add(BuildingFactory.CreateSingleCellBuilding("Basic 1x1 #12", 7, 10));
        buildings.Add(BuildingFactory.CreateSingleCellBuilding("Basic 1x1 #13", 7, 10));
        buildings.Add(BuildingFactory.CreateSingleCellBuilding("Basic 1x1 #14", 7, 10));
        buildings.Add(BuildingFactory.CreateSingleCellBuilding("Basic 1x1 #15", 7, 10));

        buildings.Add(BuildingFactory.CreateTwoByTwoBuilding("Building 2x2 #1", 5, 3));
        buildings.Add(BuildingFactory.CreateTwoByTwoBuilding("Building 2x2 #2", 5, 3));

        buildings.Add(new Building("Building 1x4 #1", 4, 2, new List<Vector2Int>
        {
            new Vector2Int(0,0),
            new Vector2Int(0,1),
            new Vector2Int(0,2),
            new Vector2Int(0,3)
        }));

        buildings.Add(new Building("Building 1x4 #2", 4, 2, new List<Vector2Int>
        {
            new Vector2Int(0,0),
            new Vector2Int(0,1),
            new Vector2Int(0,2),
            new Vector2Int(0,3)
        }));

        buildings.Add(new Building("Building 1x3 #1", 3, 1, new List<Vector2Int>
        {
            new Vector2Int(0,0),
            new Vector2Int(0,1),
            new Vector2Int(0,2)
        }));

        buildings.Add(new Building("Building 1x3 #2", 3, 1, new List<Vector2Int>
        {
            new Vector2Int(0,0),
            new Vector2Int(0,1),
            new Vector2Int(0,2)
        }));

        for (int i = 1; i <= 4; i++)
        {
            buildings.Add(BuildingFactory.CreateSingleCellBuilding($"Building 1x1 #{i}", 1, 1));
        }

        for (int i = 1; i <= 4; i++)
        {
            buildings.Add(new Building($"Building 1x2 #{i}", 2, 1, new List<Vector2Int>
            {
                new Vector2Int(0,0),
                new Vector2Int(0,1)
            }));
        }

        buildings.Add(BuildingFactory.CreateLShapedBuilding("Building L #1", 4, 2));
        buildings.Add(BuildingFactory.CreateLShapedBuilding("Building L #2", 4, 2));

        return buildings;

    }


}