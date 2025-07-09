using Game.Script.ProjectileComponent;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.SpawnMechanic
{
    [CreateAssetMenu(fileName = "Projectile Spawn Data", menuName = "Spawner/Data/Projectiles")]
    public class ProjectileSpawnData : ScriptableObject
    {
        [SerializeField] List<ProjectilePrefab> prefabs;
        public List<ProjectilePrefab> Prefabs => prefabs;
    }

    [Serializable]
    public class ProjectilePrefab
    {
        [SerializeField] int id;
        [SerializeField] string key;
        [SerializeField] ProjectileBase prefab;

        public int Id => id;
        public string Key => key;
        public ProjectileBase Prefab => prefab;
    }
}

