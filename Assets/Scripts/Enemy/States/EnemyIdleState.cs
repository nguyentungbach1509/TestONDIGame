using Game.Script.CharacterComponent;
using Game.Script.StateMachine;
using Game.Script.Subscripts.Constants;
using UnityEngine;

namespace Game.Script.Foes.States
{
    public class EnemyIdleState : State
    {
        private Enemy enemy;
        private float waitTime;

        public EnemyIdleState(CharacterBase characterBase) : base(characterBase)
        {
            enemy = character as Enemy;
        }

        public override void Enter()
        {
            base.Enter();
            waitTime = Random.Range(.5f, 1.5f);
            enemy.Animator.PlayAnimation(AnimationKey.Idle);
        }

        public override void Execute()
        {
            if(waitTime <=0)
            {
                if(enemy.Controller.CheckDistance())
                {
                    enemy.States.ChangeState(EEStateType.Atk);
                    return;
                }
                enemy.States.ChangeState(EEStateType.Move);
                return;
            }
            waitTime -= Time.deltaTime;
        }
    }
}


