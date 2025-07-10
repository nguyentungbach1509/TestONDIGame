using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.AbilityComponent
{
    [CreateAssetMenu(fileName = "Ability Spawn Data", menuName = "Spawner/Data/Ability")]
    public class AbilitySpawnData : ScriptableObject
    {
        [SerializeField] List<AbilityPrefab> prefabs;
        public List<AbilityPrefab> Prefabs => prefabs;
    }

    [Serializable]
    public class AbilityPrefab
    {
        [SerializeField] int id;
        [SerializeField] string key;
        [SerializeField] AbilityBase prefab;

        public int Id => id;
        public string Key => key;
        public AbilityBase Prefab => prefab;
    }
}

