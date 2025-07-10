using Game.Script.AbilityComponent;
using Game.Script.SpawnMechanic;
using Game.Script.SubScripts;
using Game.Script.UI;
using UnityEngine;
namespace Game.Script.GamePlay
{
    public enum EGameState
    {
        InGame, Pause, Win, Lose
    }

    public class GameManager : Singleton<GameManager>
    {

        [SerializeField] GameMode mode;

        [Header("Manager")]
        [SerializeField] SpawnerManager spawner;
        [SerializeField] UIManager uiManager;
        [SerializeField] AbilityManager abilityManager;

        private EGameState state;
        
        public SpawnerManager Spawner => spawner;
        public EGameState State => state;
        public GameMode Mode => mode;

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            spawner.Init();
            mode.Init();
            abilityManager.Init();
            uiManager.Init();
            state = EGameState.InGame;
        }

        public void Replay()
        {
            spawner.DespawnAll();
            mode.ReplayMode();
            StartGame();
        }


        public void Update()
        {
            if (state != EGameState.InGame) return;
            mode.UpdateGame();
        }

        public void LoseHandler()
        {
            state = EGameState.Lose;
            uiManager.PopUpController.GetPopup("Lose").Open();
        }

        public void WinHandler()
        {
            state = EGameState.Win;
            uiManager.PopUpController.GetPopup("Win").Open();

        }
    }
}

