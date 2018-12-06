using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class truthOD : MonoBehaviour
{

    [Header("UI references")]
    public Text contentText;
    public Text currentPlayerText;
    public Text currentPlayerTextMenu;
    public Text completedText;
    public Text skippedText;

    [Header("Managers")]
    public fileManager[] fileMansDare;
    public fileManager[] fileMansTruth;
    playerManager thePlayerMan;

    [Header("Intensity level")]
    public int intensity = 1;
    public Image[] intensityImages;
    public Color selectedColor;
    public Color unselectedColor;

    private void Start()
    {
        thePlayerMan = playerManager.instance;
        setIntensity(intensity);
    }

    public void setIntensity(int _in) {
        intensity = _in;
        for (int i = 0; i < intensityImages.Length; i++)
        {
            if (i == intensity)
                intensityImages[i].color = selectedColor;
            else
                intensityImages[i].color = unselectedColor;
        }
    }

    public void showDare() {
        string text = fileMansDare[intensity].getRandomLine();
        contentText.text = parseText(text);
        currentPlayerText.text = thePlayerMan.currentPlayer.playerName;
    }

    public void showTruth() {
        string text = fileMansTruth[intensity].getRandomLine();
        contentText.text = parseText(text);
        currentPlayerText.text = thePlayerMan.currentPlayer.playerName;
    }

    public void nextPlayer(bool skip)
    {
        if(!skip)
         thePlayerMan.nextPlayer();

        currentPlayerText.text = thePlayerMan.currentPlayer.playerName;
        currentPlayerTextMenu.text = thePlayerMan.currentPlayer.playerName;
        completedText.text = "Completed: " + thePlayerMan.currentPlayer.completed.ToString();
        skippedText.text = "Skipped: " + thePlayerMan.currentPlayer.skipped.ToString();
    }

    public void addCompleted() {
        thePlayerMan.currentPlayer.completed++;
    }

    public void addSkipped()
    {
        thePlayerMan.currentPlayer.skipped++;
    }

    public string parseText(string tx) {
        // PARSING SYSTEM:     @M: RANDOM MALE
        //                     @F: RANDOM FEMALE
        //                     @A: ALL RANDOM
        //                     @P: RANDOM IN PREFERENCE
        //                     @S: SAME SEX
        //                     @D: DIFFERENT SEX

        string phrase = "";
        string[] words = tx.Split('@');

        phrase += words[0];
        if (words.Length > 1)
        { 
            for (int word = 1; word < words.Length; word++)
            {
                char[] content = words[word].ToCharArray();
                char first = content[0];
                string textContent = "";
                for (int i = 1; i < content.Length; i++)
                {
                    textContent += content[i];
                }

                switch (first)
                {
                    case 'M':
                        phrase += thePlayerMan.getRandomPlayer(playerManager.sexes.male);
                        break;
                    case 'F':
                        phrase += thePlayerMan.getRandomPlayer(playerManager.sexes.female);
                        break;
                    case 'A':
                        phrase += thePlayerMan.getRandomPlayer(playerManager.sexes.both);
                        break;
                    case 'P':
                        phrase += thePlayerMan.getRandomPlayer(thePlayerMan.currentPlayer.preference);
                        break;
                    case 'S':
                        phrase += thePlayerMan.getRandomPlayer(thePlayerMan.currentPlayer.sex);
                        break;
                    case 'D':
                        phrase += thePlayerMan.getRandomPlayer((thePlayerMan.currentPlayer.sex==playerManager.sexes.male)?playerManager.sexes.female:playerManager.sexes.male);
                        break;
                    default:
                        break;
                }

                phrase += textContent;
            }
        }

        return phrase;
    }

}
