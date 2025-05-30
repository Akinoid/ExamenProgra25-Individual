using UnityEngine;
using Game.Managers;
using Game.Players;

namespace Game.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public GameInfoUI gameInfoUI;
        public GridManager GridManager { get; private set; }
        public PurchaseRow PurchaseRow { get; private set; }

        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }

        [SerializeField] private BuildingSelectionUI buildingSelectionUI;
        private Player currentPlayer;
        private int turnCounter = 0;
        public enum TurnPhase
        {
            BuyCellCards,
            ViewBoard,
            PlaceBuildings,
            EndTurn
        }

        private TurnPhase currentPhase = TurnPhase.BuyCellCards;

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
            Player1.AvailableBuildings = PlayerBuildingSetup.GetDefaultBuildings();
            Player2 = new Player("Jugador 2");
            Player2.AvailableBuildings = PlayerBuildingSetup.GetDefaultBuildings();

            currentPlayer = Player1;
            
        }
        private void Start()
        {
            StartTurn();
        }
        void StartTurn()
        {
            currentPhase = TurnPhase.BuyCellCards;
            Debug.Log($"Turno {turnCounter} - {currentPlayer.Name} - Fase: {currentPhase}");

            buildingSelectionUI.Initialize(currentPlayer);
            gameInfoUI.UpdateUI();
        }
        public void NextPhase()
        {
            currentPhase++;

            if ((int)currentPhase > (int)TurnPhase.EndTurn)
            {
                EndTurn();
            }
            else
            {
                Debug.Log($"Turno {turnCounter} - {currentPlayer.Name} - Fase: {currentPhase}");
                gameInfoUI.UpdateUI();
                
            }
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

            Debug.Log($"Cambio de turno. Turno {turnCounter} - {currentPlayer.Name}");

            StartTurn();

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
        public TurnPhase CurrentPhase => currentPhase;
    }
}