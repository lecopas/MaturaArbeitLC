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
        if(buttonNumber != 0)
        {
            if(selector.levelCheck[buttonNumber -1] == false)
            {
                Button button = gameObject.GetComponent<Button>();
                button.interactable = false;

            }
        }

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
        Button button = gameObject.GetComponent<Button>(); 
        ColorBlock cb = button.colors;
        cb.normalColor = Color.gray;
        button.colors = cb;
    }

    public void LoadLevel()
    {
        
        SceneManager.LoadScene(levelName);
        //selector.levelCheck[buttonNumber] = true;
        selector.currentLevelNumber = buttonNumber;
        selector.currentLevelCheck = false;
       
        
    }
}
