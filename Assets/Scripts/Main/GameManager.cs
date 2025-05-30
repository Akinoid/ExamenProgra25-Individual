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

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            GridManager = new GridManager();
            PurchaseRow = new PurchaseRow(GridManager);

            Player1 = new Player("Jugador 1");
            Player2 = new Player("Jugador 2");
        }

        
    }
}