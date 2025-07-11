using Game.Script.CharacterComponent;
using Game.Script.StateMachine;
using Game.Script.Subscripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.PlayerComponent.States
{
    public class PlayerDieState : State
    {
        private Player player;
        public PlayerDieState(CharacterBase characterBase) : base(characterBase)
        {
            player = character as Player;
            player.Animator.RegisterAnimationEvent(
                AnimationKey.Die, AnimationEventType.Finished, OnDieFinished);
        }

        public override void Enter()
        {
            base.Enter();
            player.Animator.PlayAnimation(AnimationKey.Die);
        }

        private void OnDieFinished()
        {
            player.Animator.UnRegisterAllEvent();
            player.Spawner.PlayerSpawner.RebornPlayer();
        }
    }
}