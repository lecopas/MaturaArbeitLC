using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showMass : MonoBehaviour
{
    displayProperty baseText;
    displayProperty newText;

    Rigidbody2D rb;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        baseText = FindFirstObjectByType<displayProperty>();
        newText = Instantiate(baseText, baseText.transform.parent);
        newText.ShowProperty(rb.mass,"kg");

    }

    private void Update()
    {
        // Update the position of the newText to follow the GameObject
        Vector3 worldPosition = transform.position; // Get the world position of the GameObject
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition); // Convert world position to screen position
        newText.transform.position = screenPosition; // Update the position of the newText in the UI

    }
}
