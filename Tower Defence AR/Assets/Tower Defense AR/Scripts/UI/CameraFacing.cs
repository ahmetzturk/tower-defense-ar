using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.UI
{
    public class CameraFacing : MonoBehaviour
    {

        void Update()
        {
            transform.LookAt(Camera.main.transform.position);
        }
    }
}
