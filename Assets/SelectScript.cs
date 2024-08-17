using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScript : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    countdown cd;
    public objectProperties choice;
    Vector3 copyPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = FindFirstObjectByType<countdown>();
        sr = GetComponent<SpriteRenderer>();
        //copy = GameObject.FindGameObjectWithTag("choiceCopy");
    }

    void OnMouseDown()
    {
        cd.selectedObject = gameObject;
        choice.sr.sprite = sr.sprite;
        //choice = Instantiate<GameObject>(gameObject, choice.transform.position, choice.transform.rotation);
    }
}
