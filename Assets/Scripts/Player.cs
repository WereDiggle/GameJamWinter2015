using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	
	
	public double distToGround = 0.1;

	// Use this for initialization
	void Start () {
		
		distToGround = collider.bounds.extents.y;
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

	private bool onHandle = false;

	public bool isAtGoal = false;

	private float spawnPointTime;
	private Vector3 spawnPoint;
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.timeScale > 0) {
			if (Input.GetKeyDown(grab)) {
				rigidbody.isKinematic = true;
			}
			if (Input.GetKeyUp (grab)) {
				rigidbody.isKinematic = false;
			}
			if (Input.GetKey (jump) && IsGrounded() ) {
				rigidbody.AddForce(new Vector3(0,jumpSpeed,0));
			}
			if (Input.GetKey (left) && rigidbody.velocity.x > -maxSpeed) {
				rigidbody.AddForce(new Vector3(-moveSpeed,0,0));
			}
			if (Input.GetKey (right) && rigidbody.velocity.x < maxSpeed) {
				rigidbody.AddForce(new Vector3(moveSpeed,0,0));
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Death")) {
			Respawn ();		
		} else if (other.CompareTag ("CheckPoint")) {
			spawnPoint = other.transform.position;
			spawnPointTime = Time.time;
		} else if (other.CompareTag ("Goal")) {
			isAtGoal = true;
			if (partner.isAtGoal) {
					int i = Application.loadedLevel;
					Application.LoadLevel (i + 1);
			}
		} else if (other.CompareTag ("Handle")) {
			onHandle = true;		
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Goal")) {
			isAtGoal = false;
		} else if (other.CompareTag ("Handle")) {
			onHandle = false;
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
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit)) {
			var distanceToGround = hit.distance;
			if (distanceToGround < 1 && hit.transform.gameObject != partner.gameObject) {
				return true;
			}
		}
		return false;
	}


}
