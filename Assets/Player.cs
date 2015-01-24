using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public float jumpSpeed = 5;
	public float moveSpeed = 5;

	public KeyCode jump = KeyCode.UpArrow;
	public KeyCode left = KeyCode.LeftArrow;
	public KeyCode right = KeyCode.RightArrow;
	public KeyCode grab = KeyCode.RightShift;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (jump) && IsGrounded ()) {
			rigidbody.AddForce(new Vector3(0,jumpSpeed,0));
		}
		if (Input.GetKeyDown (left)) {
			rigidbody.AddForce(new Vector3(-moveSpeed,0,0));
		}
		if (Input.GetKeyDown (right)) {
			rigidbody.AddForce(new Vector3(moveSpeed,0,0));
		}
		if (Input.GetKeyDown (grab)) {
			rigidbody.velocity.Set(0,0,0);
		}

		rigidbody.AddForce (new Vector3 (Input.GetAxis("Horizontal")*10, 0));
	}

	bool IsGrounded() {
		return Physics.CheckCapsule(collider.bounds.center,new Vector3(collider.bounds.center.x,collider.bounds.min.y-0.1f,collider.bounds.center.z),0.18f);
	}
}
