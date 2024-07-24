using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFirsttoFalse : MonoBehaviour
{
    levelSelectScript selector;
    // Start is called before the first frame update
    void Start()
    {
        selector = FindObjectOfType<levelSelectScript>();
        if(selector.firstTime == false)
        {
            gameObject.SetActive(false);
        } else
        {
            selector.firstTime = false;
        }
        
    }


}
