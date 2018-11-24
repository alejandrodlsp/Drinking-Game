using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnManager : MonoBehaviour {

	public static turnManager instance;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
			Destroy(this);
	}


	public player[] players;
	public int currentPlayerIndex;

	public void nextTurn() {
		currentPlayerIndex++;
		if(currentPlayerIndex > players.Length)
		{
			currentPlayerIndex = 0;
		}
	}

	public player getCurrentPlayer() {
		return players[currentPlayerIndex];
	}

}
