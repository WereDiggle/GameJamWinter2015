using UnityEngine;
using System.Collections;

public class Fixed2D : MonoBehaviour {

	// Use this for initialization
	void Start () { 
		if (gameObject.GetComponent("Rigidbody") != null)
			rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;
	}
	
	// Update is called once per frame
	void Update () {
		/*transform.eulerAngles = new Vector3(0,0,transform.eulerAngles.z);
		transform.position = new Vector3(transform.position.x,transform.position.y,0);*/
	}
}
