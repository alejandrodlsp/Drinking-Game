using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class languageManager : MonoBehaviour {


    public static languageManager instance;

    public int language = 0;

    public delegate void OnLanguageChange();
    public OnLanguageChange onLanguageChange;

    public Dropdown dp;

    public Dictionary<string, string> Translations { get; private set; }

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);


        onLanguageChange += languageChanged;

        if (PlayerPrefs.HasKey("language"))
        {
            language = PlayerPrefs.GetInt("language");
        }
        LoadLanguage();
    }

    private void Start()
    {
        setLanguage(0);
    }

    public void setLanguage(int e) {
        language = e;
        LoadLanguage();
        PlayerPrefs.SetInt("language", e);
        onLanguageChange();
    }

    private void LoadLanguage()
    {   
        if (Translations == null)
            Translations = new Dictionary<string, string>();

        Translations.Clear();
        string lang = getIsoLanguageCode();
        var textAsset = Resources.Load(lang + @"/translations"); //no .txt needed

        string allTexts = "";

        if (textAsset == null)
            textAsset = Resources.Load(@"en/translations") as TextAsset; //no .txt needed

        if (textAsset == null)
            Debug.LogError("File not found");

        allTexts = (textAsset as TextAsset).text;
        string[] lines = allTexts.Split(new string[] { "\r\n", "\n" }, 0);

        string key, value;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].IndexOf("=") >= 0 && !lines[i].StartsWith("#"))
            {
                key = lines[i].Substring(0, lines[i].IndexOf("="));
                value = lines[i].Substring(lines[i].IndexOf("=") + 1,
                        lines[i].Length - lines[i].IndexOf("=") - 1).Replace("\\n", Environment.NewLine);
                Translations.Add(key, value);
            }
        }
    }

    public string getIsoLanguageCode()
    {
        switch (language)
        {
            case 0:
                return "en";
            case 1:
                return "es";
            default:
                return "en";
        }
    }
    public void languageChanged() { }

    public void languageFieldUpdate() {
        if(dp!=null)
        {
            int val = dp.value;
            setLanguage(val);

        }
    }
}
