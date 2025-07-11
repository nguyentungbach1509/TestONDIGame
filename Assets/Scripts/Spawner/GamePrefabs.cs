using Game.Script.AbilityComponent;
using Game.Script.Foes.Bosses;
using Game.Script.VFXComponent;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Game.Script.SpawnMechanic
{
    [CreateAssetMenu(fileName = "GamePrefabs", menuName = "Spawner/Data/GamePrefabs")]
    public class GamePrefabs : ScriptableObject
    {
        [Header("Player")]
        [SerializeField] PlayerSpawnData playerSpawnData;
        public PlayerSpawnData PlayerPrefabs => playerSpawnData;

        [Header("Enemies")]
        [SerializeField] EnemySpawnData enemySpawn;
        public EnemySpawnData EnemyPrefabs => enemySpawn;

        [Header("Bosses")]
        [SerializeField] BossSpawnData bossSpawn;
        public BossSpawnData BossPrefabs => bossSpawn;

        [Header("Projectiles")]
        [SerializeField] ProjectileSpawnData projectileSpawn;
        public ProjectileSpawnData ProjectilePrefabs => projectileSpawn;

        [Header("VFX")]
        [SerializeField] VFXSpawnData vfxSpawn;
        public VFXSpawnData VFXPrefabs => vfxSpawn;

        [Header("Abilities")]
        [SerializeField] AbilitySpawnData abilitySpawn;
        public AbilitySpawnData AbilityPrefabs => abilitySpawn;
    }
}

