using Game.Script.GamePlay;
using Game.Script.PlayerComponent;
using Game.Script.SpawnMechanic;
using Game.Script.SubScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.AbilityComponent
{
    public class AbilityManager : Singleton<AbilityManager>
    {
        [SerializeField] AbilityHUD abilityHUD;
        private SpawnerManager spawner => SpawnerManager.Instance;
        private Dictionary<string, AbilityBase> abilities;
        private Player player => GameManager.Instance.Mode.Player;

        public Dictionary<string, AbilityBase> Abilities => abilities;
        
        public void Init()
        {
            abilities = new Dictionary<string, AbilityBase>();
            List<AbilityBase> abilityList = spawner.AbilitySpawner.SpawnAbilities(player, abilityHUD.Container);
            foreach(var ability in abilityList)
            {
                abilities.Add(ability.Ability.Key, ability);
            }
        }

        public AbilityBase GetAbility(string key)
        {
            if(abilities.TryGetValue(key, out AbilityBase ability)) return ability;
            return null;
        }
    }
}

