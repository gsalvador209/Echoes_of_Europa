using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDirectionalLight : MonoBehaviour
{
    public float angularSpeed = 10f;  

    void Update()
    {
        transform.Rotate(Vector3.right * angularSpeed * Time.deltaTime);
    }
}
