using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Core
{
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] private float timeInterval = 10f;
        private PoolManager poolManager = null;

        private void Start()
        {
            poolManager = GameObject.FindWithTag("PoolManager").GetComponent<PoolManager>();
            StartCoroutine(SpawnObject());          
        }

        IEnumerator SpawnObject()
        {
            int randomIndex = Random.Range(0, poolManager.ObjectsToPoolSize);
            GameObject obj = poolManager.GetPooledObject(randomIndex);
            obj.transform.SetPositionAndRotation(transform.position, transform.rotation);

            yield return new WaitForSeconds(timeInterval);
            StartCoroutine(SpawnObject());
        }
    }
}
