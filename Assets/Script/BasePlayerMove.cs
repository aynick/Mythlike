using UnityEngine;

namespace Script
{
    public class BasePlayerMove
    {
        private float _speed;
        private Rigidbody2D rigidbody2D;
    
        public BasePlayerMove(Rigidbody2D rigidbody2D, float speed)
        {
            this.rigidbody2D = rigidbody2D;
            _speed = speed;
            rigidbody2D.isKinematic = true;
        }

        public void Update()
        {
            Move();
        }

        private void Move()
        {
            var dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            rigidbody2D.velocity = dir * _speed;
        }
    }
}
