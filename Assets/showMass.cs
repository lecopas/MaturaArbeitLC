using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showMass : MonoBehaviour
{
    displayProperty baseText;
    displayProperty newText;

    public Accelerator accel = null;

    Rigidbody2D rb;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        baseText = FindFirstObjectByType<displayProperty>();
        newText = Instantiate(baseText, baseText.transform.parent);
        if (accel == null){
            newText.ShowProperty(rb.mass,"kg");
        } else if (accel.force != 0){
            newText.ShowProperty(accel.force,"N");
        } else if (accel.acceleration != 0){
            newText.ShowProperty(accel.acceleration,"m/s²");
        } else if (accel.speed != 0){
            newText.ShowProperty(accel.speed, "m/s");
        }
        

    }

    private void Update()
    {
        // Update the position of the newText to follow the GameObject
        Vector3 worldPosition = transform.position; // Get the world position of the GameObject
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition); // Convert world position to screen position
        newText.transform.position = screenPosition; // Update the position of the newText in the UI

    }
}
