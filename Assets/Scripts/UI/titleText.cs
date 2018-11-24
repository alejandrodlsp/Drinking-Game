using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titleText : MonoBehaviour {

	public Text title;
	public Text subtitle;
	public Animator theAnim;
	int screenIndex = 0;

	gamemode gm;

	private void Start()
	{
		theAnim = GetComponent<Animator>();
	}

	public void changeTitle(gamemode _gm, int _index) {
		gm = _gm;
		screenIndex = _index;
		StartCoroutine(change());
	}

	IEnumerator change() {
		if(screenIndex == 0)
			theAnim.SetBool("menu", true);
		else
			theAnim.SetBool("menu", false);

		theAnim.SetTrigger("load");
		yield return new WaitForSeconds(0.12f);

		title.text = gm.gameName;
		subtitle.text = gm.description;
	}
}
