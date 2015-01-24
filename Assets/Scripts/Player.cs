using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public Collider ropeAttach;
	public InteractiveCloth rope;
	public InteractiveCloth currentRope;
	public Player partner;
	public float jumpSpeed = 5;
	public float moveSpeed = 5;
	public float maxSpeed = 10;

	public KeyCode jump = KeyCode.UpArrow;
	public KeyCode left = KeyCode.LeftArrow;
	public KeyCode right = KeyCode.RightArrow;
	public KeyCode grab = KeyCode.RightShift;

	private bool isGrounded;

	private float spawnPointTime;
	private Vector3 spawnPoint;
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (jump) && isGrounded ) {
			rigidbody.AddForce(new Vector3(0,jumpSpeed,0));
		}
		if (Input.GetKey (left) && rigidbody.velocity.x > -maxSpeed) {
			rigidbody.AddForce(new Vector3(-moveSpeed,0,0));
		}
		if (Input.GetKey (right) && rigidbody.velocity.x < maxSpeed) {
			rigidbody.AddForce(new Vector3(moveSpeed,0,0));
		}
		if (Input.GetKeyDown(grab)) {
			rigidbody.isKinematic = true;
		}
		if (Input.GetKeyUp (grab)) {
			rigidbody.isKinematic = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Death")) {
			Respawn();		
		} else if (other.CompareTag ("CheckPoint")) {
			spawnPoint = other.transform.position;
			spawnPointTime = Time.time;
		}
	}

	void Respawn() {
		Vector3 currentSpawnPoint;
		if (partner.spawnPointTime > spawnPointTime) {
			currentSpawnPoint = spawnPoint;
		} else {
			currentSpawnPoint = partner.spawnPoint;
		}

		Destroy (currentRope.gameObject);

		//move player to last checkpoint
		transform.position = currentSpawnPoint + Vector3.right;
		rigidbody.velocity = Vector3.zero;
		//move partner to last checkpoint
		partner.transform.position = currentSpawnPoint + Vector3.left;
		partner.rigidbody.velocity = Vector3.zero;


		//make and attach new rope
		currentRope = Instantiate (rope, currentSpawnPoint, Quaternion.identity) as InteractiveCloth;
		partner.currentRope = currentRope;

		currentRope.AttachToCollider (ropeAttach, false, true);
		currentRope.AttachToCollider (partner.ropeAttach, false, true);
	}

	bool IsGrounded() {
		return Physics.CheckCapsule(collider.bounds.center,new Vector3(collider.bounds.center.x,collider.bounds.min.y-0.1f,collider.bounds.center.z),0.18f);
	}

	//make sure u replace "floor" with your gameobject name.on which player is standing
	void OnCollisionEnter(Collision theCollision){
		if(theCollision.gameObject.tag == "Ground")
		{
			isGrounded = true;
		}
	}

	void OnCollisionExit(Collision theCollision){
		if(theCollision.gameObject.tag == "Ground")
		{
			isGrounded = false;
		}
	}

}
