using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flagScript : MonoBehaviour
{
    Rigidbody2D rb;
    mainScript ms;
    public float req = 1;
    float cur = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ms = FindFirstObjectByType<mainScript>();
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.tag == "Modifiable"){
            cur += 1;
            if(cur >= req)
            {
                ms.Victory();
            }
        }
    }
}
