using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]private Rigidbody rb;
    private bool isThrown = false;

    // ความเร็วเริ่มต้นของการโยนลูกบอล
    public float throwSpeed = 15f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !isThrown)
        {
            // เมื่อคลิกที่เมาส์เริ่มต้นโยนลูกบอล
            isThrown = true;
            ThrowBall();
        }
    }

    private void ThrowBall()
    {
        // คำนวณทิศทางการโยนลูกบอลโดยใช้เมาส์
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 throwDirection = mouseRay.direction;

        // กำหนดความเร็วและเริ่มทิศทางการเคลื่อนที่
        rb.velocity = throwDirection * throwSpeed;
    }

}
