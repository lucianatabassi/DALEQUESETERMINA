using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TORTUGA_INTERACCION : MonoBehaviour
{

    private bool isCarrying = false;
    private GameObject carriedObject;
    public GameObject destinationObject;
    public GameObject replacementObject;
    public bool tortugaCompletado;

    public AudioClip sonido;
    public AudioClip sonidoAgarrar;
    public AudioSource audioSource;


    public GameObject circulo1;
    public GameObject circulo;
    public bool circuloSi = false;

    void Start()
    {
        tortugaCompletado = false;
        circulo.SetActive(false);
        circulo1.SetActive(true);
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //DESCOMENTAR PARA PC
       
        //if (Input.GetKey("joystick button 1")) //DESCOMENTAR PARA APK
        {
            if (!isCarrying)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Tortuga"))
                    {
                        PickUpObject(hit.collider.gameObject);
                        audioSource.PlayOneShot(sonidoAgarrar);
                        if(circuloSi)
                        {
                            circulo.SetActive(true);
                        }
                        
                    }
                }
            }
            else
            {
                DropObject();
                circulo.SetActive(false);
            }
        }


    }

    void PickUpObject(GameObject obj)
    {
        isCarrying = true;
        carriedObject = obj;
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(Camera.main.transform);
        circuloSi = true;
        circulo1.SetActive(false);


    }

    void DropObject()
    {
        isCarrying = false;
        carriedObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject.transform.SetParent(null);
        circulo1.SetActive(true);
    
        // Verificar si el objeto se entrega en el destino
        float distanceToDestination = Vector3.Distance(carriedObject.transform.position, destinationObject.transform.position);
        if (distanceToDestination < 3f) // Ajusta el valor de distancia según tus necesidades
        {
            circulo1.SetActive(false);
            // Desactiva la física y coloca el objeto en el destino
            carriedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            carriedObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            carriedObject.transform.position = destinationObject.transform.position;
          
            // Destruye el objeto transportado y reemplaza el objeto de destino
            Destroy(carriedObject);
            
            Instantiate(replacementObject, destinationObject.transform.position,  destinationObject.transform.rotation);

            tortugaCompletado = true;
            audioSource.PlayOneShot(sonido);
            
        }
    }
}


