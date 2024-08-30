using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flagScript : MonoBehaviour
{
    Rigidbody2D rb;
    mainScript ms;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ms = FindFirstObjectByType<mainScript>();
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.tag == "Modifiable"){
            ms.Victory();
        }
    }
}
