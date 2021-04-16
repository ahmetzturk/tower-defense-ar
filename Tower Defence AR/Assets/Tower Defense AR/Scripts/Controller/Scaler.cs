using System.Collections;
using System.Collections.Generic;
using TowerDefense.Core;
using UnityEngine;

namespace TowerDefense.Controller
{
    public class Scaler : MonoBehaviour
    {
        private Transform baseTransform;
        private void Start()
        {
            baseTransform = GameManager.Instance.BaseObject.transform;
            transform.localScale = baseTransform.localScale;
            transform.parent = baseTransform;
        }
    }
}
