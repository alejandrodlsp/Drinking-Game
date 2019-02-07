using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "gamemode")]
public class gamemode :  ScriptableObject{

    public string[] gameName;
	public string[] description;
	public int maxPlayers;
	public int minPlayers;

}
