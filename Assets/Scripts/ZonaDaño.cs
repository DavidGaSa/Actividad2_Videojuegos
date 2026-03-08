using UnityEngine;

public class ZonaDaño : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aquí puedes agregar la lógica para lo que sucede cuando el jugador entra en la zona de daño
            Debug.Log("¡Zona de daño activada!");
            GameManager.Instance.QuitarVida(1); // Quita una vida al GameManager
        }
    }
}
