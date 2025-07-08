using Game.Script.CharacterComponent;
using Game.Script.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.Foes.States
{
    public class EnemyDieState : State
    {
        public EnemyDieState(CharacterBase characterBase) : base(characterBase)
        {
        }
    }
}


