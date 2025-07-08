using Game.Script.CharacterComponent;
using Game.Script.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.Foes.States
{
    public class EnemyMoveState : State
    {
        public EnemyMoveState(CharacterBase characterBase) : base(characterBase)
        {
        }
    }
}

