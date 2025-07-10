using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.VFXComponent
{
    [CreateAssetMenu(fileName = "VFX Spawn Data", menuName = "Spawner/Data/VFX")]
    public class VFXSpawnData : ScriptableObject
    {
        [SerializeField] List<VFXPrefab> prefabs;
        public List<VFXPrefab> Prefabs => prefabs;
    }

    [Serializable] 
    public class VFXPrefab
    {
        [SerializeField] VFX vfxPrefab;
        [SerializeField] string key;
        public VFX Prefab => vfxPrefab;
        public string Key => key;
    }
}

