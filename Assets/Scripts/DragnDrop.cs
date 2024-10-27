using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragnDrop : MonoBehaviour{
	
	Rigidbody2D rb;

	public Collider2D dragCol;

	GameObject modified;

	public GameObject snapPointer;

	public GameObject inputPoint;

	public Accelerator acc = null;


	public bool onBlock = false;
	public bool isReady = true;
	public float rotateSpeed = 1;

	public bool dragging = false;
	public bool rotating = false;

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

	void OnMouseOver () {
		if(Input.GetMouseButtonDown(1))
		{
			if(ms.started == false)
            {
				if (rotating == true)
				{
					ms.RotationInput.SetActive(false);
					DragnDrop[] mods = FindObjectsOfType(typeof(DragnDrop)) as DragnDrop[];
					foreach (DragnDrop item in mods)
					{
						item.rotating = false;
					}
					//rotating = false;
				}
				else
				{
					DragnDrop[] mods = FindObjectsOfType(typeof(DragnDrop)) as DragnDrop[];
					foreach (DragnDrop item in mods)
					{
						item.rotating = false;
					}
					rotating = true;
					ms.mainRotation = transform.localEulerAngles.z + 90;
					if (ms.mainRotation >= 360)
					{
						ms.mainRotation -= 360;
					}
					ms.ShowRotation();
					ms.RotationInput.SetActive(true);
				}
			}
		}
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
			}
        }
	}

	void Update(){
		if(ms.started == false)
        {
			
			
			//if(rotating){
				//Vector3 mousePos = Input.mousePosition;
				//mousePos.z = 5.23f;

				//Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
				//mousePos.x = mousePos.x - objectPos.x;
				//mousePos.y = mousePos.y - objectPos.y;

				//float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
				//transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); //I made a mistake when creating the prefab so now I have to subtract 90°
				//if(Input.GetMouseButtonUp(1))
					//{
						//rotating = false;
					//}
			//}

			if(rotating == true)
            {
				
				if (inputPoint == null)
				{
					Vector3 worldPosition = transform.position; // Get the world position of the GameObject
					Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition); // Convert world position to screen position
					ms.RotationInput.transform.position = screenPosition; // Update the position of the newText in the UI
					print("inputpoint is zero");
				}
				else
				{
					Vector3 worldPosition = inputPoint.transform.position; // Get the world position of the inputPoint
					Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition); // Convert world position to screen position
					ms.RotationInput.transform.position = screenPosition; // Update the position of the newText in the UI
					ms.mainRotation = transform.localEulerAngles.z + 90;
					if (ms.mainRotation >= 360)
					{
						ms.mainRotation -= 360;
					}
					ms.ShowRotation();
				}
			}

			if (dragging)
			{

				 

				transform.Rotate(Vector3.forward * rotateSpeed * Time.fixedDeltaTime * Input.mouseScrollDelta.y);

				if (Input.GetKey("a"))
				{
					transform.Rotate(Vector3.forward * rotateSpeed* 0.5f * Time.fixedDeltaTime );
				}
                if (Input.GetKey("d"))
                {
					transform.Rotate(Vector3.forward * rotateSpeed * 0.5f * Time.fixedDeltaTime * -1);
				}

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
	public void Rotate(float rotation)
	{
		if (rotating == true){
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation - 90)); //I made a mistake when creating the prefab so now I have to subtract 90°
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
