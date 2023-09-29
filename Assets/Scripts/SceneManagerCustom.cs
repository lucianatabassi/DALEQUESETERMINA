using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerCustom : MonoBehaviour
{
    public string NombreEscena;
    void Update()
    {
        // Verificar si se presiona la tecla "D"
       //if (Input.GetKeyDown(KeyCode.D)) //DESCOMENTAR PARA PC
            if (Input.GetKey("joystick button 1")) //DESCOMENTAR PARA APK
        {
            // Cargar la escena deseada
            SceneManager.LoadScene(NombreEscena);
        }
    }
}
