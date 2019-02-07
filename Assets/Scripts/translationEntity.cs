using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class translationEntity : MonoBehaviour {

    Text text;

    public string translationKey;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        languageManager.instance.onLanguageChange += updateValue;
        updateValue();
    }

    void updateValue() {
        text.text = languageManager.instance.Translations[translationKey];
    }


}
