using Game.Script.CharacterComponent;
using Game.Script.Foes.Bosses;
using Game.Script.StateMachine;
using Game.Script.Subscripts.Constants;

namespace Game.Script.Foes.States
{
    public class EnemyDieState : State
    {
        private Enemy enemy;

        public EnemyDieState(CharacterBase characterBase) : base(characterBase)
        {
            enemy = character as Enemy;
            enemy.Animator.RegisterAnimationEvent(
                AnimationKey.Die, AnimationEventType.Finished, OnDieFinished);
        }

        public override void Enter()
        {
            base.Enter();
            enemy.Animator.PlayAnimation(AnimationKey.Die);
        }

        private void OnDieFinished()
        {
            if(enemy is Boss)
            {
                enemy.Spawner.EnemySpawner.DespawnBoss(enemy.Stats.KeyName, enemy as Boss);
                return;
            }
            enemy.Spawner.EnemySpawner.DespawnEnemy(enemy.Stats.KeyName, enemy);
        }
    }
}


