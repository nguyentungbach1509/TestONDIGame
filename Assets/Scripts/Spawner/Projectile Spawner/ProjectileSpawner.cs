using Game.Script.ProjectileComponent;
using Game.Script.SpawnMechanic;
using Game.Script.SubScripts.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.SpawnMechanic
{
    public class ProjectileSpawner : Spawner
    {
        private Dictionary<string, ObjectPool<PoolableComponent>> projectilePools;

        public ProjectileSpawner(GamePrefabs gamePrefabs) : base(gamePrefabs)
        {
            InitProjectilePool();
        }

        public void InitProjectilePool()
        {

            projectilePools = new();
            foreach (var prefab in gamePrefabs.ProjectilePrefabs.Prefabs)
            {
                string key = prefab.Key.ToString();
                ProjectileBase projectile = prefab.Prefab;
                ObjectPool<PoolableComponent> pool = PoolManager.CreateOrGetPool<ProjectileBase>(projectile, key);
                projectilePools.Add(key, pool);
            }
        }

        

        public ProjectileBase SpawnProjectile(string key, Vector3 position, Quaternion rotation)
        {
            ObjectPool<PoolableComponent> projectilePool = projectilePools[key];
            ProjectileBase   project = projectilePool.Spawn(position, rotation) as ProjectileBase;
            project.Init();
            return project;
        }

        public ProjectileBase SpawnProjectile(string key, Vector3 position, Quaternion rotation, Transform parent)
        {
            ObjectPool<PoolableComponent> projectilePool = projectilePools[key];
            ProjectileBase project = projectilePool.Spawn(position, rotation) as ProjectileBase;
            project.transform.SetParent(parent, false);
            project.Init();
            return project;
        }

        public void DespawnProjectile(string key, ProjectileBase projectile)
        {
            projectilePools[key].Despawn(projectile);
        }

        public void DespawnAll()
        {
            foreach(var pool in projectilePools)
            {
                pool.Value.Clear();
            }
        }
    }

}
