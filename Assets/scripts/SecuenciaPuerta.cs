using UnityEngine;
using UnityEngine.UI; // Para controlar botones
using UnityEngine.SceneManagement;

public class SecuenciaPuerta : MonoBehaviour
{
    [Header("Objetos de la Escena")]
    public GameObject rendija;
    public GameObject puerta;
    public GameObject azelia;

    [Header("Interfaz (UI)")]
    public GameObject botonAbrirE;
    public GameObject panelTextoAzelia;
    public GameObject botonCruzarF;

    private bool cercaDePuerta = false;

    void Update()
    {
        // PASO 1: Si Conall está cerca y pulsa E
        if (cercaDePuerta && Input.GetKeyDown(KeyCode.E))
        {
            AbrirRendija();
        }
    }

    // Se activa cuando Conall entra en el área
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "CONALL_1") // Asegúrate de que se llame así en la jerarquía
        {
            botonAbrirE.SetActive(true);
            cercaDePuerta = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "CONALL_1")
        {
            botonAbrirE.SetActive(false);
            cercaDePuerta = false;
        }
    }

    public void AbrirRendija()
    {
        rendija.SetActive(false);      // Quita la rejilla
        azelia.SetActive(false);       // Desaparece Azelia
        botonAbrirE.SetActive(false);  // Quita el primer botón
        panelTextoAzelia.SetActive(true); // Muestra el mensaje
        botonCruzarF.SetActive(true);  // Muestra el botón de la F
    }

    public void AbrirPuertaFinal()
    {
        puerta.SetActive(false);       // Quita la puerta
        panelTextoAzelia.SetActive(false);
        // Ahora, si Conall avanza, entrará en el disparador de escena
    }
}
