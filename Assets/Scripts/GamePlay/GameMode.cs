using Game.Script.PlayerComponent;
using Game.Script.WallComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.GamePlay
{
    public abstract class GameMode : MonoBehaviour
    {
        [SerializeField] protected Player player;
        [SerializeField] protected WallBase wall;

        protected bool isInit;
        
        public Player Player => player;
        public WallBase Wall => wall;

        public abstract void Init();
        public abstract void UpdateGame();
    }
}

