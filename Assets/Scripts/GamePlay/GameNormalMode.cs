using Game.Script.Foes;

namespace Game.Script.GamePlay
{
    public class GameNormalMode : GameMode
    {
        public override void Init()
        {
            player.Init();
            wall.Init();
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

