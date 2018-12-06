using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour {

    private int currentPlayerIndex = 0;
    public player currentPlayer;

    public enum sexes { male, female, both };

    public static playerManager instance;
	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
			Destroy(this.gameObject);
	}

    public GameObject playerUIInstance;
    public Transform playerContentTransform;

	public List<player> players;

    public void nextPlayer() {
        currentPlayerIndex++;

        if (currentPlayerIndex >= players.Count)
            currentPlayerIndex = 0;

        currentPlayer = players[currentPlayerIndex];
    }

	public void addPlayer()
	{
        player pl = new player();

        if (players.Count == 0)
        {
            Debug.Log(1);
            players.Add(pl);
            currentPlayer = players[0];
        }else
            players.Add(pl);


        GameObject go = (GameObject)Instantiate(playerUIInstance, playerContentTransform.position, playerContentTransform.rotation);
        go.transform.SetParent(playerContentTransform);
        go.transform.localScale = Vector3.one;
        playerUIElement uiElement = go.GetComponent<playerUIElement>();
        uiElement.playerO = pl;
        uiElement.setText("Player " + players.Count);
        uiElement.initialize();
	}


    public string getRandomPlayer(sexes sex)
    {
        if (players.Count == 0 || players.Count == 1)
            return "*PLAYER*";

        List<player> concPlayers = new List<player>();  // SEARCH FOR MATCHING PARAMS PLAYERS
        foreach (player pl in players)
        {
            if (pl.sex == sex)
            {
                concPlayers.Add(pl);
            }
        }

        while (true)
        {
            // GET A RANDOM PLAYER THAT IS NOT THE CURRENT PLAYER
            if (sex == sexes.both || concPlayers.Count == 0 || (concPlayers.Count == 1 && concPlayers.Contains(currentPlayer)))
            {
                player pn = players[Random.Range(0, players.Count)];
                if (pn.playerId == currentPlayer.playerId)
                {
                    continue;
                }
                else
                    return pn.playerName;
            }


            // GET A MATCHING PLAYER THAT IS NOT THE CURRENT PLAYER
            player ps = concPlayers[Random.Range(0, concPlayers.Count)];
            if (ps.playerId == currentPlayer.playerId)
                continue;
            else
                return ps.playerName;
        }
    }
}
