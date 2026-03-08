using UnityEngine;

public class Coleccionable : MonoBehaviour
{    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aquí puedes agregar la lógica para lo que sucede cuando el jugador recoge el coleccionable
            Debug.Log("¡Coleccionable recogido!");
            GameManager.Instance.AddCoin(1); // Agrega una moneda al GameManager
            Destroy(gameObject); // Destruye el objeto coleccionable después de ser recogido
        }
    }
}
