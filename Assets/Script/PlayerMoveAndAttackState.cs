using System.Timers;
using UnityEngine;

namespace Script
{
    public class MoveAndAttackState : BaseState
    {
        private readonly BasePlayerAttack _playerAttack;
        private readonly BasePlayerMove _playerMove;
        private readonly PlayerFlip _playerFlip;
        private Joystick _joystick;
        public MoveAndAttackState(BasePlayerAttack playerAttack,BasePlayerMove move,IStateSwitcher stateSwitch,Joystick joystick) : base(stateSwitch)
        {
            _playerAttack = playerAttack;
            _playerMove = move;
            _joystick = joystick;
        }
        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void Action()
        {
            _playerAttack.Update();
            _playerMove.Update();
            if (_joystick.Direction == Vector2.zero)
            {
                StateSwitch.SwitchState<IdleState>();
            }
        }
    }
}