using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class UIUpdater : MonoBehaviour
{
    //Creamos las variables que manejan el texto.
    [SerializeField] private TextMeshProUGUI textoMonedas;
    [SerializeField] private TextMeshProUGUI textoVidas;

    //Creamos los métodos que actualizan el texto de las monedas y las vidas.
    private void actualizarMonedas(int coins)
    {
        textoMonedas.text = "Monedas: " + coins.ToString();
    }

    private void actualizarVidas(int vidas)
    {
        textoVidas.text = "Vidas: " + vidas.ToString();
    }

    //En el Start, nos suscribimos a los eventos de cambio de monedas y vidas para actualizar el texto cada vez que cambien.
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