using Game.Script.CharacterComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.StateMachine
{
    public interface IState
    {
        void Enter();
        void Execute();    
        void Exit();    
    }
}

