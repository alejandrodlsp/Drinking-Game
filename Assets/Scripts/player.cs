using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class player {

    public playerManager.sexes sex;
    public playerManager.sexes preference;

    public int skipped = 0;
    public int completed = 0;

    public int playerId = 0;
    private static int currentGlobalId = 0;

    public string playerName = "Player";

    public player() {
        playerId += currentGlobalId;
        currentGlobalId++;

        playerName = "Player";
        preference = playerManager.sexes.female;
        sex = playerManager.sexes.male;
    }

	public void setName(string _name) {
		if (_name == null || playerName == "")
			return;

		playerName = _name;
	}
}
