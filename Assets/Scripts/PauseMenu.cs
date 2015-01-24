using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {


	public KeyCode pause = KeyCode.Escape;
	public MeshRenderer foreground;

	private bool isPause = false;


	// Use this for initialization
	void Start () {
		foreground.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (pause)) {
			isPause = !isPause;

			if (isPause) {
				Time.timeScale = 0.00001f;
				foreground.enabled = true;
			} else {
				Time.timeScale = 1;
				foreground.enabled = false;
			}
		}
	}
}
