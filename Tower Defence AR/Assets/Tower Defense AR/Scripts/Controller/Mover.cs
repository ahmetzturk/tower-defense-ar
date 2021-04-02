using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Controller
{
    public class Mover : MonoBehaviour
    {
        private Rigidbody myRigidbody;
        [SerializeField] private float speed = 0.5f;

        private void OnEnable()
        {
            myRigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            Move();
        }

        private void Move()
        {
            myRigidbody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }
    }
}
