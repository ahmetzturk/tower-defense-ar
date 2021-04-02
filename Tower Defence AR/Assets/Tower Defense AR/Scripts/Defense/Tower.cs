using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Defence
{
    public class Tower : MonoBehaviour
    {
        private void Awake()
        {
            HideTower();
        }

        private void HideTower()
        {
            MonoBehaviour[] monoBehaviours = GetComponents<MonoBehaviour>();
            foreach (var monoBehaviour in monoBehaviours)
            {
                if(monoBehaviour != this)
                    monoBehaviour.enabled = false;
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        public void CreateTower()
        {
            MonoBehaviour[] monoBehaviours = GetComponents<MonoBehaviour>();
            foreach (var monoBehaviour in monoBehaviours)
            {
                monoBehaviour.enabled = true;
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
