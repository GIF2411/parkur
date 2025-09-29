using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadScript : MonoBehaviour
{
    //script to add a force to every object that touches the main object, this script's parent

    private Rigidbody[] toMove = null;
    [SerializeField] private float forceAmount = 1f;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioSource jumpSoundSource;
    [SerializeField] private bool clearsForceOnExit = true;

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
                rb.AddForce(-transform.up * forceAmount);
            }
        }



    }


    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            toMove = contact.otherCollider.GetComponentsInChildren<Rigidbody>();
        }
        if (jumpSoundSource != null && jumpSound != null)
        {
            jumpSoundSource.PlayOneShot(jumpSound);
        }

    }



    void OnCollisionExit(Collision collision)
    {
        if (clearsForceOnExit && toMove != null)
        {
            foreach (Rigidbody rb in toMove)
            {
                rb.velocity = Vector3.zero;
            }
        }
        toMove = null;
    }

}
