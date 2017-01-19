using UnityEngine;
using System.Collections;

public class AddForce : MonoBehaviour {

	public Rigidbody VTest;
	public float force = 1.5f;
	private Vector3 target;

	void Start () {
		target = transform.position;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;
		}
		Vector3 direction = -(VTest.transform.position - target.normalized);
		VTest.MovePosition(transform.position + direction * force * Time.deltaTime);


	}    
}