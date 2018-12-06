using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup : MonoBehaviour {

    [HideInInspector]
    public static popup instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public Text uiTitle;
    public Text uiContent;
    public Jun_TweenRuntime runtime; 

    public GameObject contentBox;

    public void openPopup(string title, string content) {
        contentBox.transform.localScale = Vector3.zero;
        runtime.Play();
        uiTitle.text = title;
        uiContent.text = content;
        contentBox.SetActive(true);
    }
}
