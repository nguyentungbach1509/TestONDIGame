using Game.Script.Foes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.SpawnMechanic
{
    [CreateAssetMenu(fileName = "Enemy Spawn Data", menuName = "Spawner/Data/Enemy")]
    public class EnemySpawnData : ScriptableObject
    {
        [SerializeField] List<EnemyPrefab> prefabs;
        public List<EnemyPrefab> Prefabs => prefabs;
    }

    [Serializable] 
    public class EnemyPrefab
    {
        [SerializeField] int id;
        [SerializeField] string key;
        [SerializeField] Enemy prefab;

        public int Id => id;
        public string Key => key;
        public Enemy Prefab => prefab;
    }
}


