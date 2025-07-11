using Game.Script.CharacterComponent;
using Game.Script.StateMachine;
using Game.Script.Subscripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.PlayerComponent.States
{
    public class PlayerAtkState : State
    {
        private Player player;
        public PlayerAtkState(CharacterBase characterBase) : base(characterBase)
        {
            player = character as Player;
            player.Animator.RegisterAnimationEvent(
                AnimationKey.Atk,
                AnimationEventType.Finished,
                OnAtkFinished);
            player.Animator.RegisterAnimationEvent(
                AnimationKey.Atk,
                AnimationEventType.Hit,
                OnAtk);
        }

        public override void Enter()
        {
            base.Enter();
            player.Controller.StartAtk();
            player.Animator.PlayAnimation(AnimationKey.Atk);
        }

        public override void Execute()
        {
            if (player.Controller.IsMove())
            {
                player.States.ChangeState(EEStateType.Move);
                return;
            }
        }

        private void OnAtk()
        {
            player.Controller.Atk();
            Debug.Log("Hit");
        }

        private void OnAtkFinished()
        {
            Debug.Log("Finished");
            player.States.ChangeState(EEStateType.Idle);
        }
    }
}