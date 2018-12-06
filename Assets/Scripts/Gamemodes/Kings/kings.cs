using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kings : MonoBehaviour {

	public kingsOutcome[] outcomes;
	public Text outcomeTitle;
	public Text outcomeText;
	public Image outcomeImage;

	public Jun_TweenRuntime runtime;


	//QUIZ
	[SerializeField] private fileManager theManager;
	[SerializeField] private Sprite quizSprite;
	bool quizAnswered = false;
	string quizAnswer = " ";

	private void Awake()
	{
		load();
	}


	public void load()
	{
		if (quizAnswered)
		{
			outcomeText.text = "Answer: " + quizAnswer + ".\n If you got it wrong, DRINK!";
			quizAnswered = false;
			return;
		}

		runtime.Play();
		int index = Random.Range(0, outcomes.Length + 1);
		if (index >= outcomes.Length)
		{
			quizAnswered = true;
			outcomeTitle.text = "Quiz!";
			string[] tx = theManager.getRandomLine().Split(';');
			quizAnswer = tx[1];
			outcomeText.text = tx[0];
			outcomeImage.sprite = quizSprite;
		}
		else {

			kingsOutcome outcome = outcomes[index];
			outcomeTitle.text = outcome.outcomeName;
			outcomeText.text = outcome.outcomeDescription;
			outcomeImage.sprite = outcome.outcomeImage;
		}

	}
}
