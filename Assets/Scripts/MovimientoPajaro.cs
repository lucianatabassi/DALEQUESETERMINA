using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPajaro : MonoBehaviour
{
 public Transform[] waypoints; // Lista de puntos por los que el objeto se mover�
    public float speed = 5.0f; // Velocidad de movimiento del objeto
    public float rotationSpeed = 5.0f; // Velocidad de rotaci�n del objeto
    public float floatAmplitude = 0.5f; // Amplitud de la oscilaci�n vertical
    public float floatFrequency = 1.0f; // Frecuencia de la oscilaci�n vertical
    private int currentWaypointIndex = 0; // �ndice del punto actual
    private PAJARO scriptPajaro;

    public AudioClip sonidoDarVenda;
    public AudioSource audioSource;

    void Start()
    {
        scriptPajaro = FindObjectOfType<PAJARO>();
    }

    void Update()
    {
        if (scriptPajaro.pajaroCurado)
        {
            Movimiento();
        }
    }
    public void Movimiento(){
    if (currentWaypointIndex < waypoints.Length)
            {
                Vector3 targetPosition = waypoints[currentWaypointIndex].position;

                // Mover el objeto hacia el punto objetivo
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

                // Oscilaci�n vertical
                float verticalOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
                Vector3 floatOffset = Vector3.up * verticalOffset;
                transform.position += floatOffset;

                // Rotar el objeto hacia el punto objetivo
                Vector3 directionToTarget = targetPosition - transform.position;
                if (directionToTarget != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }

                // Comprobar si el objeto est� lo suficientemente cerca del punto objetivo
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    currentWaypointIndex++; // Avanzar al siguiente punto
                }
            }
            else
            {
                // Si se han recorrido todos los puntos, reiniciar el circuito
                currentWaypointIndex = 0;
            }
}

    private void sonidoCurar()
    {
        if (scriptPajaro.pajaroCurado && sonidoDarVenda != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoDarVenda);
            Debug.Log("AA");
        }
    }



}



