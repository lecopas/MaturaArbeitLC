using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showMass : MonoBehaviour
{
    displayProperty baseText;
    displayProperty newText;
    public bool showRotation = false;

    public Accelerator accel = null;
    public GameObject rotationPoint = null;

    Rigidbody2D rb;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        baseText = FindFirstObjectByType<displayProperty>();
        newText = Instantiate(baseText, baseText.transform.parent);
        if(showRotation == false) {
            if (accel == null)
            {
                newText.ShowProperty(rb.mass, "kg");
            }
            else if (accel.force != 0)
            {
                newText.ShowProperty(accel.force, "N");
            }
            else if (accel.acceleration != 0)
            {
                newText.ShowProperty(accel.acceleration, "m/s²");
            }
            else if (accel.speed != 0)
            {
                newText.ShowProperty(accel.speed, "m/s");
            }
        }
        else
        {
            float rot = transform.localEulerAngles.z + 90;
            print(rot);
            if(rot >= 360)
            {
                rot -= 360;
            }
            print(rot);
            newText.ShowProperty(rot, "°");
        }
        
        

    }

    private void Update()
    {
        // Update the position of the newText to follow the GameObject
        if(rotationPoint == null)
        {
            Vector3 worldPosition = transform.position; // Get the world position of the GameObject
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition); // Convert world position to screen position
            newText.transform.position = screenPosition; // Update the position of the newText in the UI
        } else
        {
            Vector3 worldPosition = rotationPoint.transform.position; // Get the world position of the GameObject
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition); // Convert world position to screen position
            newText.transform.position = screenPosition; // Update the position of the newText in the UI
        }
        

    }
}
