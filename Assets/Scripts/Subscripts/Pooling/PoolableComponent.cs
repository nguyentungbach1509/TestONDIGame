using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.SubScripts.Pooling
{
    public class PoolableComponent : MonoBehaviour, IPoolable
    {
        public virtual void OnDespawn()
        {

        }

        public virtual void OnSpawn()
        {

        }
    }
}


