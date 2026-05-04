using UnityEngine;
using TMPro; //Necesario para el texto

public class SistemaDialogo : MonoBehaviour
{
    public GameObject panelDialogo;
    public TextMeshProUGUI textoDialogo;
    public ControlPersonajes scriptControl; //conall aquí
    void Update()
    {
        //Solo si el panel está encendido
        if (panelDialogo.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.F))//queria que fuera con la misma tecla e para cerrar pero no dejo porque lo abria al mismo tiempo 
            {
                CerrarDialogo();
            }
        }
    }
    public void MostrarMensaje(string mensaje)
    {
        panelDialogo.SetActive(true);
        textoDialogo.text = mensaje;

        //Pausa el movimiento de los personajes
        scriptControl.enabled = false;
    }

    public void CerrarDialogo()
    {
        panelDialogo.SetActive(false);
        //gameplay devuelto
        scriptControl.enabled = true;
    }
}
