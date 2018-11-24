using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

	Jun_TweenRuntime tu;
	public Text nameText;
	string playerName = "Player";

	public enum gender { male, female, both };

	public gender playerGender;
	public gender playerInterest;

	private void Awake()
	{
		nameText.text = playerName;
	}

	public void setName(string _name) {
		if (_name == null || playerName == "")
			return;

		playerName = _name;
		nameText.text = playerName;
	}
}
