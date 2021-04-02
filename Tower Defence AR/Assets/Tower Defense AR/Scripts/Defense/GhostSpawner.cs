using System.Collections;
using System.Collections.Generic;
using TowerDefence.Manager;
using UnityEngine;

namespace TowerDefence.Defence
{
    public class GhostSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject ghost;

        public void SpawnGhost()
        {
            GameObject baseObject = GameObject.FindWithTag("Base");

            Instantiate(ghost, new Vector3(baseObject.transform.position.x, baseObject.transform.position.y + 4 * baseObject.transform.localScale.x, baseObject.transform.position.z), ghost.transform.rotation);
            MonoBehaviour[] scripts = baseObject.GetComponents<MonoBehaviour>();
            // disables base scripts (lean touch)
            foreach (var script in scripts)
            {
                script.enabled = false;
            }
            // disables all buttons
            GameManager.SetPassiveAll();
        }
    }
}
