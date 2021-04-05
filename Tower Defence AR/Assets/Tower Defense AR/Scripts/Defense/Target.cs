using System.Collections;
using System.Collections.Generic;
using TowerDefense.Attributes;
using UnityEngine;

namespace TowerDefense.Defense
{
    public class Target : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {               
                other.gameObject.SetActive(false);
                other.GetComponent<Health>().MakeFullHealth();
            }
        }
    }
}
