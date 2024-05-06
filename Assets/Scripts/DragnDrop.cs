using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragnDrop : MonoBehaviour{
	
	Rigidbody2D rb;

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
	}

	void Update(){
		if (dragging){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
		}
	}
}
