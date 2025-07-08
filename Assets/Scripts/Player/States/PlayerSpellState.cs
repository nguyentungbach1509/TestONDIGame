using Game.Script.CharacterComponent;
using Game.Script.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.PlayerComponent
{
    public class PlayerSpellState : State
    {
        private Player player;
        public PlayerSpellState(CharacterBase characterBase) : base(characterBase)
        {
            player = character as Player;
        }
    }
}

