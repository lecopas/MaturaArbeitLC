using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : MonoBehaviour
{

    public Rigidbody2D rbParent;
    Rigidbody2D rb;
    public float force = 1;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 forward = transform.TransformDirection(Vector3.up);
        rbParent.AddForceAtPosition(forward * force, rb.transform.position);
    }
}
