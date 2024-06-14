using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragnDrop : MonoBehaviour{
	
	Rigidbody2D rb;

	GameObject modified;

	public Accelerator acc;

	public bool onBlock = false;
	public bool isReady = true;

	public bool dragging = false;
	private float distance;

	private void Start(){
		rb = GetComponent<Rigidbody2D>();
	}

	void OnMouseDown(){
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}

	void OnMouseUp(){
		rb.velocity = new Vector3(0,0,0);
		dragging = false;
		if(onBlock == true)
        {
			if(modified != null) // if the accelerator is on a modifiable object when releasing the mouse button, it will become the child of said object
            {
				isReady = true;
				gameObject.transform.parent = modified.transform;
				Rigidbody2D rbModified = modified.GetComponentInParent<Rigidbody2D>();
				acc.rbParent = rbModified;
			}
        }
	}

	void Update(){
		if (dragging){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{


		if (other.tag == "Modifiable")
		{
			onBlock = true;
			modified = other.gameObject;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{

		if (other.tag == "Modifiable")
		{
			onBlock = false;
			isReady = false;
            if (dragging) // to make sure that the accelerator was removed by the player. (and not the faulty collision system)
            {
				modified = null;
				transform.parent = null;
				acc.rbParent = null;
			}
		}
	}
}
