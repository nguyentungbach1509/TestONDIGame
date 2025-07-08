using Game.Script.CharacterComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.PlayerComponent
{
    [RequireComponent(typeof(PlayerController))]
    public class Player : CharacterBase
    {
        [SerializeField] PlayerController controller;

        private PlayerStateController states;
        public PlayerController Controller => controller;
        public PlayerStateController States => states;

        private void Start()
        {
            Init();
        }

        public override void Init()
        {
            base.Init();
            states = new PlayerStateController(this);
        }

        private void Update()
        {
            states.UpdateState();
        }
    }
}


