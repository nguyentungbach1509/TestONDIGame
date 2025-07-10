using Game.Script.AbilityComponent;
using Game.Script.CharacterComponent;
using Game.Script.SpawnMechanic;
using Game.Script.StateMachine;
using Game.Script.SubScripts;
using UnityEngine;

namespace Game.Script.PlayerComponent
{
    [RequireComponent(typeof(PlayerController))]
    public class Player : CharacterBase
    {
        [SerializeField] PlayerController controller;

        private PlayerStateController states;
        private AbilityManager abilityManager => AbilityManager.Instance;
        private Vector2 initPosition;
        private Vector2 initScale;

        public PlayerController Controller => controller;
        public PlayerStateController States => states;

        public override void Init()
        {
            base.Init();
            initPosition = transform.position;
            initScale = animator.transform.localScale;
            states = new PlayerStateController(this);
            controller.Init(spawner, abilityManager);
        }

        public override void Execute()
        {
            states.UpdateState();
        }

        public override void FaceTo(Transform target = null)
        {
            if (target == null) return;
            if (target.position.x > transform.position.x) Flip(true);
            else Flip(false);
        }

        public override void AddKilledCount(int count)
        {
            base.AddKilledCount(count);
            RegenHpAbility regen = abilityManager.GetAbility(PrefabConstants.RegenHp_Ability) as RegenHpAbility;
            regen.UseAbility();
        }

        public void ReTransform()
        {
            transform.position = initPosition;
            animator.transform.localScale = initScale;
        }

        protected override void OnDie(CharacterBase character)
        {
            base.OnDie(character);
            states.ChangeState(EEStateType.Die);
        }
    }
}


