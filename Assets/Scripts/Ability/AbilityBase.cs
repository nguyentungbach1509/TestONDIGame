using Game.Script.PlayerComponent;
using Game.Script.SubScripts.Pooling;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace Game.Script.AbilityComponent
{
    public abstract class AbilityBase : PoolableComponent
    {
        [SerializeField] AbilityData data;
        [SerializeField] protected Image abilityImg;
        

        protected Player player;
        protected Ability ability;

        public Ability Ability => ability;
        
        public virtual void Init(Player player)
        {
            ability = new Ability(data);
            abilityImg.sprite = ability.Sprite;
            this.player = player;
        }

        public abstract void UseAbility();
        public abstract void UseAbility(Transform target);
    }
}

