using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenMenu : MonoBehaviour {

	public GameObject screen;

	public gamemode gameMode;

	[HideInInspector] public bool active = false;

	public void enableScreen() {
		active = true;
		screen.SetActive(true);
	}

	public void disableScreen() {
		active = false;
		screen.SetActive(false);
	}

}
