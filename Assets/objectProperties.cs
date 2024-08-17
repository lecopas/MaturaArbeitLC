using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectProperties : MonoBehaviour
{
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

}
