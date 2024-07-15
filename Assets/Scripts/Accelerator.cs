using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : MonoBehaviour
{
    public Collider2D tempCollider;
    public Rigidbody2D rbParent = null;
    Rigidbody2D rb;
    public float force = 1;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(rbParent != null) // constantly applies force to object. works with F = m * a
        {
            Vector3 forward = transform.TransformDirection(Vector3.up);
            rbParent.AddForceAtPosition(forward * force, rb.transform.position);
        }
    }
}
