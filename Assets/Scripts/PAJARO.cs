using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAJARO : MonoBehaviour
{
    public Transform[] waypoints; // Lista de puntos por los que el objeto se mover�
    public float speed = 5.0f; // Velocidad de movimiento del objeto
    public float rotationSpeed = 5.0f; // Velocidad de rotaci�n del objeto
    public float floatAmplitude = 0.5f; // Amplitud de la oscilaci�n vertical
    public float floatFrequency = 1.0f; // Frecuencia de la oscilaci�n vertical
    private int currentWaypointIndex = 0; // �ndice del punto actual
    public GameObject circulo;
    public GameObject corazon;
    public GameObject newPajaro;
    public bool pajaroCurado = false;
    public Camera miCamara;
    public GameObject pajaro;

    public AudioClip sonidoDarVenda;  
    public AudioSource audioSource;

    private VENDA_INTERACCION scriptVenda;

    public bool pajaroCompletado = false;

    void Start()
    {
        corazon.SetActive(false);
        circulo.SetActive(false);
        scriptVenda = FindObjectOfType<VENDA_INTERACCION>();
        newPajaro.SetActive(false);
    }

  /* private void OnMouseDown()  //ESTO DESCOMENTALO PARA QUE FUNCIONE EN COMPU Y COMENTALO PARA EL APK
    {
        Destroy(GameObject.FindGameObjectWithTag("Venda"));
        pajaroCurado = true;
        sonidoCurar();
        Destroy(circulo);
        cambioPajaro();
        corazon.SetActive(true);
        Debug.Log("Pajaro curado");
        pajaroCompletado = true;
    }*/

  /*  private void OnJoystickButtonDown()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1.0f);


        foreach (Collider collider in colliders)
        {
            // Comprueba si el objeto que colisiona con la rama tiene una etiqueta "Moho".
            if (collider.CompareTag("Venda"))
            {
                // Si es moho, destr�yelo.
                pajaroCurado = true;
                sonidoCurar();
                Destroy(circulo);
                cambioPajaro();
                corazon.SetActive(true);
                //Debug.Log("Pajaro curado");
                pajaroCompletado = true;

            }
        }
    }*/

    private void Update()
    {
        if (scriptVenda.circuloSi)
        {
            circulo.SetActive(true);
        }
        else
        {
            circulo.SetActive(false);
        }
        if (scriptVenda.agarroVenda)
        {
            //if (Input.GetMouseButtonDown(0)) // DESCOMENTAR PARA PC
           if (Input.GetKey("joystick button 1")) // DESCOMENTAR PARA APK
            {

                Ray ray = miCamara.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == pajaro) // Verifica si el rayo golpeó al objeto del pájaro
                    {
                        // Aquí debes implementar la lógica para verificar si el objeto en la mano es el correcto y destruirlo si es así.
                        Destroy(GameObject.FindGameObjectWithTag("Venda"));
                        pajaroCurado = true;
                        scriptVenda.circuloSi = false;
                       //cambioPajaro();
                        corazon.SetActive(true);
                        Debug.Log("Pajaro curado");
                        pajaroCompletado = true;
                    }
                }
            }
        }
        if (pajaroCurado)
        {
            cambioPajaro();
        }
        
    }

    private void cambioPajaro()
    {
            // Encuentra todos los objetos con el tag "Pajaro"
            GameObject[] objetosPajaro = GameObject.FindGameObjectsWithTag("Pajaro");

            // Itera a través de todos los objetos con el tag "Pajaro" y reemplázalos
            foreach (GameObject obj in objetosPajaro)
            {
                // Obtén la posición y rotación del objeto actual
                Vector3 position = obj.transform.position;
                Quaternion rotation = obj.transform.rotation;

                // Destruye el objeto actual con el tag "Pajaro"
                Destroy(obj);

            // Instancia el nuevoPajaro (prefab) en la posición y con la rotación del objeto actual
            newPajaro.SetActive(true);
                //Instantiate(newPajaro, position, rotation);
            }
        
    }


     private bool enRango(GameObject obj)
    {
        float distance = Vector3.Distance(obj.transform.position, transform.position);
        return distance <= 3f; // Adjust the range as needed
    }


}

