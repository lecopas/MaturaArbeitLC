using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainScript : MonoBehaviour
{
    
    levelSelectScript selector;
    GameObject got;
    GameObject startBox;

    public GameObject pauseScreen;

    public bool started = false;
    bool isDead = false;
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

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if(Time.timeScale == 1)
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
                
            } else if(isDead == false)
            {
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
            }
        }
    }
    public void StartSim()
    {
        started = true;
        GameObject[] intObjects = GameObject.FindGameObjectsWithTag("Modifiable");
        foreach (GameObject thing in intObjects)
            thing.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            
    }
    public void Resume()
    {
        if(isDead == false)
        {
            Time.timeScale = 1;
        }
    }

    public void Death(){
        isDead = true;
        got.SetActive(true);
        Time.timeScale = 0;
    }

    public void Reset(){
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void LevelSelect()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelect");
    }
}
