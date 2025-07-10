using Game.Script.AbilityComponent;
using Game.Script.Foes;
using Game.Script.ProjectileComponent;
using Game.Script.SpawnMechanic;
using Game.Script.SubScripts;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
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
        private List<Enemy> enemyInMeleeRange = new();
        private SpawnerManager spawner;
        private AbilityManager abilityManager;

        private bool lastHorizontal;
        private bool isAtking;

        public bool LastHorizontal => lastHorizontal;
        public Transform FirePoint => firePoint;


        public void Init(SpawnerManager spawner, AbilityManager abilityManager)
        {
            this.spawner = spawner;
            this.abilityManager = abilityManager;
        }

        #region Move Handler
        public bool IsMove()
        {
            Vector2 direct = joyStick.Direction;
            if(direct.magnitude > 0.01f)
            {
                isAtking = false;
                lastHorizontal = joyStick.Horizontal > 0;
            }
            if(!isAtking) player.Flip(lastHorizontal);
            return joyStick.Direction.magnitude > 0.01f;
        }

        public void Move()
        {
            Vector2 direct = joyStick.Direction.normalized;
            Vector2 newPosition = rb.position + direct * Time.fixedDeltaTime * player.Stats.Speed;
            Vector3 viewPort = Camera.main.WorldToViewportPoint(newPosition);
            viewPort.x = Mathf.Clamp(viewPort.x, 0.05f, 0.95f); //chừa chút lề
            viewPort.y = Mathf.Clamp(viewPort.y, 0.05f, 0.95f);
            newPosition = Camera.main.ViewportToWorldPoint(viewPort);

            rb.MovePosition(newPosition);
        }
        #endregion

        #region Atk Handler
        public void StartAtk()
        {
            isAtking = true;
            player.FaceTo(currentTarget.transform);
        }

        public EAtkType IsRangeAtk()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, atkRange, layerMask);

            enemyInMeleeRange.Clear();
            float distance = 0;
            float minDistance = atkRange;
            currentTarget = null;

            foreach(var collider in colliders)
            {
                Enemy enemy = EnemyCache.GetEnemy(collider);
                if (enemy == null) continue;
                enemy.HideAim();
                distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance <= atkMeleeRange)
                {
                    enemyInMeleeRange.Add(enemy);
                    currentTarget = enemy;
                    continue;
                }
                if(distance <= minDistance)
                {
                    minDistance = distance;
                    currentTarget = enemy;
                }
            }
            
            if (enemyInMeleeRange.Count > 0) return EAtkType.Melee;
            if (distance <= atkRange && distance > atkMeleeRange) return EAtkType.Range;
            return EAtkType.None;
        }

        public void Atk(bool isRange = false)
        {
            if(currentTarget == null) return;
            
            if(isRange)
            {
                currentTarget.ShowAim();
                ArrowAbility arrowAbility = abilityManager.GetAbility(PrefabConstants.Arrow_Ability) as ArrowAbility;
                if (arrowAbility.IsAvailable)
                {
                    arrowAbility.UseAbility(currentTarget.transform);
                    return;
                }
                Arrow arrow = spawner.ProjectileSpawner.SpawnProjectile(PrefabConstants.Arrow, firePoint.position, Quaternion.identity) as Arrow;
                arrow.SetOwner(player);
                arrow.SetDamage(player.Stats.Damage);
                arrow.MoveTo(currentTarget.transform);
                
                return;
            }

            foreach(var enemy in enemyInMeleeRange)
            {
                enemy.ShowAim();
                enemy.Stats.UpdateHp(new DamageInfor(player.Stats.Damage, player));
            }
            return;
        }
        #endregion


        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, atkRange);
            Gizmos.DrawWireSphere(transform.position, atkMeleeRange);
        }
    }
}


