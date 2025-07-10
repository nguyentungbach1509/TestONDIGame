using Game.Script.SpawnMechanic;
using Game.Script.StateMachine;
using Game.Script.SubScripts;
using Game.Script.SubScripts.Pooling;
using UnityEngine;

namespace Game.Script.CharacterComponent
{
    public class CharacterBase : PoolableComponent
    {
        [Header("References")]
        [SerializeField] protected CharacterData data;
        [SerializeField] protected CharacterCanvas canvas;
        [SerializeField] protected AnimationController animator;
        [SerializeField] protected Transform vfxContainer;

        protected CharacterStats stats;
        protected int killedCount;
        protected SpawnerManager spawner => SpawnerManager.Instance;

        public CharacterStats Stats => stats;
        public AnimationController Animator => animator;
        public int KilledCount => killedCount;
        public SpawnerManager Spawner => spawner;
        public Transform VfxTransform => vfxContainer;

        public void SetKilledCount(int count) => killedCount = count;
        public virtual void AddKilledCount(int count) => killedCount += count;

        public virtual void Init()
        {
            stats = new CharacterStats(data);
            stats.OnHealthChange += OnHit;
            stats.OnDie += OnDie;
            killedCount = 0;
            canvas.HealthBar.SetInitHP();
        }
        public void Flip(bool flip)
        {
            float scaleX = animator.transform.localScale.x;
            float scaleY = animator.transform.localScale.y;
            if (flip)
            {
                scaleX = Mathf.Abs(scaleX) * -1;
                animator.transform.localScale = new Vector3(scaleX, scaleY, 0);
                return;
            }
            scaleX = Mathf.Abs(scaleX);
            animator.transform.localScale = new Vector3(scaleX, scaleY, 0);
            return;
        }

        protected void OnHit(float percent)
        {
            canvas.HealthBar.UpdateHealth(percent);
            if (percent == 1) return;
            SpawnerManager.Instance.VFXSpawner.SpawnVFX(PrefabConstants.VFX_Impact, vfxContainer.position, Quaternion.identity, vfxContainer);
        }

        public virtual void Execute()
        {

        }

        public virtual void FaceTo(Transform target=null)
        {

        }

        public virtual void FaceTo(Vector2 position)
        {

        }

        protected virtual void OnDie(CharacterBase character)
        {
            stats.OnHealthChange -= OnHit;
            stats.OnDie -= OnDie;
        }
    }
}

