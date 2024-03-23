using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]private Rigidbody rb;
    private bool isThrown = false;

    
    public float throwSpeed = 15f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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

        
        // คำนวณความเร่งโดยใช้สูตร F=ma
        Vector3 force = rb.mass * throwDirection * throwSpeed;

        // กำหนดความเร่งให้กับวัตถุ
        rb.AddForce(force, ForceMode.Impulse);

    }

}
