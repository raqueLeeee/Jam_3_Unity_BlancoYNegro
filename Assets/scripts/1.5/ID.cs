using UnityEngine;

public class ID : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "White" || other.name == "Black")
        {
            FindObjectOfType<MinijuegoManager>().Ganar();
        }

        if (other.CompareTag("Suelo"))
        {
            FindObjectOfType<MinijuegoManager>().Perder();
        }
    }
}