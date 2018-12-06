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
        if (currentScreen == index && !first)
            return;

		if(menusAnimator == null)		// FETCH ANIMATOR
			menusAnimator = GetComponent<Animator>();

        if(!first)
        if (screens[index].gameMode.minPlayers > playerManager.instance.players.Count)
        {
            popup.instance.openPopup("Not enough players", "You need at least " + screens[index].gameMode.minPlayers + " players to play");
            return;
        }

		currentScreen = index;  // SET CURRENT INDEX OF SCREEN

		mainMenuAnimator.SetBool("loaded", (currentScreen == 0));	// Set animator bools
		menusAnimator.SetBool("loaded", (currentScreen != 0));

		StartCoroutine(disableScreens());       // DISABLE ALL ACTIVE SCREENS
		screens[currentScreen].enableScreen();  // ENABLE CURRENT SCREEN

        if (!first)
        {       // IF NOT THE FIRST LOAD SCREEN, THEN 
            titleText.changeTitle(screens[currentScreen].gameMode, currentScreen);  // CHANGE TITLE
            first = false;
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

    public void aboutPopup() {
        popup.instance.openPopup("ABOUT", "Party Games, by Alejandro de los Santos. \nalejandropsld@gmail.com\n@alejandrodlsp\n\nAssets from game-icons.net");
    }
}
