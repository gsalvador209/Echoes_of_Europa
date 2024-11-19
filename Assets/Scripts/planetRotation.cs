using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteOrbit : MonoBehaviour
{
    public Transform centerPoint; 
    public float orbitRadius = 4000f; // Radio de la orbita
    public float orbitSpeed = 10f; //Velocidad rotacional
    public Vector3 orbitAxis = Vector3.up; //Vector y

    public float verticalAmplitude = 2000.0f; //La amplitud para el movimiento sinusoidal
    public float verticalPeriod = 1000.0f; //La frecuencia angular dle segundo movimiento

    private float currentAngle = 280f; 

    void Update()
    {
        if (centerPoint != null)
        {
            // Calcula el nuevo anggulo en función del tiempo
            currentAngle += orbitSpeed * Time.deltaTime;
            if (currentAngle >= 360f) currentAngle -= 360f; //Reinicia a 0


            Vector3 horizontalOffset = new Vector3(
                Mathf.Sin(currentAngle*Mathf.Deg2Rad)*orbitRadius,
                0,
                Mathf.Cos(currentAngle*Mathf.Deg2Rad) * orbitRadius
                );

            //Valor del segundo movimiento sinusoidal
            float verticalOffset = verticalAmplitude * Mathf.Sin(Time.time/ verticalPeriod * Mathf.PI * 2f);

            Vector3 combinedOffset = horizontalOffset + new Vector3(0, verticalOffset, 0);

       
            // Hace la traslación
            transform.position = centerPoint.position + combinedOffset;

            // Hace que solo se vea una cara en la rotación, como la luna
            //transform.LookAt(centerPoint);
        }
    }
}
