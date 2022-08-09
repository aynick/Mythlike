using UnityEngine;

namespace Script
{
    public class IdleState : BaseState
    {
        private Animator _animator;
        private BasePlayerAttack _playerAttack;
        private Joystick _joystick;
        public override void Enter()
        {
        }

        public override void Exit()
        { 
        }

        public override void Action()
        {
            _playerAttack.Update();
            if (_joystick.Direction != Vector2.zero)
            {
                StateSwitch.SwitchState<MoveAndAttackState>();
            }
        }

        public IdleState(IStateSwitcher stateSwitch ,BasePlayerAttack playerAttack,Joystick joystick) : base(stateSwitch)
        {
            _playerAttack = playerAttack;
            _joystick = joystick;
        }
    }
}