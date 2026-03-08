using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class UIUpdater : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textoMonedas;
    [SerializeField] private TextMeshProUGUI textoVidas;


    private void actualizarMonedas(int coins)
    {
        textoMonedas.text = "Monedas: " + coins.ToString();
    }

    private void actualizarVidas(int vidas)
    {
        textoVidas.text = "Vidas: " + vidas.ToString();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()

    {
        actualizarMonedas(GameManager.Instance.Coins); // Actualiza el texto al iniciar
        actualizarVidas(GameManager.Instance.Vidas); // Actualiza el texto al iniciar
        GameManager.Instance.OnCoinsChanged += actualizarMonedas; //Indica el contador cada vez que cambie el número de monedas
        GameManager.Instance.OnVidasChanged += actualizarVidas; //Indica el contador cada vez que cambie el número de vidas

        
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= actualizarMonedas; //Para evitar errores
        GameManager.Instance.OnVidasChanged -= actualizarVidas; //Para evitar errores
    }
}