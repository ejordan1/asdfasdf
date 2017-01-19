using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TapToMove : NetworkBehaviour {
	//flag to check if the user has tapped / clicked. 
	//Set to true on click. Reset to false on reaching destination
	private bool flag = false;
	//destination point
	private Vector3 target;
	//vertical position of the gameobject
	private float yAxis;
	private bool rotateToTarget = false;
	private bool travelToTarget = false;
	public float forceAdded = 1000f;
	public Rigidbody rb;
	Vector3 mousePositionInWorld;
	float angle ;
	float startRotationOffset = 90;  //This is angle offset at starting.

	void Start(){
		rb = GetComponent<Rigidbody>();
		//save the y axis value of gameobject
		yAxis = gameObject.transform.position.y;
	}

	public override void OnStartLocalPlayer()
	{
		Camera.main.GetComponent<ObjectToFollow> ().setTarget (gameObject.transform);
	}

	// Update is called once per frame
	void Update () {

		if (!isLocalPlayer)
		{ 
			return;
		}

		if (Input.GetMouseButtonDown (0)) {
			var mouseClick = Input.mousePosition;
			mouseClick.z = gameObject.transform.position.z - Camera.main.transform.position.z;
			target = Camera.main.ScreenToWorldPoint (mouseClick);
			rotateToTarget = false;
			travelToTarget = true;
			print ("NEW TARGET: " + target);
			Debug.DrawLine (Camera.main.transform.position, target, Color.red, 10f);
		

		//if (rotateToTarget == false && travelToTarget == true) {
		//^was in original code to make the application of force steady over each frame.
		//I took it out so there is only one application of force on the click.
			var distanceToTarget = Vector3.Distance (gameObject.transform.position, target);


			//this resets the objects force to 0 before applying new force.
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero; 


			if (distanceToTarget > 1.5) {
				//movement
				print ("Distance: " + distanceToTarget);
				target.z = 0;
				Vector3 direction = (target - gameObject.transform.position).normalized;
				rb.AddForce (direction * forceAdded);

				//rotation

				//rb.AddTorque (transform. * torque * turn); TEST 

				mousePositionInWorld = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				angle = ( Mathf.Atan2 (mousePositionInWorld.y - transform.position.y, mousePositionInWorld.x - transform.position.x) * Mathf.Rad2Deg);

				transform.eulerAngles = new Vector3(0,0 ,startRotationOffset + angle);









				//rb.AddTorque (transform. * torque * turn); TEST 

			} else {

				travelToTarget = false;
				print ("travelling COMPLETE");
			}            
		}
	}
}
