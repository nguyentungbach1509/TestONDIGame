using Game.Script.SubScripts.Pooling;
using System;
using UnityEngine;


namespace Game.Script.VFXComponent
{
    public class VFX : PoolableComponent
    {
        [SerializeField] AnimationClip clip;

        public Action OnVFXEnd;

        public override void OnSpawn()
        {
            base.OnSpawn();
        }

        public override void OnDespawn()
        {
            OnVFXEnd?.Invoke();
            base.OnDespawn();
        }

        public float EndOffsetTime => clip.length + .125f;
        public float EndTime => clip.length;
        public float EndReduceTime => clip.length - .125f;
    }
}


