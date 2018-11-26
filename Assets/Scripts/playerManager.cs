using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour {

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

	public void addPlayer()
	{
        player pl = new player();
        players.Add(pl);

        GameObject go = (GameObject)Instantiate(playerUIInstance, playerContentTransform.position, playerContentTransform.rotation);
        go.transform.SetParent(playerContentTransform);
        go.transform.localScale = Vector3.one;
        playerUIElement uiElement = go.GetComponent<playerUIElement>();
        uiElement.playerO = pl;
        uiElement.setText("Player " + players.Count);
        uiElement.initialize();
	}
}
