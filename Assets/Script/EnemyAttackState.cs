using UnityEngine;

namespace Script
{
    public class EnemyAttackState : BaseState
    {
        private EnemyAttack _enemyAttack;
        private Enemy _enemy;
        public EnemyAttackState(IStateSwitcher stateSwitcher,EnemyAttack enemyAttack, Enemy enemy) : base(stateSwitcher)
        {
            _enemy = enemy;
            _enemyAttack = enemyAttack;
        }

        public override void Enter()
        {
            Debug.Log("Attack Enter");
        }

        public override void Exit()
        {
            Debug.Log("Attack Exit");
        }

        public override void Action()
        {
            if (_enemyAttack.Player() == null)
            {
                StateSwitcher.SwitchState<EnemyPatrolState>();
            }
            _enemyAttack.Update();
        }
    }
}