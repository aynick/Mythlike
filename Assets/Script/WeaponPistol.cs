using System;
using UnityEngine;

namespace Script
{
    public class WeaponPistol : Weapon
    {
        private Transform FirePoint;
        [SerializeField] private Bullet bullet;
        private float cd;
        
        private void Start()
        {
            FirePoint = transform.GetChild(0);
        }

        private void Update()
        {
            coolDown();
        }

        void coolDown()
        {
            if (cd <= 0)
            {
                isReady = true;
            }

            if (cd > 0)
            {
                cd -= Time.deltaTime;
            }
        }
        
        public override void Attack()
        {
            if(!isReady) return;
            Bullet bulletClone = Instantiate(bullet, FirePoint.position, FirePoint.rotation);
            bulletClone.GetComponent<Bullet>().Damage = Damage;
            cd = FireRate;
            isReady = false;
            Debug.Log(Damage);
        }
    }
}