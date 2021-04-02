using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Core
{
    public class PoolProjectile : MonoBehaviour
    {
        private Queue<GameObject> pooledObjects;
        [SerializeField]
        private GameObject objectToPool;
        [SerializeField]
        private float poolSize;

        private void Awake()
        {
            SetPooledObjects();
        }

        private void SetPooledObjects()
        {
            pooledObjects = new Queue<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {             
                GameObject obj = Instantiate(objectToPool, transform);
                obj.SetActive(false);
                pooledObjects.Enqueue(obj);              
            }
        }

        public GameObject GetPooledObject()
        {
            GameObject obj = pooledObjects.Dequeue();
            obj.SetActive(true);
            pooledObjects.Enqueue(obj);
            return obj;
        }
    }
}
