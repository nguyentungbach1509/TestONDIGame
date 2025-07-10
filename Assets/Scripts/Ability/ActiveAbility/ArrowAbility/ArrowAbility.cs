using Game.Script.ProjectileComponent;
using Game.Script.SpawnMechanic;
using Game.Script.SubScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.AbilityComponent
{
    public class ArrowAbility : ActiveAbility
    {
        private SpawnerManager spawner => SpawnerManager.Instance;

        public override void UseAbility(Transform target)
        {
            if (!isAvailable) return;
            base.UseAbility();
            ArrowSkill arrow = spawner.ProjectileSpawner.SpawnProjectile(
                PrefabConstants.Arrow_Skill, 
                player.Controller.FirePoint.position, Quaternion.identity) as ArrowSkill;
            arrow.SetOwner(player);
            arrow.SetDamage(player.Stats.Damage * 2);
            arrow.MoveTo(target);
            ReduceCoolDownTime();
        }
    }
}

