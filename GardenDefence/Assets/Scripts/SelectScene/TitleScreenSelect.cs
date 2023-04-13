using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenSelect : MonoBehaviour
{
    public GameManager gm;
    public Button continueButton;

    public GameObject screenCanva;
    public GameObject storyText;
    public GameObject introM;
    public bool setTitle = false;
    
    void Start()
    {
        if (setTitle)
        {
            screenCanva.SetActive(true);
            storyText.SetActive(false);
            introM.SetActive(false);
        }
       
        GameData data = SaveSystem.LoadPlayer();
        if (data.level1_Complete == false)
        {
            continueButton.interactable = false;
        }
        else
        {
            continueButton.interactable = true;
        }
    }

    public void Continue()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void toIntro()
    {
        screenCanva.SetActive(false);
        storyText.SetActive(true);
        introM.SetActive(true);
    }

    public void NewGame()
    {
        gm.level1_Complete = false;
        gm.level2A_Complete = false;
        gm.level2B_Complete = false;
        gm.level3A_Complete = false;
        gm.level3B_Complete = false;
        gm.level3C_Complete = false;
        gm.level4_Complete = false;
        SaveSystem.SavePlayer(gm);
        SceneManager.LoadScene("LevelSelect");
    }

    public void Encyclopedia()
    {
        SceneManager.LoadScene("Encyclopedia");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
