using UnityEngine;
using System.Collections;

public class ballSpawner : MonoBehaviour {

	public Transform ball;
	public float spawnRate;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnBall", 0, spawnRate);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void spawnBall() {
		Instantiate (ball, transform.position, Quaternion.identity);
	}
}
