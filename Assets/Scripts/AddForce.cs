using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    //script to add a force to every object that touches the main object, this script's parent

    private Rigidbody[] toMove = null;
    [SerializeField] private float forceAmount = 1f;

    // Start is called before the first frame update
    void Start()
    {
        toMove = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toMove != null)
        {
            foreach (Rigidbody rb in toMove)
            {
                rb.AddForce(-transform.forward * forceAmount);
            }
        }



    }


    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            toMove = contact.otherCollider.GetComponentsInChildren<Rigidbody>();
        }
    }
    void OnCollisionExit(Collision collision)
    {
        toMove = null;
    }

}
