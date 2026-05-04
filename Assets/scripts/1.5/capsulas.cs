using UnityEngine;

public class ControlCapsulas : MonoBehaviour
{
    public Transform blanca;
    public Transform negra;
    public float velocidad = 7f;

    void Update()
    {
        if (Time.timeScale == 0) return; // Si hay Game Over, no se mueven

        // Blanca: A y D
        if (Input.GetKey(KeyCode.A)) blanca.Translate(Vector3.left * velocidad * Time.deltaTime);
        if (Input.GetKey(KeyCode.D)) blanca.Translate(Vector3.right * velocidad * Time.deltaTime);

        // Negra: Flechas
        if (Input.GetKey(KeyCode.LeftArrow)) negra.Translate(Vector3.left * velocidad * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow)) negra.Translate(Vector3.right * velocidad * Time.deltaTime);
    }
}