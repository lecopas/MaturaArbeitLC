using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScroll : MonoBehaviour
{
    public GameObject cam;
    public float scrollSpeed;
    public float floor;
    public float roof;
    levelSelectScript ls;

    private void Start()
    {
        ls = FindFirstObjectByType<levelSelectScript>();
        cam.transform.position = new Vector3(0, ls.cameraPosition);
        print(ls.cameraPosition);
    }

    private void Update()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            if (cam.transform.position.y < roof)
            {
                cam.transform.position = new Vector3(0 , cam.transform.position.y + scrollSpeed * Time.fixedDeltaTime * Input.mouseScrollDelta.y);
            }
        } else if (Input.mouseScrollDelta.y < 0)
        {
            if(cam.transform.position.y > floor)
            {
                cam.transform.position = new Vector3(0, cam.transform.position.y + scrollSpeed * Time.fixedDeltaTime * Input.mouseScrollDelta.y);
            }
        } else if (Input.GetKey(KeyCode.UpArrow))
        {
            if(cam.transform.position.y < roof)
            {
                cam.transform.position = new Vector3(0, cam.transform.position.y + scrollSpeed * Time.fixedDeltaTime * 1);
            }
            
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (cam.transform.position.y > floor)
            {
                cam.transform.position = new Vector3(0, cam.transform.position.y + scrollSpeed * Time.fixedDeltaTime * -1);
            }
        }
    }
}
