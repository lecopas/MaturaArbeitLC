using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("selector");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
