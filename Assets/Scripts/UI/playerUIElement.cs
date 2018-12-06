using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerUIElement : MonoBehaviour {

    public player playerO;

    public InputField inText;

    public Image malSex, femSex, malPref, femPref, biPref;

    public Color selectedColor;
    public Color unselectedColor;

    public void initialize()
    {
        if (playerO.sex == playerManager.sexes.male) setSex(0);
        else setSex(1);

        if (playerO.preference == playerManager.sexes.male) setPreference(0);
        else if (playerO.preference == playerManager.sexes.female) setPreference(1);
        else setPreference(2);

        inText.text = playerO.playerName;
    }

    public void setSex(int i)
    {
        if (i == 0){
            playerO.sex = playerManager.sexes.male;
            malSex.color = selectedColor;
            femSex.color = unselectedColor;
        }
        else {
            malSex.color = unselectedColor;
            femSex.color = selectedColor;
            playerO.sex = playerManager.sexes.female;
        }
    }

    public void setPreference(int i)
    {
        if (i == 0)
        {
            malPref.color = selectedColor;
            femPref.color = unselectedColor;
            biPref.color = unselectedColor;
            playerO.preference = playerManager.sexes.male;
        }
        else if (i == 1)
        {
            malPref.color = unselectedColor;
            femPref.color = selectedColor;
            biPref.color = unselectedColor;
            playerO.preference = playerManager.sexes.female;
        }
        else
        {
            malPref.color = unselectedColor;
            femPref.color = unselectedColor;
            biPref.color = selectedColor;
            playerO.preference = playerManager.sexes.both;
        }
    }

    public void setText(string val) {
        if (val == "" || val == null)
            val = inText.text;
        playerO.setName(val);
    }

    public void removePlayer() {
        playerManager.instance.players.Remove(playerO);
        Destroy(this.gameObject);
    }
}
