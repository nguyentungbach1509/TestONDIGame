using Game.Script.CharacterComponent;
using Game.Script.Foes.States;
using Game.Script.GamePlay;
using Game.Script.PlayerComponent;
using Game.Script.StateMachine;
using Game.Script.WallComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


namespace Game.Script.Foes
{
    [RequireComponent(typeof(EnemyController))]
    public class Enemy : CharacterBase
    {
        [Header("References")]
        [SerializeField] Collider2D hitBox;
        [SerializeField] EnemyController controller;
        [SerializeField] GameObject spriteObject;

        private EnemyStateController states;
        protected Player player;
        protected WallBase wall;

        public EnemyStateController States => states;
        public Collider2D Collider => hitBox;
        public EnemyController Controller => controller;

        
        public override void Init()
        {
            base.Init();
            states = new EnemyStateController(this);
            spriteObject.SetActive(false);
            player = GameManager.Instance.Mode.Player;
            wall = GameManager.Instance.Mode.Wall;
            controller.Init(player, wall);
        }


        public override void Execute()
        {
            states.UpdateState();
        }

        protected override void OnDie(CharacterBase character)
        {
            states.ChangeState(EEStateType.Die);
            base.OnDie(character);
            if (character != this) character.AddKilledCount(1);
        }

        public override void FaceTo(Transform target=null)
        {
            if (target == null) return;
            if (target.position.x >= transform.position.x) Flip(true);
            else Flip(false);
        }

        public override void FaceTo(Vector2 position)
        {
            if (position.x >= transform.position.x) Flip(true);
            else Flip(false);
        }

        public void HideAim()
        {
            spriteObject.SetActive(false);
        }

        public void ShowAim()
        {
            spriteObject.SetActive(true);
        }

        public override void OnDespawn()
        {
            base.OnDespawn();
            animator.UnRegisterAllEvent();
        }
    }
}

