namespace Script
{
    public abstract class BasePlayerState
    {
        protected IStateSwitcher StateSwitcher;
        protected BasePlayerState(IStateSwitcher stateSwitcher)
        {
            StateSwitcher = stateSwitcher;
        }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Action();
    }
}