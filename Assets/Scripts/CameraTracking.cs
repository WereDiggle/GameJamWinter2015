using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraTracking : MonoBehaviour {
	// the list of objects to track
	public List<GameObject> anchors;


	// for controlling the camera settings
	public float fov = 90;
	public float mindist = 15;
	public float maxdist = 40;

	// the camera itself
	public Camera cam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// this vector will be used to update our position
		Vector2 goalPos = new Vector2(0,0);

		foreach(GameObject anchor in anchors){
			goalPos.x += anchor.transform.position.x;
			goalPos.y += anchor.transform.position.y;
		}

		// find the average point
		goalPos.x = goalPos.x / anchors.Count;
		goalPos.y = goalPos.y / anchors.Count;

		// find the distance between this new point and our current point
		Vector2 newPos = Vector2.Lerp(transform.position, goalPos, 0.05f);

		transform.position = newPos;

		Vector3 maxDist = transform.position;
		// set the camera distance to keep everything on screen
		foreach(GameObject anchor in anchors){
			if(Vector3.Distance(transform.position, anchor.transform.position) > Vector3.Distance(transform.position, maxDist)) {
				maxDist = anchor.transform.position;
			}
		}

		float opp = Vector2.Distance(maxDist, transform.position);
		//print ("opp = " + opp);

		// new target camera distance
              		// geometry!

		float newZ = 1f * Mathf.Tan(Mathf.Deg2Rad*fov) * opp * 2; 
		//print ("newZ = " + newZ);
		if(newZ > maxdist) {
			newZ = maxdist;
			//print ("too far!");

		}

		if(newZ < mindist) {
			newZ = mindist;
			//print ("too close!");
		}

		//print ("newZ = " + newZ);
		newZ = Mathf.Lerp(cam.transform.position.z, -1f * newZ, .1f);
		cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, newZ);

	}

	public void AddAnchor(GameObject a) {
		anchors.Add(a);

	}

	public void RemoveAnchor(GameObject a) {
		anchors.Remove(a);
		
	}
}
