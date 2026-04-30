using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player: MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocidad = 7f;
    public float fuerzaSalto = 10f;

    int saltosRealizados = 0;
    int maxSaltos = 2;

    void Update()
    {
        // MOVIMIENTO 
        float direccion = 0;

        if (Input.GetKey(KeyCode.D))
        {
            direccion = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direccion = -1;
        }

        rb.velocity = new Vector2(direccion * velocidad, rb.velocity.y);

        // SALTO CON ESPACIO O W
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && saltosRealizados < maxSaltos)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            saltosRealizados++;
        }
    }

    private void OnCollisionEnter2D(Collision2D NS)
    {
        if (NS.gameObject.CompareTag("Ground"))
        {
            saltosRealizados = 0;
        }
    }
}