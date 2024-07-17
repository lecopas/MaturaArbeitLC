using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyForce : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 1;
    public string direction = null;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (direction == "left")
        rb.AddForce(Vector2.left * force);
    }
}
