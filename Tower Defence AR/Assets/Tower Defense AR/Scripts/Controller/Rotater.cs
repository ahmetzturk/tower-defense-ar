using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Controller
{
    public class Rotater : MonoBehaviour
    {
        [SerializeField] private Transform turret;
        [SerializeField] private float speed;
        public Transform Turret { get => turret; }

        public void Rotate()
        {
            turret.transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
        }
    }
}
