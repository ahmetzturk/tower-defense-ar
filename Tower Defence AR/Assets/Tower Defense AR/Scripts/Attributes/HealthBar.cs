using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Attributes
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Health health;
       
        void Update()
        {
            rectTransform.localScale = new Vector3(health.GetHealthPercentage(), 1, 1);
        }
    }
}
