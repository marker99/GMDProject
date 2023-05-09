using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform teleportLocation;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger Entered");
            rb.transform.position = teleportLocation.position;
        }
    }
}