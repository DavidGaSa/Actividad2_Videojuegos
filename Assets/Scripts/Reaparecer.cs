using UnityEngine;

// Este script se lo pones a la lava, pinchos o el vacío
public class Reaparecer : MonoBehaviour 
{
    public void OnTriggerEnter(Collider other)
    {
        // Usamos CompareTag porque está más optimizado en Unity que usar ==
        if (other.CompareTag("Player"))
        {
            // 1. Avisamos al GameManager de que hemos perdido una vida
            GameManager.Instance.QuitarVida(1);

            // 2. Ejecutamos tu método para teletransportar al jugador
            other.GetComponent<PlayerController>().Reaparece();
        }
    }
}