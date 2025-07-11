using Game.Script.SpawnMechanic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.Foes.Bosses
{
    [CreateAssetMenu(fileName = "Boss Spawn Data", menuName = "Spawner/Data/Boss")]
    public class BossSpawnData : ScriptableObject
    {
        [SerializeField] List<BossPrefab> prefabs;
        public List<BossPrefab> Prefabs => prefabs;
        
    }

    [Serializable]
    public class BossPrefab 
    {
        [SerializeField] int id;
        [SerializeField] string key;
        [SerializeField] Boss prefab;
        [SerializeField] int wave;
        
        public int Id => id;
        public string Key => key;
        public Boss Prefab => prefab;
        public int Wave => wave;
    }
}

