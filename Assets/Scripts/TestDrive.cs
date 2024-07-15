using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDrive : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + Vector2.down * speed * Time.fixedDeltaTime);
    }
}
