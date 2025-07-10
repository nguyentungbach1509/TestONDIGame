using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Script.CharacterComponent;
using Game.Script.SpawnMechanic;

namespace Game.Script.StateMachine
{
    public class State : IState
    {
        protected CharacterBase character;
        
        public State(CharacterBase characterBase)
        {
            character = characterBase;
        }

        public virtual void Enter()
        {
            
        }

        public virtual void Execute()
        {
            
        }

        public virtual void Exit()
        {
            
        }
    }
}


