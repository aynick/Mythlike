using System;
using UnityEngine;

namespace Script
{
    public class WeaponPistol : Weapon
    {
        private Transform FirePoint;
        [SerializeField] private Bullet bullet; 

        private void Start()
        {
            FirePoint = transform.GetChild(0);
        }

        public override void Attack()
        {
            Bullet bulletClone = Instantiate(bullet, FirePoint.position, transform.rotation);
            bulletClone.GetComponent<Bullet>().Damage = Damage;
        }
    }
}