using Game.Script.StateMachine;
using Game.Script.SubScripts.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.CharacterComponent
{
    public class CharacterBase : PoolableComponent
    {
        [Header("References")]
        [SerializeField] protected CharacterData data;
        [SerializeField] protected CharacterCanvas canvas;
        [SerializeField] protected AnimationController animator;
        
        protected CharacterStats stats;

        public CharacterStats Stats => stats;
        public AnimationController Animator => animator;

        public void Flip(bool flip)
        {
            float scaleX = transform.localScale.x;
            float scaleY = transform.localScale.y;
            if (flip)
            {
                scaleX = Mathf.Abs(scaleX) * -1;
                transform.localScale = new Vector3(scaleX, scaleY, 0);
                return;
            }
            scaleX = Mathf.Abs(scaleX);
            transform.localScale = new Vector3(scaleX, scaleY, 0);
            return;
        }

        
        public virtual void Init()
        {
            stats = new CharacterStats(data);
            stats.OnHealthChange += canvas.HealthBar.UpdateHealth;
            stats.OnDie += OnDie;
        }

        public virtual void Execute()
        {

        }

        public virtual void FaceTo(Transform target=null)
        {

        }

        protected virtual void OnDie()
        {
            stats.OnHealthChange -= canvas.HealthBar.UpdateHealth;
            stats.OnDie -= OnDie;
        }
    }
}

