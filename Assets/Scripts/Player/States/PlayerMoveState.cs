using Game.Script.CharacterComponent;
using Game.Script.StateMachine;
using Game.Script.Subscripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.PlayerComponent.States
{
    public class PlayerMoveState : State
    {
        private Player player;

        public PlayerMoveState(CharacterBase characterBase) : base(characterBase)
        {
            player = character as Player;   
        }

        public override void Enter()
        {
            base.Enter();
            player.Animator.PlayAnimation(AnimationKey.Move);   
        }

        public override void Execute()
        {
            player.Controller.Move();

            if (!player.Controller.IsMove())
            {
                player.States.ChangeState(EEStateType.Idle);
                return;
            }

        }
    }
}