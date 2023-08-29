using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    
    void Update()
    {
        transform.Rotate(45.0f * Time.deltaTime, 0f, 0f);
    }
}
