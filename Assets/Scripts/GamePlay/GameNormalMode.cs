using Game.Script.Foes;
using Game.Script.WallComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.GamePlay
{
    public class GameNormalMode : GameMode
    {
        [SerializeField] Enemy enemy;

        public override void Init()
        {
            player.Init();
            enemy.Init();
            isInit = true;
        }

        public override void UpdateGame()
        {
            if (!isInit) return;
            player.Execute();
            enemy.Execute();
        }
    }
}

