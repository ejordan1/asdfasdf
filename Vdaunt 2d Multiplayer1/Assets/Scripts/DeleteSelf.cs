using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSelf : MonoBehaviour {

	public float lifetime = 3f;

	// Use this for initialization
	void Start () {


		Destroy (gameObject, lifetime);

	}


}
