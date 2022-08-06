using UnityEngine;

namespace Script
{
    public class EnemyPatrolState : BaseState
    {
        private EnemyPatrol _enemyPatrol;
        private Animator _animator;
        private Rigidbody2D _rigidbody2D;
        public EnemyPatrolState(IStateSwitcher stateSwitch,EnemyPatrol enemyPatrol,Animator animator,Rigidbody2D rigidbody2D) : base(stateSwitch)
        {
            _rigidbody2D = rigidbody2D;
            _animator = animator;
            _enemyPatrol = enemyPatrol;
        }

        public override void Enter()
        {
            Debug.Log("das");
        }

        public override void Exit()
        {    
            Debug.Log("enemy patrol State exit");
        }

        public override void Action()
        {
            if (_enemyPatrol.FindPlayer())
            {
                StateSwitch.SwitchState<EnemyChaseState>();   
            }
            else if (_rigidbody2D.velocity.normalized == Vector2.zero)
            {
                _animator.SetTrigger("Idle");
            }
            else
            {
                _animator.SetTrigger("Chase");
            }
            _enemyPatrol.Update();
        }
    }
}