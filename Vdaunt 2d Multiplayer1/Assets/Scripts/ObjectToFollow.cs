using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ObjectToFollow : NetworkBehaviour {

	public Transform objectToFollow;
	
	public float speed = 2.0f;

		

	void Update ()
	{
		float interpolation = speed * Time.deltaTime;
		if (objectToFollow != null) {
			

			//the 5 and 3 below are just to get the right ratio; speed is changed in screen
			Vector3 position = this.transform.position;
			position.y = Mathf.Lerp (this.transform.position.y, objectToFollow.transform.position.y, 11 * interpolation);
			position.x = Mathf.Lerp (this.transform.position.x, objectToFollow.transform.position.x, 8 * interpolation);
		
			this.transform.position = position;
		}
	}

	public void setTarget(Transform target)
	{
		objectToFollow = target;
	}
}