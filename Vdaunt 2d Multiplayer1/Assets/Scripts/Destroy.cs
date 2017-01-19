using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {


	public GameObject death;

	//int explode = Animator.StringToHash("Explosion");


	void OnTriggerEnter (Collider other)
	{
		GameObject deathClone = (GameObject) Instantiate(death, transform.position, transform.rotation);

	

			Destroy (transform.parent.gameObject);
			//make go faster when gets kill
			//other.AddForce (direction * forceAdded


			
	}
}