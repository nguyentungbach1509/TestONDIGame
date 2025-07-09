using Game.Script.CharacterComponent;
using Game.Script.StateMachine;
using Game.Script.Subscripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.Foes.States
{
    public class EnemyAtkState : State
    {
        private Enemy enemy;

        public EnemyAtkState(CharacterBase characterBase) : base(characterBase)
        {
            enemy = character as Enemy;
            enemy.Animator.RegisterAnimationEvent(
                AnimationKey.Atk, 
                AnimationEventType.Finished, 
                OnAtkFinished);
        }

        public override void Enter()
        {
            base.Enter();
            enemy.Animator.PlayAnimation(AnimationKey.Atk);
        }

        private void OnAtkFinished()
        {
            enemy.States.ChangeState(EEStateType.Idle);
        }
    }
}


