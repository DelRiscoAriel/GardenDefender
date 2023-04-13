using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public GameManager gm;
    public GameObject winText;

    public Button level1Abutton;
    public GameObject BadImage1A;
    public Button level2A_button;
    public GameObject BadImage2A;
    public Button level2B_button;
    public GameObject BadImage2B;
    public Button level3A_button;
    public GameObject BadImage3A;
    public Button level3B_button;
    public GameObject BadImage3B;
    public Button level3C_button;
    public GameObject BadImage3C;
    public Button level4_button;
    public GameObject BadImage4;

    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        var newColorRed = level2A_button.colors;
        newColorRed.disabledColor = Color.red;

        var newColorGreen = level2A_button.colors;
        newColorGreen.disabledColor = Color.green;

        if (gm.level1_Complete == false)
        {
            level1Abutton.interactable = true;
            BadImage1A.SetActive(true);
            level2A_button.colors = newColorRed;
            level2A_button.interactable = false;
            BadImage2A.SetActive(true);
            level2B_button.colors = newColorRed;
            level2B_button.interactable = false;
            BadImage2B.SetActive(true);
            level3A_button.colors = newColorRed;
            level3A_button.interactable = false;
            BadImage3A.SetActive(true);
            level3B_button.colors = newColorRed;
            level3B_button.interactable = false;
            BadImage3B.SetActive(true);
            level3C_button.colors = newColorRed;
            level3C_button.interactable = false;
            BadImage3C.SetActive(true);
            level4_button.colors = newColorRed;
            level4_button.interactable = false;
            BadImage4.SetActive(true);
        }
        if (gm.level1_Complete == true)
        {
            level1Abutton.interactable = false;
            BadImage1A.SetActive(false);
            level2A_button.interactable = true;
            level2B_button.interactable = true;
        }
        if (gm.level2A_Complete == true)
        {
            level2A_button.colors = newColorGreen;
            BadImage2A.SetActive(false);
            level2A_button.interactable = false;
            level3A_button.interactable = true;
        }
        if (gm.level2B_Complete == true)
        {
            level2B_button.colors = newColorGreen;
            BadImage2B.SetActive(false);
            level2B_button.interactable = false;
            level3C_button.interactable = true;
        }
        if (gm.level2A_Complete == true && gm.level2B_Complete == true)
        {
            level3B_button.interactable = true;
        }
        if (gm.level3A_Complete == true)
        {
            level3A_button.colors = newColorGreen;
            level3A_button.interactable = false;
            BadImage3A.SetActive(false);
        }
        if (gm.level3B_Complete == true)
        {
            level3B_button.colors = newColorGreen;
            level3B_button.interactable = false;
            BadImage3B.SetActive(false);
        }
        if (gm.level3C_Complete == true)
        {
            level3C_button.colors = newColorGreen;
            level3C_button.interactable = false;
            BadImage3C.SetActive(false);
        }
        if (gm.level3A_Complete == true && gm.level3B_Complete == true && gm.level3C_Complete == true)
        {
            level4_button.interactable = true;
        }
        if (gm.level4_Complete == true)
        {
            level4_button.colors = newColorGreen;
            level4_button.interactable = false;
            BadImage4.SetActive(false);
            winText.SetActive(true);
        }
    }

    public void Level1A()
    {
        SceneManager.LoadScene("Level1A");
    }
    public void Level2A()
    {
        SceneManager.LoadScene("Level2A");
    }
    public void Level2B()
    {
        SceneManager.LoadScene("Level2B");
    }
    public void Level3A()
    {
        SceneManager.LoadScene("Level3A");
    }
    public void Level3B()
    {
        SceneManager.LoadScene("Level3B");
    }
    public void Level3C()
    {
        SceneManager.LoadScene("Level3C");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Level4A");
    }

    public void TitleScreen()
    {
        SaveSystem.SavePlayer(gm);
        SceneManager.LoadScene("TitleScreen");
    }
    public void Encyclopedia()
    {
        SaveSystem.SavePlayer(gm);
        SceneManager.LoadScene("Encyclopedia");
    }
    public void Load()
    {
        GameData data = SaveSystem.LoadPlayer();

        gm.level1_Complete = data.level1_Complete;
        gm.level2A_Complete = data.level2A_Complete;
        gm.level2B_Complete = data.level2B_Complete;
        gm.level3A_Complete = data.level3A_Complete;
        gm.level3B_Complete = data.level3B_Complete;
        gm.level3C_Complete = data.level3C_Complete;
        gm.level4_Complete = data.level4_Complete;
    }
}
