using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fileManager : MonoBehaviour {

	public string[] filenames;
	string textContent;

	private string[] values;
	private List<int> usedIndices = new List<int>();

	public void Start()
	{
		readFile();
        languageManager.instance.onLanguageChange += readFile;
	}

	public void readFile() {
		usedIndices.Clear();

		TextAsset txtAssets = (TextAsset)Resources.Load(filenames[languageManager.instance.language], typeof(TextAsset));
		textContent = txtAssets.text;
		values = textContent.Split('\n');
	}

	public string getRandomLine() {
        if (values == null)
            readFile();

		int index = -1;
		do
		{
			if (usedIndices.Count >= values.Length)
				usedIndices.Clear();

			index = Random.Range(0, values.Length);
		}
		while (usedIndices.Contains(index) && usedIndices.Count <= values.Length);


		if (index < 0 )//|| usedIndices.Contains(index))
			return "** ERROR, INDEX NOT FOUND **";

		usedIndices.Add(index);
		return values[index];
	}

}
