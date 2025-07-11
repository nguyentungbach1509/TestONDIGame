using Game.Script.Foes;
using Game.Script.Foes.Bosses;
using Game.Script.ProjectileComponent;
using Game.Script.SubScripts;
using Game.Script.SubScripts.Pooling;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Game.Script.SpawnMechanic
{
    public class EnemySpawner : Spawner
    {
        private List<string> enemyPoolKeys = new();
        private Dictionary<string, ObjectPool<PoolableComponent>> enemyPools;


        public EnemySpawner(GamePrefabs gamePrefabs) : base(gamePrefabs)
        {
            EnemyCache.Init();
            InitPoolEnemy();
            InitPoolBoss();
        }

        #region Normal Enemy
        private void InitPoolEnemy()
        {
            enemyPools = new();

            foreach (var spawnerData in gamePrefabs.EnemyPrefabs.Prefabs)
            {
                string key = spawnerData.Key.ToString();
                enemyPoolKeys.Add(key);
                Enemy enemyPrefab = spawnerData.Prefab;
                ObjectPool<PoolableComponent> pool = PoolManager.CreateOrGetPool<Enemy>(enemyPrefab, key);
                enemyPools.Add(key, pool);
            }
        }

        public Enemy SpawnEnemy(string key, Vector3 position, Quaternion rotation)
        {
            ObjectPool<PoolableComponent> enemyPool = enemyPools[key];

            Enemy enemy = enemyPool.Spawn(position, rotation) as Enemy;
            //enemy.SetUpPositionAwake(position);
            enemy.Init();
            EnemyCache.AddEnemy(enemy); 
            return enemy;
        }

        public void DespawnEnemy(string key, Enemy enemy)
        {
            EnemyCache.RemoveEnemy(enemy);
            enemyPools[key].Despawn(enemy);
        }

        public void DespawnAll()
        {
            foreach(var enemy in EnemyCache.EnemyDict.Values)
            {
                if(enemy is Boss) bossPools[enemy.Stats.KeyName].Despawn(enemy);
                else enemyPools[enemy.Stats.KeyName].Despawn(enemy);
            }
            EnemyCache.RemoveAll();
        }
        #endregion

        #region Boss
        private Dictionary<string, ObjectPool<PoolableComponent>> bossPools;
        private BossSpawnData bossPrefabs;
        private List<string> bossKeys = new();


        private void InitPoolBoss()
        {
            bossPools = new();
            bossPrefabs = gamePrefabs.BossPrefabs;
            foreach (var spawnerData in gamePrefabs.BossPrefabs.Prefabs)
            {
                string key = spawnerData.Key.ToString();
                bossKeys.Add(key);
                Boss bossPrefab = spawnerData.Prefab;
                ObjectPool<PoolableComponent> pool = PoolManager.CreateOrGetPool<Boss>(bossPrefab, key);
                bossPools.Add(key, pool);
            }
        }

        public Boss SpawnBoss(string key, Vector3 position, Quaternion rotation)
        {
            Boss boss = bossPools[key].Spawn(position, rotation) as Boss;
            boss.Init();
            EnemyCache.AddEnemy(boss);
            return boss;
        }

        public Boss SpawnBoss(int wave, Vector3 position, Quaternion rotation)
        {
            string key = bossPrefabs.Prefabs.Find(e => e.Wave == wave).Key;
            return SpawnBoss(key, position, rotation);
        }

        public void DespawnBoss(string key, Boss boss)
        {
            EnemyCache.RemoveEnemy(boss);
            bossPools[key].Despawn(boss);
        }
        #endregion

    }
}

