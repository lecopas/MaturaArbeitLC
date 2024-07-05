using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public bool completed = false;
    public string levelName;
    levelSelectScript selector;

    void Start(){
        Scene scene = SceneManager.GetActiveScene();
        selector = FindObjectOfType<levelSelectScript>();

        if (scene.name == "LevelSelect"){
            if (selector.level1Complete == true){
                completed = true;
                Button button = gameObject.GetComponent<Button>(); 
                ColorBlock cb = button.colors;
                cb.normalColor = Color.green;
                button.colors = cb;
            }
        }
    }

    public void ActivateButton(){
        completed = true;
        Button button = gameObject.GetComponent<Button>(); 
        ColorBlock cb = button.colors;
        cb.normalColor = Color.green;
        button.colors = cb;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
        selector.level1Complete = true;
    }
}
