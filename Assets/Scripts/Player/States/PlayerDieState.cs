using Game.Script.CharacterComponent;
using Game.Script.StateMachine;
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
        }
    }
}