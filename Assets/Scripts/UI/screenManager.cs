using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class screenManager : MonoBehaviour {

	#region Singleton
	public static screenManager instance;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
			Destroy(this);
		loadScreen(0);
		first = false;
		menusAnimator = GetComponent<Animator>();
	}
	#endregion

	public Animator mainMenuAnimator;
	private Animator menusAnimator;

	public screenMenu[] screens;
	public titleText titleText;

	int currentScreen = 0;
	private bool first = true;

	public void loadScreen(int index) {
		if(menusAnimator == null)		// FETCH ANIMATOR
			menusAnimator = GetComponent<Animator>();

		currentScreen = index;  // SET CURRENT INDEX OF SCREEN

		mainMenuAnimator.SetBool("loaded", (currentScreen == 0));	// Set animator bools
		menusAnimator.SetBool("loaded", (currentScreen != 0));

		StartCoroutine(disableScreens());       // DISABLE ALL ACTIVE SCREENS
		screens[currentScreen].enableScreen();	// ENABLE CURRENT SCREEN
			
		if (!first)		// IF NOT THE FIRST LOAD SCREEN, THEN 
			titleText.changeTitle(screens[currentScreen].gameMode, currentScreen);	// CHANGE TITLE
	}

	IEnumerator disableScreens() {
		yield return new WaitForSeconds(1.5f);
		for (int i = 1; i < screens.Length; i++) {
			if (i != currentScreen && screens[i].active) {
					screens[i].disableScreen();
			}
		}
	}
}
