using UnityEngine;
using UnityEngine.SceneManagement; //cambiar

public class MenuPrincipal : MonoBehaviour
{
    // Esta función la usaremos para el botón Jugar
    public void EmpezarJuego()
    {
        SceneManager.LoadScene("EscenaMansion");
    }

    
}