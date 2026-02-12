using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float velocidad = 12f; 
    [SerializeField] private float jumpForce = 5f; 
    [SerializeField] private float aireRozamiento = 0.2f; 

    [SerializeField] private Transform modeloVisual; // Arrastra aquí al hijo (el Oso)
    [SerializeField] private float velocidadGiro = 10f; // Velocidad de rotación del modelo

    private float moveH;
    private float moveV;
    
    private bool isGrounded; 
    private bool jump; 

    public float respawn;

    void Start()
    {
        if(rb == null) rb = GetComponent<Rigidbody>();
        
        // NUEVO: Protección por si olvidas asignar el modelo
        if (modeloVisual == null) modeloVisual = transform.GetChild(0); 
    }

    void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        // --- 1. CÁLCULO DE DIRECCIÓN (NUEVO) ---
        // En lugar de usar new Vector3(moveH, 0, moveV), calculamos según la cámara
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        // "Aplanamos" los vectores para ignorar la inclinación de la cámara (evitar ir al suelo)
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // Creamos la dirección mezclando los inputs con la orientación de la cámara
        Vector3 direccion = (camForward * moveV + camRight * moveH).normalized;


        // --- 2. APLICACIÓN DE FUERZA (TU LÓGICA ANTERIOR) ---
        if (isGrounded)
        {
            rb.AddForce(direccion * velocidad, ForceMode.Force);
        }
        else
        {
            rb.AddForce(direccion * velocidad * aireRozamiento, ForceMode.Force);
        }

        // --- 3. ROTACIÓN DEL MODELO (NUEVO) ---
        // Si nos estamos moviendo, giramos el personaje hacia esa dirección
        if (direccion != Vector3.zero && modeloVisual != null)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
            // Slerp hace una rotación suave en lugar de instantánea
            modeloVisual.rotation = Quaternion.Slerp(modeloVisual.rotation, rotacionObjetivo, velocidadGiro * Time.fixedDeltaTime);
        }

        // --- 4. SALTO (TU LÓGICA ANTERIOR) ---
        if (jump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false; 
            isGrounded = false; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = false;
    }


    public void Reaparece()
    {
        // Si caemos por debajo de -10 en Y, hacemos respawn
        transform.position = new Vector3(0f, 0f, 0f);
        rb.linearVelocity = Vector3.zero; // Detenemos cualquier movimiento residual
        Debug.Log("Has caído. Respawn!");
    }
}