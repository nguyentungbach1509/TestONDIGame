using Game.Script.PlayerComponent;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace Game.Script.AbilityComponent
{
    public class ActiveAbility : AbilityBase
    {
        [SerializeField] protected Image fillImg;

        protected float coolDown;
        protected bool isAvailable;
        protected Coroutine coolDownCoroutine;

        public bool IsAvailable => isAvailable;

        public override void Init(Player player)
        {
            base.Init(player);
            isAvailable = true;
            coolDown = ability.CooldownTime;
        }

        public override void UseAbility()
        {
            isAvailable = false;
        }

        public override void UseAbility(Transform target)
        {
            isAvailable = false;
        }

        protected void ReduceCoolDownTime()
        {
            if (coolDownCoroutine != null) StopCoroutine(coolDownCoroutine);
            coolDownCoroutine = StartCoroutine(ReduceTime());

            IEnumerator ReduceTime()
            {
                while (coolDown > 0)
                {
                    fillImg.fillAmount = coolDown / ability.CooldownTime;
                    coolDown -= Time.deltaTime;
                    yield return null;
                }
                fillImg.fillAmount = 0;
                isAvailable = true;
                coolDown = ability.CooldownTime;
            }
        }
    }
}

