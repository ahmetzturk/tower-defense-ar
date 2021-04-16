using System.Collections;
using System.Collections.Generic;
using TowerDefense.Core;
using UnityEngine;

namespace TowerDefense.Controller
{
    public class Mover : MonoBehaviour
    {
        private Rigidbody myRigidbody;
        [SerializeField] private float speed = 2f;
        private Transform baseObjectTransform;

        private void Start()
        {
            baseObjectTransform = GameManager.Instance.BaseObject.transform;
        }

        private void OnEnable()
        {
            myRigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            Move();
            speed = baseObjectTransform.localScale.x * 2;
        }

        private void Move()
        {
            myRigidbody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }
    }
}
