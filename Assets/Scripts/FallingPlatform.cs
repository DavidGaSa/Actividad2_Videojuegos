using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    [SerializeField] private float desaparicion = 0.3f;

    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos que sea el Player quien la toca
        if (collision.gameObject.CompareTag("Player"))
        {
            // Esta línea mágica destruye este objeto (gameObject) pasados los segundos que indiques
            Destroy(gameObject, desaparicion);
        }
    }
}