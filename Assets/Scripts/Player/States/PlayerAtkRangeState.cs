using Game.Script.CharacterComponent;
using Game.Script.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.PlayerComponent.States
{
    public class PlayerAtkRangeState : State
    {
        private Player player;

        public PlayerAtkRangeState(CharacterBase characterBase) : base(characterBase)
        {
            player = character as Player;
        }
    }
}

