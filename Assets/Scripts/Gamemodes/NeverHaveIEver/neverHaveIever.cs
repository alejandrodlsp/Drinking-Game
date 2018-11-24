using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class neverHaveIever : MonoBehaviour {

	public fileManager mildFileManager;
	public fileManager spicyFileManager;

	public Jun_TweenRuntime runtime;

	public Text questName;

	private void Awake()
	{
		loadMildQuestion();
	}

	public void loadMildQuestion() {
		runtime.Play();
		string question = mildFileManager.getRandomLine();
		questName.text = question;
	}

	public void loadHardQuestion() {
		runtime.Play(); 
		string question = spicyFileManager.getRandomLine();
		questName.text = question;
	}
}
