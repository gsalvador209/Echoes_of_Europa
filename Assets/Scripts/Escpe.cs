using UnityEngine;
using System.Collections;

// Quits the player when the user hits escape

public class ExampleClass : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}