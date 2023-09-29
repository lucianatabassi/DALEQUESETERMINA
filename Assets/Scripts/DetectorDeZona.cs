using UnityEngine;

public class DetectorDeZona : MonoBehaviour
{
    private ControladorSonidoInicial controladorSonidoInicial;
    private PAJARO scriptPajaro;

    private bool sonidoDetenido = false; // Para evitar detener el sonido más de una vez

    public AudioClip sonido; // Asigna el nuevo sonido en el Inspector
    public GameObject jugador; // Variable para el jugador
    
    private void Start()
    {
        controladorSonidoInicial = FindObjectOfType<ControladorSonidoInicial>();
        scriptPajaro = FindObjectOfType<PAJARO>();
    }

    private void Update()
    {
        if (jugador != null && !sonidoDetenido)
        {
            if (scriptPajaro != null && scriptPajaro.pajaroCompletado)
            {
                // Detén aquí el sonido inicial
                controladorSonidoInicial.audioSource.Stop();
                sonidoDetenido = true; // Marcar que el sonido ha sido detenido

                // Reproduce el nuevo sonido
               /* if (nuevoSonido != null)
                {
                    controladorSonidoInicial.audioSource.clip = nuevoSonido;
                    controladorSonidoInicial.audioSource.Play();
                }*/
            }
        }
    }
}
