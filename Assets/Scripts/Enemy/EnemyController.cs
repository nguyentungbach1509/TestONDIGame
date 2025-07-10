using Game.Script.CharacterComponent;
using Game.Script.PlayerComponent;
using Game.Script.SpawnMechanic;
using Game.Script.SubScripts;
using Game.Script.WallComponent;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Game.Script.Foes
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] Enemy enemy;
        [SerializeField] float atkRange;
        [SerializeField] LayerMask layerMask;
        [SerializeField] float offSetRange;

        private Vector2 fixedTarget;

        private Player targetPlayer;
        private WallBase targetWall;
        private Vector2 impactPoint;

        private SpawnerManager spawner => SpawnerManager.Instance;

        public float AtkRange => atkRange;  
       

        public void Init(Player player, WallBase wall)
        {
            targetPlayer = player;
            targetWall = wall;
            fixedTarget = wall.GetRandomPointOnWall();
            impactPoint = fixedTarget;
        }


        public void MoveTo()
        {
            if (targetWall == null) return;
            enemy.FaceTo(targetWall.transform);
            float distance = Vector2.Distance(transform.position, fixedTarget);
            if ((CheckImpactWallBase()))
            {
                fixedTarget = transform.position;
                return;
            }
            if (distance > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, fixedTarget, enemy.Stats.Speed * Time.deltaTime);
                return;
            }
            transform.position = fixedTarget;
            return;
        }

        public bool CheckDistance()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, targetPlayer.transform.position);
            float distanceToWall = Vector2.Distance(transform.position, fixedTarget);

            if (distanceToPlayer <= atkRange && targetPlayer != null)
            {
                enemy.FaceTo(targetPlayer.transform);
            }

            if (distanceToWall <= atkRange && targetWall != null)
            {
                enemy.FaceTo(fixedTarget);
            }
            return distanceToPlayer <= atkRange || distanceToWall <= atkRange;
        }

        public void Atk()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, targetPlayer.transform.position);
            float distanceToWall = Vector2.Distance(transform.position, fixedTarget);
        
            if(distanceToPlayer <= atkRange && targetPlayer!=null)
            {
                targetPlayer.Stats.UpdateHp(enemy.Stats.Damage);
                return;
            }

            if(distanceToWall <= atkRange && targetWall!=null)
            {
                spawner.VFXSpawner.SpawnVFX(PrefabConstants.VFX_Impact, impactPoint, Quaternion.identity);
                targetWall.Stats.UpdateHp(enemy.Stats.Damage);
                return;
            }
        }

        public bool CheckImpactWallBase()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, atkRange-offSetRange, layerMask);
            if(colliders.Length > 0)
            {
                Collider2D firstCollide = colliders[0];
                impactPoint = firstCollide.ClosestPoint(transform.position);
            } 
            
            return colliders.Length > 0;
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, atkRange);
        }
    }
}

