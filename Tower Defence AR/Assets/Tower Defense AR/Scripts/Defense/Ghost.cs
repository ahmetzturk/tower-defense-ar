using System.Collections;
using System.Collections.Generic;
using TowerDefense.Manager;
using UnityEngine;

namespace TowerDefense.Defense
{
    public class Ghost : MonoBehaviour
    {
        private Vector3 currentMousePos;
        private Vector3 prevMousePos = Vector3.zero;
        [SerializeField] private float speed = 10f;
        private int myLayer;

        private void Awake()
        {
            string myLayerName = LayerMask.LayerToName(gameObject.layer);
            myLayer = LayerMask.GetMask(myLayerName);
        }

        private void Update()
        {
            Drag();
            DoRaycast();
        }

        private void DoRaycast()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity, myLayer))
            {
                if (hit.transform.GetChild(0).gameObject.activeSelf == false)
                    CreateTower(hit);
            }
        }

        private void CreateTower(RaycastHit hit)
        {
            hit.collider.gameObject.GetComponent<Tower>().CreateTower();
            // enables all buttons again
            GameManager.Instance.SetActiveAllButtons();
            CancelGhost cancelGhost = FindObjectOfType<CancelGhost>();
            cancelGhost.SetPassive();
            Destroy(gameObject);
        }

        private void Drag()
        {
            if (UnityEngine.Input.GetMouseButton(0))
            {
                if (prevMousePos == Vector3.zero)
                {
                    prevMousePos = new Vector3(UnityEngine.Input.mousePosition.x,
                                               UnityEngine.Input.mousePosition.y,
                                               Camera.main.nearClipPlane);
                }
                currentMousePos = new Vector3(UnityEngine.Input.mousePosition.x,
                                  UnityEngine.Input.mousePosition.y,
                                  Camera.main.nearClipPlane);

                Vector3 distanceVector = Camera.main.ScreenToWorldPoint(currentMousePos) -
                                         Camera.main.ScreenToWorldPoint(prevMousePos);
                Vector3 modifiedDistanceVector = new Vector3(distanceVector.x, 0, distanceVector.y);
                transform.position += modifiedDistanceVector * speed * Time.deltaTime;

                prevMousePos = new Vector3(UnityEngine.Input.mousePosition.x,
                               UnityEngine.Input.mousePosition.y,
                               Camera.main.nearClipPlane);
            }
            else
            {
                prevMousePos = Vector3.zero;
            }
        }
    }
}
