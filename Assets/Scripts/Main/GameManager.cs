using UnityEngine;
using Game.Managers;
using Game.Players;
using Game.Buildings;
using Game.GridSystem;
using System.Collections.Generic;

namespace Game.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        [SerializeField] private GridManager gridManagerObject;
        public GameInfoUI gameInfoUI;
        public GridManager GridManager { get; private set; }
        public PurchaseRow PurchaseRow { get; private set; }
        private bool isPlacingBuilding = false;
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }

        //[SerializeField] private BuildingSelectionUI buildingSelectionUI;
        private Player currentPlayer;
        private int turnCounter = 0;
        public enum TurnPhase
        {
            BuyCellCards,
            Build,
            EndTurn
        }

        public void StartBuildingPlacement(Player player)
        {
            isPlacingBuilding = true;
            currentPlayer = player;
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
            GridManager = gridManagerObject;

            Player1 = new Player("Jugador 1");
            Player1.AvailableBuildings = PlayerBuildingSetup.GetDefaultBuildings();
            Player2 = new Player("Jugador 2");
            Player2.AvailableBuildings = PlayerBuildingSetup.GetDefaultBuildings();

            currentPlayer = Player1;
            
        }
        void Update()
        {
            if (isPlacingBuilding && Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    
                    Cell clickedCell = hit.collider.GetComponent<Cell>();
                    if (clickedCell != null && clickedCell.IsOwned && clickedCell.OwnerId == currentPlayer.GetPlayerId() && clickedCell.IsEmpty())
                    {
                        PlaceBasicBuilding(clickedCell);
                        isPlacingBuilding = false;
                    }
                }
            }
        }
        void PlaceBasicBuilding(Cell cell)
        {
            var building = currentPlayer.AvailableBuildings
                .Find(b => b.Name.StartsWith("Basic 1x1"));

            if (building == null)
            {
                Debug.LogWarning("No se encontró ningún edificio 'Basic 1x1' en la lista del jugador.");
                return;
            }

            bool placed = currentPlayer.PlaceBuilding(building, new List<Cell> { cell });
            if (!placed)
            {
                Debug.LogWarning("No se pudo colocar el edificio.");
                return;
            }

            Vector3 worldPos = cell.transform.position;
            GameObject visual = Instantiate(GridManager.buildingVisualPrefab);
            visual.transform.position = worldPos;

            var visualScript = visual.GetComponent<BuildingVisual>();
            visualScript.Initialize(building);
        }
        private void Start()
        {
            StartTurn();
        }
        void StartTurn()
        {
            gameInfoUI.UpdateUI();
            currentPhase = TurnPhase.BuyCellCards;
            Debug.Log($"Turno {turnCounter} - {currentPlayer.Name} - Fase: {currentPhase}");
            ApplyRoundEffects();
            //buildingSelectionUI.Initialize(currentPlayer);
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
                StartBuildingPlacement(currentPlayer);
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