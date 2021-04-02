using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Core
{
    public class Node : MonoBehaviour
    {
        private Collider enemy = null;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {            
                enemy = other;
            }
        }

        private void Update()
        {
            if (enemy == null) return;
            if(Vector3.Distance(transform.position, enemy.transform.position) < 0.5f)
            {
                StartCoroutine(RotateSmoothly(enemy));
                enemy = null;
            }
        }

        IEnumerator RotateSmoothly(Collider enemy)
        {
            while (enemy.transform.forward != transform.forward)
            {
                enemy.transform.forward += Vector3.MoveTowards(enemy.transform.forward, transform.forward, Time.deltaTime);           
            }
            yield return null;
        }
    }
}
