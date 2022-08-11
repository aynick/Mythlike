using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class BasePlayerAttack
    {
        private Transform _hand;
        private Weapon _weapon;
        private Player _playerClass;
        private Transform transform;
        private Camera _camera;
        private PlayerFlip _playerFlip;
        private Button _button;
        private Rigidbody2D _rigidbody2D;
        private float _range;
        public BasePlayerAttack(Transform playerTransform,Player player,PlayerFlip playerFlip,Rigidbody2D rigidbody2D,Button attackButton,float range)
        {
            _playerFlip = playerFlip;
            transform = playerTransform;
            _weapon = transform.GetChild(0).GetChild(0).GetComponent<Weapon>();
            _playerClass = player;
            _button = attackButton;
            _rigidbody2D = rigidbody2D;
            _range = range;
            Init();
            _button.onClick.AddListener(Attack);
        }

        private void Init()
        {
            _weapon.Damage += _playerClass.damage;
            _hand = transform.Find("Hand");
            _camera = GameObject.FindObjectOfType<Camera>();
        }

        public void Update()
        {
            RotateWeapon(IsFindEnemy());
        }

        Vector2 IsFindEnemy()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, _range);
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out EnemyBehavior enemyBehavior))
                {
                    return enemyBehavior.transform.position;
                }
            }
            return Vector2.zero;
        }

        public void Attack()
        {
            _weapon.Attack();
        }
        private void RotateWeapon( Vector2 rotateDir)
        {
            var Dir = new Vector2(rotateDir.x - transform.position.x, rotateDir.y - transform.position.y);
            if (rotateDir == Vector2.zero)
            {
                Dir = _rigidbody2D.velocity;
            }
            var thisVector = Vector3.right;
            var angle = Vector3.SignedAngle(thisVector, Dir, Vector3.forward);
            if (angle < -90 || angle > 90)
            {
                _playerFlip.Flip(-1);
            }
            else
            {
                _playerFlip.Flip(1);
            }
            _hand.localRotation = Quaternion.Euler(transform.localRotation.x,transform.localRotation.y,angle);
        }
    }
}
