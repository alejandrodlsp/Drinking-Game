using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mostLikelyTo : MonoBehaviour {

	public fileManager fileMan;

	public Jun_TweenRuntime runtime;

	public Text questName;

	private void Awake()
	{
		load();
	}

	public void load() {
		runtime.Play();
		string question = fileMan.getRandomLine();
		questName.text = question;
	}

}
