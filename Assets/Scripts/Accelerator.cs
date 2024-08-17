using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : MonoBehaviour
{
    public Collider2D tempCollider;
    public Rigidbody2D rbParent = null;
    Rigidbody2D rb;

    mainScript ms;
    public float force = 0;

    public float acceleration = 0;
    public float duration = 0;
    float timeLeft;
    public float speed = 0;
    public float mod = 1;

    bool isDone = false;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ms = FindAnyObjectByType<mainScript>();
        timeLeft = duration;
    }

    void FixedUpdate()
    {
        if (force != 0)
        {
            if (rbParent != null) // constantly applies force to object. works with F = m * a
            {
                Vector3 forward = transform.TransformDirection(Vector3.up);
                rbParent.AddForceAtPosition(forward * force, rb.transform.position);
            }
        } else if (acceleration != 0)
        {
            if (rbParent != null)
            {
                if (ms.started == true)
                {
                    if (duration == 0)
                    {
                        
                        Vector3 forward = transform.TransformDirection(Vector3.up);
                        rbParent.AddForceAtPosition(forward * (acceleration * rb.mass), rb.transform.position);
                    }
                    else
                    {
                        if (timeLeft > 0.02)
                        {
                            Vector3 forward = transform.TransformDirection(Vector3.up);
                            rbParent.AddForceAtPosition(forward * (acceleration * rb.mass), rb.transform.position);
                            timeLeft -= Time.deltaTime;
                        }
                    }
                }
            }
        } else if (speed != 0)
        {
            if(rbParent != null)
            {
                if (ms.started == true)
                {
                    if (isDone == false)
                    {
                        Vector3 forward = transform.TransformDirection(Vector3.up);
                        Vector3 par = rbParent.velocity;
                        rbParent.velocity = par + (forward * speed);
                        isDone = true;
                    }
                }
            } 
        }
    }
    public void getForce(string input){
        force = float.Parse(input,System.Globalization.CultureInfo.InvariantCulture);
    }
    public void getAcceleration(string input){
        acceleration = float.Parse(input,System.Globalization.CultureInfo.InvariantCulture) * mod;
    }
}
