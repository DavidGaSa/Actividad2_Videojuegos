using UnityEditor.Callbacks;
using UnityEngine;

public class Reaparecer : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate() {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colision con trigger");
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().Reaparece();
        }
    }
}
