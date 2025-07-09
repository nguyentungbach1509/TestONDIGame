using Game.Script.SpawnMechanic;
using Game.Script.SubScripts.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.ProjectileComponent
{
    public class ProjectileBase : PoolableComponent
    {
        [SerializeField] protected ProjectileData data;

        protected Projectile projectile;
        protected SpawnerManager spawner => SpawnerManager.Instance;

        public virtual void Init()
        {
            projectile = new Projectile(data);
        }

        public virtual void MoveTo() {  }
        public virtual void MoveTo(Vector2 target) { }

        protected virtual void DestroyProjectile()
        {
            spawner.ProjectileSpawner.DespawnProjectile(projectile.Key, this);
        }
    }
}

