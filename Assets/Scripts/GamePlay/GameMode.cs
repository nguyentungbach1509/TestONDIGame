using Game.Script.PlayerComponent;
using Game.Script.SpawnMechanic;
using Game.Script.WallComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.GamePlay
{
    public abstract class GameMode : MonoBehaviour
    {
        [SerializeField] protected Player player;
        [SerializeField] protected WallBase wall;
        [SerializeField] protected WaveData data;

        protected bool isInit;
        protected List<Wave> waves;
        protected int currentEnemyNumber;
        protected GameManager gameManager => GameManager.Instance;
        protected SpawnerManager spawner => SpawnerManager.Instance;

        public Player Player => player;
        public WallBase Wall => wall;

        public abstract void Init();
        public abstract void UpdateGame();

        public int GetEnemyNumber() => currentEnemyNumber;
        public void SetEnemyNumber(int number) => currentEnemyNumber = number;
        public void AddEnemy(int number)
        {
            currentEnemyNumber += number;
        }
        public bool EndWave(int currentWave)
        {
            bool end = currentEnemyNumber >= waves[currentWave - 1].NumberEnemy;
            return end;
        }

        public bool IsLastWave(int currentWave) => currentWave >= waves.Count - 1;
        public void ReplayMode()
        {
            isInit = false;
            player.ReTransform();
        }
    }
}

