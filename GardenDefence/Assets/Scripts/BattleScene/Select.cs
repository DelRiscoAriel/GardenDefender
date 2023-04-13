using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    public GameManager gm;
    public bool onePlayer = false;

    public GameObject characterOnePrefab;
    public GameObject characterTwoPrefab;
    public GameObject characterThreePrefab;
    public GameObject characterFourPrefab;
    public BattleSystem bs;

    bool firstCharacterSelected = false;
    bool secondCharacterSelected = false;

    public GameObject CharacterSelectCanvas;

    public Button CharacterOne;
    public Button CharacterTwo;
    public Button CharacterThree;
    public Button CharacterFour;

    // Start is called before the first frame update
    void Start()
    {
        bs.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (onePlayer)
        {
            if (firstCharacterSelected)
            {
                Destroy(CharacterSelectCanvas);
                bs.playerPrefabSecond = characterOnePrefab;
                bs.enabled = true;
            }
        }
        else
        {
            if (firstCharacterSelected && secondCharacterSelected)
            {
                Destroy(CharacterSelectCanvas);

                bs.enabled = true;
            }
        }
        
    }

    public void SelectCharacterOne()
    {
        CharacterOne.interactable = false;
        if (firstCharacterSelected == false)
        {
            bs.playerPrefabFirst = characterOnePrefab;
            firstCharacterSelected = true;
        }
        else if (secondCharacterSelected == false)
        {
            bs.playerPrefabSecond = characterOnePrefab;
            secondCharacterSelected = true;
        }
    }
    public void SelectCharacterTwo()
    {
        CharacterTwo.interactable = false;
        if (firstCharacterSelected == false)
        {
            bs.playerPrefabFirst = characterTwoPrefab;
            firstCharacterSelected = true;
        }
        else if (secondCharacterSelected == false)
        {
            bs.playerPrefabSecond = characterTwoPrefab;
            secondCharacterSelected = true;
        }
    }
    public void SelectCharacterThree()
    {
        CharacterThree.interactable = false;
        if (firstCharacterSelected == false)
        {
            bs.playerPrefabFirst = characterThreePrefab;
            firstCharacterSelected = true;
        }
        else if (secondCharacterSelected == false)
        {
            bs.playerPrefabSecond = characterThreePrefab;
            secondCharacterSelected = true;
        }
    }
    public void SelectCharacterFour()
    {
        CharacterFour.interactable = false;
        if (firstCharacterSelected == false)
        {
            bs.playerPrefabFirst = characterFourPrefab;
            firstCharacterSelected = true;
        }
        else if (secondCharacterSelected == false)
        {
            bs.playerPrefabSecond = characterFourPrefab;
            secondCharacterSelected = true;
        }
    }
}
