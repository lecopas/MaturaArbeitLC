using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class failCollision : MonoBehaviour
{
    mainScript ms;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        ms = FindObjectOfType<mainScript>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.tag == "Modifiable"){
            ms.Death();
        }
    }
}
