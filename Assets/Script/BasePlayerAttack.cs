using UnityEngine;

namespace Script
{
    public class BasePlayerAttack
    {
        private Transform _hand;
        private Weapon _weapon;
        private Player _playerClass;
        private Transform transform;

        public BasePlayerAttack(Transform playerTransform,Player player)
        {
            transform = playerTransform;
            _weapon = transform.GetChild(0).GetChild(0).GetComponent<Weapon>();
            _playerClass = player;
            Init();
        }

        private void Init()
        {
            _weapon.Damage += _playerClass.damage;
            _hand = transform.Find("Hand");
        }

        public void Update()
        {
            Attack();
            RotateWeapon();
        }

        private void Attack()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _weapon.Attack();
            }
        }
        private void RotateWeapon()
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var mouseDir = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            var thisVector = Vector3.right;
            var angle = Vector3.SignedAngle(thisVector, mouseDir, Vector3.forward);
            _hand.localRotation = Quaternion.Euler(transform.localRotation.x,transform.localRotation.y,angle);
        }
    }
}
