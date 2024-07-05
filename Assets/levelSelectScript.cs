using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelectScript : MonoBehaviour
{

    public bool[] levelCheck = {false, false, false, false, false};

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ActivateButtonCode(ButtonScript button){
        button.ActivateButton();
    }
}
