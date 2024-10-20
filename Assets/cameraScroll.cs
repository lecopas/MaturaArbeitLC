using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScroll : MonoBehaviour
{
    public GameObject cam;
    public float scrollSpeed;
    public float floor;
    public float roof;

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
        }
    }
}
