using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Game.Buildings;
using Game.Players;

public class BuildingSelectionUI : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform buttonContainer;

    private Player currentPlayer;
    private Building selectedBuilding;

    public delegate void OnBuildingSelected(Building building);
    public event OnBuildingSelected BuildingSelected;

    public void Initialize(Player player)
    {
        currentPlayer = player;
        RefreshUI();
    }

    private void RefreshUI()
    {
        foreach (Transform child in buttonContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (Building building in currentPlayer.AvailableBuildings)
        {
            GameObject buttonObj = Instantiate(buttonPrefab, buttonContainer);
            TMP_Text text = buttonObj.GetComponentInChildren<TMP_Text>();
            text.text = building.ToString();

            Button btn = buttonObj.GetComponent<Button>();
            btn.onClick.AddListener(() => OnBuildingClicked(building));
        }
    }

    private void OnBuildingClicked(Building building)
    {
        selectedBuilding = building;
        Debug.Log("Edificio seleccionado: " + building.Name);
        BuildingSelected?.Invoke(building);
    }

    public Building GetSelectedBuilding()
    {
        return selectedBuilding;
    }
}