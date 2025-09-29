using System.Collections;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    private Rigidbody[] toMove = null;
    [SerializeField] private float forceAmount = 1f;

    void Start()
    {
        toMove = GetComponentsInChildren<Rigidbody>();
    }

    void Update()
    {
        if (toMove != null)
        {
            foreach (Rigidbody rb in toMove)
            {
                // Cap the force to avoid excessive speed
                if (rb.velocity.magnitude < forceAmount)
                {
                    rb.AddForce(-transform.forward * forceAmount);
                }
            }
        }
    }

    // Entri nell’acqua (trigger)
    void OnTriggerEnter(Collider other)
    {        toMove = other.GetComponentsInChildren<Rigidbody>();
    }

    // Esci dall’acqua (trigger)
    void OnTriggerExit(Collider other)
    {
        toMove = null;
    }
}
