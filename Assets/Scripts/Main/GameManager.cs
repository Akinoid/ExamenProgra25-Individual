using UnityEngine;
using Game.Managers;
using Game.Players;

namespace Game.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public GridManager GridManager { get; private set; }
        public PurchaseRow PurchaseRow { get; private set; }

        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }

        private Player currentPlayer;
        private int turnCounter = 0;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);


            Player1 = new Player("Jugador 1");
            Player2 = new Player("Jugador 2");

            currentPlayer = Player1;
        }

        public void EndTurn()
        {
            if (currentPlayer == Player1)
            {
                currentPlayer = Player2;
            }
            else
            {
                
                ApplyRoundEffects();

                currentPlayer = Player1;
                turnCounter++;
            }

            Debug.Log($"Turno {turnCounter} - {currentPlayer.Name}");
        }
        private void ApplyRoundEffects()
        {
            Player1.Money += Player1.CalculateIncome();
            Player1.Population = Mathf.Min(100, Player1.CalculatePopulation());

            Player2.Money += Player2.CalculateIncome();
            Player2.Population = Mathf.Min(100, Player2.CalculatePopulation());

            CheckForVictory();
        }

        private void CheckForVictory()
        {
            if (Player1.Population >= 100)
                Debug.Log("Jugador 1 gana!");

            if (Player2.Population >= 100)
                Debug.Log("Jugador 2 gana!");
        }

        public Player CurrentPlayer => currentPlayer;

    }
}