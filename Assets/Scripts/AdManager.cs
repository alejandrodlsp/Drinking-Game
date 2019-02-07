using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

    #region Singleton
    public static AdManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this);
    }
    #endregion


    int portraitBufferCount = 10;
    int maxPortraitActionBuffer = 35;
    int minPortraitActionBuffer = 20;

    int maxVideoBufferCount = 100;
    int videoBufferCount = 100;

    private void Start()
    {
        if (PlayerPrefs.HasKey("videoBufferCount"))
        {
            videoBufferCount = PlayerPrefs.GetInt("videoBufferCount");
        }
        else
        {
            PlayerPrefs.SetInt("videoBufferCount", maxVideoBufferCount);
        }

        portraitBufferCount = Random.Range(minPortraitActionBuffer, maxPortraitActionBuffer);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.E)) {
            portraitBufferCount--;         
        }

        if (portraitBufferCount <= 0)
        {
            if (Advertisement.IsReady("portrait"))
            {
                Advertisement.Show("portrait");
            }
            portraitBufferCount = Random.Range(minPortraitActionBuffer, maxPortraitActionBuffer);
        }

        if (videoBufferCount <= 0) {
            if (Advertisement.IsReady("video"))
            {
                Advertisement.Show("video");
            }
            videoBufferCount = maxVideoBufferCount;
        }
	}

    public void bufferAction() {
        portraitBufferCount--;
        videoBufferCount--;
        PlayerPrefs.SetInt("videoBufferCount", videoBufferCount);
    }
}
