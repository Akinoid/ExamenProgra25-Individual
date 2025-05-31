using System.Collections.Generic;
using Game.GridSystem;
using Game.Cards;
using Game.Buildings;
using UnityEngine;

namespace Game.Players
{
    public class Player
    {
        private static int playerCount = 0;
        private int playerId;

        public string Name { get; private set; }
        public int Money { get; set; }
        public int Population { get; set; }

        public List<Cell> OwnedCells { get; private set; }
        public List<Building> AvailableBuildings { get; set; }
        public Dictionary<string, int> AvailableBuildingsDict { get; private set; }
        public List<Building> PlacedBuildings { get; private set; }

        public Player(string name, int startingMoney = 20)
        {
            playerCount++;
            playerId = playerCount;

            Name = name;
            Money = startingMoney;
            Population = 0;
            OwnedCells = new List<Cell>();
            PlacedBuildings = new List<Building>();

            AvailableBuildings = PlayerBuildingSetup.GetDefaultBuildings();
            AvailableBuildingsDict = new Dictionary<string, int>();
            var defaultBuildings = PlayerBuildingSetup.GetDefaultBuildings();
            foreach (var building in defaultBuildings)
            {                
                AvailableBuildingsDict.Add(building.Name, 1);
            }
        }

        public int GetPlayerId()
        {
            return playerId;
        }

        public bool HasCell(string id)
        {
            return OwnedCells.Exists(c => c.Id == id);
        }

        public bool OwnsCells(List<string> cellIds)
        {
            foreach (var id in cellIds)
            {
                if (!OwnedCells.Exists(c => c.Id == id))
                    return false;
            }
            return true;
        }

        public bool BuyCell(CellCard card)
        {
            if (Money >= card.Cost && !card.Cell.IsOwned)
            {
                Money -= card.Cost;
                card.Cell.SetOwner(GetPlayerId());
                OwnedCells.Add(card.Cell);
                return true;
            }
            return false;
        }

        public void ApplyBuildingEffects(Building building)
        {

            Money += building.Income;
            Population += building.Population;
            if (Population > 100) Population = 100;

            PlacedBuildings.Add(building);
        }

        public bool PlaceBuilding(Building building, List<Cell> targetCells)
        {
            if (!AvailableBuildingsDict.ContainsKey(building.Name) || AvailableBuildingsDict[building.Name] <= 0)
            {
                Debug.LogWarning("No quedan edificios de este tipo para colocar");
                return false;
            }
            
            
            foreach (var cell in targetCells)
            {
                if (OwnedCells.Contains(cell))
                {
                    cell.PlaceBuilding(building);
                }
            }

            
            ApplyBuildingEffects(building);

            
            

            // Descontar edificio disponible
            AvailableBuildingsDict[building.Name]--;

            return true;
        }

        public int CalculateIncome()
        {
            int total = 0;
            foreach (var building in PlacedBuildings)
            {
                total += building.Income;
            }
            return total;
        }

        public int CalculatePopulation()
        {
            int total = 0;
            foreach (var building in PlacedBuildings)
            {
                total += building.Population;
            }
            return total;
        }
    }
}