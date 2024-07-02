using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartSim()
    {
        print("confirm");
        GameObject[] intObjects = GameObject.FindGameObjectsWithTag("Modifiable");
        foreach (GameObject thing in intObjects)
            thing.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            
    }
}
