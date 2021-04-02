using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Core 
{ 
    public class PoolManager : MonoBehaviour
    {
        private Queue<GameObject> [] pooledObjects;
        [SerializeField]
        private GameObject [] objectsToPool;
        [SerializeField]
        private float[] poolSize;

        public int ObjectsToPoolSize { get => objectsToPool.Length; }

        private void Awake()
        {
            SetPooledObjects();
        }

        private void SetPooledObjects()
        {
            pooledObjects = new Queue<GameObject>[objectsToPool.Length];
            for (int i = 0; i < objectsToPool.Length; i++)
            {
                pooledObjects[i] = new Queue<GameObject>();
            }
            for (int i = 0; i < objectsToPool.Length; i++)
            {
                for (int j = 0; j < poolSize[i]; j++)
                {
                    GameObject obj = Instantiate(objectsToPool[i], transform);
                    obj.SetActive(false);
                    pooledObjects[i].Enqueue(obj);
                }
            }
        }
        
        public GameObject GetPooledObject(int index)
        {
            GameObject obj = pooledObjects[index].Dequeue();
            obj.SetActive(true);
            pooledObjects[index].Enqueue(obj);
            return obj;
        }

    }
}
