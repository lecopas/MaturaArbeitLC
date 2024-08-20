using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainScript : MonoBehaviour
{
    
    public levelSelectScript selector;
    GameObject got;
    GameObject startBox;

    public bool started = false;
    private void Start()
    {
        Time.timeScale = 1;
        selector = FindAnyObjectByType<levelSelectScript>();
        got = GameObject.FindGameObjectWithTag("gameOverText");
        got.SetActive(false);

        startBox = GameObject.FindGameObjectWithTag("startText");
        if(selector.currentLevelCheck == false)
        {
            startBox.SetActive(true);
            selector.currentLevelCheck = true;
            
        } else
        {
            startBox.SetActive(false);
            
        }
        

    }
    public void StartSim()
    {
        started = true;
        GameObject[] intObjects = GameObject.FindGameObjectsWithTag("Modifiable");
        foreach (GameObject thing in intObjects)
            thing.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            
    }

    public void Death(){
        got.SetActive(true);
        Time.timeScale = 0;
    }

    public void Reset(){
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
