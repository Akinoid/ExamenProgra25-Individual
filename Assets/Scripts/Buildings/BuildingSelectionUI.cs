using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Buildings;
using Game.Players;
using TMPro;

public class BuildingSelectionUI : MonoBehaviour
{
    [SerializeField] private GameObject buildingItemPrefab; 
    [SerializeField] private Transform contentParent;

    private Player currentPlayer;

    private Building selectedBuilding;

    public delegate void OnBuildingSelected(Building building);
    public event OnBuildingSelected BuildingSelected;

    public void Initialize(Player player)
    {
        currentPlayer = player;
        PopulateBuildingList();
    }

    private void PopulateBuildingList()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var kvp in currentPlayer.AvailableBuildingsDict)
        {
            string buildingName = kvp.Key;
            int quantity = kvp.Value;

            if (quantity <= 0) continue;

            GameObject itemGO = Instantiate(buildingItemPrefab, contentParent);
            Text[] texts = itemGO.GetComponentsInChildren<Text>();

            Text nameText = texts[0];
            Text qtyText = texts[1];

            nameText.text = buildingName;
            qtyText.text = $"x{quantity}";

            Button btn = itemGO.GetComponent<Button>();
            btn.onClick.AddListener(() => OnBuildingItemClicked(buildingName));
        }
    }

    private void OnBuildingItemClicked(string buildingName)
    {
        selectedBuilding = currentPlayer.AvailableBuildings.Find(b => b.Name == buildingName);
        if (selectedBuilding == null)
        {
            Debug.LogError("Edificio no encontrado en lista de edificios disponibles");
            return;
        }

        Debug.Log($"Edificio seleccionado: {selectedBuilding.Name}");
        BuildingSelected?.Invoke(selectedBuilding);
    }

    public Building GetSelectedBuilding()
    {
        return selectedBuilding;
    }
}