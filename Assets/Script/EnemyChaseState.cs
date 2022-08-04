using UnityEngine;

namespace Script
{
    public class EnemyChaseState : BaseState
    {
        private EnemyChase _enemyChase;
        private Enemy _enemy;
        public EnemyChaseState(IStateSwitcher stateSwitcher,EnemyChase enemyChase, Enemy enemy) : base(stateSwitcher)
        {
            _enemy = enemy;
            _enemyChase = enemyChase;
        }

        public override void Enter()
        {
            Debug.Log("Chase Exit");

        }

        public override void Exit()
        {
            Debug.Log("Chase Exit");
        }

        public override void Action()
        {
            if (_enemyChase.FindPlayer() != null)
            {
                if (Vector2.Distance(_enemyChase.FindPlayer().transform.position,_enemyChase._transform.position) <= _enemy.AttackRange)
                {
                    StateSwitcher.SwitchState<EnemyAttackState>();
                }
                
                _enemyChase.Update();
            } 
            else
            {
                StateSwitcher.SwitchState<EnemyPatrolState>();
            }
        }

    }
}