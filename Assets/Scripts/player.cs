using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class player : MonoBehaviour {

    public playerManager.sexes sex;
    public playerManager.sexes preference;

    public string playerName = "Player";

    public player() {
        sex = playerManager.sexes.male;
        preference = playerManager.sexes.female;
    }

	public void setName(string _name) {
		if (_name == null || playerName == "")
			return;

		playerName = _name;
	}
}
