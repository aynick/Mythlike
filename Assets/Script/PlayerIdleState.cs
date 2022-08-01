using UnityEngine;

namespace Script
{
    public class PlayerIdleState : BasePlayerState
    {
        private Animator _animator;
        private BasePlayerAttack _playerAttack;
        public override void Enter()
        {
            Debug.LogError("IdleState Enter");
        }

        public override void Exit()
        { 
            Debug.LogError("IdleState Exit");
        }

        public override void Action()
        {
            Debug.LogError("IdleState Action");
            _playerAttack.Update();
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                StateSwitcher.SwitchState<PlayerMoveAndAttackState>();
            }
        }

        public PlayerIdleState(IStateSwitcher stateSwitcher ,BasePlayerAttack playerAttack) : base(stateSwitcher)
        {
            _playerAttack = playerAttack;
        }
    }
}