using Game.Script.CharacterComponent;
using System.Collections.Generic;


namespace Game.Script.StateMachine
{
    public enum EEStateType
    {
        Idle, Die, Atk, Move, AtkRange, Spell
    }

    public abstract class StateController
    {
        protected IState currentState;
        protected Dictionary<EEStateType, State> cachedStates;
        

        public void UpdateState()
        {
            currentState?.Execute();
        }

        public void ChangeState(EEStateType type)
        {
            currentState?.Exit();
            if(cachedStates.TryGetValue(type, out State state))currentState = state;
            else currentState = DetectState(type);
            currentState?.Enter();
        }

        protected abstract State DetectState(EEStateType type);
        
    }
}


