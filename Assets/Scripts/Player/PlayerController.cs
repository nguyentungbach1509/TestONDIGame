using Game.Script.Foes;
using Game.Script.ProjectileComponent;
using Game.Script.SpawnMechanic;
using Game.Script.SubScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.PlayerComponent
{
    public enum EAtkType
    {
        None, Range, Melee
    }

    [RequireComponent(typeof(Player))]
    public class PlayerController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Player player;
        [SerializeField] Joystick joyStick;
        [SerializeField] Rigidbody2D rb;

        [Header("Settings")]
        [SerializeField] Transform firePoint;
        [SerializeField] float atkMeleeRange;
        [SerializeField] float atkRange;
        [SerializeField] LayerMask layerMask;

        private Enemy currentTarget;
        private SpawnerManager spawner => SpawnerManager.Instance;
        private bool lastHorizontal;

        public bool LastHorizontal => lastHorizontal;
        public Transform FirePoint => firePoint;

        public bool IsMove()
        {
            lastHorizontal = joyStick.Horizontal > 0;
            return joyStick.Direction.magnitude > 0.01f;
        }

        

        public void Move()
        {
            player.Flip(joyStick.Horizontal > 0);
            Vector2 direct = joyStick.Direction.normalized;
            Vector2 newPosition = rb.position + direct * Time.fixedDeltaTime * player.Stats.Speed;
            Vector3 viewPort = Camera.main.WorldToViewportPoint(newPosition);
            viewPort.x = Mathf.Clamp(viewPort.x, 0.05f, 0.95f); //chừa chút lề
            viewPort.y = Mathf.Clamp(viewPort.y, 0.05f, 0.95f);
            newPosition = Camera.main.ViewportToWorldPoint(viewPort);

            rb.MovePosition(newPosition);
        }

        public EAtkType IsRangeAtk()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, atkRange, layerMask);

            float distance = 0;
            float minDistance = atkRange;

            foreach(var collider in colliders)
            {
                Enemy enemy = EnemyCache.GetEnemy(collider);
                if (enemy == null) continue;
                enemy.HideAim();
                distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance <= atkMeleeRange) continue;
                if(distance <= minDistance)
                {
                    minDistance = distance;
                    currentTarget = enemy;
                }
            }
            
            if (distance <= atkRange && distance > atkMeleeRange) return EAtkType.Range;
            if(distance <= atkMeleeRange) return EAtkType.Melee;
            return EAtkType.None;
        }

        public void Atk(bool isRange = false)
        {
            if(isRange)
            {
                currentTarget?.ShowAim();
                player.FaceTo(currentTarget.transform);
                Arrow arrow = spawner.ProjectileSpawner.SpawnProjectile(PrefabConstants.Arrow, firePoint.position, Quaternion.identity) as Arrow;
                arrow.MoveTo(currentTarget.transform.position);
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, atkRange);
            Gizmos.DrawWireSphere(transform.position, atkMeleeRange);
        }
    }
}


