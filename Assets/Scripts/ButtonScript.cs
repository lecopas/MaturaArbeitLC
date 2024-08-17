using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public bool completed = false;
    public int buttonNumber;
    public string levelName;
    levelSelectScript selector;

    void Start(){
        Scene scene = SceneManager.GetActiveScene();
        selector = FindObjectOfType<levelSelectScript>();

        if (scene.name == "LevelSelect"){
            if (selector.levelCheck[buttonNumber] == true){
                completed = true;
                Button button = gameObject.GetComponent<Button>(); 
                ColorBlock cb = button.colors;
                cb.normalColor = Color.gray;
                button.colors = cb;
            }
        }
    }

    public void ActivateButton(){
        completed = true;
        Button button = gameObject.GetComponent<Button>(); 
        ColorBlock cb = button.colors;
        cb.normalColor = Color.gray;
        button.colors = cb;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
        selector.levelCheck[buttonNumber] = true;
        selector.currentLevelCheck = false;
    }
}
