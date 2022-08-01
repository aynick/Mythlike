using System.Timers;
using UnityEngine;

namespace Script
{
    public class PlayerMoveAndAttackState : BasePlayerState
    {
        private readonly BasePlayerAttack _playerAttack;
        private readonly BasePlayerMove _playerMove;
        private readonly PlayerFlip _playerFlip;
        public PlayerMoveAndAttackState(BasePlayerAttack playerAttack,BasePlayerMove move,IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
            _playerAttack = playerAttack;
            _playerMove = move;
        }
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
            _playerAttack.Update();
            _playerMove.Update();
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                StateSwitcher.SwitchState<PlayerIdleState>();
            }
        }
    }
}