using UnityEngine;

public class ControlPersonajes : MonoBehaviour
{
    public float velocidad;
    public Transform azeliaTransform;
    public float distanciaDetras;
    public float suavizado;

    private SpriteRenderer conallSprite;
    private SpriteRenderer azeliaSprite;

    void Start()
    {
        conallSprite = GetComponent<SpriteRenderer>();
        azeliaSprite = azeliaTransform.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //MOVIMIENTO getaxis=awsd+flechas
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movH, movV, 0);
        transform.position += movimiento * velocidad * Time.deltaTime;

        //para q azelia vaya detrás
        Vector3 puntoDetras;

        if (movH > 0) //Conall va a la derecha flipx vuelta horizontal
        {
            conallSprite.flipX = false;
            azeliaSprite.flipX = false;
            //El objetivo de Azelia es a la IZQUIERDA de Conall
            puntoDetras = transform.position + Vector3.left * distanciaDetras;
        }
        else if (movH < 0) //Conall va a la izquierda
        {
            conallSprite.flipX = true;
            azeliaSprite.flipX = true;
            //El objetivo de Azelia es a la DERECHA de Conall
            puntoDetras = transform.position + Vector3.right * distanciaDetras;
        }
        else
        {
            //Si está quieto se mantiene ahí
            float direccion = conallSprite.flipX ? 1 : -1;
            puntoDetras = transform.position + new Vector3(direccion * distanciaDetras, 0, 0);
        }

        //MOVIMIENTO SUAVE DE AZELIA HACIA ESE PUNTO
        //Usamos Lerp para que el cambio de lado no sea un salto brusco
        azeliaTransform.position = Vector3.Lerp(azeliaTransform.position, puntoDetras, Time.deltaTime * suavizado);
    }
}
