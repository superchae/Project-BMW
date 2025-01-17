using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneController : MonoBehaviour
{
    Dictionary<string, int> stageDict = new Dictionary<string, int>()
    {
        {"Stage1", 1 },
        {"Stage2", 2 },
        {"Stage3", 3 },
    };

    Dictionary<string, int> characterDict = new Dictionary<string, int>()
    {
        {"CatButton", 1 },
        {"MouseButton", 2 },
        {"DogButton", 3 },
    };

    bool isPaused = false;
    GameObject AudioManager;

    private void Awake()
    {
        AudioManager = GameObject.Find("AudioManager");
        DontDestroyOnLoad(AudioManager);
    }

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log(currentScene.name.ToString());
        AudioManager.GetComponent<AudioManager>().PlayBGM();
        SetScreenDirection();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void toStageSelectionScene()
    {
        PlayerPrefs.SetInt("Stage", 0);
        SceneManager.LoadScene("Stage Selection");
    }

    public void toGameoverScene()
    {
        SceneManager.LoadScene("Gameover");
    }

    public void moveStage()
    {
        bool readyToMove = false;
        GameObject clickedObject = EventSystem.current.currentSelectedGameObject;
        int stageNum = stageDict[clickedObject.name];
        if (stageNum == 1)
        {
            StageInfo.stageNumber = stageNum;
            readyToMove = true;
        }
        else
        {
            if (stageNum == 2 && PlayerPrefs.GetInt("UnlockAfternoon") == 1)
            {
                StageInfo.stageNumber = stageNum;
                readyToMove = true;
            }
            if (stageNum == 3 && PlayerPrefs.GetInt("UnlockNight") == 1)
            {
                StageInfo.stageNumber = stageNum;
                readyToMove = true;
            }
        }
        Debug.Log(StageInfo.stageNumber.ToString());
        if (readyToMove)
        {
            SceneManager.LoadScene("Character Selection");
        }

    }

    public void toSideViewGameplayScene()
    {
        PlayerPrefs.SetInt("Stage", 0);
        SceneManager.LoadScene("SideView Gameplay " + StageInfo.stageNumber.ToString());
    }

    public void characterSelection()
    {
        GameObject clickedObject = EventSystem.current.currentSelectedGameObject;
        CharacterInfo.characterNumber = characterDict[clickedObject.name];
        Debug.Log(CharacterInfo.characterNumber.ToString());
    }

    public void gamePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void toOpeningScene()
    {
        SceneManager.LoadScene("Opening");
    }

    public void toTopViewScene()
    {
        SceneManager.LoadScene("TopView Gameplay");
    }

    public void toSideViewScene()
    {
        SceneManager.LoadScene("SideView Gameplay 1");
    }

    public void toCharacterSelectionScene()
    {
        SceneManager.LoadScene("Character Selection");
    }

    public void toLobby()
    {
        PlayerPrefs.SetInt("StageNum", 0);
        SceneManager.LoadScene("Lobby");
    }

    public void toCharacterSettingsScene()
    {
        SceneManager.LoadScene("Character Settings");
    }

    public void toGameClearScene()
    {
        PlayerPrefs.SetInt("Stage", StageInfo.stageNumber);
        SceneManager.LoadScene("GameClear");
    }

    public void SetScreenDirection()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        if (CurrentScene.name.Contains("TopView"))
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        else
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
}
