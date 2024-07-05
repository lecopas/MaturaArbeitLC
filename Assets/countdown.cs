using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour
{
    mainScript ms;
    public float timeTotal;
    public string result;
    float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        ms = FindObjectOfType<mainScript>();
        timeLeft = timeTotal;
    }

    // Update is called once per frame
    void Update()
    {
        if(ms.started == true){
            timeLeft -= Time.deltaTime;

            if ( timeLeft < 0){
                if(result == "victory"){
                    SceneManager.LoadScene("LevelSelect");
                }
            }
        }
    }
}
