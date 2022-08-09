using UnityEngine;

namespace Script
{
    public class BasePlayerMove
    {
        private float _speed;
        private Rigidbody2D rigidbody2D;
        private Joystick _joystick;
    
        public BasePlayerMove(Rigidbody2D rigidbody2D, float speed,Joystick joystick)
        {
            this.rigidbody2D = rigidbody2D;
            _speed = speed;
            _joystick = joystick;
            this.rigidbody2D.isKinematic = true;
        }

        public void Update()
        {
            Move();
        }

        private void Move()
        {
            Debug.Log(_joystick.Direction);
            var dir = _joystick.Direction;
            rigidbody2D.velocity = dir * _speed;
        }
    }
}
