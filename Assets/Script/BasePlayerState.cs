namespace Script
{
    public abstract class BaseState
    {
        protected IStateSwitcher StateSwitch;
        protected BaseState(IStateSwitcher stateSwitch)
        {
            StateSwitch = stateSwitch;
        }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Action();
    }
}