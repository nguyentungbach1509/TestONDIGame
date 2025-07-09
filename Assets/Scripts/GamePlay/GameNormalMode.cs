using Game.Script.Foes;
using Game.Script.WallComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.GamePlay
{
    public class GameNormalMode : GameMode
    {
        public override void Init()
        {
            player.Init();
            isInit = true;
        }

        public override void UpdateGame()
        {
            if (!isInit) return;
            player.Execute();
            EnemyCache.UpdateAllEnemy();
        }
    }
}

