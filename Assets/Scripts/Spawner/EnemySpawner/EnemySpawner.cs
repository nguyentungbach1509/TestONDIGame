using Game.Script.Foes;
using Game.Script.ProjectileComponent;
using Game.Script.SubScripts;
using Game.Script.SubScripts.Pooling;
using System.Collections;
using System.Collections.Generic;
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
        }

        
        private void InitPoolEnemy()
        {
            enemyPools = new();

            foreach (var spawnerData in gamePrefabs.EnemyPrefabs.Prefabs)
            {
                string key = spawnerData.Key.ToString();
                enemyPoolKeys.Add(key);
                Enemy enemyPrefab = spawnerData.Prefab as Enemy;
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
    }
}

