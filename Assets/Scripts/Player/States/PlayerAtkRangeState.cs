using Game.Script.CharacterComponent;
using Game.Script.StateMachine;
using Game.Script.Subscripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.PlayerComponent.States
{
    public class PlayerAtkRangeState : State
    {
        private Player player;

        public PlayerAtkRangeState(CharacterBase characterBase) : base(characterBase)
        {
            player = character as Player;
            player.Animator.RegisterAnimationEvent(
                AnimationKey.AtkRange, 
                AnimationEventType.Finished, 
                OnAtkFinished);
            player.Animator.RegisterAnimationEvent(
                AnimationKey.AtkRange, 
                AnimationEventType.Hit, 
                OnAtk);
        }

        public override void Enter()
        {
            base.Enter();
            player.Animator.PlayAnimation(AnimationKey.AtkRange);
        }


        private void OnAtk()
        {
            player.Controller.Atk(true);
            Debug.Log("Hit");
        }

        private void OnAtkFinished()
        {
            Debug.Log("Finished");
            player.States.ChangeState(EEStateType.Idle);
        }
    }
}

