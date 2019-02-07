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
 
	private void Awake()
	{
		theAnim = GetComponent<Animator>();
	}

	public void changeTitle(gamemode _gm, int _index, bool animate) {
		gm = _gm;
		screenIndex = _index;
		StartCoroutine(change(animate));
	}

    IEnumerator change(bool animate) {
        if (animate) { 
            if (screenIndex == 0)
                theAnim.SetBool("menu", true);
            else
                theAnim.SetBool("menu", false);

        theAnim.SetTrigger("load");
        yield return new WaitForSeconds(0.12f);
        }

		title.text = gm.gameName[languageManager.instance.language];
		subtitle.text = gm.description[languageManager.instance.language];
	}
}
