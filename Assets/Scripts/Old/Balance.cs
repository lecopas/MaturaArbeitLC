using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 1;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
        rb.AddForceAtPosition(Vector2.up * rb.mass * 9.81f, rb.transform.position);
        //rb.MovePosition(rb.position + Vector2.up * moveSpeed * Time.fixedDeltaTime);
    }
}
