using Game.Script.CharacterComponent;
using Game.Script.StateMachine;
using Game.Script.Subscripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.Foes.States
{
    public class EnemyMoveState : State
    {
        private Enemy enemy;

        public EnemyMoveState(CharacterBase characterBase) : base(characterBase)
        {
            enemy = characterBase as Enemy;
        }

        public override void Enter()
        {
            base.Enter();
            enemy.Animator.PlayAnimation(AnimationKey.Move);
        }

        public override void Execute()
        {
            if (enemy.Controller.CheckDistance())
            {
                enemy.States.ChangeState(EEStateType.Atk);
                return;
            }
            enemy.Controller.MoveTo();
        }
    }
}

