using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bowling : MonoBehaviour
{
    [SerializeField]private Rigidbody rb;
    [SerializeField]private AudioClip hitSound;
    private bool isThrown = false;
    private AudioSource audioSource;

    
    public float throwAcceleration = 15f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !isThrown)
        {
            
            isThrown = true;
            ThrowBall();
        }
    }

    private void ThrowBall()
    {
        
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 throwDirection = mouseRay.direction;

        
        //F=ma
        Vector3 force = rb.mass * throwDirection * throwAcceleration;

        
        rb.AddForce(force, ForceMode.Impulse);

    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a pin
        if (collision.gameObject.CompareTag("Pins"))
        {
            // Play the hit sound
            audioSource.Play();
        }
    }        
     



}
