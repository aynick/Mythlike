namespace Script
{
    public abstract class Enemy
    {
        private int _healthPoint;
        public float AttackRange;
        public int Damage;
        public float AttackRate;
        public float Speed;
        public float DetectRange;

        public Enemy(int Hp,float attackRn,int dmg,float attackRt,float speed,float detectR)
        {
            _healthPoint = Hp;
            AttackRange = attackRn;
            AttackRate = attackRt;
            Speed = speed;
            DetectRange = detectR;
        }
    }
}