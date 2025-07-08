using Game.Script.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.CharacterComponent
{
    public class CharacterBase : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] protected CharacterData data;
        [SerializeField] protected CharacterCanvas canvas;
        [SerializeField] protected AnimationController animator;
        [SerializeField] protected SpriteRenderer spriteRenderer;

        protected CharacterStats stats;
        public CharacterStats Stats => stats;
        public AnimationController Animator => animator;
        
        public void Flip(bool flip) => spriteRenderer.flipX = flip;

        public virtual void Init()
        {
            stats = new CharacterStats(data);
            stats.OnHealthChange += canvas.HealthBar.UpdateHealth;
        }

        public virtual void FaceTo()
        {

        }
    }
}

