using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragnDrop : MonoBehaviour{
	
	Rigidbody2D rb;

	public Collider2D dragCol;

	GameObject modified;

	public GameObject snapPointer;

	public Accelerator acc = null;


	public bool onBlock = false;
	public bool isReady = true;
	public float rotateSpeed = 1;

	public bool dragging = false;
	private float distance;
	mainScript ms;


	public ContactFilter2D movementFilter;

	List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();


	private void Start(){
		rb = GetComponent<Rigidbody2D>();
		ms = FindFirstObjectByType<mainScript>();
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
				if (snapPointer != null && gameObject != null)
				{
					Vector3 selfPosition = gameObject.transform.position;
					selfPosition.x = snapPointer.transform.position.x;
					gameObject.transform.position = selfPosition;
				}
				else
				{
					Debug.LogError("snapPointer or gameObject is null");
					print(snapPointer);
				}
				
			}
        }
	}

	void Update(){
		if(ms.started == false)
        {
			if (dragging)
			{

				//Rotation Code

				transform.Rotate(Vector3.forward * rotateSpeed * Time.fixedDeltaTime * Input.mouseScrollDelta.y);

				//Movement Code

				dragCol.enabled = false;
				acc.tempCollider.enabled = true;
				gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				Vector3 rayPoint = ray.GetPoint(distance);

				rb.MovePosition(rayPoint);
			}
			else
			{
				gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
				dragCol.enabled = true;
				acc.tempCollider.enabled = false;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Modifiable")
		{
			onBlock = true;
			modified = other.gameObject;
		}
		if (other.tag == "Snap"){
			snapPointer = other.gameObject;
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
		if (other.tag == "Snap"){
			if (dragging){
				snapPointer = null;
			}
			
		}
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



	//Vector3 direction = (rayPoint - transform.position).normalized;
			//TryMoveSimple(direction);

			//Vector3 movePosition = transform.position;
 
			//movePosition.x = Mathf.MoveTowards(transform.position.x, rayPoint.x, speed * Time.deltaTime);
			//movePosition.y = Mathf.MoveTowards(transform.position.y, rayPoint.y, speed * Time.deltaTime);
 
			//rb.MovePosition(movePosition);
}
