using UnityEngine;
using System.Collections;

public class follower : MonoBehaviour {
	public GameObject otherkoala;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 diff = transform.position - otherkoala.transform.position;

		diff.Normalize();

		rigidbody2D.velocity = diff*-3;
	}
}
