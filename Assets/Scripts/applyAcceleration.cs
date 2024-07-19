using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyAcceleration : MonoBehaviour
{
    public Collider2D tempCollider;

    public Rigidbody2D rbParent = null;

    Rigidbody2D rb;

    mainScript ms;

    public float acceleration;

    public float duration;
    float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        ms = FindAnyObjectByType<mainScript>();
        rb = GetComponent<Rigidbody2D>();
        timeLeft = duration;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rbParent != null) 
        {
            if (ms.started == true)
            {
                if (duration != 0)
                {
                    rbParent.AddForceAtPosition(Vector2.right * (acceleration * rb.mass), rb.transform.position);
                }
                else
                {
                    if (timeLeft > 0)
                    {
                        rbParent.AddForceAtPosition(Vector2.right * (acceleration * rb.mass), rb.transform.position);
                        timeLeft -= Time.deltaTime;
                    }
                }
            }
        }
    }
}
