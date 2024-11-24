using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour
{
    visbleCountdown countText;
    mainScript ms;
    public float timeTotal;
    public string result;
    public string expectedResult = null;
    public string playerResult;
    float timeLeft;

    public GameObject correctObject = null;
    public GameObject selectedObject = null;

    public bool visibleTimer = true;
    // Start is called before the first frame update
    void Start()
    {
        countText = FindFirstObjectByType<visbleCountdown>();
        ms = FindObjectOfType<mainScript>();
        timeLeft = timeTotal;
        if(countText != null){
            countText.DisplayTime(timeLeft,".0");
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if(ms.started == true){
            timeLeft -= Time.deltaTime;
            float displayedTime = Mathf.Round(timeLeft * 10f) * .1f;  // Floor to 2 decimal places
            if(countText != null){
                if(displayedTime >= 0)
                {
                    if(displayedTime % 1 == 0)
                    {
                        countText.DisplayTime(displayedTime,".0");
                    } else
                    {
                        countText.DisplayTime(displayedTime,"");
                    }
                    
                }
            }
            

            if ( timeLeft < 0){
                if(result == "victory"){
                    if(expectedResult != "null"){
                        if(playerResult == expectedResult){
                            ms.Victory();
                        } else {
                            ms.Death();
                        }
                    } else if(correctObject != null)
                    {
                        if(selectedObject == correctObject)
                        {
                            ms.Victory();
                        } else
                        {
                            ms.Death();
                        }
                    } else
                    {
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
