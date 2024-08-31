using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMain : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left shift"))
        {
            if (Input.GetKeyDown("escape"))
            {
                Button[] btn = FindObjectsOfType(typeof(Button)) as Button[];

                foreach (Button butn in btn)
                    butn.interactable = true;

            }
        }
    }
}
