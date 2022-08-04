using System.Timers;
using UnityEngine;

namespace Script
{
    public class MoveAndAttackState : BaseState
    {
        private readonly BasePlayerAttack _playerAttack;
        private readonly BasePlayerMove _playerMove;
        private readonly PlayerFlip _playerFlip;
        public MoveAndAttackState(BasePlayerAttack playerAttack,BasePlayerMove move,IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
            _playerAttack = playerAttack;
            _playerMove = move;
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
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                StateSwitcher.SwitchState<IdleState>();
            }
        }
    }
}