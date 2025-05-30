using TMPro;
using UnityEngine;
using Game.Core;

public class GameInfoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text turnText;
    [SerializeField] private TMP_Text player1MoneyText;
    [SerializeField] private TMP_Text player1PopulationText;
    [SerializeField] private TMP_Text player2MoneyText;
    [SerializeField] private TMP_Text player2PopulationText;

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        UpdateUI(); 
    }

    public void UpdateUI()
    {
        var gm = GameManager.Instance;

        turnText.text = $"Turno de: {gm.CurrentPlayer.Name}";

        player1MoneyText.text = $"Dinero: {gm.Player1.Money}";
        player1PopulationText.text = $"Población: {gm.Player1.Population}";

        player2MoneyText.text = $"Dinero: {gm.Player2.Money}";
        player2PopulationText.text = $"Población: {gm.Player2.Population}";
    }
}
