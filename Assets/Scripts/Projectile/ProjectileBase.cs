using Game.Script.CharacterComponent;
using Game.Script.Foes;
using Game.Script.SpawnMechanic;
using Game.Script.SubScripts;
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
        protected Transform currentTarget;

        public virtual void Init()
        {
            projectile = new Projectile(data);
        }

        public virtual void MoveTo() {  }
        public virtual void MoveTo(Transform target) { currentTarget = target; }
        public void SetDamage(float damage) => projectile.SetDamage(damage);
        public void SetOwner(CharacterBase owner) => projectile.SetSource(owner); 
        
        protected virtual void DestroyProjectile()
        {
            spawner.ProjectileSpawner.DespawnProjectile(projectile.Key, this);
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag(PrefabConstants.EnemyTag)) return;
            Enemy enemy = EnemyCache.GetEnemy(collision);
            if (enemy == null) return;
            if(currentTarget != enemy.transform) return;
            enemy.Stats.UpdateHp(new DamageInfor(projectile.Damage, projectile.Source));
        }
    }
}

