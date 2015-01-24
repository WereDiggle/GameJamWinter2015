using UnityEngine;
using System.Collections;

public class RemoveAnchor : MonoBehaviour {

	public GameObject cameraStuff;
	public GameObject anchor;

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other) {
		//print ("Collided with " + other.name);
		if(other.name == "Player") {
			CameraTracking c = cameraStuff.GetComponent<CameraTracking>();
			c.RemoveAnchor(anchor);
		}
	}
}
