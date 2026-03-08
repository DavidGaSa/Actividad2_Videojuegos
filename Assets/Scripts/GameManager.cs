using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 1. Creamos una propiedad estática (global) para acceder a este script
    public static GameManager Instance { get; private set; }
    private int coins;
    private GameObject gameObject;

    public event Action<int> OnCoinsChanged;

    private void Awake()
    {
        // 2. Comprobamos si ya existe una instancia
        if (Instance != null && Instance != this)
        {
            // Si ya hay uno y no soy yo, me destruyo para evitar duplicados
            this.Destroy(this.gameObject);
        }
        else
        {
            // Si no hay ninguno, yo soy la instancia principal
            Instance = this;
            
            //Evita que el GameManager se destruya al cambiar de escena
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Destroy(object gameObject)
    {
        throw new NotImplementedException();
    }

    public void AddCoin(int amount)
    {
        coins += amount;
        OnCoinsChanged?.Invoke(coins); // Notifica que las monedas han cambiado
    }
}