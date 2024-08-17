using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyVelocity : MonoBehaviour
{
    mainScript ms;

    Rigidbody2D rb;

    public float speed;

    bool isDone = false;

    private void Start()
    {
        ms = FindAnyObjectByType<mainScript>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(speed, 0, 0);
    }

    private void Update() // very ineficient; have to fix later
    {
        if (ms.started == true)
        {
            if(isDone == false)
            {
                rb.velocity = new Vector3(speed, 0, 0);
                isDone = true;
            }
        }
    }
}
