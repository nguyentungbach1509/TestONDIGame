using Game.Script.AbilityComponent;
using Game.Script.Foes;
using Game.Script.PlayerComponent;
using Game.Script.SubScripts.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.SpawnMechanic
{
    public class AbilitySpawner : Spawner
    {

        private Dictionary<string, ObjectPool<PoolableComponent>> abilityPools;

        public AbilitySpawner(GamePrefabs gamePrefabs) : base(gamePrefabs)
        {
            InitPoolAbility();
        }

        private void InitPoolAbility()
        {
            abilityPools = new();

            foreach (var spawnerData in gamePrefabs.AbilityPrefabs.Prefabs)
            {
                string key = spawnerData.Key.ToString();
                AbilityBase abilityPrefab = spawnerData.Prefab;
                ObjectPool<PoolableComponent> pool = PoolManager.CreateOrGetPool<AbilityBase>(abilityPrefab, key);
                abilityPools.Add(key, pool);
            }
        }

        public List<AbilityBase> SpawnAbilities(Player player, Transform parent)
        {
            List<AbilityBase> abilities = new();
            foreach(var prefab in gamePrefabs.AbilityPrefabs.Prefabs)
            {
                AbilityBase ability = abilityPools[prefab.Key].Spawn(Vector3.zero, Quaternion.identity) as AbilityBase;
                ability.transform.localPosition = Vector3.zero;
                ability.transform.parent = parent;
                ability.Init(player);
                abilities.Add(ability);
            }

            return abilities;
            
        }

        public void DespawnAbilities(List<AbilityBase> abilities)
        {
            foreach(var ability in abilities)
            {
                abilityPools[ability.Ability.Key].Despawn(ability);
            }
        }
    }
}

