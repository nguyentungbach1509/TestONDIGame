using Game.Script.Foes;
using Game.Script.SpawnMechanic;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game.Script.GamePlay
{
    public enum EWaveType
    {
        DefWave, BreakingWave
    }


    public class GameNormalMode : GameMode
    {
        [SerializeField] float buildingTime;

        private float timeCounter;
        private EWaveType waveType;
        private int maxWave;
        public int currentWave;

        public EWaveType WaveType => waveType;
        public static Action<float> OnTimeChange;
        public static Action<int> OnWaveChange;


        public override void Init()
        {
            player.Init();
            wall.Init();
            waves = new List<Wave>(data.Data);
            maxWave = waves.Count;
            currentWave = 0;
            waveType = EWaveType.BreakingWave;
            timeCounter = buildingTime;
            wall.Stats.OnDestroy -= gameManager.LoseHandler;
            wall.Stats.OnDestroy += gameManager.LoseHandler;
            isInit = true;
        }

        public override void UpdateGame()
        {
            if (!isInit) return;
            ChangeWave();
            player.Execute();
            if (waveType != EWaveType.DefWave) return;
            EnemyCache.UpdateAllEnemy();
        }

        private void ChangeWave()
        {
            if (waveType == EWaveType.BreakingWave)
            {
                CountDownTime();
                return;
            }
            if (EnemyCache.IsEmpty() && EndWave(currentWave))
            {
                EnemyCache.RemoveAll();
                SetEnemyNumber(0);
                spawner.PauseSpawn(currentWave);
                timeCounter = buildingTime;
                waveType = EWaveType.BreakingWave;
                OnWaveChange?.Invoke(-1);
                return;
            }
            /*if (EndWave(currentWave))
            {
                spawner.PauseSpawn(currentWave);
                timeCounter = buildingTime;
                return;
            }*/
        }

        private void CountDownTime()
        {
            if (currentWave >= maxWave)
            {
                gameManager.WinHandler();
                return;
            }

            if (timeCounter > 0) timeCounter -= Time.deltaTime;
            else
            {
                currentWave++;
                waveType = EWaveType.DefWave;
                spawner.SpawnRandomEnemy(currentWave);
                OnWaveChange?.Invoke(currentWave);
            }
            OnTimeChange?.Invoke(timeCounter / buildingTime);
        }

    }
}

