using TowerDefense.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TowerDefense.Attack
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] ProjectileSettings projectileData;
        [SerializeField] private float eventuallyDeactiveTime = 10f;
        private float timeSinceShooted;

        private void OnEnable()
        {
            timeSinceShooted = 0;
        }

        void Update()
        {
            Move();
            DeactiveEventually();
            timeSinceShooted += Time.deltaTime;
        }

        private void DeactiveEventually()
        {
            if(timeSinceShooted > eventuallyDeactiveTime)
            {
                gameObject.SetActive(false);             
            }
        }

        private void Move()
        {
            transform.position += transform.forward * projectileData.speed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.GetComponent<Health>().TakeDamage(projectileData.damage);
                gameObject.SetActive(false);
            }
        }
    }
}
