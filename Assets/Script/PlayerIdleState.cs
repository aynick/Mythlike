using UnityEngine;

namespace Script
{
    public class IdleState : BaseState
    {
        private Animator _animator;
        private BasePlayerAttack _playerAttack;
        public override void Enter()
        {
        }

        public override void Exit()
        { 
        }

        public override void Action()
        {
            _playerAttack.Update();
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                StateSwitcher.SwitchState<MoveAndAttackState>();
            }
        }

        public IdleState(IStateSwitcher stateSwitcher ,BasePlayerAttack playerAttack) : base(stateSwitcher)
        {
            _playerAttack = playerAttack;
        }
    }
}