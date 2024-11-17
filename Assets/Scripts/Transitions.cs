using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    public Animator controller; //El controlador creado para el modelo

 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            controller.SetBool("W_key",true);
            Debug.Log("Deberia avanzar el modelo");
        }
        else
        {
            controller.SetBool("W_key", false);
        }
    }
}
