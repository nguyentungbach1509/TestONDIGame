using Game.Script.PlayerComponent.States;
using Game.Script.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.PlayerComponent
{
    public class PlayerStateController : StateController
    {
        private Player player;

        public PlayerStateController(Player player)
        {
            cachedStates = new();
            this.player = player;
            ChangeState(EEStateType.Idle);
        }

        protected override State DetectState(EEStateType type)
        {
            State state;
            switch(type)
            {
                case EEStateType.Idle:
                    state = new PlayerIdleState(player);
                    break;
                case EEStateType.Move:
                    state = new PlayerMoveState(player);
                    break;
                case EEStateType.Atk:
                    state = new PlayerAtkState(player);
                    break;
                case EEStateType.AtkRange:
                    state = new PlayerAtkRangeState(player);
                    break;
                case EEStateType.Spell:
                    state = new PlayerSpellState(player);
                    break;
                default:
                    state = new PlayerDieState(player);
                    break;
            }

            cachedStates.Add(type, state);
            return state;
        }
    }
}

