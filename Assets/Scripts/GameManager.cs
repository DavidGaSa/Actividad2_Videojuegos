using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 1. Creamos una propiedad estática (global) para acceder a este script
    public static GameManager Instance { get; private set; }
    public int Coins => coins; // Propiedad pública para acceder a las monedas
    private int coins;

    public event Action<int> OnCoinsChanged;

    public int Vidas => vidas; // Propiedad pública para acceder a las vidas
    private int vidas;
    public event Action<int> OnVidasChanged;

    private void Awake()
    {
        // 2. Comprobamos si ya existe una instancia
        if (Instance != null && Instance != this)
        {
            // Si ya hay uno y no soy yo, me destruyo para evitar duplicados
            Destroy(gameObject);
        }
        else
        {
            // Si no hay ninguno, yo soy la instancia principal
            Instance = this;
            
            //Evita que el GameManager se destruya al cambiar de escena
            DontDestroyOnLoad(gameObject);
        }
    }


    public void AddCoin(int cantidad1)
    {
        coins += cantidad1;
        OnCoinsChanged?.Invoke(coins); // Notifica que las monedas han cambiado
    }

    public void QuitarVida(int cantidad2)
    {
        vidas -= cantidad2;
        OnVidasChanged?.Invoke(vidas); // Notifica que las vidas han cambiado
        if (vidas <= 0)
        {
            vidas = 3; // Reinicia las vidas para el próximo intento
            coins = 0; // Reinicia las monedas para el próximo intento

            OnCoinsChanged?.Invoke(coins); // Notifica que las monedas han cambiado
            OnVidasChanged?.Invoke(vidas); // Notifica que las vidas han cambiado

            // Aquí puedes agregar la lógica para lo que sucede cuando el jugador pierde todas las vidas
            Debug.Log("¡Has perdido todas las vidas! Reiniciando el juego...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena actual
        }
    }
}