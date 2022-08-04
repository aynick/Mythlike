namespace Script
{
    public abstract class BaseState
    {
        protected IStateSwitcher StateSwitcher;
        protected BaseState(IStateSwitcher stateSwitcher)
        {
            StateSwitcher = stateSwitcher;
        }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Action();
    }
}