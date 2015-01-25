using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public float fov = 90.0f;
	public Player playerOne;
	public GUISkin myskin;
	public KeyCode pauseButton = KeyCode.Escape;
	public MeshRenderer foreground;


	private Rect windowRect;
	private bool paused = false , waited = true;
	private int menuID;
	
	private void Start() {
		foreground.enabled = false;
		windowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200);
	}
	
	private void waiting() {
		waited = true;
	}
	
	private void Update() {
		if (waited)
			if (Input.GetKeyDown(pauseButton))
		{
			paused = !paused;

			if (paused) {
				pause();
			} else {
				unPause();
			}
			
			waited = false;
			Invoke("waiting",0.01f);
		}
	}

	private void pause() {
		foreground.enabled = true;
		Time.timeScale = 0.0001f;
	}

	private void unPause() {
		foreground.enabled = false;
		Time.timeScale = 1;
	}

	private void OnGUI() {
		if (paused) {
			if (menuID==0) windowRect = GUI.Window (menuID, windowRect, pauseWindow, "Pause Menu");
			if (menuID==1) windowRect = GUI.Window (menuID, windowRect, optionWindow, "Option Menu");
		}
	}
	
	private void pauseWindow(int id) {

		if (GUILayout.Button("Resume") || Input.GetKeyDown(pauseButton))
		{
			paused = false;
			menuID = 0;
			unPause();

		}
		if (GUILayout.Button("Options"))
		{
			menuID = 1;
		}
		if (GUILayout.Button("Reset"))
		{
			paused = false;
			menuID = 0;
			unPause();
			playerOne.Respawn();

		}

	}

	private void optionWindow(int id) {
		GUILayout.Label ("FOV Slider");
		fov = GUILayout.HorizontalSlider (fov, 30.0f, 160.0f);
		if (GUILayout.Button("Back") || Input.GetKeyDown(pauseButton))
		{
			menuID = 0;
			
		}

	}
	
	/*
	public GUISkin myskin;
	public KeyCode pause = KeyCode.Escape;
	public MeshRenderer foreground;

	private Rect windowRect;
	private bool isPause = false, waited = true;

	// Use this for initialization
	void Start () {
		foreground.enabled = false;
		windowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200);
	}

	void waiting()
	{
		waited = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (waited) {
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

	void OnGui() {
		if (isPause)
			windowRect = GUI.Window(0, windowRect, windowFunc, "Pause Menu");
	}

	private void windowFunc(int id)
	{
		if (GUILayout.Button("Resume"))
		{
			isPause = false;
		}
		if (GUILayout.Button("Options"))
		{
			
		}
		if (GUILayout.Button("Quit"))
		{
			
		}
	}*/

}
