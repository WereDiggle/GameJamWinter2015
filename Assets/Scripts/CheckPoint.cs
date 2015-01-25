using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckPoint : MonoBehaviour {

	public List<GameObject> objectsToReset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player")) {
			Player p = other.gameObject.GetComponent<Player>();
			p.spawnPoint = p.transform.position;
			p.spawnPointTime = Time.timeSinceLevelLoad;
		}
	}
}


