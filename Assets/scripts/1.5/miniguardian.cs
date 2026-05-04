using UnityEngine;

public class Miniguardian : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // IMPORTANTE: Primera letra en Mayúscula como en tu jerarquía
        if (other.name == "White" || other.name == "Black")
        {
            FindObjectOfType<MinijuegoManager>().Perder();
        }

        if (other.CompareTag("Suelo"))
        {
            Destroy(gameObject);
        }
    }
}