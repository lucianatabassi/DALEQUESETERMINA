using UnityEngine;

public class ControladorSonidoInicial : MonoBehaviour
{
    private PAJARO scriptPajaro;
    private InteraccionCarpincho scriptCarpincho;
    private ObjectInteraction scriptCiervo;
    private TORTUGA_INTERACCION scriptTortuga;

    public AudioSource audioSource;
    public AudioClip sonidoAMBIENTE;
    public AudioSource audioSourceTRISTE;
    public AudioClip sonidoInicial;

    private void Start()
    {
        scriptPajaro = FindObjectOfType<PAJARO>();
        scriptTortuga = FindObjectOfType<TORTUGA_INTERACCION>();
        scriptCarpincho = FindObjectOfType<InteraccionCarpincho>();
        scriptCiervo = FindObjectOfType<ObjectInteraction>();

        audioSourceTRISTE = GetComponent<AudioSource>();
        audioSourceTRISTE.clip = sonidoInicial;
        audioSourceTRISTE.Play();

        audioSource.PlayOneShot(sonidoAMBIENTE);
    }

    void Update()
    {
        if (scriptPajaro.pajaroCompletado && scriptTortuga.tortugaCompletado && scriptCarpincho.carpinchoCompletado && scriptCiervo.ciervoCompletado)
        {


            audioSourceTRISTE.Stop();

        }
    }
}
