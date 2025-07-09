using Game.Script.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.Foes.States
{
    public class EnemyStateController : StateController
    {
        private Enemy enemy;

        public EnemyStateController(Enemy enemy)
        {
            cachedStates = new();
            this.enemy = enemy;
            ChangeState(EEStateType.Idle);
        }

        protected override State DetectState(EEStateType type)
        {
            State state;
            switch (type)
            {
                case EEStateType.Idle:
                    state = new EnemyIdleState(enemy);
                    break;
                case EEStateType.Move:
                    state = new EnemyMoveState(enemy);
                    break;
                case EEStateType.Atk:
                    state = new EnemyAtkState(enemy);
                    break;
                default:
                    state = new EnemyDieState(enemy);
                    break;
            }

            cachedStates.Add(type, state);
            return state;
        }
    }
}

