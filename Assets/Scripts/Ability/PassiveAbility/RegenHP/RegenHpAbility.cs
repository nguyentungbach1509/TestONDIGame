using Game.Script.PlayerComponent;
using Game.Script.SubScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.AbilityComponent
{
    public class RegenHpAbility : PassiveAbility
    {
        [SerializeField] float regenAmount;

        private int enemyCount;

        public override void Init(Player player)
        {
            base.Init(player);
        }

        public override void UseAbility()
        {
            enemyCount++;
            if (enemyCount >= 5)
            {
                player.Stats.UpdateHp(regenAmount, true);
                player.Spawner.VFXSpawner.SpawnVFX(
                    PrefabConstants.VFX_Healing, player.VfxTransform.position, Quaternion.identity, player.VfxTransform);
                enemyCount = 0;
                return;
            }
            base.UseAbility();
        }
    }
}

