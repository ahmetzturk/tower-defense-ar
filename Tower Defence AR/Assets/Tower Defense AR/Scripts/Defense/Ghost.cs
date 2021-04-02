using System.Collections;
using System.Collections.Generic;
using TowerDefence.Manager;
using UnityEngine;

namespace TowerDefence.Defence
{
    public class Ghost : MonoBehaviour
    {
        private Vector3 currentMousePos;
        private Vector3 prevMousePos = Vector3.zero;
        [SerializeField] private float speed = 10f;
        private LayerMask myLayer;

        private void Awake()
        {
            myLayer = ~gameObject.layer;
            print(myLayer.value);
        }

        private void Update()
        {
            Drag();
            DoRaycast();
        }

        private void DoRaycast()
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity, myLayer.value))
            {
                CreateTower(hit);
            }
        }

        private void CreateTower(RaycastHit hit)
        {
            hit.collider.gameObject.GetComponent<Tower>().CreateTower();
            // enables all buttons again
            GameManager.SetActiveAll();
            Destroy(gameObject);
        }

        private void Drag()
        {
            if (Input.GetMouseButton(0))
            {
                if (prevMousePos == Vector3.zero)
                {
                    prevMousePos = new Vector3(Input.mousePosition.x,
                                               Input.mousePosition.y,
                                               Camera.main.nearClipPlane);
                }
                currentMousePos = new Vector3(Input.mousePosition.x,
                                  Input.mousePosition.y,
                                  Camera.main.nearClipPlane);

                Vector3 distanceVector = Camera.main.ScreenToWorldPoint(currentMousePos) -
                                         Camera.main.ScreenToWorldPoint(prevMousePos);
                Vector3 modifiedDistanceVector = new Vector3(distanceVector.x, 0, distanceVector.y);
                transform.position += modifiedDistanceVector * speed * Time.deltaTime;

                prevMousePos = new Vector3(Input.mousePosition.x,
                               Input.mousePosition.y,
                               Camera.main.nearClipPlane);
            }
            else
            {
                prevMousePos = Vector3.zero;
            }
        }

    }
}
