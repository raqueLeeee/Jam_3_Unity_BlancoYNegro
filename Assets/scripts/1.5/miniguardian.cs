using UnityEngine;

public class Miniguardian : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        //para la condicion de perder
        if (other.name == "White" || other.name == "Black")
        {
            Debug.Log("chocasteee");
            FindObjectOfType<MinijuegoManager>().Perder();
        }

        if (other.CompareTag("Suelo"))
        {
            Destroy(gameObject);
        }
    }
}