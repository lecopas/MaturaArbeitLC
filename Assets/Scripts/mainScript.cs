using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScript : MonoBehaviour
{
    public bool started = false;
    // Start is called before the first frame update
    public void StartSim()
    {
        started = true;
        GameObject[] intObjects = GameObject.FindGameObjectsWithTag("Modifiable");
        foreach (GameObject thing in intObjects)
            thing.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            
    }
}
