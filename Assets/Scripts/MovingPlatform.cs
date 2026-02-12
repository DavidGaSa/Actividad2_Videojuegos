using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 posicionInicial;
    private Vector3 posicionFinal;
    private Rigidbody rb;
    private bool voyAlFinal = true; 

    [SerializeField] private GameObject destino; 
    [SerializeField] private float velocidad = 2.0f; 

    private void Start()
    {
        posicionInicial = transform.position;
        posicionFinal = destino.transform.position;

        destino.GetComponent<MeshRenderer>().enabled = false; 
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // 1. Definimos cual es el objetivo actual segun el booleano
        Vector3 objetivoActual = voyAlFinal ? posicionFinal : posicionInicial;

        // 2. Nos movemos hacia ese objetivo
        Vector3 nuevaPosicion = Vector3.MoveTowards(
            transform.position, 
            objetivoActual, 
            velocidad * Time.fixedDeltaTime
        );

        rb.MovePosition(nuevaPosicion);

        // 3. Comprobamos si hemos llegado al objetivo actual
        if (Vector3.Distance(transform.position, objetivoActual) < 0.01f)
        {
            // Solo invertimos el booleano, NO las posiciones
            voyAlFinal = !voyAlFinal;
        }
    }
}