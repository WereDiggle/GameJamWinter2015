using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		rigidbody.AddForce (new Vector3 (Input.GetAxis("Horizontal")*10, 0));
		
		transform.eulerAngles = new Vector3(0,0,transform.eulerAngles.z);
		transform.position = new Vector3(transform.position.x,transform.position.y,0);
	}
}
