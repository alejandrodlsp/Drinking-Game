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
        languageManager.instance.onLanguageChange = changeTitle;

		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
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

    public void changeTitle() {
        titleText.changeTitle(screens[currentScreen].gameMode, currentScreen, false);  // CHANGE TITLE
    }

	public void loadScreen(int index) {
        if (currentScreen == index && !first)
            return;

		if(menusAnimator == null)		// FETCH ANIMATOR
			menusAnimator = GetComponent<Animator>();

        if(!first)
        if (screens[index].gameMode.minPlayers > playerManager.instance.players.Count)
        {
            popup.instance.openPopup(languageManager.instance.Translations["notEnoughPlayers"], languageManager.instance.Translations["notEnoughPlayers1"] + screens[index].gameMode.minPlayers + languageManager.instance.Translations["notEnoughPlayers2"]);
            return;
        }

		currentScreen = index;  // SET CURRENT INDEX OF SCREEN

		mainMenuAnimator.SetBool("loaded", (currentScreen == 0));	// Set animator bools
		menusAnimator.SetBool("loaded", (currentScreen != 0));

		StartCoroutine(disableScreens());       // DISABLE ALL ACTIVE SCREENS
		screens[currentScreen].enableScreen();  // ENABLE CURRENT SCREEN

        if (!first)
        {       // IF NOT THE FIRST LOAD SCREEN, THEN 
            titleText.changeTitle(screens[currentScreen].gameMode, currentScreen, true);  // CHANGE TITLE
            first = false;
        }
        else {
            titleText.changeTitle(screens[currentScreen].gameMode, currentScreen, false);
        }
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
