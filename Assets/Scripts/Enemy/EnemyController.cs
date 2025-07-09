using Game.Script.CharacterComponent;
using Game.Script.PlayerComponent;
using Game.Script.WallComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.Foes
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] Enemy enemy;
        [SerializeField] float atkRange;

        private Vector2 fixedTarget;

        private Player targetPlayer;
        private WallBase targetWall;


        public float AtkRange => atkRange;  
       

        public void Init(Player player, WallBase wall)
        {
            targetPlayer = player;
            targetWall = wall;
            fixedTarget = wall.GetRandomPointOnWall();
        }


        public void MoveTo()
        {
            if (targetWall == null) return;
            enemy.FaceTo(targetWall.transform);
            float distance = Vector2.Distance(transform.position, fixedTarget);
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
                enemy.FaceTo(targetWall.transform);
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
                targetWall.Stats.UpdateHp(enemy.Stats.Damage);
                return;
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, atkRange);
        }
    }
}

