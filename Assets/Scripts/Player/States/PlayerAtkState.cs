using Game.Script.CharacterComponent;
using Game.Script.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.PlayerComponent.States
{
    public class PlayerAtkState : State
    {
        private Player player;
        public PlayerAtkState(CharacterBase characterBase) : base(characterBase)
        {
            player = character as Player;
        }
    }
}