using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mainScript : MonoBehaviour
{
    
    levelSelectScript selector;
    public GameObject got;
    public GameObject victoryBox;
    public GameObject startBox;

    public GameObject pauseScreen;

    public bool started = false;
    bool isDead = false;

    public GameObject RotationInput;
    public TMP_InputField tmp_if;
    public TMP_Text baseText;
        
    public float mainRotation;
    private void Start()
    {
        Time.timeScale = 1;
        selector = FindAnyObjectByType<levelSelectScript>();
        //got = GameObject.FindGameObjectWithTag("gameOverText");
        got.SetActive(false);

        //startBox = GameObject.FindGameObjectWithTag("startText");
        ToggleStartbox(true);
        if(selector.currentLevelCheck == false)
        {
            ToggleStartbox(true);
            selector.currentLevelCheck = true;
            
        } else
        {
            ToggleStartbox(false);
            
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
        RotationInput.SetActive(false);
        GameObject[] intObjects = GameObject.FindGameObjectsWithTag("Modifiable");
        foreach (GameObject thing in intObjects)
            thing.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GameObject[] unModObjects = GameObject.FindGameObjectsWithTag("unModifiable");
        foreach (GameObject thing in unModObjects)
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

    public void ToggleStartbox(bool inp)
    {
        if (startBox != null)
        {
            startBox.SetActive(inp);
        }
        
    }

    public void Victory()
    {
        if(selector != null){
            if (selector.levelLegit == true)
            {
                selector.levelCheck[selector.currentLevelNumber] = true;
            }
        }
        isDead = true;
        if(victoryBox == null){
            LevelSelect();
        } else {
            victoryBox.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
    public void GetRotation(string gotten){
        mainRotation = float.Parse(gotten,System.Globalization.CultureInfo.InvariantCulture);
        DragnDrop[] mods = FindObjectsOfType(typeof(DragnDrop)) as DragnDrop[];
            foreach(DragnDrop item in mods)
            {
                item.Rotate(mainRotation);
            }
    }

    public void ShowRotation()
    {
        //tmp_if.text = mainRotation.ToString();
        float tempRot = mainRotation;
        baseText.text = mainRotation.ToString() + "°";
    }
    public void ResetInput()
    {
        tmp_if.text = null;
    }
}
