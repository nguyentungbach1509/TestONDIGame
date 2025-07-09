using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Game.Script.SpawnMechanic
{
    [CreateAssetMenu(fileName = "GamePrefabs", menuName = "Spawner/Data/GamePrefabs")]
    public class GamePrefabs : ScriptableObject
    {
        [Header("Enemies")]
        [SerializeField] EnemySpawnData enemySpawn;
        public EnemySpawnData EnemyPrefabs => enemySpawn;

        [Header("Projectiles")]
        [SerializeField] ProjectileSpawnData projectileSpawn;
        public ProjectileSpawnData ProjectilePrefabs => projectileSpawn;
    }
}

