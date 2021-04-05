using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Attributes
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float healthPoints = 100f;
        private float maxHealthPoints;

        private void OnEnable()
        {
            maxHealthPoints = healthPoints;
        }

        private void Update()
        {
            if(healthPoints == 0)
            {
                Die();
            }
        }            

        private void Die()
        {
            gameObject.SetActive(false);
            healthPoints = maxHealthPoints;
        }
        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(0, healthPoints -= damage);
            // 
        }

        public float GetHealthPoints()
        {                     
            return healthPoints;
        }

        public float GetHealthPercentage()
        {
            return healthPoints / maxHealthPoints;
        }

        public float GetMaxHealthPoints()
        {
            return maxHealthPoints;
        }

        public void MakeFullHealth()
        {
            healthPoints = maxHealthPoints;
        }
    }
}
