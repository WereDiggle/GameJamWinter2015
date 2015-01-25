using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckPoint : MonoBehaviour {

	public List<GameObject> objectsToReset;

	private List<Vector3> locations;

	// Use this for initialization
	void Start () {
		foreach (GameObject resetObject in objectsToReset) {
			locations.Add(resetObject.transform.position);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player")) {
			//sets player spawn points
			Player p = other.gameObject.GetComponent<Player>();
			p.spawnPoint = p.transform.position;
			p.spawnPointTime = Time.timeSinceLevelLoad;

			//puts objects back in place
			int i=0;
			foreach (GameObject resetObject in objectsToReset) {
				resetObject.transform.position = locations[i];
				i++;
			}

		}
	}
}


