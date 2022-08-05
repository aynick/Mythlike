using UnityEngine;

namespace Script
{
    public class EnemyAttackState : BaseState
    {
        private EnemyAttack _enemyAttack;
        private Enemy _enemy;
        private Animator _animator;
        private Rigidbody2D _rigidbody2D;
        public EnemyAttackState(IStateSwitcher stateSwitch,EnemyAttack enemyAttack, Enemy enemy,Animator animator,Rigidbody2D rigidbody2D) : base(stateSwitch)
        {
            _animator = animator;
            _enemy = enemy;
            _enemyAttack = enemyAttack;
            _rigidbody2D = rigidbody2D;
        }

        public override void Enter()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }

        public override void Exit()
        {
            Debug.Log("Attack Exit");
        }

        public override void Action()
        {
            if (_enemyAttack.Player() == null)
            {
                StateSwitch.SwitchState<EnemyPatrolState>();
            }
            _enemyAttack.Update();
            if (_enemyAttack.IsAttacked)
            {
                _animator.SetTrigger("Attack");
            }
            else
            {
                _animator.SetTrigger("Idle");
            }
        }
    }
}