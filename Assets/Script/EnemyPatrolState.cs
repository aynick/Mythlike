using UnityEngine;

namespace Script
{
    public class EnemyPatrolState : BaseState
    {
        private EnemyPatrol _enemyPatrol;
        public EnemyPatrolState(IStateSwitcher stateSwitcher,EnemyPatrol enemyPatrol) : base(stateSwitcher)
        {
            _enemyPatrol = enemyPatrol;
        }

        public override void Enter()
        {
            Debug.Log("enemy patrol State enter");
        }

        public override void Exit()
        {    
            Debug.Log("enemy patrol State exit");
        }

        public override void Action()
        {
            if (_enemyPatrol.FindPlayer())
            {
                StateSwitcher.SwitchState<EnemyChaseState>();   
            }
            _enemyPatrol.Update();
        }
    }
}