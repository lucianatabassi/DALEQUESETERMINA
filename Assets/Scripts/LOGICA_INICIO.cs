using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LOGICA_INICIO : MonoBehaviour
{
    public int escena;
    public void CambiarEscena()
    {
        // Verificar si se presiona la tecla "D"
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Cargar la escena deseada
            SceneManager.LoadScene(escena);
        }
    }
}
