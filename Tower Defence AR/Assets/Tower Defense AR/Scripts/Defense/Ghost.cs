using System.Collections;
using System.Collections.Generic;
using TowerDefense.Core;
using UnityEngine;

namespace TowerDefense.Defense
{
    public class Ghost : MonoBehaviour
    {
        private Vector3 currentMousePos;
        private Vector3 prevMousePos = Vector3.zero;
        [SerializeField] private GameObject towerPrefab = null;
        [SerializeField] private float speed = 10f;
        private int myLayer;
        private Transform baseObjectTransform;

        private void Awake()
        {
            string myLayerName = LayerMask.LayerToName(gameObject.layer);
            myLayer = LayerMask.GetMask(myLayerName);
            baseObjectTransform = GameManager.Instance.BaseObject.transform;
            transform.localScale = baseObjectTransform.localScale;
        }

        private void Update()
        {
            Drag();
            DoRaycast();
            speed = baseObjectTransform.localScale.x * 1000;
        }

        private void DoRaycast()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity, myLayer))
            {
                Destroy(hit.collider.gameObject);
                CreateTower(hit);
            }
        }

        private void CreateTower(RaycastHit hit)
        {
            GameObject tower = Instantiate(towerPrefab, hit.point, Quaternion.identity);
            tower.transform.localScale = GameManager.Instance.BaseObject.transform.localScale;
            tower.transform.parent = GameManager.Instance.BaseObject.transform;
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
