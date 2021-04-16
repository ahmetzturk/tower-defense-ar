using System.Collections;
using System.Collections.Generic;
using TowerDefense.Core;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Defense
{
    public class GhostSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject ghost;
        [SerializeField] private Button cancelGhost;


        public void SpawnGhost()
        {
            GameObject baseObject = GameManager.Instance.BaseObject;

            cancelGhost.gameObject.SetActive(true);

            Instantiate(ghost, new Vector3(baseObject.transform.position.x, baseObject.transform.position.y + 3 * baseObject.transform.localScale.x, baseObject.transform.position.z), ghost.transform.rotation);
            
            // disables all lean touch scripts of base
            GameManager.Instance.SetPassiveAllBaseScripts();
            // disables all buttons
            GameManager.Instance.SetPassiveAllButtons();
        }
    }
}
