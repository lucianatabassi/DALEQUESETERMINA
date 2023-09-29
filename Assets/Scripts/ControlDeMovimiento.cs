using UnityEngine;

public class ControlDeMovimiento : MonoBehaviour
{
    public GameObject objetoAMover;
    public float velocidadMovimiento = 5.0f;

    private bool movimientoHabilitado = false;

    private void Update()
    {
        // Si el movimiento está habilitado, mueve el objeto hacia adelante.
        if (movimientoHabilitado)
        {
            objetoAMover.transform.Translate(Vector3.forward * velocidadMovimiento * Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        // Cuando el usuario hace clic en el objeto de control, habilita el movimiento.
        movimientoHabilitado = true;
        DesactivarObstaculos();
    }

    private void DesactivarObstaculos()
    {
        // Desactiva todos los obstáculos en el juego.
        GameObject[] obstaculos = GameObject.FindGameObjectsWithTag("Obstaculo");

        foreach (GameObject obstaculo in obstaculos)
        {
            obstaculo.SetActive(false);
        }
    }
}

