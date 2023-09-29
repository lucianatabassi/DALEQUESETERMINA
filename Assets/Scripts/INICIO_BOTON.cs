using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class INICIO_BOTON : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return)) //CODIGO VERSION WEB 
   //if (Input.GetKey("p"))
    { 
EmpezarJuego();
    }
}
     void EmpezarJuego()
     {
        SceneManager.LoadScene(2);
     }
}
