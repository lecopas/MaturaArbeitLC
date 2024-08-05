using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour
{
    mainScript ms;
    public float timeTotal;
    public string result;
    public string expectedResult = null;
    public string playerResult;
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
                    if(expectedResult != null){
                        if(playerResult == expectedResult){
                            SceneManager.LoadScene("LevelSelect");
                        } else {
                            ms.Death();
                        }
                    } else {
                        SceneManager.LoadScene("LevelSelect");
                    }
                    
                } else if(result == "failure"){
                    ms.Death();
                }
            }
        }
    }
    public void GetPlayerResult(string input){
        playerResult = input;
    }
}
