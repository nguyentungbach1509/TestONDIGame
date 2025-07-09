using Game.Script.SpawnMechanic;
using Game.Script.SubScripts;
using System.Collections;
using System.Collections.Generic;
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

        private SpawnerManager spawner => SpawnerManager.Instance;
        private EGameState state;

        public EGameState State => state;
        public GameMode Mode => mode;

        private void Start()
        {
            spawner.Init();
            mode.Init();
        }

        public void Update()
        {
            mode.UpdateGame();
        }
    }
}

