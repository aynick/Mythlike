using UnityEngine;

namespace Script
{
    public class EnemyChaseState : BaseState
    {
        private EnemyChase _enemyChase;
        private Enemy _enemy;
        private Animator _animator;
        public EnemyChaseState(IStateSwitcher stateSwitch,EnemyChase enemyChase, Enemy enemy,Animator animator) : base(stateSwitch)
        {
            _animator = animator;
                _enemy = enemy;
            _enemyChase = enemyChase;
        }

        public override void Enter()
        {
            Debug.Log("ChaseEnter");
        }

        public override void Exit()
        {
            Debug.Log("Exit");
        }

        public override void Action()
        {
            _enemyChase.Update();
            _animator.SetTrigger("Chase");
            if (_enemyChase.FindPlayer() != null)
            {
                if (Vector2.Distance(_enemyChase.FindPlayer().transform.position,_enemyChase._transform.position) < _enemy.AttackRange)
                {
                    StateSwitch.SwitchState<EnemyAttackState>();
                }
            } 
            else
            {
                StateSwitch.SwitchState<EnemyPatrolState>();
            }
        }

    }
}