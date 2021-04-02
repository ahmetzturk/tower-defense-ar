using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    private Transform baseTransform;
    private void OnEnable()
    {      
        baseTransform = GameObject.FindWithTag("Base").transform;
        transform.parent = baseTransform;
    }
}
