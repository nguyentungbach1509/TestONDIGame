using Game.Script.SubScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.ProjectileComponent
{
    public class ArrowSkill : Arrow
    {
        public override void DestroyProjectile()
        {
            spawner.VFXSpawner.SpawnVFX(PrefabConstants.VFX_Spell, transform.position, Quaternion.identity);
            base.DestroyProjectile();
        }
    }
}

