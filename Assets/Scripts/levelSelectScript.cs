using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelectScript : MonoBehaviour
{
    public GameObject startBox;

    public bool[] levelCheck = {false, false, false, false, false};

    public bool firstTime = true;

    public bool currentLevelCheck = false;

    public bool levelLegit = true;

    public int currentLevelNumber;

    public float cameraPosition = 0;

    public float firstTimeagain = 0;



    private void Start()
    {
        if(firstTimeagain == 0)
        {
            startBox.SetActive(true);
            firstTimeagain = firstTimeagain + 1;
        }
    }
        public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ActivateButtonCode(ButtonScript button){
        button.ActivateButton();
    }
}
