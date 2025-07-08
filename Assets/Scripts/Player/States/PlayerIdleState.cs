using Game.Script.CharacterComponent;
using Game.Script.StateMachine;
using Game.Script.Subscript.Constants;


namespace Game.Script.PlayerComponent.States
{
    public class PlayerIdleState : State
    {
        private Player player;

        public PlayerIdleState(CharacterBase characterBase) : base(characterBase)
        {
            player = character as Player; 
        }

        public override void Enter()
        {
            base.Enter();
            player.Animator.PlayAnimation(AnimationKey.Idle);
        }

        public override void Execute()
        {
            if (player.Controller.IsMove())
            {
                player.States.ChangeState(EEStateType.Move);
                return;
            }
        }
    }
}


