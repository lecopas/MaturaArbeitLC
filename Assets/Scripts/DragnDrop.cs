using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragnDrop : MonoBehaviour{
	
	Rigidbody2D rb;

	public Collider2D dragCol;

	GameObject modified;

	public Accelerator acc;

	public bool onBlock = false;
	public bool isReady = true;
	public float speed = 1;

	public bool dragging = false;
	private float distance;

	public ContactFilter2D movementFilter;

	List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

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
				acc.tempCollider.enabled = false;
			}
        }
	}

	void Update(){
		if (dragging){
			gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			dragCol.enabled = false;
			acc.tempCollider.enabled = true;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
			Vector3 direction = (rayPoint - transform.position).normalized;
			TryMoveSimple(direction);
			
		}
        else
        {
			gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
			dragCol.enabled = true;
			acc.tempCollider.enabled = false;
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

	private bool TryMove(Vector2 direction)
	{
		if (direction != Vector2.zero)
		{
			int count = rb.Cast(
				direction,
				movementFilter,
				castCollisions,
				speed * Time.fixedDeltaTime);

			if (count == 0)
			{
				rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
				return true;
			}
			else
			{
				rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

				return false;
			}
		}
		else
		{
			return false;
		}
	}

	private void TryMoveSimple(Vector2 direction)
    {
		rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
	}

	//bool success = TryMove(direction);
	//         if (!success)
	//         {
	//	success = TryMove(new Vector2(direction.x, 0));
	//         }

	//         if (!success)
	//         {
	//	TryMove(new Vector2(0, direction.y));
	//         }
	//transform.position = Vector3.MoveTowards(transform.position, rayPoint, speed * Time.deltaTime);
	//transform.position = rayPoint;
}
