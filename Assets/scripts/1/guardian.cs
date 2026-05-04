using UnityEngine;

public class GuardianInteraccion : MonoBehaviour
{
    public GameObject botonE; 
    public string mensaje = "¡Alto! Identificación, por favor.";

    private bool jugadorCerca = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            botonE.SetActive(true); //Aparece la E
        }
    }



    void Update()
    {
        //Si estoy cerca y pulso E, llamo al sistema de diálogo
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            botonE.SetActive(false);
            FindObjectOfType<SistemaDialogo>().MostrarMensaje(mensaje);
        }
    }

}
