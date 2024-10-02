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
            countText.DisplayTime(timeLeft);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if(ms.started == true){
            timeLeft -= Time.deltaTime;
            float displayedTime = Mathf.Floor(timeLeft * 100f) * 0.01f;  // Floor to 2 decimal places
            if(countText != null){
                countText.DisplayTime(displayedTime);
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
